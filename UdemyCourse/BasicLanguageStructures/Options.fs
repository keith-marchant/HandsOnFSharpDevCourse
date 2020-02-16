namespace UdemyCourse.BasicLanguageStructures

module Options = 

    let safeDivide (x, y) = 
        if y = 0.0
            then None
            else Some (x/y)
