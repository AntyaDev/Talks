#r @"../../packages/Chessie/lib/net40/Chessie.dll"
#load "Errors.fs"
#load "Domain.fs"
open Domain
open Chessie.ErrorHandling

/// creating new basket and adding one product
let emptyBasket = Basket.createNew("test")
let product = { id = "test_prod"; qty = 2; price = 2 }
let activeBasket = Basket.addToEmpty(emptyBasket, product)
let view = Basket.activeToView(activeBasket)
let lineTotal = view.lines.Head.lineTotal
let basketTotal = view.total
