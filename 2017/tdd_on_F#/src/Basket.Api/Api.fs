module Basket.Api

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.RequestErrors
open Json
open Chessie.ErrorHandling
open Domain
open Domain.Errors
open Domain.Dependency
open Domain.Commands

[<EntryPoint>]
let main argv =

    let execCommand = CommandExec.exec(Db.fakeRepository)

    let createNewBasket () = asyncTrial {
        let! result = execCommand Command.CreateNewBasket
        return result |> JSON        
    }    

    let errorHandler (msgs: Error list) =
        BAD_REQUEST ""

    let handle (request: unit -> AsyncResult<string,Error>) (errorFn:Error list -> WebPart) =
        fun context -> async {
            let! response = request() |> Async.ofAsyncResult
            match response with
            | Pass json         -> return! OK json context
            | Warn (json, msgs) -> return! OK json context
            | Fail msgs         -> return! errorFn msgs context
        }    

    let api =
        choose
            [ GET >=> choose
                [ path "/api/basket/%s" >=> OK "Hello GET"
                  path "/goodbye"       >=> OK "Good bye GET" ]
              
              POST >=> choose
                [ path "/api/basket" >=> handle createNewBasket errorHandler 
                  path "/goodbye"    >=> OK "Good bye POST" ] ]

    startWebServer defaultConfig api
    0
