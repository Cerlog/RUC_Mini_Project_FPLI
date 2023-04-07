module Comp
open Syntax

type 'a env = (variableName * 'a) list

let rec mapInstructions instrs =
    match instrs with
    | [] -> []
    | (Asm.ILOAD i) :: tl -> (Asm.ILOAD i) :: mapInstructions tl
    // Add more cases for other instructions
    | _ -> failwith "Unknown instruction encountered"


// type of instructions for compiler
type ins = |IPUSH of int // one value gets pushed on stack
            |IADD
            |IMUL
            |ISUB
            |IDIV
            |INEG
            |ILOAD of int // load value from stack
            

// Compute index of variable in environment
let rec varpos x = function
  | []       -> failwith ("unbound: " + x)
  | y :: env -> if x = y then 0 else 1 + varpos x env

// Generate a new label
let mutable labelCounter = 0
let newLabel _ =
  let this = labelCounter
  labelCounter <- this + 1;
  "L" + string(this)
  
  
let rec lookUp x env =
    match env with
    | []                -> failwith ("unbound variable name: " + x)
    | (key, value)::env -> if key = x then value else lookUp x env

// Compiler
let rec comp env = function
    | INT i -> [ILOAD i]
    | NEG e -> comp env e @ [INEG]
    | ADD (e1, e2) -> comp env e1 @ comp env e2 @ [IADD] // adding instruction to the compiler about patern matching
    | SUB (e1, e2) -> comp env e1 @ comp env e2 @ [ISUB] // adding instruction to the compiler about patern matching
    | MULT (e1, e2) -> comp env e1 @ comp env e2 @ [IMUL] // adding instruction to the compiler about patern matching
    | DIV (e1, e2) -> comp env e1 @ comp env e2 @ [IDIV] // adding instruction to the compiler about patern matching

// ...
    
let compile = function
    PROG (defs, e) -> comp [] e
    
    
// Interpreter
let evalProg (funcs, e) =
    let rec eval env = function
        | INT i -> i
        | NEG e -> - eval env e
        | ADD (e1, e2) -> eval env e1 + eval env e2
        | SUB (e1, e2) -> eval env e1 - eval env e2
        | MULT (e1, e2) -> eval env e1 * eval env e2
        | DIV (e1, e2) -> eval env e1 / eval env e2
        | VAR e -> lookup e env
        | CALL (f, e) -> let v = eval evn e
                         let (x, body) = lookup f funcs
                         eval [(x, v)] body
        | IF (cond, e1, e2) -> if eval env cond <> 0 then eval env e1 else eval env e2


    eval [] e




