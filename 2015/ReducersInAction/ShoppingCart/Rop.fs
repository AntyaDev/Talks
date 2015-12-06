[<AutoOpen>]
module Rop

type Result<'TSuccess,'TFailure> = 
  | Ok of 'TSuccess
  | Bad of 'TFailure

/// Wraps a value in a Success
let inline ok<'TSuccess,'TFailure> (x:'TSuccess) : Result<'TSuccess,'TFailure> = Ok(x)

/// Wraps a message in a Failure
let inline fail<'TSuccess,'TFailure> (msg:'TFailure) : Result<'TSuccess,'TFailure> = Bad(msg)

let map f result = 
  match result with
  | Ok s -> s |> f |> Ok
  | Bad e -> Bad e

let inline (<!>) f result = map f result

let map2 (f:'a -> 'b -> 'c) (result0:Result<'a,'e>) (result1:Result<'b,'e>) =
  match result0,result1 with
  | (Ok s0, Ok s1) -> Ok(f s0 s1)
  | (Bad e0, _)          -> Bad e0
  | (_, Bad e1)          -> Bad e1
 
let bind f result = 
  match result with
  | Ok s -> f s
  | Bad e -> Bad e

let inline (>>=) result f = bind f result

let inline (>=>) switch1 switch2 x = 
   match switch1 x with
   | Ok s -> switch2 s
   | Bad f -> Bad f 

let bind2 f input result =
  match result with
  | Ok s -> f input s
  | Bad e -> Bad e

let get result = 
  match result with
  | Ok s -> s
  | Bad f -> failwith "result contains failure."