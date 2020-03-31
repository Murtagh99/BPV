function adresseAusgabe() {
    $.ajax({
        type: "GET",
        url: readInput(),
        cache: false,
        success: function (data) {
            console.log(data);
            return data;
        }
    })

}

function readInput() {
    let input = document.getElementById("input").value;

    let re = /^\d+/
    let postcode;

    if (!input) {
        return "api/adressdaten"
    }

    if (postcode = input.match(re)) {      
        return "api/adressdaten/postcode=" + postcode[0];
    }

    else {
        return "api/adressdaten/name=" + input.toLowerCase();
    }

    
}