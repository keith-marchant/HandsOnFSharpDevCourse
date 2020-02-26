namespace UdemyCourse.DataProcessing

module OrdersParser =

    #if INTERACTIVE
    #r @"C:\Users\kemar\.nuget\packages\fparsec\1.1.1\lib\netstandard2.0\FParsecCS.dll"
    #r @"C:\Users\kemar\.nuget\packages\fparsec\1.1.1\lib\netstandard2.0\FParsec.dll"
    #endif

    open System
    open System.IO
    open FParsec

    type Order = 
        {
            OrderNumber : string
            CustomerName : string
            OrderDate : DateTime
            ShipVia : string
            Items : Item list
        }
    and Item = 
        {
            ProductNumber : string
            ProductName : string
            Quantity : int
            Price : decimal
        }

    let input = File.ReadAllText(@"D:\Source\UdemyCourse\UdemyCourse\DataProcessing\Orders.csv")

    let parseA = pchar<unit> 'A'
    run parseA "ABC"

    let testParser parser = 
        let innerFunc input =
            match run parser input with
            | Success(result, _, remainderPos)
                ->  printfn "Success: %A" result
                    printfn "Rest of input: %s" (input.Substring(int32(remainderPos.Index)))
            | Failure(errorMessage, _, _)
                -> printfn "Failure: %s" errorMessage
        innerFunc

    testParser parseA "ABC"

    let parseB = pchar<unit> 'B'

    let parseAorB = 
        parseA <|> parseB

    testParser parseAorB "ABC"
    testParser (many parseAorB) "DCBA"
    testParser pint32 "123 more stuff"

    let parseInts =
        sepBy pint32<unit> (pchar ',')

    testParser parseInts "123,456,789"

    let parseDelimitedData pdata pdelim =
        sepBy pdata pdelim

    let parseIntsRefactor = 
        parseDelimitedData pint32<unit> (pchar<unit> ',')

    let dataInQuotes p =
        between (skipChar<unit> '"') (skipChar '"') p

    let intInQuotes = dataInQuotes pint32

    testParser intInQuotes "\"248\""

    let stringInQuotes = 
        dataInQuotes (manyChars (satisfy (fun c -> c <> '"')))

    testParser stringInQuotes "\"Test Test\""

    let decimalInQuotes = stringInQuotes |>> decimal

    testParser decimalInQuotes "\"235.96\""

    let dateTimeInQuotes =
        stringInQuotes
        |>> fun s -> DateTime.ParseExact(s, "yyyy-mm-dd", null)

    testParser dateTimeInQuotes "\"2018-01-01\""