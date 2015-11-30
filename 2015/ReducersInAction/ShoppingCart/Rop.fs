module Rop

type Result<'TSuccess,'TFailure> = 
  | Success of 'TSuccess
  | Failure of 'TFailure

let map f result = 
  match result with
  | Success s -> s |> f |> Success
  | Failure e -> Failure e

let map2 (f:'a -> 'b -> 'c) (result0:Result<'a,'e>) (result1:Result<'b,'e>) =
  match result0,result1 with
  | (Success s0, Success s1) -> Success(f s0 s1)
  | (Failure e0, _)          -> Failure e0
  | (_, Failure e1)          -> Failure e1
 
let bind f result = 
  match result with
  | Success s -> f s
  | Failure e -> Failure e

let bind2 f input result =
  match result with
  | Success s -> f input s
  | Failure e -> Failure e

let get result = 
  match result with
  | Success s -> s
  | Failure f -> failwith "result contains failure."