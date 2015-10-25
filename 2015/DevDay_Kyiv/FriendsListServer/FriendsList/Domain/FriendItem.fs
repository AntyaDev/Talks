namespace Domain

module FriendItem =
  open Domain.DomainPrimitiveTypes

  type State = {
    Id: Id
    FullName: String200
  }
 
  type Command = 
    | Add of FullName:String200
    | Delete
    | Star
  
  type Event = 
    | Added of id:Id * fullName:String200
    | Deleted of id:Id
    | Stared of id:Id