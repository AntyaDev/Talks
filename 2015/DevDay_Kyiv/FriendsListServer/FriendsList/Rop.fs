module Rop

type Result<'TSuccess, 'TFailure> =
   | Success of 'TSuccess
   | Failure of 'TFailure

let map f result = 
  match result with
  | Success s -> s |> f |> Success
  | Failure f -> Failure f
 
let bind f result = 
  match result with
  | Success s -> f s
  | Failure f -> Failure f