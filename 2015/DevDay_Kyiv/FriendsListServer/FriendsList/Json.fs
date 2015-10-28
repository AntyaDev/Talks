module JSON
open Newtonsoft.Json
open Newtonsoft.Json.Serialization
open Suave.Http
open Suave.Http.Successful

let toJson data = 
  let jsonSerializerSettings = new JsonSerializerSettings()
  jsonSerializerSettings.ContractResolver <- new CamelCasePropertyNamesContractResolver()
  JsonConvert.SerializeObject(data, jsonSerializerSettings)
  |> OK
  >>= Writers.setMimeType "application/json; charset=utf-8"

let fromJson<'T> json =
  JsonConvert.DeserializeObject(json, typeof<'T>) :?> 'T