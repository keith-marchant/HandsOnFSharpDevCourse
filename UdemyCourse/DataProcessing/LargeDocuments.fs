namespace UdemyCourse.DataProcessing

module LargeDocuments = 
    
    open System
    open System.IO
    open System.Collections.Generic

    // #time

    let wikiTitlesFile = @"C:\Users\kemar\Downloads\enwiki-latest-all-titles"

    let readLines fileName = 
        fileName
        |> File.ReadLines

    let readWordsInLine (line: string) = 
        line.Split([| ' '; '_';'\\';'/';' '|])
        |> Seq.ofArray
        |> Seq.map (fun s -> s.Trim())

    let readWordsInFile fileName = 
        fileName
        |> readLines
        |> Seq.collect readWordsInLine

    let wikiTitlesWords = readWordsInFile wikiTitlesFile

    wikiTitlesWords |> Seq.contains "LexiSession"

    let isWordinSequence (words : string seq) = 
        let wordSet = new HashSet<string>()
        let enumerator = words.GetEnumerator()
        fun word ->
            if wordSet.Contains word
                then true
                else
                    let mutable isFound = false
                    while enumerator.MoveNext() && (not isFound) do
                        let w = enumerator.Current
                        wordSet.Add w |> ignore
                        if w = word
                            then isFound <- true

                    isFound

    let isWordInWikiTitles = isWordinSequence wikiTitlesWords
    isWordInWikiTitles "Wiki"

    let countWordsInSequence words =
        let wordCounts = new Dictionary<string, int>()
        words
        |> Seq.iter (fun word ->
            if wordCounts.ContainsKey(word)
                then wordCounts.[word] <- wordCounts.[word] + 1
                else wordCounts.[word] <- 1)
        fun word ->
            if wordCounts.ContainsKey(word)
                then wordCounts.[word]
                else 0

    let countWordsInWikiTitles = countWordsInSequence wikiTitlesWords
    countWordsInWikiTitles "Wiki"
