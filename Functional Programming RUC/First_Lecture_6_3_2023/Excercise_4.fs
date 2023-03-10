(* Excercise 4 *
Given input n, the factorial function compute sthe product of the integers from 1 to n
1 x 2 x 3 x ... x n
(If n is zero, the result is 1)

Complete the following definition of the factorial function in F#.
let rec fac n =
    if n = ?
    then ?
    else ? fac (n -1)
    
*)
let rec fac n =
    if n = 0
    then 1
    else n * fac (n-1);;
fac 0;;
val it: int = 1

fac 13;;
//val it: int = 1932053504