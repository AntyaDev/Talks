namespace Domain.Queries

open Chessie.ErrorHandling
open Domain
open Domain.Errors
open Domain.Dependency

module BasketQuery =

    type Query =
        | GetBasket  of id: BasketId

    let private logger = Serilog.Log.ForContext("BasketQuery", "")

    let exec (db: IRepository) (query: Query) = asyncTrial {

        logger.Debug("{@Query}", query)

        match query with
        | GetBasket id  -> return! db.getBasket(id)                              
    }
        

module ProductQuery =

    type Query =        
        | GetProduct of id: ProductId

    let private logger = Serilog.Log.ForContext("ProductQuery", "")

    let exec (db: IRepository) (query: Query) = asyncTrial {

        logger.Debug("{@Query}", query)

        match query with
        | GetProduct id -> return! db.getProduct(id)                              
    } 
    