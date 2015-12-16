module Aggregate
open System
open Rop

type Transformer<'TState,'TCommand,'TEvent,'TError> = {
  ZeroState: 'TState
  Reducer: 'TState -> 'TEvent -> 'TState
  Producer: 'TState -> 'TCommand -> Result<'TEvent,'TError>
}

type Id = System.Guid

let createHandler (transformer:Transformer<'TState,'TCommand,'TEvent,'TError>,
                   load:Type*Id -> Async<obj seq>,
                   commit:Id*int -> obj -> Async<unit>) =
  fun (id, version) command -> async {
    let! events = load(typeof<'TEvent>, id)
    let events = events |> Seq.cast :> 'TEvent seq
    let state = Seq.fold transformer.Reducer transformer.ZeroState events
    let event = transformer.Producer state command
    match event with
    | Ok e -> do! commit (id, version) e
              return event
    | Bad msg -> return msg |> fail
  }