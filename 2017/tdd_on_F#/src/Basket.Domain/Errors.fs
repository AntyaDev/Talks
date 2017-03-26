namespace Domain.Errors

type Error =
    | FatalError of exn
    | BasketIsAlreadyPaid of basketId: string
    | BasketNotFound of basketId: string
    | RemoveItemFromEmptyBasket of basketId: string
    | RemoveItemFromPaidBasket of basketId: string
    | AddQtyForEmptyBasket of basketId: string
    | AddQtyForPaidBasket of basketId: string
    | ProductNotFound of productId: string




















module Helpers =
    open Chessie.ErrorHandling

    let asyncOk value = 
        value |> ok |> Async.singleton |> AR

    let asyncFail value =
        value |> fail |> Async.singleton |> AR

    let toAsyncResult result =
        match result with
        | Ok(value, msg) as x -> x |> Async.singleton |> AR        
        | Bad error      as x -> x |> Async.singleton |> AR