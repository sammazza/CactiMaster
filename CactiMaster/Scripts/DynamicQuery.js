function filter1Click() {
    if (document.getElementById("filter1").value == "gender") {
        document.getElementById("filter1Text").innerHTML =
            "<input type='radio' name='value1' value='Male' checked='checked'/>Male" +
            "<input type='radio' name='value1' value='Female' />Female";
    }
    else if (document.getElementById("filter1").value == "yearBorn" ||
        document.getElementById("filter1").value == "fromYear") {
        var yearStr = "<select name='value1'> " +
            "<option value='0'>select year</option>";
        var currentYear = new Date().getFullYear();
        var fromYear = currentYear - 40;
        var toYear = currentYear - 10;
        for (var i = fromYear; i < toYear; i++) {
            yearStr += `<option value='${i}'> ${i} </option>`;
        }
        document.getElementById("filter1Text").innerHTML = yearStr + "</select>";
    }
    else if (document.getElementById("filter1").value == "prefix") {
        var prefixStr = "<select name='value1'>";
        var prefixes = ["050", "052", "053", "054", "055", "056", "058", "059", "02", "03", "04", "07", "08", "09"]
        prefixes.forEach((p) => prefixStr += `<option value='${p}'>${p}</option>`);

        prefixStr += "</select>";
        document.getElementById("filter1Text").innerHTML = prefixStr;
    }
    else if (document.getElementById("filter1").value == "hobby") {
        var hobbyStr = "<select name='value1'>";
        hobbyStr += "<option value='1'>Sailing</option>";
        hobbyStr += "<option value='2'>Biking</option>";
        hobbyStr += "<option value='3'>Cooking</option>";
        hobbyStr += "<option value='4'>Movies</option>";
        hobbyStr += "</select>";
        document.getElementById("filter1Text").innerHTML = hobbyStr;
    }
    else
        document.getElementById("filter1Text").innerHTML = "<input type='text' name='value1' />"

}


function filter2Click() {
    if (document.getElementById("filter2").value == "gender") {
        document.getElementById("filter2Text").innerHTML =
            "<input type='radio' name='value2' value='Male' checked='checked'/>Male" +
            "<input type='radio' name='value2' value='Female' />Female";
    }
    else if (document.getElementById("filter2").value == "yearBorn" ||
        document.getElementById("filter2").value == "toYear") {
        var yearStr = "<select name='value2'> " +
            "<option value='0'>select year</option>";
        var currentYear = new Date().getFullYear();
        var fromYear = currentYear - 40;
        var toYear = currentYear - 10;
        for (var i = fromYear; i < toYear; i++) {
            yearStr += `<option value='${i}'> ${i} </option>`;
        }
        document.getElementById("filter2Text").innerHTML = yearStr + "</select>";
    }
    else if (document.getElementById("filter2").value == "prefix") {
        var prefixStr = "<select name='value2'>";

        var prefixes = ["050", "052", "053", "054", "055", "056", "058", "059", "02", "03", "04", "07", "08", "09"]
        prefixes.forEach((p) => prefixStr += `<option value='${p}'>${p}</option>`);

        prefixStr += "</select>";
        document.getElementById("filter2Text").innerHTML = prefixStr;
    }
    else if (document.getElementById("filter2").value == "hobby") {
        var hobbyStr = "<select name='value2'>";
        hobbyStr += "<option value='1'>Sailing</option>";
        hobbyStr += "<option value='2'>Biking</option>";
        hobbyStr += "<option value='3'>Cooking</option>";
        hobbyStr += "<option value='4'>Movies</option>";
        hobbyStr += "</select>";
        document.getElementById("filter2Text").innerHTML = hobbyStr;
    }
    else // all other text fields
        document.getElementById("filter2Text").innerHTML = "<input type='text' name='value2' />"
}
