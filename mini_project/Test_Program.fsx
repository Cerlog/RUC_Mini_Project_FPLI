#load "All.fsx"


open System.IO
open Lexer
open Parser
open Syntax


let parse (input: string) : Syntax.prog =
    let lexbuf = LexBuffer<_>.FromString input
    let ast = Parser.start Lexer.tokenize lexbuf
    ast

printfn "Enter input code:"
let input = System.Console.ReadLine()

printfn "Parsing input..."
let parsedAST = parse input
printfn "Resulting AST:"
printfn "%A" parsedAST
