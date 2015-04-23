module Infrastructure

module Http =

   open Rop
   
   let toHttpResponse result = 
      match result with
      | Success r   -> r.ToString()
      | Failure msg -> msg.ToString()


module Dto =
   
   open DomainPrimitiveTypes
   open DomainModel

   [<CLIMutable>]
   type AuthorDto = {
      Id : string
      FirstName : string
      LastName : string
      Email : string
   }
   
   [<CLIMutable>]
   type DocumentDto = {
      Id : string
      Title : string
      Description : string
      Author : AuthorDto
      Content : string
   }

   let toDocumentDto (doc:Document) = 
      { DocumentDto.Id = (IdM.value doc.Id).ToString()
        Title = String100M.value doc.Title
        Description = String200M.value doc.Description
        Content = doc.Content
        Author = 
           { Id = (IdM.value doc.Author.Id).ToString()
             FirstName = NameM.value doc.Author.Name.FirstName
             LastName = NameM.value doc.Author.Name.LastName
             Email = EmailM.value doc.Author.EmailAdress } }


   module Validators = 

      open Rop      
      open DomainModel
      
      let validateId (author:AuthorDto) =
         match Validators.validateId(author.Id) with
         | Success s   -> succeed author
         | Failure msg -> fail msg

      let validateFirstName (author:AuthorDto) =     
         match Validators.validateName(author.FirstName) with
         | Success s   -> succeed author
         | Failure msg -> fail msg

      let validateLastName (author:AuthorDto) = 
         match Validators.validateName(author.LastName) with
         | Success s   -> succeed author
         | Failure msg -> fail msg
            
      let validateEmail (author:AuthorDto) =
         match Validators.validateEmail(author.Email) with
         | Success s   -> succeed author
         | Failure msg -> fail msg

      let validateAuthor = validateId 
                           >=> validateFirstName
                           >=> validateLastName
                           >=> validateEmail