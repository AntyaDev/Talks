module Rop

type Result<'TSuccess, 'TMessage> =
   | Success of 'TSuccess
   | Failure of 'TMessage
   
let succeed x = Success(x) 

let fail msg = Failure(msg)

let (>=>) switch1 switch2 x = 
   match switch1 x with
   | Success s -> switch2 s
   | Failure f -> Failure f 

let mapR oneTrackFunction twoTrackInput = 
   match twoTrackInput with
   | Success s -> Success(oneTrackFunction s)
   | Failure f -> Failure f