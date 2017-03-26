
[<Measure>] type m                  (* meter *)
[<Measure>] type s                  (* second *)
[<Measure>] type kg                 (* kilogram *)
[<Measure>] type N = (kg * m)/(s^2) (* Newtons *)
[<Measure>] type Pa = N/(m^2)       (* Pascals *)

let distance = 100.0<m>
let time = 5.0<s>
let speed = distance / time


let testFn (x: float<m>) (y: float<s>) = x / y
    