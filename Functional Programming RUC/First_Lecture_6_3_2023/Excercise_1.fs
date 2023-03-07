(* Excercise 1 *)

// a
"Hello world";;
// val it: string = "Hello world"

// b
Hello world
// error FS0039: The value or constructor 'Hello' is not defined.

// c
3 + 4;;
//val it: int = 7

// d
3 + four;;
// The value or constructor 'four' is not defined.

// e
3 + "four";;
// The type 'string' does not match the type 'int'

// f
3 + 4.2;;
// The type 'float' does not match the type 'int'

// g
4.2 + 3;;
// The type 'int' does not match the type 'float'

// h
4.2 + 3.0;;
// val it: float = 7.2

// i
"horse" + "shoe";;
//val it: string = "horseshoe"
