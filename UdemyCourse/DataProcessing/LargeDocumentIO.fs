namespace UdemyCourse.DataProcessing

module LargeDocumentIO = 

    open System
    open System.IO
    open System.Collections.Generic

    (*
    #time
    *)

    let f = 
        fun () -> 
            for i in [ 1..100 ] do printfn "%d" i

    f()

    let timeAFunction func =
        let stopwatch = System.Diagnostics.Stopwatch.StartNew()
        let result = func()
        stopwatch.Stop()
        (stopwatch.ElapsedMilliseconds, result)

    timeAFunction f



