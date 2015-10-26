namespace Domain

open Rop
open Domain.DomainPrimitiveTypes

type Friend = {
  Id: Id
  FullName: String200
}

type Friends = Friends of List<Friend>


module FriendM =
  let create (fullName:String200) = {Id = IdM.newId; FullName = fullName}


module FriendsM =
  open Rop
  
  type Command = 
    | AddFriend of fullName:string
    | DeleteFriend of id:string
    | StarFriend of id:string
  
  type Event = 
    | FriendAdded of friend:Friend
    | FriendDeleted of id:Id
    | FriendStared of id:Id

  let exec state command = 
    match command with
    | AddFriend fullName -> fullName |> String200M.create |> map FriendM.create |> map FriendAdded
    | DeleteFriend id    -> id |> IdM.create |> map FriendDeleted
    | StarFriend id      -> id |> IdM.create |> map FriendStared

