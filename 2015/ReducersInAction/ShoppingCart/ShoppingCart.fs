[<RequireQualifiedAccess>]
module ShoppingCart

type State =
  | Empty
  | Active
  | Paid

type Command = 
  | CreateCart
  | AddItem
  | RemoveItem
  | PayCart

type Event =
  | CartCreated
  | ItemAdded
  | ItemRemoved
  | CartPaid