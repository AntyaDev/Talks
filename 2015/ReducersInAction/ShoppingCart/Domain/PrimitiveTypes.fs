namespace Domain.PrimitiveTypes
open Rop
open Domain.Errors

module private StringValidator = 
  
  let validLength maxLength (str:string) = 
    match str with
    | null -> fail Error.StrMissing
    | _ when str.Length > maxLength -> Error.StrMustNotBeLongerThan(maxLength) |> fail
    | _ -> ok str
  
  let createStr ctor result = 
    match result with
    | Ok str -> ok(ctor str)
    | Bad msg -> fail msg

module Id = 
  
  type Id = Id of System.Guid
  
  let validate idStr = 
    match System.Guid.TryParse idStr with
    | (true, guid) -> ok guid
    | _ -> Error.StrDoesntMatchPattern("GUID") |> fail
  
  let create = validate >> map Id
  let newId = System.Guid.NewGuid() |> Id
  let get (Id v) = v
  let toStr (Id v) = v.ToString("N")

module String200 = 

  type String200 = 
    | String200 of string
  
  let validate = StringValidator.validLength 200
  let create = validate >> StringValidator.createStr String200
  let get (String200 v) = v