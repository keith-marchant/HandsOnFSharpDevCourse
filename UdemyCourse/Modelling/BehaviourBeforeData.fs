namespace UdemyCourse.Modelling

module BehaviourBeforeData = 

    // To open a checking account, a customer provides
    // an application, two forms of identification
    // and an initial deposit

    type CheckingAccount = CheckingAccount
    type Application = Application
    type Identification = Identification
    [<Measure>] type money
    type Deposit = decimal<money>

    let openCheckingAccount 
        (application : Application) 
        (id : Identification * Identification) 
        (deposit : Deposit) = 
            if deposit >= 500M<money>
                then Some CheckingAccount
                else None


    //openCheckingAccount None (None, None) 500M<money>

