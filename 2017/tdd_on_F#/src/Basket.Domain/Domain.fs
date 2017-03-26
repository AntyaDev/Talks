namespace Domain

open Chessie.ErrorHandling
open Domain.Errors

// product
type ProductId = string
type Price = int
type Qty = int

type Product = { id: ProductId; qty: Qty; price: Price }

// basket
type BasketId = string

// read model
type Line       = { productId: ProductId; qty: Qty; lineTotal: Price }
type BasketView = { id: BasketId; lines: Line list; total: Price }

// state
type EmptyBasket  = { id: BasketId; }
type ActiveBasket = { id: BasketId; unpaidProducts: Product list }
type PaidBasked   = { id: BasketId; lines: Line list; total: Price }

type BasketState = 
    | Empty  of EmptyBasket
    | Active of ActiveBasket
    | Paid   of PaidBasked

module Basket = 
    let createNew (basketId: BasketId) : EmptyBasket = 
        { id = basketId }

    let findProduct (state: ActiveBasket, id: ProductId) =
        state.unpaidProducts |> List.tryFind (fun p -> p.id = id)

    /// add product to EmptyBasket
    let addToEmpty (state: EmptyBasket, product: Product) =
        { id = state.id; unpaidProducts = [product] }

    /// add product to ActiveBasket
    let addToActive (state: ActiveBasket, product: Product) =
        match findProduct(state, product.id) with   
        | Some p -> 
                    let updatedProduct = { p with qty = p.qty + 1 }
                    let filteredProductsList = state.unpaidProducts |> List.filter (fun x -> x.id <> p.id)
                    { id = state.id; unpaidProducts = updatedProduct :: filteredProductsList }        
        
        | None   -> { id = state.id; unpaidProducts = product :: state.unpaidProducts }

    /// try to add product to Basket
    let addProduct (basket, product) =
        match basket with
        | Empty state  -> ok <| addToEmpty(state, product)        
        | Active state -> ok <| addToActive(state, product)
        | Paid state   -> fail <| Error.BasketIsAlreadyPaid(state.id)

    /// remove product from ActiveBasket
    let removeFromActive (state: ActiveBasket, id: ProductId) =
        match findProduct(state, id) with
        | Some product -> 
                          let products = state.unpaidProducts |> List.filter (fun p -> p.id <> id)                          
                          match products with
                          | [] -> ok <| Empty ({ id = state.id })
                          | _  -> ok <| Active({ id = state.id; unpaidProducts = products })
        
        | None -> fail <| Error.ProductNotFound(id)

    /// try to remove product from busket
    let removeProduct (basket, productId) =
        match basket with
        | Empty  state -> fail <| Error.RemoveItemFromEmptyBasket(state.id)        
        | Active state -> removeFromActive(state, productId)
        | Paid   state -> fail <| Error.RemoveItemFromPaidBasket(state.id)    
    
    /// add Qty to product which is into ActiveBasket
    let addQtyToActive (state: ActiveBasket, id: ProductId, qty: Qty) = trial {
        let product = findProduct(state, id)
        match product with
        | Some p -> 
                    let updatedProduct = {p with qty = p.qty + qty}
                    let! newState = removeFromActive(state, id)
                    return! addProduct(newState, updatedProduct)
        
        | None   -> return! fail <| Error.ProductNotFound(id)
    }

    let addQty (basket, productId, qty) =
        match basket with
        | Empty  state -> fail <| Error.AddQtyForEmptyBasket(state.id)
        | Active state -> addQtyToActive(state, productId, qty)                             
        | Paid   state -> fail <| Error.AddQtyForPaidBasket(state.id)

    let calculatePrice (product: Product) =
        product.price * product.qty

    let buildLine (product: Product) =
        { productId = product.id
          qty = product.qty
          lineTotal = calculatePrice(product) }

    let activeToView (state: ActiveBasket) : BasketView =
        let total = state.unpaidProducts |> List.sumBy (calculatePrice)
        let lines = state.unpaidProducts |> List.map (buildLine)
        { id = state.id; lines = lines; total = total }

    let toView (basket) : BasketView =
        match basket with
        | Empty state  -> { id = state.id; lines = []; total = 0 }        
        | Active state -> activeToView(state)                          
        | Paid state   -> { id = state.id; lines = state.lines; total = state.total }