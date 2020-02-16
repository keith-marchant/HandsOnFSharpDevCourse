namespace UdemyCourse.BasicLanguageStructures

module Record = 

    // Optional
    [<Struct>]
    type Person = 
        {
            FirstName : string
            LastName : string
            Age : int
        }

    let richard = 
        {
            FirstName = "Keith"
            LastName = "Marchant"
            Age = 32
        }

    let func1 person = 
        (person.FirstName, person.Age)

