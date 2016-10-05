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
                
                $("#lblstatus").addClass("alert alert-success");
                $("#lblstatus").text("Employee found!");

                $("#lblstatus").removeClass("alert-danger");

                ajaxCall("Get", "api/departments/" + data.DepartmentID, "").done(function (data) {
                    if (data.Name !== "not found") {
                        $("#departmentname").text(data.Name);
                    }
                    else {
                        $("departmentname").text("");
                    }

                }).fail(function (jqXHR, textStatus, errorThrown) {
                    errorRoutine(jqXHR);
                });

            }
            else {
                $("#firstname").text("not found");
                $("#email").text("");
                $("#title").text("");
                $("#phone").text("");
                $("#departmentname").text("");
                $("#lblstatus").addClass("alert alert-danger");
                $("#lblstatus").text("No Such Employee");
            }

        }).fail(function (jqXHR, textStatus, errorThrown) {
            errorRoutine(jqXHR);
        });//ajax call


    });//button click

    $("#empgetbutton").click(function (e) {

        $("#lblstatus").text("Obtaining server data please wait...");
        var lastname = $("#TextBoxFindLastname").val();

        ajaxCall("Get", "api/employees/" + lastname, "")
        .done(function (data) {

            if (data.Lastname !== "not found") {
                $("#TextBoxEmail").val(data.Email);
                $("#TextBoxTitle").val(data.Title);
                $("#TextBoxFirstname").val(data.Firstname);
                $("#TextBoxLastname").val(data.Lastname);
                $("#TextBoxPhone").val(data.Phoneno);
                localStorage.setItem("Id", data.Id);
                localStorage.setItem("DepartmentId", data.DepartmentID);
                localStorage.setItem("Version", data.Version);
                $("#lblstatus").text("Data Loaded");
            }
            else {
                $("#TextBoxEmail").val("");
                $("#TextBoxTitle").val("");
                $("#TextBoxFirstname").val("");
                $("#TextBoxLastname").val("");
                $("#TextBoxPhone").val("");
                localStorage.setItem("Id", "");
                localStorage.setItem("DepartmentId", "");
                localStorage.setItem("Version", "");
                $("#lblstatus").text("Data not Found");

            }

        }).fail(function (jqXHR, textStatus, errorThrown) {
            errorRoutine(jqXHR);
        });

        $("#theModal").modal("show");
        return false;

    });

    $("#empupdbutton").click(function (e) {

        emp = new Object();
        emp.Title = $("#TextBoxTitle").val();
        emp.Email = $("#TextBoxEmail").val();
        emp.Firstname = $("#TextBoxFirstname").val();
        emp.Lastname = $("#TextBoxLastname").val();
        emp.Phoneno = $("#TextBoxPhone").val();
        emp.Id = localStorage.getItem("Id");
        emp.DepartmentId = localStorage.getItem("DepartmentId");
        emp.Version = localStorage.getItem("Version");

        ajaxCall("Put", "api/employees", emp).done(function (data) {
            $("#lblstatus").text(data);
        })
        .fail(function (jqXhr, textStatus, errorThrown) {
            errorRoutine(jqXhr);
        });

        return false;
    });

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