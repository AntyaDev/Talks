#r @"../../packages/FSharp.DependentTypes/lib/net452/DependentTypes.dll"
open FSharp.DependentTyping
open FSharp.DependentTypes.Strings
open FSharp.DependentTypes.Numbers

type ProductDescription = BoundedString<Lower=10, Upper=2000>
type ProductName = BoundedString<5, 50>
type OneChar = BoundedString<1, 1>

type ProductPrice = BoundedDecimal<0.01m, 999.99m>

type Product = { name: ProductName; description: ProductDescription }

let newProduct (name: string, description: string) =
  match ProductName.TryCreate(name), ProductDescription.TryCreate(description) with
  | Some n, Some d -> Some { name = n; description = d }
  | _ -> None

let prod = newProduct("Widgets", "sprockets and whatsits for the discerning Who")
let productName = prod.Value.name
