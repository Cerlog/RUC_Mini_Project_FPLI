(* Functional Programming and Language Implementation
    Petr Boska Nylander, 10/03/2023, 1st hand-in (Excercise 6)
*)

(* Excercise 6
Let us represent times of the day as triples (h, m, s) of integers, where h is the hour after midnight,
 m is minutes after the hour, and s the seconds. (For example, 14:05:30 is represented as (14, 5, 30).) *)
 
 (* 6 a)
 Implement a function tick that increments a time-of-day by one second.
 For example, on input (14, 36, 15) is must return (14, 36, 16), on input (14, 36, 59) is
 must return (14, 37, 0), and on input (14, 59, 59) is must return (15, 0, 0).*)
 let rec tick (h, m, s) =
    if s = 59 && m = 59
    then (h+1, 0, 0) // hour increments by 1, if min and sec = 59.
    elif s = 59      // if sec = 59
    then (h, m+1, 0)        // min gets incremented
    else (h, m, s+1) // sec increment in the rest of the cases
    
tick (14, 59, 58);;
// val it: int * int * int = (14, 59, 59)

tick (14, 36, 15);;
// val it: int * int * int = (14, 36, 16)

tick (14, 36, 59);;
//val it: int * int * int = (14, 37, 0)

tick(14, 59, 59);;
// val it: int * int * int = (15, 0, 0)

(* b)
Implement a function before, that takes two such times-of-day as input and that returns true
iff the first comes before the second *)
let rec before (h1, m1, s1) (h2, m2, s2) =      // checking for the 3 cases
    if h1 < h2 && m1 < m2 || s1 < s2            // checks h and min only, sec can be > h & min
    then true
    elif (h1 = h2) && m1 < m2 && s1 < h2       // check for min and sec only, h is fixed
    then true
    elif (h1 = h2) && (m1 = m2) && (s1 < s2)   // check for sec only, h and min are fixed
    then true
    else false                                 // all other cases evaluate to false
    
before (12, 12, 12) (13, 14, 15)
//val it: bool = true

before (12, 12, 12) (12, 14, 15)
//val it: bool = true

before (12, 12, 12) (12, 14, 11)
// val it: bool = false

before (12, 12, 12) (12, 12, 15)
// val it: bool = true

before (12, 12, 12) (12, 12, 13)
// val it: bool = true

before (12, 12, 12) (12, 12, 11)
// val it: bool = false

(* c)
Modify tickFrom so that, when the user types “stop”, it returns the time that it has just printed.*)
let rec tickFrom ((h, m, s) as t) =
    printf $"%02d{h}:%02d{m}:%02d{s} "
    if System.Console.ReadLine() = "stop" then
        (h, m, s) // returns current time, when stop entered
    else
        tickFrom (tick t)

tickFrom (12, 12, 11)