module Domain

type CartItem = string

type Cart =
    | Empty
    | Active of items:CartItem list
    | PaidFor of items:CartItem list * amount:decimal
 
type Cart with
  static member New = Cart.Empty
 
  member this.Add item =
    match this with
    | Cart.Empty        -> Cart.Active [item]
    | Cart.Active items -> Cart.Active(item :: items)
    | Cart.PaidFor _    -> printfn "ERROR: can't add items to a paid cart"
                           this
 
  member this.Remove item =
    match this with
    | Cart.Empty        -> printfn "ERROR: can't remove items from an empty cart"
                           this
    
    | Cart.Active items -> let newItems = items |> List.filter (fun i -> i <> item)
                           match newItems with
                           | [] -> Cart.Empty
                           | _ -> Cart.Active newItems
    
    | Cart.PaidFor _    -> printfn "ERROR: can't remove items from a paid cart"
                           this
 
  member this.Pay amount =
    match this with
    | Cart.Active items -> Cart.PaidFor (items, amount)    
    | _ -> printfn "ERROR: can't pay for a cart that's not active"
           this

let emptyCart = Cart.New
 
let cartA = (Cart.New).Add "A"
 
let cartAB = cartA.Add "B"
 
let cartB = cartAB.Remove "A"
 
let emptyCart2 = cartB.Remove "B"
 
let emptyCart3 = emptyCart2.Remove "B"
 
let paidCart = cartAB.Pay 100m