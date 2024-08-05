setInterval("displayDate()", 1000);

function displayDate() {
    var timeNow = new Date();
    currentTime = timeNow.toLocaleTimeString();
    currentDate = timeNow.toLocaleDateString();
    document.getElementById("clock").innerHTML = currentTime;
    document.getElementById("todayDate").innerHTML = currentDate;
}



