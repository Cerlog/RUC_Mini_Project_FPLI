module poly


(* Excercise 2 *)

// a
// binding the pair of constants to variable f
//let f(x) = 2.0 * x**2 + 4.0*x -1.0;;
let f = (2.0, 4.0, -1.0)

// b
// vertex of the 2nd degree polynomial
let vertex (a, b, c) = (-b / (2.0 * a), -b * b / (4.0 * a) + c);;



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
    
let solve2 (a, b, c) = let d = sqrt(b**2.0 - 4.0 * a * c) in ((-b - sqrt(d) / 2.0 * a), (-b + sqrt(d)) / 2.0 * a)
    


// d
let eval (a, b, c) (x: float) = a * x**2 + b * x + c;;

