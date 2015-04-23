module DomainPrimitiveTypes

open Rop

type Id = Id of System.Guid

type String100 = String100 of string

type String200 = String200 of string

type Name = Name of string

type Email = Email of string


type StringError = 
   | Missing
   | MustNotBeLongerThan of int
   | DoesntMatchPattern of string   

let private validateStr length (str:string) =
   match str with
   | null -> fail StringError.Missing
   | _ when str.Length > length -> fail (MustNotBeLongerThan length)
   | _                          -> succeed str

let private createStr ctor result =
   match result with
   | Success str   -> succeed (ctor str)
   | Failure msg -> fail msg


module IdM =
   
   let validate str = 
      match System.Guid.TryParse(str) with
      | true, _  -> succeed str
      | false, _ -> fail (DoesntMatchPattern " {6F9619FF-8B86-D011-B42D-00CF4FC964FF}")

   let value (Id v) = v

module String100M = 

   let validate = validateStr 100
   let create = validate >> createStr String100
   let value (String100 v) = v
   
module String200M =

   let validate = validateStr 200
   let create = validate >> createStr String200
   let value (String200 v) = v

module NameM =    
   open System   

   let validate (name:string) =
      if Char.IsUpper(name.Chars(0)) then succeed(name)
      else fail(StringError.DoesntMatchPattern "name should be: 'Ivan', 'Anton', not 'anton' or 'iVan'")

   let create = validate >=> String100M.create
   let value (Name v) = v

module EmailM =    

   let validate (str:string) =
      if str.Contains("@") then succeed str
      else fail (DoesntMatchPattern "*@*")

   let value (Email v) = v

   