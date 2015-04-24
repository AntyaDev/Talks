module Strategy

let quicksort array =
    printfn "quick sort"

let shellsort array =
    printfn "shell short"
    
let bubblesort array =
    printfn "bubble sort"

let executeStrategy f array = f(array)

// set strategy to be quick sort
let strategy1 = executeStrategy quicksort // partial application
[1..6] |> strategy1

// set strategy to be bubble sort
let strategy2 = executeStrategy bubblesort
[1..6] |> strategy2