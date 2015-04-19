module DomainModel

open DomainPrimitiveTypes

type PersonalName = {
   FirstName : Name
   LastName : Name
}

type Author = {
   Id : Id
   Name : PersonalName
   EmailAdress : Email
}

type Document = {
   Id : Id
   Title : String100
   Description : String200
   Author : Author
   Content : string
}

module Validators = 

   open Rop
   open DomainPrimitiveTypes

   let validateId = IdM.validate

   let validateName = String100M.validate >=> NameM.validate

   let validateEmail = String100M.validate >=> EmailM.validate

   let validateDescr = String200M.validate

   let validateTitle = String100M.validate