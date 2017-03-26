namespace Domain.Commands

open Chessie.ErrorHandling
open Domain
open Domain.Errors
open Domain.Errors.Helpers
open Domain.Dependency
open Domain.Queries

type Command = 
    | CreateNewBasket
    | AddProductToBasket      of basketId:string * productId:string
    | RemoveProductFromBasket of basketId:string * productId:string


module CommandExec = 
    let private logger = Serilog.Log.ForContext("CommandExec", "")

    let retrieveProductWithBasket (db, productId, basketId) = asyncTrial {
        let getProductQuery = ProductQuery.GetProduct(productId)
        let! product        = ProductQuery.exec db getProductQuery
        
        let getBasketQuery  = BasketQuery.GetBasket(basketId)
        let! basket         = BasketQuery.exec db getBasketQuery
        return (product, basket)
    }

    let exec (db: IRepository) (command: Command) = asyncTrial {
        
        logger.Debug("{@Command}", command)
        
        match command with
        | CreateNewBasket -> let basketId = System.Guid.NewGuid().ToString("N") 
                             let! newBasket = db.addBasket(Basket.createNew(basketId))
                             logger.Debug("{@Basket} created", newBasket)
                             return newBasket
        
        | AddProductToBasket(basketId, productId) ->  

                             let! (product, basket) = retrieveProductWithBasket(db, productId, basketId)                             
                             let! basket = Basket.addProduct(basket, product)
                             let! result = db.updateBasket(Active(basket)) 
                             return result
        
        | RemoveProductFromBasket(basketId, productId) ->
        
                             let! (product, basket) = retrieveProductWithBasket(db, productId, basketId) 
                             let! basket = Basket.removeProduct(basket, product.id)                             
                             let! result = db.updateBasket(basket) 
                             return result                                                                                                                                                               
    }