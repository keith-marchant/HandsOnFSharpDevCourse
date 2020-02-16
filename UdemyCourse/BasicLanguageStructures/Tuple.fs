namespace UdemyCourse.BasicLanguageStructures

module Tuple = 

    let tuple1 = (5,10)
    let tuple2 = (2, 4)

    let tupleFunc (x ,y) = 
        (x + y, x * y)

    tuple1 |> tupleFunc

    let tuple3 = (5, 10)
    tuple1 = tuple3

    tuple1 < (5, 11)

    let tuple4 = struct (1,1)

