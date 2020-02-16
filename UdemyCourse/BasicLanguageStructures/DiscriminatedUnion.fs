namespace UdemyCourse.BasicLanguageStructures

open System

module DiscriminatedUnion = 

    type TrafficSignals = 
    | Red
    | Yellow
    | Green

    type Shape = 
    | Circle of float
    | Rectangle of float * float
    | Square of float

    type MessageReceiverState = 
    | Off
    | Activating of WhenActivated : DateTime
    | Idle of IdleDuration : TimeSpan
    | MessageReceived of Message : string * WhenReceived : DateTime
    | Deactivating of WhenDeactivated : DateTime



