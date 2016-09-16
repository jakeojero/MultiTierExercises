$(function () {

    $("#empbutton").click(function (e) {
        var lastname = $("#TextBoxLastname").val();
        $("#lblstatus").text("please wait...");

        ajaxCall("Get", "api/employees/" + lastname, "").done(function (data) {
            if (data.Lastname !== "not found") {
                $("#email").text(data.Email);
                $("#title").text(data.Title);
                $("#firstname").text(data.Firstname);
                $("#phone").text(data.Phoneno);
                $("#lblstatus").text("employee found");
            }
            else {
                $("#firstname").text("not found");
                $("#email").text("");
                $("#title").text("");
                $("#phone").text("");
                $("#lblstatus").text("no such employee");
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            errorRoutine(jqXHR);
        });//ajax call

    });//button click

});//jquery default function

function ajaxCall(type, url, data) {
    return $.ajax({//return the promise that `$.ajax` returns
        type: type,
        url: url,
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processData: true
    });
}

function errorRoutine(jqXHR) {//common error
    if (jqXHR.responseJson == null) {
        $("#lblstatus").text(jqXHR.responseText);
    }
    else {
        $("#lblstatus").text(jqXHR.responseJson.Message);
    }
}