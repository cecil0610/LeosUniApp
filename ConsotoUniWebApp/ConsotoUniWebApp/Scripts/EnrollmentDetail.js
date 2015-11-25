document.addEventListener("DOMContentLoaded", function () {
    CurrentStudentId = getUrlParameters("id", "", true);
    StudentModule.getStudentById(CurrentStudentId, function (Student) {
        var FullName = Student["FirstName"] + " " + Student["LastName"] + " : Enrolled Courses ";
        document.getElementById("StudentInfo").innerHTML = FullName;
        document.getElementById("StudentInfo").classList.remove("hidden");
    });

    document.getElementById("AddCourseLink").addEventListener('click', function (e) {
        window.location.href = 'AddCourse.html'
            + '?id=' + CurrentStudentId;
    });

    EnrollmentModule.getEnrollments(function (Enrollments) {
        var TotalEnrolled = 0;
        for (i = 0; i < Enrollments.length; i++) {
            if (parseInt(Enrollments[i].StudentID) == parseInt(CurrentStudentId)) {
                TotalEnrolled++;
                CurrentCourseId = Enrollments[i].CourseID;
                EnrollmentId = Enrollments[i].EnrollmentID;
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
                    switch (Course["CompletionStatus"]) {
                        case 0:
                            CompletionStatusCol.innerHTML = "InProgress";
                            break;
                        case 1:
                            CompletionStatusCol.innerHTML = "Completed";
                    };
                    CurrentRow.appendChild(CompletionStatusCol);

                    var EditCol = document.createElement('td');
                    var EditButton = document.createElement('button');
                    EditButton.className = "btn btn-default";
                    EditButton.innerHTML = "Edit";
                    EditButton.setAttribute("data-id", CurrentCourseId);
                    EditButton.setAttribute("data-btntype", "Edit");
                    EditCol.appendChild(EditButton);
                    CurrentRow.appendChild(EditCol);

                    EditButton.addEventListener('click', function (e) {
                        var TargetButton = e.target;
                        window.location.href = 'EditCourseWork.html'
                            + '?id=' + TargetButton.getAttribute("data-id");
                    });

                    var DeleteCol = document.createElement('td');
                    var DeleteButton = document.createElement('button');
                    DeleteButton.className = "btn btn-default";
                    DeleteButton.innerHTML = "Delete";
                    DeleteButton.setAttribute("data-id", EnrollmentId);
                    DeleteButton.setAttribute("data-btntype", "Delete");
                    DeleteCol.appendChild(DeleteButton);
                    CurrentRow.appendChild(DeleteCol);

                    DeleteButton.addEventListener('click', function (e) {
                        var TargetButton = e.target;
                        var TargetEnrollmentId = TargetButton.getAttribute("data-id");
                        EnrollmentModule.deleteEnrollment(TargetEnrollmentId, function () {
                            window.location.reload(true);
                        });

                        var CurrentEnrolled = parseInt(document.getElementById("TotalEnrolled").innerHTML) - 1;
                        document.getElementById("TotalEnrolled").innerHTML = CurrentEnrolled;
                    });

                    document.getElementById("OutputEnrollmentList").appendChild(CurrentRow);
                });
            };
        };
        document.getElementById("TotalEnrolled").innerHTML = TotalEnrolled;
        document.getElementById("EnrollmentInfo").classList.remove("hidden");
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
