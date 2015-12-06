namespace Domain
open System
open Domain.PrimitiveTypes
open Domain.PrimitiveTypes.Id
open Errors
open Rop

[<RequireQualifiedAccess>]
module ShoppingCart = 

  type Product = {
    Id: Id
    Quantity: uint32
  } with
    static member TryCreate(id:string, qt:uint32) =
      id |> Id.create |> Rop.map(fun id -> {Id = id; Quantity = qt})
      

  type CartState = {
    Id: Id option
    Products: Product list
    IsPayed: bool
  } with
    member this.TryOperate(f: CartState -> Result<'T,Error>) = 
      if this.IsPayed then fail CantBeAppliedToPaidCart
      elif this.Id.IsNone then fail CantBeAppliedToPaidCart
      else f(this)

    static member Zero = { Id = None; Products = []; IsPayed = false }
  

  type Command =
    | CreateCart    of cartId:string
    | AddProduct    of product:string*uint32
    | RemoveProduct of productId:string
  
  type Event =
    | CartCreated    of cartId:Id
    | ProductAdded   of product:Product
    | ProductRemoved of productId:Id


  let private createCart (cartId:string) =
    cartId |> Id.create |> Rop.map(CartCreated)

  let private addProduct (id:string, qt:uint32, state:CartState) =
    match Product.TryCreate(id,qt) with
    | Ok pr -> state.TryOperate(
                fun s -> if Seq.contains pr s.Products 
                           then fail StrMissing
                         else pr |> ProductAdded |> ok)
    | Bad msg -> fail msg

  let private removeProduct (productId:string, state:CartState) = 
    match Id.create(productId) with
    | Ok id -> state.TryOperate(
                fun s -> if s.Products |> Seq.exists(fun p -> p.Id = id)
                            then fail StrMissing
                          else fail StrMissing)
    | Bad msg -> fail msg

      
  let producer command (state:CartState) =
    match command with
    | CreateCart cartId -> createCart(cartId)
    | AddProduct (id, qt) -> addProduct(id, qt, state)
    | RemoveProduct productId -> removeProduct(productId, state)
                    
  let reducer event (state:CartState) =
    match event with
    | CartCreated cartId -> { state with Id = Some(cartId) }
    | ProductAdded product -> { state with Products = product :: state.Products }
    | ProductRemoved productId -> { state with Products = state.Products
                                                          |> List.filter(fun p -> p.Id <> productId) }