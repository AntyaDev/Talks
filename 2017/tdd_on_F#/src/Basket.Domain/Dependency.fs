namespace Domain.Dependency

open Domain
open Domain.Errors
open Chessie.ErrorHandling

type IRepository =
    abstract member addBasket:    EmptyBasket  -> AsyncResult<BasketState, Error>
    abstract member updateBasket: BasketState -> AsyncResult<BasketState, Error>
    abstract member getBasket:    BasketId     -> AsyncResult<BasketState, Error>
    abstract member getProduct:   ProductId    -> AsyncResult<Product, Error>