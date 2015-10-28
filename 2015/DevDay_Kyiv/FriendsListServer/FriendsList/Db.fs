module Db
open System.Collections.Generic
open Rop
open PrimitiveTypes
open PrimitiveTypes.Id
open Errors
open FriendList

let private storage = Dictionary<Id,State>()

let loadState id =
  match storage.TryGetValue(id) with
  | (true,frndList) -> Success frndList
  | _               -> id |> Id.get |> Error.FriendListNotFound |> Failure
    
let saveState id frndList =
  match storage.TryGetValue(id) with
  | (true,fList) -> storage.[id] <- fList
                    Success fList

  | _            -> storage.Add(id, frndList)
                    Success frndList