namespace UdemyCourse.HigherOrderFunctions

module PartialFunctions = 

    let add x y =
        x + y

    let add2 = add 2
    add2 4
    add2 7

    let add' (x,y) = 
        x + y

    let add'' x y = 
        add' (x,y)

    let add2' = add'' 2

    add2' 6

    let doOperation f x y = 
        f x y

    let doAdd = doOperation add

    doAdd 8 9

    let doMultiply = doOperation (*)

    doMultiply 8 9

    open System
    open System.Globalization

    let stringCompare s1 s2 = 
        String.Compare(s1, s2, true, CultureInfo.InvariantCulture)

    let stringCompare'
        (ignoreCase:bool)
        (cultureInfo:CultureInfo)
        s1 s2 = 
            String.Compare(s1, s2, ignoreCase, cultureInfo)

    let stringCompare''= 
        stringCompare' true CultureInfo.InvariantCulture

    let result = stringCompare'' "a" "b"       