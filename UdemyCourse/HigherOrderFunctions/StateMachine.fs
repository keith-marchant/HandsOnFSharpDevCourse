namespace UdemyCourse.HigherOrderFunctions

module Automobile = 

    type AutomobileState = 
        | NotRunning
        | Idling
        | Moving

    type AutomobileEvent = 
        | Ignition
        | PutInDrive
        | TurnLeft
        | TurnRight
        | Stop
        | TurnOff

    // This will work but allows for runtime errors should an invalid tuple be presented 
    //let stateMachine (state, event) = 
    //    match state, event with
    //    | NotRunning, Ignition
    //        -> Idling
    //    | Idling, PutInDrive
    //        -> Moving
    //    | Moving, TurnLeft
    //        -> Moving
    //    | Moving, TurnRight
    //        -> Moving
    //    | Moving, Stop
    //        -> Idling
    //    | Idling, TurnOff
    //        -> NotRunning
    //    | _
    //        -> failwith "Invalid state transition"

    let private stateTransitions event =
        match event with
        | Ignition
            -> Idling
        | PutInDrive
            -> Moving
        | TurnLeft
            -> Moving
        | TurnRight
            -> Moving
        | Stop
            -> Idling
        | TurnOff
            -> NotRunning

    let private getEventsForState state = 
        match state with
        | NotRunning
            -> [| Ignition |]
        | Idling
            -> [| PutInDrive; TurnOff |]
        | Moving
            -> [| TurnLeft; TurnRight; Stop |]

    type AllowedEvent = 
        {
            EventInfo : AutomobileEvent
            RaiseEvent : unit -> EventResult
        }
    and EventResult = 
        {
            CurrentState : AutomobileState
            AllowedEvents : AllowedEvent array
        }

    let rec private stateMachine event = 
        let newState = stateTransitions event
        let newEvents = getEventsForState newState
        {
            CurrentState = newState
            AllowedEvents = 
                newEvents
                |> Array.map (fun e ->
                    let f() = stateMachine e
                    {
                        EventInfo = e
                        RaiseEvent = f
                    })
        }

    let init() = stateMachine TurnOff

module AutomobileTest =
    open Automobile

    let result1 = init()

    let result2 = result1.AllowedEvents.[0].RaiseEvent()
