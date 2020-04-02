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
    let street = document.getElementById("inputStreet").value;
    let matching = city.match(/^\d+/);
    let url = "api/adressdaten";

    if (indicator && matching[0].length === 5) {
        url = url.concat("/Street/postcode=" + matching[0]);
        if (street) {
            return url.concat("/street=" + street.toLowerCase());
        }
    } else if (!indicator) {
        url = url.concat("/City/");
        if (matching) {
            return url.concat("postcode=" + matching[0])
        } else if (city) {
            return url.concat("name=" + city.toLowerCase())
        }
    }
    return url;
}