#r "nuget: FsLexYacc.Runtime, 10.2.0"
#r "asm.dll"
#r "vm.dll"
#load "Syntax.fs" "Parser.fsi" "Parser.fs" "Lexer.fs" "Parse.fs" "Comp.fs"

open Syntax

let testCases = [
    ("1 + 2", ADD (INT 1, INT 2));
    // Add more test cases as needed
]

let testExpression (input: string) (expected: exp) =
    let resultExp = Parse.fromString input
    let resultProg = PROG ([], resultExp)
    let compiledResult = Comp.compile resultProg

    if compiledResult = expected then
        printfn "Test PASSED: %s => %A" input expected
    else
        printfn "Test FAILED: %s => %A, expected %A" input compiledResult expected


let runTests () =
    for (input, expected) in testCases do
        testExpression input expected


runTests ()
