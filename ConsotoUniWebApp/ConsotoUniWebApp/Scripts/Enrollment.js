﻿document.addEventListener("DOMContentLoaded", function () {
    var StudentId = getUrlParameters("id", "", true);
    StudentModule.getStudentById(StudentId, function (Student) {
        var FullName = Student["FirstName"] + " " + Student["LastName"];
        document.getElementById("StudentInfo").innerHTML = FullName;
    });

});

function getUrlParameters(parameter, staticURL, decode) {
    var currLocation = (staticURL.length) ? staticURL : window.location.search,
        parArr = currLocation.split("?")[1].split("&"),
        returnBool = true;

    for (var i = 0; i < parArr.length; i++) {
        parr = parArr[i].split("=");
        if (parr[0] == parameter) {
            return (decode) ? decodeURIComponent(parr[1]) : parr[1];
            returnBool = true;
        } else {
            returnBool = false;
        }
    }

    if (!returnBool) return false;
};