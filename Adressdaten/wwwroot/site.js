function getAddress() {
    return new Promise(resolve => {
        $.ajax({
            type: "GET",
            url: readInput(),
            cache: false,
            success: function (data) {
                console.log(data);
                resolve(data);
            }
        })
    })
}

function readInput() {
    //let city = document.getElementById("inputCity").value;
    //let street = document.getElementById("inputStreet").value;
    //let matching = city.match(/^\d+/);
    return "api/mitglieder/Mitglied";

    //if (indicator && matching[0].length === 5) {
    //    url = url.concat("/Street/postcode=" + matching[0]);
    //    if (street) {
    //        url = url.concat("/street=" + street.toLowerCase());
    //    }
    //} else if (!indicator) {
    //    url = url.concat("/City");
    //    if (matching) {
    //        url = url.concat("/postcode=" + matching[0])
    //    } else if (city) {
    //        url = url.concat("/name=" + city.toLowerCase())
    //    }
    //} else {
    //    url = url.concat("/norequest")
    //}
    //return url;
}

async function getMitglieder() {
    let mitglieder = await getAddress();
    let div = document.getElementById("mitgliederContainer");
    mitglieder.forEach(mitglied => {
        let p = document.createElement("p");
        let text = document.createTextNode(mitglied.vorname + " " + mitglied.nachname);
        p.appendChild(text);
        div.appendChild(p);
    });
}