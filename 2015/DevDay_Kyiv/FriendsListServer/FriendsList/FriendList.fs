module FriendList
open Rop
open PrimitiveTypes
open PrimitiveTypes.Id
open PrimitiveTypes.String200

type FriendItem = {
  Id: Id
  FullName: String200
  Stared: bool
}

type State = {
  Name: String200
  Items: List<FriendItem>
}
with static member Zero = { Name = String200("New Friend List"); Items = [] }

let private newFriend (fullName:String200) = 
  { Id = Id.newId; FullName = fullName; Stared = false }

type Command =
  | CreateFriendList
  | AddFriend of fullName:string
  | DeleteFriend of id:string
  | StarFriend of id:string
  
type Event =
  | FriendListCreated of State
  | FriendAdded of FriendItem
  | FriendDeleted of Id
  | FriendStared of Id

let producer command frndList = 
  match command with
  | CreateFriendList   -> frndList |> FriendListCreated |> Success
  | AddFriend fullName -> fullName |> String200.create |> map newFriend |> map FriendAdded
  | DeleteFriend id    -> id |> Id.create |> map FriendDeleted
  | StarFriend id      -> id |> Id.create |> map FriendStared

let reducer event frndList =
  match event with
  | FriendListCreated newState -> newState
  | FriendAdded friend -> { frndList with Items = friend :: frndList.Items }
  | FriendDeleted id -> { frndList with Items = frndList.Items |> List.filter(fun i -> i.Id <> id) }
  | FriendStared id -> failwith "Not implemented"
