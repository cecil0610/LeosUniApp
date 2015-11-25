document.addEventListener("DOMContentLoaded", function () {
    CurrentStudentId = getUrlParameters("id", "", true);
    StudentModule.getStudentById(CurrentStudentId, function (Student) {
        var FullName = Student["FirstName"] + " " + Student["LastName"] + " : Enrolled Courses ";
        document.getElementById("StudentInfo").innerHTML = FullName;
        document.getElementById("StudentInfo").classList.remove("hidden");
    });

    EnrollmentModule.getEnrollments(function (Enrollments) {
        var TotalEnrolled = 0;
        for (i = 0; i < Enrollments.length; i++) {
            if (Enrollments[i].StudentID == CurrentStudentId) {
                TotalEnrolled++;
                var CurrentCourseId = Enrollments[i].CourseID;
                CourseModule.getCourseById(CurrentCourseId, function (Course) {
                    var CurrentRow = document.createElement('tr');
                    CurrentRow.setAttribute("data-id", CurrentCourseId);

                    var TitleCol = document.createElement('td');
                    TitleCol.innerHTML = Course["Title"];
                    CurrentRow.appendChild(TitleCol);

                    var CreditsCol = document.createElement('td');
                    CreditsCol.innerHTML = Course["Credits"];
                    CurrentRow.appendChild(CreditsCol);

                    var CompletionStatusCol = document.createElement('td');
                    CompletionStatusCol.innerHTML = Course["CompletionStatus"];
                    CurrentRow.appendChild(CompletionStatusCol);

                    document.getElementById("OutputEnrollmentList").appendChild(CurrentRow);
                });
            };
        };
        document.getElementById("TotalEnrolled").innerHTML = "The Total of Enrolled Courses: "+ TotalEnrolled;
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
