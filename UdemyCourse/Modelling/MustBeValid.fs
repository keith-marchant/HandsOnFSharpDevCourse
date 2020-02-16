namespace UdemyCourse.Modelling

module MustBeValid = 

    type CheckingAccount = CheckingAccount
    type Identification = 
        | DriverLicense of string
        | SSNCard of string
        | MilitaryId of string
        | Passport of string

    type TwoIds = 
        private
        | Ids of Identification * Identification

    let makeTwoIds (id1 : Identification) (id2 : Identification) = 
        match (id1, id2) with
        | (DriverLicense _), (DriverLicense _)
            -> None
        | (SSNCard _), (SSNCard _)
            -> None
        | (MilitaryId _), (MilitaryId _)
            -> None
        | (Passport _), (Passport _)
            -> None
        | _
            -> Some (Ids (id1, id2))

    let openCheckingAccount (ids: TwoIds) =
        let Ids (id1, id2) = ids
        CheckingAccount

module Tests = 

    open MustBeValid

    let goodIds = makeTwoIds (DriverLicense "abc") (Passport "123")
    let account1 = openCheckingAccount goodIds.Value

    let badIds = makeTwoIds (DriverLicense "abc") (DriverLicense "123")
    let account2 = openCheckingAccount badIds.Value // throws errors