module State
open Rop
open Errors
open PrimitiveTypes
open PrimitiveTypes.Id

type Transformer<'TState,'TCommand,'TEvent> = {
  ZeroState: 'TState
  Reducer: 'TEvent -> 'TState -> 'TState
  Producer: 'TCommand -> 'TState -> Result<'TEvent,Error> 
}

let createHandler (transformer:Transformer<'TState,'TCommand,'TEvent>,
                   loadState:Id -> Result<'TState,Error>,
                   saveState:Id -> 'TState -> Result<'TState,Error>) =
                    
  fun (command, stateId:Option<Id>) ->
    let (id,state) = match stateId with
                     | Some id -> (id, loadState id)
                     | None    -> (Id.newId, Success(transformer.ZeroState))
    
    let event = state |> Rop.bind(transformer.Producer command)
    let newState = Rop.map2(transformer.Reducer) event state
    let result = Rop.bind2(saveState) id newState
    match result with
    | Success s -> (id,Rop.get(event)) |> Success
    | Failure e -> Failure e

    