module Tests

open Expecto
open Chessie.ErrorHandling
open Domain
open Domain.Errors

[<Tests>]
let tests =
  testList "basket properties" [
    
    ///-------------------------------------------------------------  
    /// if there's only one line in our basket, it's total must be the same as the basket's total.    
    ///-------------------------------------------------------------  
    testProperty "total of single line" <| fun (qty: Qty) (price: Price) ->
        
        let emptyBasket = Basket.createNew("test")
        let product = { id = "test_prod"; qty = qty; price = price }
        
        let activeBasket = Basket.addToEmpty(emptyBasket, product)
        let view = Basket.activeToView(activeBasket)

        let lineTotal = view.lines.Head.lineTotal
        let basketTotal = view.total

        Expect.equal lineTotal basketTotal "must be the same as basket total"


    ///-------------------------------------------------------------  
    /// whenever a new product is added, if it's already in the basket, the number of lines stays the same    
    ///-------------------------------------------------------------  
    testProperty "adding product multiple times downto the basket" <| fun (N: uint16) ->

        let emptyBasket = Empty(Basket.createNew("test"))
        let singleProduct = { id = "test_prod"; qty = 1; price = 2 }

        let addProductFunc basket pr = 
          match Basket.addProduct(basket, pr) with 
          | Ok (b, msg) -> Active(b) 
          | _           -> failwith "adding product func doesn't work at all! Fix it!"

        let basketView = [1..(int N + 1)]                        // generating list with random elements Count
                         |> List.map (fun _ -> singleProduct)    // generating products list
                         |> List.fold addProductFunc emptyBasket // populating emptyBasket
                         |> Basket.toView
        
        Expect.equal basketView.lines.Length 1 "must have one line"
      
    ///-------------------------------------------------------------  
    /// if we add N different products, our basket will have N lines
    ///-------------------------------------------------------------  
    testProperty "adding multiple products to the basket" <| fun (N: uint16) ->

        let emptyBasket = Empty(Basket.createNew("test"))

        let generateProduct (productId: int) =
            { id = "test_prod" + productId.ToString(); qty = 1; price = 2 }

        let addProductFunc basket pr = 
            match Basket.addProduct(basket, pr) with 
            | Ok (b, msg) -> Active(b) 
            | _           -> failwith "adding product func doesn't work at all! Fix it!"

        
        let randomLength = (int N + 1);

        let basketView = [1..randomLength]                           // generating list with random elements Count
                         |> List.map (fun id -> generateProduct(id)) // generating products list
                         |> List.fold addProductFunc emptyBasket     // populating emptyBasket
                         |> Basket.toView

        Expect.equal basketView.lines.Length randomLength "must have N lines"
  ]

  

  