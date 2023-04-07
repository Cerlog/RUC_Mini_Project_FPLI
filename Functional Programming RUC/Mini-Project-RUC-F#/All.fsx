#r    "nuget: FsLexYacc.Runtime, 10.2.0"
#r     "asm.dll"
#r     "vm.dll"
#load "Syntax.fs" "Parser.fs" "Lexer.fs" "Parse.fs" "arith.fs"
open VM
open Parse
open Arith
open Asm
open System
open Syntax
open Lexer


// Add F# code here
