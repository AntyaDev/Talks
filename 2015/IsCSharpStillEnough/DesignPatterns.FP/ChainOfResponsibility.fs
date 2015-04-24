module ChainOfResponsibility

type LeaveSettings = {
    UserId : string
    NumberOfDays : int
}

module ReportingManager =
    
    let validateDays days =
        if days.NumberOfDays < 3 then true
        else false

module ProjectManager =
    
    let validateDays days =
        if days.NumberOfDays < 3 && days.NumberOfDays <= 10 then true
        else false

module TopManager =    

    let validateDays days = true


let check validateFn (leaveSettings, result) =
    if result then (leaveSettings, true)
    else (leaveSettings, validateFn(leaveSettings))

// create chain function
let chainOfResponsibility = check ReportingManager.validateDays 
                            >> check ProjectManager.validateDays
                            >> check TopManager.validateDays

let leaveSettings = { UserId = "TestUserId"; NumberOfDays = 5 }

let result = chainOfResponsibility(leaveSettings, false)

