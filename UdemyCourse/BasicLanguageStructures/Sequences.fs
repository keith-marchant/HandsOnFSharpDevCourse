namespace UdemyCourse.BasicLanguageStructures

module Sequences = 

    let seqArray = seq [| 1 ; 2 ; 3 |]

    let seqList1 = seq [ 1 ; 2;  3 ]
    let seqList2 = seq [ 1..3 ]

    // Sequences are lazy, values won't exist until accessed
    let seq1 = seq { 1..3 }
    seq1 |> Seq.take 1

    let seq2 = seq { for i in 1..3 -> i }
    let se3 = Seq.init 3 (fun id -> id + 1)

    let seq4 = Seq.initInfinite ( fun id -> id + 1 )



