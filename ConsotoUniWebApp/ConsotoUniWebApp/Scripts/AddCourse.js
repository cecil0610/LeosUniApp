document.addEventListener("DOMContentLoaded", function () {
    CurrentStudentId = getUrlParameters("id", "", true);
    CourseModule.getCourses(function (Courses) {
        setupCoursesTable(Courses);
    });
});

function setupCoursesTable(CoursesList) {
    for (i = 0; i < CoursesList.length; i++) {
        var CurrentRow = document.createElement('tr');
        CurrentRow.setAttribute("data-id", CoursesList[i].CourseID);

        var TitleCol = document.createElement('td');
        TitleCol.innerHTML = CoursesList[i].Title;
        CurrentRow.appendChild(TitleCol);

        var CreditsCol = document.createElement('td');
        CreditsCol.innerHTML = CoursesList[i].Credits;
        CurrentRow.appendChild(CreditsCol);

        var AddCol = document.createElement('td');
        var AddButton = document.createElement('button');
        AddButton.className = "btn btn-default";
        AddButton.innerHTML = "Add";
        AddButton.setAttribute("data-id", CoursesList[i].CourseID);
        AddButton.setAttribute("data-btntype", "Add");
        AddCol.appendChild(AddButton);
        CurrentRow.appendChild(AddCol);

        AddButton.addEventListener('click', function (e) {
            var TargetButton = e.target;
            var CurrentCourseId = TargetButton.getAttribute("data-id");
            var newEnrollment = {
                CourseID: CurrentCourseId,
                StudentID: CurrentStudentId
            };

            EnrollmentModule.getEnrollments(function (Enrollments) {
                flag1 = true;
                for (i = 0; i < Enrollments.length; i++) {
                    if (flag1) {
                        flag2 = false,
                        flag3 = false;
                        if (parseInt(Enrollments[i].StudentID) == parseInt(newEnrollment.StudentID)) {
                            flag2 = true;
                        };
                        if (parseInt(Enrollments[i].CourseID) == parseInt(newEnrollment.CourseID)) {
                            flag3 = true;
                        };
                        if (flag2 && flag3) {
                            flag1 = false;
                        }
                    };
                };

                if (flag1) {
                    EnrollmentModule.addEnrollment(newEnrollment, function () {
                        alert("You are enrolled!");
                    });
                } else {
                    alert("You are already enrolled in this Course!");
                };
            });

        });

        document.getElementById("OutputCourseList").appendChild(CurrentRow);
    };

    document.getElementById("CourseTable").classList.remove("hidden");
    document.getElementById("LoadingMessage").style.display = "none";

};

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