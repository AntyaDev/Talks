module Db

open System.Collections.Generic
open Chessie.ErrorHandling
open Domain
open Domain.Errors
open Domain.Errors.Helpers
open Domain.Dependency

let private fakeBasketDb = new Dictionary<BasketId, BasketState>()
let private fakeProductDb = new Dictionary<ProductId, Product>()

let fakeRepository = 
    { new IRepository with 

        member x.addBasket(state: EmptyBasket) = 
            let emptyBasket = Empty(state)
            fakeBasketDb.Add(state.id, emptyBasket)
            emptyBasket |> asyncTrial.Return   

        member x.updateBasket(basket: BasketState) =            
            match basket with
            | Paid state   -> asyncFail <| Error.BasketIsAlreadyPaid(state.id)
            
            | Empty state  -> match fakeBasketDb.TryGetValue(state.id) with
                              | (true, value) -> let basket = Empty(state)
                                                 fakeBasketDb.[state.id] <- basket
                                                 asyncOk   <| basket
                              | (false, _)    -> asyncFail <| Error.BasketNotFound(state.id)

            | Active state -> match fakeBasketDb.TryGetValue(state.id) with
                              | (true, value) -> let basket = Active(state)
                                                 fakeBasketDb.[state.id] <- basket
                                                 asyncOk   <| basket
                              | (false, _)    -> asyncFail <| Error.BasketNotFound(state.id)
        
        member x.getBasket(id: BasketId) =
            match fakeBasketDb.TryGetValue(id) with
            | (true, value)    -> asyncOk   <| value
            | (false, _)       -> asyncFail <| Error.BasketNotFound(id)

        member x.getProduct(id: ProductId) =
            match fakeProductDb.TryGetValue(id) with
            | (true, value)    -> asyncOk   <| value
            | (false, _)       -> asyncFail <| Error.ProductNotFound(id)
}

