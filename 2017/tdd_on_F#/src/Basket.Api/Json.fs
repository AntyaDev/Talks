module Json

open Newtonsoft.Json
open Newtonsoft.Json.Serialization
open Suave
open Suave.Operators
open Suave.Successful

let private jsonSerializerSettings = JsonSerializerSettings()
jsonSerializerSettings.ContractResolver <- new CamelCasePropertyNamesContractResolver()

let JSON v =
    JsonConvert.SerializeObject(v, jsonSerializerSettings)
    //|> OK
  //>=> Writers.setMimeType "application/json; charset=utf-8"