// Signature file for parser generated by fsyacc
module Parser
type token = 
  | EOF
  | PLUS
  | MINUS
  | STAR
  | HAT
  | LPAR
  | RPAR
  | NAME of (string)
  | INT of (int)
type tokenId = 
    | TOKEN_EOF
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_STAR
    | TOKEN_HAT
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_NAME
    | TOKEN_INT
    | TOKEN_end_of_input
    | TOKEN_error
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_exp
/// This function maps tokens to integer indexes
val tagOfToken: token -> int

/// This function maps integer indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val start : (FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> FSharp.Text.Lexing.LexBuffer<'cty> -> (Syntax.exp) 
