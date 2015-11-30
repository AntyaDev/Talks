namespace Domain

[<RequireQualifiedAccess>]
module ShoppingCart = 

  type State = 
    | Empty
    | Active
    | Paid
  
  type Command = 
    | CreateCart
    | AddItem of id:int
    | RemoveItem of id:int
    | PayCart
  
  type Event = 
    | CartCreated
    | ItemAdded
    | ItemRemoved
    | CartPaid