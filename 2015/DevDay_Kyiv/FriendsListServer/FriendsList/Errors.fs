module Errors
open System

type Error = 
  | StrMissing
  | StrMustNotBeLongerThan of maxLen:int
  | StrDoesntMatchPattern of patrn:string
  | FriendListNotFound of id:Guid