
open Rop
open DomainModel
open Infrastructure.Http
open Infrastructure.Dto

// GET /host/api/documents/{documentId}
let getDocument (getDocById:int -> Result<Document,string>) logFailure =   
   getDocById 
   >> logFailure
   >> mapR(toDocumentDto)
   >> toHttpResponse

// POST /host/api/authors/
let postNewAuthor (authorDto:AuthorDto) =
   authorDto
   |> Validators.validateAuthor   
       

[<EntryPoint>]
let main argv = 
   printfn "%A" argv
   0

