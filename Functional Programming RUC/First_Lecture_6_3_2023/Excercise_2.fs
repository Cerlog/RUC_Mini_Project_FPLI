(* Excercise 2 *)

// a
// binding the pair of constants to variable f
//let f(x) = 2.0 * x**2 + 4.0*x -1.0;;
let f = (2.0, 4.0, -1.0)

// b
// vertex of the 2nd degree polynomial
let vertex (a, b, c) =
    let x_1 = -b / (2.0 * a)
    let y_1 = -b * b / (4.0 * a) + c
    (x_1, y_1)
vertex f;;


// c
let solve (a, b, c) =
    let d = b**2.0 - 4.0 * a * c
    let x1 = (-b - sqrt(d)) / 2.0 * a
    let x2 = (-b + sqrt(d)) / 2.0 * a
    (x1, x2)
    
    
(*let solveSqrt (a, b, c) =
    let sqrtD = sqrt(b**2.0 - 4.0 * a * c)
    let x1 = (-b - sqrtD) / 2.0 * a
    let x2 = (-b + sqrtD) / 2.0 * a
    (x1, x2)*)
    
(*let solve2 (a, b, c) =
    let d = sqrt(b**2.0 - 4.0 * a * c)
    in ((-b - sqrt(d) / 2.0 * a), (-b + sqrt(d)) / 2.0 * a)
    
solve f;;*)
// val it: float * float = (-8.898979486, 0.8989794856)

// d
let eval (a, b, c) (x: float) = a * x**2 + b * x + c;;
eval f (-1.0)
//val it: float = -3.0

eval f (1.0)
// val it: float = 5.0