open Suave
open Suave.Http.Successful 
open Suave.Web
open System.IO
open System
open Suave.Http
open Suave.Http.Applicatives

let indexHtml = File.ReadAllText("client/index.html")
let bundlejs = File.ReadAllText("client/bundle.js")

let app = 
   choose [
      GET >>= choose [
         path "/" >>= Writers.setMimeType "text/html" >>= OK indexHtml 
         path "/bundle.js" >>= Writers.setMimeType "application/javascript" >>= OK bundlejs
      ]; 
   ]

//choose [ GET "/" >>= Writers.setMimeType "text/html" >>= OK indexHtml ]

startWebServer defaultConfig app