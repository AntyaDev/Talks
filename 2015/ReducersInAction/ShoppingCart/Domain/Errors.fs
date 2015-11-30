namespace Domain
open System

module Errors =
  
  type Error = 
    | StrMissing
    | StrMustNotBeLongerThan of maxLen:int
    | StrDoesntMatchPattern of pattern:string
    | FriendListNotFound of id:Guid
