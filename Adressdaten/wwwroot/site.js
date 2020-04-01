async function getAddress(indicator) {
    $.ajax({
        type: "GET",
        url: await readInput(indicator),
        cache: false,
        success: function (data) {
            console.log(data);
            return data;
        }
    })

}

function readInput(indicator) {
    let city = document.getElementById("inputCity").value;
    let re = /^\d+/
    let postcode;

    if (indicator && !document.getElementById("inputStreet").value) {
        return "api/adressdaten/streetpostalcode=" + city.match(re)[0]
    }

    else if (indicator) {
        return "api/adressdaten/postalcode=" + city.match(re)[0] + "&street=" + document.getElementById("inputStreet").value.toLowerCase()
    }

    else if (!city) {
        return "api/adressdaten"
    }

    else if (postcode = city.match(re)) {      
        return "api/adressdaten/postcode=" + postcode[0];
    }

    else {
        return "api/adressdaten/name=" + city.toLowerCase();
    }

    
}