module Domain.PrimitiveTypes
open Rop

type Id = Id of System.Guid
type String200 = String200 of string

module StringValidator =
  type StringError = 
     | Missing
     | MustNotBeLongerThan of int
     | DoesntMatchPattern of string

  let validLength maxLength (str:string) =
     match str with
     | null -> Failure StringError.Missing
     | _ when str.Length > maxLength -> MustNotBeLongerThan(maxLength) |> Failure
     | _    -> Success str

  let createStr ctor result =
     match result with
     | Success str -> Success (ctor str)
     | Failure msg -> Failure msg


module IdM =
  open StringValidator

  let validate idStr = 
    match System.Guid.TryParse idStr with
    | (true, guid) -> Success guid
    | _            -> DoesntMatchPattern("GUID") |> Failure

  let create = validate >> map Id 

  let newId = System.Guid.NewGuid() |> Id

          
module String200M =
  let validate = StringValidator.validLength 200

  let create = validate >> StringValidator.createStr String200

  let get (String200 v) = v