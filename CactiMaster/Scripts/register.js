//const { ellipsis } = require("modernizr");

function hasBadChars(text, elementError) {
    let badChar = "0123456789~!@#$%^&*()_+=|[]{};:?><,.` ";

    for (let i = 0; i < badChar.length; i++) {
        if (text.indexOf(badChar[i]) != -1) {
            elementError.innerHTML = "Invalid character " + badChar[i] + " in field";
            return true;
        }
    }
    if (text.indexOf("'") != -1) {
        elementError.innerHTML = "Single quote not allowed in field";
        return true;

    }
    if (text.indexOf('"') != -1) {
        elementError.innerHTML = "Double quote not allowed";
        return true;
    }
    return false;
}

function hasHebrewLetter(text, elementError) {
    for (let i = 0; i < text.length; i++) {
        if (text[i] >= 'א' && text[i] <= 'ת') {
            elementError.innerHTML = "All letters must be English letters";
            return true;
        }
    }
    return false;
}

function hasNonEnglishLetter(text, elementError) {
    let lowerText = text.toLowerCase();
    for (let i = 0; i < lowerText.length; i++) {
        if (lowerText[i] < 'a' || lowerText[i] > 'z') {
            elementError.innerHTML = "All letters must be English letters";
            return true;
        }
    }
    return false;
}


function checkName(name, elementError)
{
    //fname = fname.trim();

    /* because of trim we no longer need this test
    if (name.length == "") {
        document.getElementById(elementError).innerHTML = "Field cannot be empty";
        return false;
    }
    */
    if (name.length < 2) {
        document.getElementById(elementError).innerHTML = "Field must have at least 2 letters";
        return false;
    }

    if (hasBadChars(name, document.getElementById(elementError))) {
        return false;
    }

    //if (hasHebrewLetter(name, document.getElementById(elementError))) {
    if (hasNonEnglishLetter(name, document.getElementById(elementError))) {
        return false;
    }

    return true;

}

function checkUserName(uname) {
    return checkName(uname, "erroruname");
}

function checkFirstName(fname) {

    return checkName(fname, "errorfname");

    //fname = fname.trim();

    /* because of trim we no longer need this test
    if (fname.length == "") {
        document.getElementById("errorfname").innerHTML = "Field cannot be empty";
        return false;
    }
    */
    if (fname.length < 2) {
        document.getElementById("errorfname").innerHTML = "First name must have at least 2 letters";
        return false;
    }

    if (hasBadChars(fname, document.getElementById("errorfname"))) {
        return false;
    }

    //if (hasHebrewLetter(fname, document.getElementById("errorfname"))) {
    if (hasNonEnglishLetter(fname, document.getElementById("errorfname"))) {
        return false;
    }

    return true;
}

function checkLastName(lname) {
    return checkName(lname, "errorlname");

    //lname = lname.trim();
    /*
    if (lname == "") {
        document.getElementById("errorlname").innerHTML = " שדה השם לא יכול להיות ריק";
        return false;
    }
    */
    if (lname.length < 2) {
        document.getElementById("errorlname").innerHTML = "השדה חייב להיות באורך של 2 תווים לפחות";
        return false;
    }

    if (hasBadChars(lname, document.getElementById("errorlname"))) {
        return false;
    }

    //if (hasHebrewLetter(lname, document.getElementById("errorlname"))) {
    if (hasNonEnglishLetter(lname, document.getElementById("errorlname"))) {
        return false;
    }

    return true;
}

function checkEmail(umail) {
    if (umail == "") {
        document.getElementById("errormail").innerHTML = "Email cannot be empty";
        return false;
    }
    if (umail.indexOf('@') == -1) {
        document.getElementById("errormail").innerHTML = "Email address must include @";
        return false;
    }
    if (umail.indexOf('@') != umail.lastIndexOf('@')) {
        document.getElementById("errormail").innerHTML = "Email address must include only one @";
        return false;
    }
    if (umail.indexOf('@') == 0 || umail.indexOf('@') == umail.length-1) {
        document.getElementById("errormail").innerHTML = "@ cannot be first or last";
        return false;
    }
    //if (hasHebrewLetter(umail, document.getElementById("errormail"))) {
    if (hasnonEnglishLetter(umail, document.getElementById("errormail"))) {
        return false;
    }


    if ((umail.split("@").length == 2) &&
        (umail.indexOf("@") != -1) &&
        (umail.indexOf(".") != 0) &&
        (umail.lastIndexOf(".") != umail.length - 1) &&
        (umail.length >= 5 && umail.length <= 30)) {
        return true;
    }
    else {
        document.getElementById("errormail").innerHTML = "Invalid email address, must include @ and a dot (.)";
        return false;
    }
}

function checkPassword(password) {
    if (password.length < 6) {
        document.getElementById("errorpassword").innerHTML = "password must be have at least 6 characters";
        return false;
    }
    return true;
}

function checkVerifyPassword(password, verifypassword) {
    if (password != verifypassword) {
        document.getElementById("errorverifypassword").innerHTML = "Passwords do not match";
        return false;
    }
    return true;
}

function checkAge(age) {
    if (isNaN(age)) {
        document.getElementById("erroryearborn").innerHTML = "Please select a year";
        return false;
    }
    return true;
}

// https://www.upnext.co.il/articles/israeli-id-numer-validation/#:~:text=%D7%A9%D7%9C%D7%91%201%3A%20%D7%A0%D7%9B%D7%AA%D7%95%D7%91%20%D7%90%D7%AA%20%D7%A8%D7%A6%D7%A3%20%D7%94%D7%9E%D7%A1%D7%A4%D7%A8%D7%99%D7%9D%20%D7%A9%D7%9C%20%D7%94%D7%97%D7%9C%D7%A7,%D7%99%D7%94%D7%A4%D7%95%D7%9A%20%D7%9C%D7%94%D7%99%D7%95%D7%AA%20%D7%A1%D7%9B%D7%95%D7%9D%20%D7%A9%D7%AA%D7%99%20%D7%94%D7%A1%D7%A4%D7%A8%D7%95%D7%AA%20%D7%A9%D7%9E%D7%A8%D7%9B%D7%99%D7%91%D7%95%D7%AA%20%D7%90%D7%95%D7%AA%D7%95%3A%201%2C4%2C3%2C8%2C5%2C3%2C7%2C7
function checkTZ(tzid) {
    var index = 8;
    var chkdigit = Number(tzid[index]);
    var mul = 2;
    var sum = 0;
    var tmp = 0;
    index--;

    while (index >= 0) {

        tmp = mul * Number(tzid[index]);
        if (tmp >= 10)
            sum = sum + tmp % 10 + Math.floor(tmp / 10);
        else
            sum = sum + mul * Number(tzid[index]);

        if (mul == 2)
            mul = 1;
        else
            mul = 2;
        index--;
    }
    if (10 - sum % 10 == chkdigit)
        return true;

    return false;
}

function isOnlyDigits(tzid) {

    if (isNaN(tzid))
        return false;
    return true;
    /**
        numchar = "0123456789";
        for (var i = 0; i < tzid.length; i++)
        if (numchar.indexOf(tzid[i]) == -1)
            return false;
    **/
}

function checkTZId(tzid) {
    //tzid = tzid.trim();

    if (isNaN(tzid)) {
        document.getElementById("uiderror").innerHTML = "Only digits allowed";
        return false;
    }

    if (tzid.length != 9) {
        document.getElementById("uiderror").innerHTML = "ID must have exactly 9 digits";
        return false;
    }
    /*
    if (tzid == "") {
        document.getElementById("uiderror").innerHTML = "שדה תעודת זהות אינו יכול להיות ריק";
        return false;
    }
    */
    if (!isOnlyDigits(tzid)) {
        document.getElementById("uiderror").innerHTML = "ID must be digits only";
        return false;
    }

    if (checkTZ(tzid) == false) {
        document.getElementById("uiderror").innerHTML = "מספר תעודת זהות אינו תקין אנא הכנס שוב";
        return false;
    }
    return true;
}

function checkPhone(prefix, phone) {
    if (isNaN(prefix)) {
        document.getElementById("errorphone").innerHTML = "Please select prefix";
        return false;
    }
    if (isNaN(phone)) {
        document.getElementById("errorphone").innerHTML = "Phone number must be all digits";
        return false;
    }
    if (phone.length != 7) {
        document.getElementById("errorphone").innerHTML = "Phone number must be 7 digits";
        return false;
    }
    return true;

}

function validateForm() {
    // קריאת ערכי שדות הטופס הנבחרים
    resetForm();

    let uname = regform.uname.value.trim();
    let fname = regform.fname.value.trim();
    let lname = regform.lname.value.trim();
    let umail = regform.email.value.trim();
    let password = regform.password.value.trim();
    let verifypassword = regform.verifypassword.value.trim();
    let age = regform.yearborn.value.trim();
    let tzid = regform.tzid.value.trim();
    let prefix = regform.prefix.value.trim();
    let phone = regform.phone.value.trim();

    // ביצוע בדיקות תקינות על השדות השונים
    let check0 = checkUserName(uname);
    let check1 = checkFirstName(fname);
    let check2 = checkLastName(lname);
    let check3 = checkEmail(umail);
    let check4 = checkPassword(password);
    let check4_1 = checkVerifyPassword(password, verifypassword);
    let check5 = checkAge(age);
    let check6 = checkTZId(tzid);
    let check7 = checkPhone(prefix, phone)

    // אם כל הבדיקות תקינות החזר אמת אחרת שקר
    if (check0 && check1 && check2 && check3 && check4 && check4_1 && check5 && check6 && check7) 
        return true;

    return false;
}

function resetForm() {
    clearErrorsMessages();
}

function clearErrorsMessages() {
    document.getElementById("erroruname").innerHTML = "";
    document.getElementById("errorfname").innerHTML = "";
    document.getElementById("errorlname").innerHTML = "";
    document.getElementById("uiderror").innerHTML = "";
    document.getElementById("errormail").innerHTML = "";
    document.getElementById("errorpassword").innerHTML = "";
    document.getElementById("errorverifypassword").innerHTML = "";
    document.getElementById("erroryearborn").innerHTML = "";
    document.getElementById("errorphone").innerHTML = "";
}




/*********

function checkForm() {
 
    var uName = document.getElementById("uName").value;
    if (uName.length < 3) {
        var element = document.getElementById("errorUName");
        element.value = "User name must be longer than 2";
        element.style.display = "inline";
        return false;
    }
    else {
        element.value = "";
        document.getElementById("errorUName").style.display = "none";
        return true;
    }
}

 *********/