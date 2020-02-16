﻿namespace UdemyCourse.HigherOrderFunctions

module DependencyInjection = 

    type Application = Application
    type Ids = Ids
    type Deposit = Deposit
    type CheckingAccount = CheckingAccount

    let validateApplication (application : Application) = 
        true


    let openCheckingAccount
        validateApplication
        validateIds
        validateDeposit
        (application : Application)
        (ids : Ids)
        (deposit : Deposit) =

        // verify the application is complete
        // verify that ids are valid
        // verify that deposit amount is sufficient

        if not (validateApplication application) then None
        elif not (validateIds ids) then None
        elif not (validateDeposit deposit) then None
        // if everything is OK then return the checking account
        else Some CheckingAccount

