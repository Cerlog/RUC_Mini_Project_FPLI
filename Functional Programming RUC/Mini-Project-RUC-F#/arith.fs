module Arith

(* 
syntax for interpreter 
*)

type varname = string (* variable names *)
type exp =  | INT of int (* integer constants *)
            | NEG of exp (* negation *)
            | ADD of exp * exp (* addition *) 
            | SUB of exp * exp (* subtraction *)  
            | MUL of exp * exp (* multiplication *)
            | VAR of varname (* variables *)
            | EXP of exp * exp (* exponentiation *)
            | LET of varname * exp * exp (* let binding *)
            
            
(* 
interpreter          
*)
type 'a env = (varname * 'a) list (* environments *)

let rec lookup x = function // lookup function
    | [] -> failwith ("unbound: " + x) 
    | (y, v) :: env -> if x = y then v else lookup x env 

(*  
let testLookup x values =
    let env = List.mapi (fun i v -> (string i, v)) values
    lookup x env  
    
> testLookup "0" [1; 2; 3];; -> val it: int = 1
This function takes a string and a list of values and returns
the value at the position of the string in the list.
*)


let rec eval env = function // eval function
    | INT i -> i // if it's an integer, return the integer
    | VAR x -> lookup x env // if it's a variable, look it up in the environment
    | ADD (e1, e2) -> eval env e1 + eval env e2 // if it's an addition, evaluate the two expressions and add them
    | MUL (e1, e2) -> eval env e1 * eval env e2 // if it's a multiplication, evaluate the two expressions and multiply them
    | SUB (e1, e2) -> eval env e1 - eval env e2 // if it's a subtraction, evaluate the two expressions and subtract them
    | NEG (e1) -> -1 * (eval env e1) // if it's a negation, evaluate the expression and multiply it by -1
    | EXP (e1, e2) -> pown (eval env e1) (eval env e2) // pown is a function from the F# library
    | LET (x, e1, e2) -> // if it's a let binding, evaluate the first expression and bind it to the variable
                        let v1 = eval env e1 // evaluate the first expression
                        eval ((x, v1) :: env) e2 // evaluate the second expression with the new environment
    

//let testEval expression =
//    let ast = Parse.fromString expression
//    let result = eval [] ast
//    result



(* 
type of instructions for compiler
*)
type ins =  |IPUSH of int // one value gets pushed on stack
            |ILOAD of int // one value gets loaded from stack
            |IADD // two values get added
            |IMUL // two values get multiplied
            |ISUB // two values get subtracted
            |ISWAP // two values get swapped
            |IPOP // one value gets popped off stack
            |IEXP // two values get exponentiated
            
            

(* 
compiler
*)
type env = string list // environment
let rec varpos x = function // returns position of variable in environment
  | [] -> failwith ("unbound: " + x)
  | y :: env -> if x = y then
                    0
                else
                    1
                + varpos x env
let rec adddummy env = "" :: env
let rec comp env = function
    | INT i -> [IPUSH i]
    | VAR x -> [ILOAD (varpos x env)]
    | ADD (e1, e2) -> comp env e1 @ comp env e2 @ [IADD] 
    | MUL (e1, e2) -> comp env e1 @ comp env e2 @ [IMUL] 
    | SUB (e1, e2) -> comp env e1 @ comp env e2 @ [ISUB]
    | NEG (e1) -> comp env e1 @ [IMUL; IPUSH (-1)]
    | LET (x, e1, e2) ->    comp env e1        @
                            comp (x :: env) e2 @
                            [ISWAP]            @
                            [IPOP]
    | EXP (e1, e2) -> comp env e1 @ comp env e2 @ [IEXP]
    

// VM
//let rec exec ins st =
//    match (ins, st) with
//    | ([], [v])                        -> v
//   | (IPUSH i :: ins, st)             -> exec ins (i ::st) // recursive call with i and remaining instructions
//    | (IADD    :: ins, y :: x :: st)   -> exec ins (x + y :: st) // exec on remaining inst and stach with x+y on top with rema\ining el
//    | (IMUL    :: ins, y :: x :: st )  -> exec ins (x * y :: st)
//    | (ISUB    :: ins, y :: x :: st)   -> exec ins (x - y :: st)
    
(* 
let rec exec ins st =
  match (ins, st) with
    | ([], [v]) -> v
    | (IPUSH i :: ins, st) -> exec ins (i :: st) 
    | (IADD :: ins, y :: x :: st) -> exec ins (x + y :: st)
*) 