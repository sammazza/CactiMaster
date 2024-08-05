function filter1Click() {
    if (document.getElementById("filter1").value == "Brand") {
        var brandStr = "<select name='value1'>";
        var brands = ["VW", "Toyota", "Renaut", "Suzuki"]
        for (let i = 0; i < brands.length; i++)
            brandStr += `<option value='${i + 1}'>${brands[i]}</option>`;

        brandStr += "</select>";
        document.getElementById("filter1Text").innerHTML = brandStr;
    }
    else if (document.getElementById("filter1").value == "YearOnRoad" ||
        document.getElementById("filter1").value == "fromYear") {
        var yearStr = "<select name='value1'> " +
            "<option value='0'>select year</option>";
        var currentYear = new Date().getFullYear();
        var fromYear = currentYear - 7;
        var toYear = currentYear;
        for (var i = fromYear; i < toYear; i++) {
            yearStr += `<option value='${i}'> ${i} </option>`;
        }
        document.getElementById("filter1Text").innerHTML = yearStr + "</select>";
    }
    else if (document.getElementById("filter1").value == "Type") {
        document.getElementById("filter1Text").innerHTML =
            "<input type='radio' name='value1' value='Private' checked='checked'/>Private" +
            "<input type='radio' name='value1' value='Commercial' />Commercial";
    }
    else /* Model, DailyRate, Doors */
        document.getElementById("filter1Text").innerHTML = "<input type='text' name='value1' />"
}


function filter2Click() {
    if (document.getElementById("filter2").value == "Brand") {
        var brandStr = "<select name='value2'>";
        var brands = ["VW", "Toyota", "Renaut", "Suzuki"]
        for (let i = 0; i < brands.length; i++)
            brandStr += `<option value='${i + 1}'>${brands[i]}</option>`;

        brandStr += "</select>";
        document.getElementById("filter2Text").innerHTML = brandStr;
    }
    else if (document.getElementById("filter2").value == "YearOnRoad" ||
        document.getElementById("filter2").value == "fromYear") {
        var yearStr = "<select name='value2'> " +
            "<option value='0'>select year</option>";
        var currentYear = new Date().getFullYear();
        var fromYear = currentYear - 7;
        var toYear = currentYear;
        for (var i = fromYear; i < toYear; i++) {
            yearStr += `<option value='${i}'> ${i} </option>`;
        }
        document.getElementById("filter2Text").innerHTML = yearStr + "</select>";
    }
    else if (document.getElementById("filter2").value == "Type") {
        document.getElementById("filter2Text").innerHTML =
            "<input type='radio' name='value2' value='Private' checked='checked'/>Private" +
            "<input type='radio' name='value2' value='Commercial' />Commercial";
    }
    else /* Model, DailyRate, Doors */
        document.getElementById("filter2Text").innerHTML = "<input type='text' name='value2' />"
}
