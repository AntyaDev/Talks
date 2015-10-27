module Domain.Friend

open Rop
open Domain.PrimitiveTypes

type FriendItem = {
  Id: Id
  FullName: String200
}

let createFriend (fullName:String200) = { Id = IdM.newId; FullName = fullName }

type FriendList = Friends of List<FriendItem>

type Command = 
  | AddFriend of fullName:string
  | DeleteFriend of id:string
  | StarFriend of id:string
  
type Event = 
  | FriendAdded of friend:FriendItem
  | FriendDeleted of id:Id
  | FriendStared of id:Id

let exec state command = 
  match command with
  | AddFriend fullName -> fullName |> String200M.create |> map createFriend |> map FriendAdded
  | DeleteFriend id    -> id |> IdM.create |> map FriendDeleted
  | StarFriend id      -> id |> IdM.create |> map FriendStared

