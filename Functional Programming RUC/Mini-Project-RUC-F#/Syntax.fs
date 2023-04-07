module Syntax

type exp = | INT of int
           | VAR of string
           | ADD of exp * exp
           | SUB of exp * exp
           | MUL of exp * exp
           | EXP of exp * exp // added and go back to a parser
