$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "api/adressdaten/plz=4&ort=tem",
        cache: false,
        success: function (data) {
            console.log(data);
            return data;
        }
    })
})