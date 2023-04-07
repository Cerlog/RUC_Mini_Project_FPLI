module TestArith

open Arith

type TestCase = {
    Input: exp
    ExpectedOutput: int
}

let testEval evalFn testCases =
    let testSingleCase (testCase: TestCase) =
        let result = evalFn [] testCase.Input
        if result <> testCase.ExpectedOutput then
            printfn "FAILED: Input: %A, Expected: %d, Got: %d" testCase.Input testCase.ExpectedOutput result
        else
            printfn "PASSED: Input: %A, Expected: %d, Got: %d" testCase.Input testCase.ExpectedOutput result

    List.iter testSingleCase testCases

let testCases = [
    { Input = ADD (INT 3, INT 4); ExpectedOutput = 7 }
    { Input = MUL (INT 5, ADD (INT 2, INT 3)); ExpectedOutput = 25 }
    // Add more test cases here
]

testEval eval testCases