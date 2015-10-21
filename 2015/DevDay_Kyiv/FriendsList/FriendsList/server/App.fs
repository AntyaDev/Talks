open Suave
open Suave.Http.Successful 
open Suave.Web
open System.IO
open System
open Suave.Http
open Suave.Http.Applicatives

let indexHtml = File.ReadAllText("client/dest/index.html")

let app = path "/" >>= Writers.setMimeType "text/html" >>= OK indexHtml

startWebServer defaultConfig app