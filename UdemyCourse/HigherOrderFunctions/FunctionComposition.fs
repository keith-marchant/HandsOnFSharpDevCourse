namespace UdemyCourse.HigherOrderFunctions

module FunctionComposition = 

    let subtract x y = x - y
    subtract 9 3

    3 //this passes in as the last argument
    |> subtract 9
    |> subtract 88

    subtract 88 <| (subtract 9 <| 3) // Passes in the arguments in the first spot

    let square x = x * x
    let triple x = x * 3.0
    let negate x = -x

    let toFloat x = (float)x
    let toInt (x:float) = (int)x

    let squareAndTripleAndNegate = square >> toFloat >> triple >> toInt >> negate

    squareAndTripleAndNegate 5

    let add x y = x + y

    let splitPair f (x:int,y:int) = f x y

    let addAndSquare = splitPair add >> square // equivalent to (splitPair add) >> square