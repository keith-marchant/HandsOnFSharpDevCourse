namespace UdemyCourse.DataProcessing

module FunctionsAndCollections = 

    open System
    open System.IO

    seq { 1..3 }
    |> Seq.iter (printfn "%d")

    seq { for i in 1..3 -> i*i }
    |> Seq.iter (printfn "%d")

    seq { for i in 1 .. 3 do yield i*i }
    |> Seq.iter (printfn "%d")

    seq {
        for i in 1..3 do
            for j in 4..5 do
                yield i + j
    }
    |> Seq.iter (printfn "%d")

    let rec listAllFiles path = 
        seq {
            for file in Directory.GetFiles(path) do
                yield file
            for directory in Directory.GetDirectories(path) do
                yield! listAllFiles directory //yield! means the function evaluates into a sequence itself
        }

    listAllFiles @"C:\source\HandsOnFSharpDevCourse\UdemyCourse"
    |> Seq.iter (printfn "%s")

    
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


    let lines = readSingleLines @"C:\source\HandsOnFSharpDevCourse\UdemyCourse\DataProcessing\Loan payments data.csv"
    let enumerator = lines.GetEnumerator()
    enumerator.MoveNext() // File is now locked
    enumerator.Current
    enumerator.Dispose() // Dispose and unlock the file

    lines
    |> Seq.iter (printfn "%s") // Does the above automatically so no need to explicitly call dispose
    