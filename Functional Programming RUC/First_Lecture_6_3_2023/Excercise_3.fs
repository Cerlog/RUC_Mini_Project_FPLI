(* Excercise 3 *)

(* a) Copy-paste the definition of the scalarMultip into the F# interactive system (i.e., after the prompt “>”),
 add “;;” at the end, and hit enter. Now the function is available and can be used. 
 (Notice that the function expects both x and the elements of the matrix to be integers, not reals.)
*)
let scalarMultip x ((a, c), (b, d)) = ((x*a, x*c), (x*b, x*d));;

// representing the matrix A as a pair of pairs
let A = ((6,7), (0, 2))

(* b) Use the function scalarMultip to compute the scalar multiplication of 5 and the matrix ((6,7), (0, 2)).*)
scalarMultip 5 A

(* c)  If you want to edit a function definition (for example, because it contained an error),
don't type it directly into the F# interactive system. Instead save it to file
(that ends with .fs) and load it into the interpreter with the command *)

//  #load "filename";;

(* Create a file called matrix.fs and save the definition of smult in the file.
(Save all of the following functions in that file too.) The file must start with a module declaration.
Add this line at the top of the file:*)

// module Matrix
(* Notice that there should be no “;;” at the end of any of the lines in files like this.*)

(*Save the file, and type *)

// #load "matrix.fs";;
(* in the REPL. You can now use the function smult by typing Matrix.smult.
Or you can include all functions defined in the file once and for all by typing *)

//  open Matrix;;

(* After this, you can simly type smult, without the module. *)

(* d) Implement a function det that takes a matrix as input and returns its determinant
(which, for 2×2 matrices, is defined to be ad − bc).
 Such a function can be implemented by pattern matching, like this:*)

let det ((a, c), (b, d))  = (a * d) - (b * c);;
det A;;

(* e) Implement a function transpose that, given a representation of an input matrix*)
let transpose ((a, c), (b, d)) = ((a, b), (c, d));;
transpose A;;

(* f) Implement a function "add" that takes two matrices A, B as input and returns A + B. as output *)
let add ((a1, c1), (b1, d1)) ((a2, c2), (b2, d2)) = ((a1+a2, c1+c2), (b1+b2, d1+d2));;
add A A 

(*g ) Implement a matrix multiplication function. If you define the operation by *)
// let (.*) ... ... = ?
(* then you can use .* as an inflix matrix-multip operator *)

let ( .* ) ((a1, c1), (b1, d1)) ((a2, c2), (b2, d2)) = (((a1 * a2) + (b1 * c2) , (a1 * b2) + (b1 * d2)),
                                                        ((a1 * b2) + (b1 * d2) , (c1 * b2) + (d1 * d2)));;

let B = ((1, 2), (3, 4))
let C = ((5, 6), (7, 8))

B .* C



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