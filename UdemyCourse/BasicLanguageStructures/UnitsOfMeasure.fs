namespace UdemyCourse.BasicLanguageBehaviour

module UnitsOfMeasure = 

    [<Measure>] type ft
    [<Measure>] type sec

    let someFeet = 20.0<ft>
    let someSecs = 2.34<sec>

    someFeet * 11.0

    let feetSec = someFeet / someSecs

    someSecs * feetSec

    7778.987 * 1.0<ft>

    let doubleIt (fl : float<_>) = 
        fl + fl

    doubleIt someFeet

