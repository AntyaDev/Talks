module Domain

type ProductId = System.Guid
type CartItemId = System.Guid

type CartItem = {
   Id : CartItemId
   Product : ProductId
}

type EmptyState = NoItems    

type ActiveState = {
   UnpaidItems : CartItem list
}

type PaidForState = { 
   PaidItems : CartItem list
   Payment : decimal 
}

type Cart = 
   | Empty of EmptyState
   | Active of ActiveState
   | PaidFor of PaidForState 

   
let addToEmptyCart item = 
   Cart.Active { UnpaidItems = [item] }

let addToActiveCart cart item = 
   let items = item :: cart.UnpaidItems
   Cart.Active { cart with UnpaidItems = items }

let removeFromActiveCart cart item = 
   let items = cart.UnpaidItems 
               |> List.filter (fun i -> i <> item)                
                  
   match items with
   | [] -> Cart.Empty NoItems
   | _ -> Cart.Active { cart with UnpaidItems = items }

let payForActiveCart cart amount =   
   Cart.PaidFor { PaidItems = cart.UnpaidItems
                  Payment = amount }