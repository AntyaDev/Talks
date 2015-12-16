module Serialization

open Newtonsoft.Json
open Microsoft.FSharp.Reflection
open System.Text

let private s = new JsonSerializer()
    
let private getEventType (o:obj) =
  let t = o.GetType()
  if FSharpType.IsUnion(t) || (t.DeclaringType <> null && FSharpType.IsUnion(t.DeclaringType)) then
      let cases = FSharpType.GetUnionCases(t)
      let unionCase,_ = FSharpValue.GetUnionFields(o, t)
      unionCase.Name
  else t.Name
        
let serialize (obj:obj) =
  let json = JsonConvert.SerializeObject(obj)
  let data = Encoding.UTF8.GetBytes(json)
  let eventType = getEventType(obj)
  (eventType,data)
          
let deserialize (t:System.Type, eventType:string, data:byte array) =
  let json = Encoding.UTF8.GetString(data)
  JsonConvert.DeserializeObject(json, t)
