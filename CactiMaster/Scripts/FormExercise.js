
function isAllDigits(str) {
    let v = !isNaN(str)
    return v;
}

function countDigits(str) {
    let count = 0;
    for (let i = 0; i < str.length; i++) {
        if (str[i] >= '0' && str[i] <= '9')
            count++;
    }
    return count;
}

let licensePlateFormat = "new";

function checkLicensePlace() {

    let licensePlate = document.getElementById("licensePlate").value;
    if (isAllDigits(licensePlate)) {

        if (licensePlate.length == 8) {
            licensePlateFormat = "new";
            return true;
        }
        else if (licensePlate.length == 7) // XXX XX XXX, XX XXX XX
        {
            licensePlateFormat = "old";
            return true;
        }
    }
    else if (licensePlate.length == 10) // new format XXX-XX-XXX
    {
        licensePlateFormat = "new";
        if (licensePlate[3] == '-' && licensePlate[6] == '-' && countDigits(licensePlate) == 8)
            return true;
    }
    else (licensePlate.length == 9) // old format XX-XXX-XX
    {
        licensePlateFormat = "old";
        if (licensePlate[2] == '-' && licensePlate[6] == '-' && countDigits(licensePlate) == 7)
            return true;
    }

    let errMsg = document.getElementById("errorLicensePlate");
    errMsg.innerHTML = "License plate is not formatted properly (XXX-XX-XXX or XX-XXX-XXX)";
    return false;
}

function checkYear() {
    let year = document.getElementById("carYear").value;
    if (year == "none") {
        let errMsg = document.getElementById("errorCarYear");
        errMsg.innerHTML = "please choose year";
        return false;
    }

    let carYear = parseInt(year);
    if (carYear < 2017 && licensePlateFormat == "old")
        return true;
    else if (carYear >= 2017 && licensePlateFormat == "new")
        return true;

    let errMsg = document.getElementById("errorCarYear");
    errMsg.innerHTML = "Registration Year does not match License Number format";
    return false;
}


function checkTZID() {
    let tzid = document.getElementById("israelID").value;
    let checkDigit = parseInt(document.getElementById("checkDigit").value);
    let sum = 0;

    let mult = 1;
    for (var d in tzid) {
        sum += parseInt(d) * mult;
        if (mult == 1)
            mult = 2;
        else
            mult = 1;
    }
    sum += checkDigit;
    if (sum % 10 == 0) {
        return true;
    }
    let errMsg = document.getElementById("errorTZID");
    errMsg.innerHTML = "Incorrect TZ ID number";
    return false;
}

function clearErrorMessages() {
    let errMsg = document.getElementById("errorTZID");
    errMsg.innerHTML = "";
    errMsg = document.getElementById("errorCarYear");
    errMsg.innerHTML = "";
    errMsg = document.getElementById("errorLicensePlate");
    errMsg.innerHTML = "";


}
function checkCarRegistration() {

    clearErrorMessages();
    licensePlateFormat = "";

    let licensePlateOK = checkLicensePlace();
    let yearOK = checkYear();
    let tzIDOK = checkTZID();
    if (licensePlateOK && yearOK && tzIDOK)
        return true;
    return false;

}
