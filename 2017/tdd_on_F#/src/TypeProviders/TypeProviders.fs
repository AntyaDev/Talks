module TypeProviders

open FSharp.Data

type Simple = JsonProvider<""" { "name":"John", "age":94 } """>

type Values = JsonProvider<""" [{"value":94 }, {"value":"Tomas" }] """>

[<EntryPoint>]
let main argv =

    let simple = Simple.Parse(""" { "name":"Tomas", "age":4 } """)
    
    printfn "%i" simple.Age
    printfn "%s" simple.Name

    for item in Values.GetSamples() do 
        match item.Value.Number, item.Value.String with
        | Some num, _ -> printfn "Numeric: %d" num
        | _, Some str -> printfn "Text: %s" str
        | _ -> printfn "Some other value!"
    
    0 // return an integer exit code
