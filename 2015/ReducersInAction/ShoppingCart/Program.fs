open Newtonsoft.Json
open Aggregate
open Domain

let eventStore = lazy(
  let endPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 1113)
  EventStore.conn endPoint)

let repo = EventStore.makeRepository(eventStore.Value,
                                     "ShoppingCart",
                                     Serialization.serialize,
                                     Serialization.deserialize)
let handleCommand' =
  let transformer = { ZeroState = ShoppingCart.CartState.Zero
                      Producer = ShoppingCart.producer
                      Reducer = ShoppingCart.reducer }
  
  Aggregate.createHandler(transformer, repo.Load, repo.Commit)

let handleCommand (id,v) c = handleCommand' (id,v) c |> Async.RunSynchronously


[<EntryPoint>]
let main argv =
  let id = System.Guid.NewGuid()
  let comand = ShoppingCart.Command.CreateCart(id.ToString("N"))
  let event = handleCommand(id, -1) comand

  let productId = System.Guid.NewGuid().ToString("N")
  let addProdComd = ShoppingCart.Command.AddProduct(productId, 2u)
  let event = handleCommand(id, 0) addProdComd

  printfn "%A" argv
  0 // return an integer exit code