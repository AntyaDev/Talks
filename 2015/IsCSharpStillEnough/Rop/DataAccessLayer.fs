module DataAccessLayer

open System
open Rop
open DomainModel

type IDocumentDao = 

   abstract GetAll : unit -> Result<Document seq, Exception>

   abstract GetById : int -> Result<Document, Exception>

   abstract Insert : Document -> Result<unit, Exception>