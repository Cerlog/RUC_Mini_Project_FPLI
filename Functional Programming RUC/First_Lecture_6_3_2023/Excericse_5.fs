(* Excercise 5
Implement a function sumUpTo that, given input n, computes the sum of the integers from 1 to n:
*)


// gauss
let rec sumUpTo n =
    if n = 0
    then 0
    else (n * (n + 1))/2;;  // gauss formula (is it cheating?)
sumUpTo 100;;
// val it: int = 5050

 
// recurssion
let rec sumUpTo n =
    if n = 0
    then 0
    else n + sumUpTo(n - 1)
sumUpTo 100