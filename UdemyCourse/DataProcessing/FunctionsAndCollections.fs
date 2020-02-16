namespace UdemyCourse.DataProcessing

module FunctionsAndCollections = 

    open System
    open System.IO

    seq { 1..3 }
    |> Seq.iter (printfn "%d")

    seq { for i in 1..3 -> i*i }
    |> Seq.iter (printfn "%d")

