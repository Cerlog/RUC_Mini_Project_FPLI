module Syntax

type variableName   = string // variable name
type functionName   = string // function name
type exp    = INT   of int // integer
            | NAME  of variableName // variable name
            | ADD   of exp * exp // added addition
            | SUB   of exp * exp // added subtraction
            | MULT  of exp * exp // added multiplication
            | DIV   of exp * exp // added division
            | NEG   of exp       // added negation
            | VAR   of variableName
            | EQ    of exp * exp
            
            (* TODO: ADD MORE *) 
            | LET   of variableName * exp * exp // added let
            | IF    of exp * exp * exp // added if
            | CALL  of functionName * exp // added function call
            
type func = functionName * (variableName * exp) // function name, argument name, body
type def    = FUNC  (* of TODO *) 

type prog   = PROG  of def list * exp  
