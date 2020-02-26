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

    let wikiTitlesFile = @"C:\Users\kemar\Downloads\enwiki-latest-all-titles"
    let readAllLines fileName = 
        fileName
        |> File.ReadAllLines
        |> Seq.ofArray

    let readLines fileName = 
        fileName
        |> File.ReadLines

    let readSingleLines filePath =
        seq {
                let rec readLine (reader:StreamReader) = 
                    seq {
                        if reader.EndOfStream = false
                        then    
                            yield reader.ReadLine()
                            yield! readLine reader
                    }

                use stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None)
                let reader = new StreamReader(stream)
                yield! readLine reader
        }

    wikiTitlesFile |> readAllLines |> Seq.length
    wikiTitlesFile |> readLines |> Seq.length
    wikiTitlesFile |> readSingleLines |> Seq.length

