namespace UdemyCourse.DataProcessing

module LoanPayments = 

    open System.IO
    open System
    open System.Globalization

    let lines = 
        File.ReadAllLines(@"D:\Source\UdemyCourse\UdemyCourse\DataProcessing\Loan payments data.csv")
        |> Array.distinct
        |> Array.map (fun s -> s.Split(','))

    let header = lines |> Array.take 1

    let data = lines |> Array.skip 1

    header

    data.Length

    [<Measure>]type days
    [<Measure>]type dollar
    [<Measure>]type terms
    [<Measure>]type age

    type LoanStatus = 
        | PaidOff of PaidOffTime : DateTime
        | Collection of PastDueDays : int<days>
        | Collection_PaidOff of PaidOffTime : DateTime * PastDueDays : int<days>

    type Education = 
        | HighSchoolOrBelow
        | College
        | MasterOrAbove

    type Gender = 
        | Male
        | Female

    let dateTimeParseUS stringToParse =
        DateTime.Parse(stringToParse, new CultureInfo("en-US"))

    let transformToLoanStatus (status, paidOffTime, pastDueDays) = 
        match status with
        | "PAIDOFF"
            -> PaidOff(dateTimeParseUS paidOffTime)
        | "COLLECTION"
            -> Collection((Int32.Parse(pastDueDays)) * 1<days>)
        | "COLLECTION_PAIDOFF"
            -> Collection_PaidOff(dateTimeParseUS paidOffTime, (Int32.Parse(pastDueDays)) * 1<days>)
        | unknown
            -> failwith (sprintf "Unrecognised loan status: \"%s\"" unknown)

    let transformToEducation = function
        | "High School or Below"
            -> HighSchoolOrBelow
        | "Bechalor"
        | "college"
            -> College
        | "Master or Above"
            -> MasterOrAbove
        | x 
            -> failwith (sprintf "Unrecognised education: \"%s\"" x)

    let transformToGender = function
        | "male"
            -> Male
        | "female"
            -> Female
        | x 
            -> failwith (sprintf "Unrecognised gender: \"%s\"" x)

    type LoanPaymentData = 
        {
            LoanId : string;
            LoanStatus : LoanStatus;
            Principal : int<dollar>;
            Terms : int<terms>;
            EffectiveDate : DateTime;
            DueDate : DateTime;
            Age : int<age>;
            Education : Education;
            Gender : Gender
        }
    
    let transformToLoanPaymentData (data : string array) = 
        {
            LoanId = data.[0];
            LoanStatus = transformToLoanStatus (data.[1], data.[6], data.[7]);
            Principal = Int32.Parse(data.[2]) * 1<dollar>;
            Terms = Int32.Parse(data.[3]) * 1<terms>;
            EffectiveDate = dateTimeParseUS(data.[4]);
            DueDate = dateTimeParseUS(data.[5]);
            Age = Int32.Parse(data.[8]) * 1<age>;
            Education = data.[9] |> transformToEducation;
            Gender = data.[10] |> transformToGender
        }

    let paymentData = 
        data
        |> Array.map transformToLoanPaymentData

    paymentData
    |> Array.map (fun pd -> pd.EffectiveDate)
    |> Array.distinct


