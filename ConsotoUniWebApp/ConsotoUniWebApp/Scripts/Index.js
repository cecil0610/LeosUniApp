document.addEventListener("DOMContentLoaded", function () {
    StudentModule.getStudents(function (Students) {
        setupStudentsTable(Students);
    });

    function setupStudentsTable(StudentsList) {
        for (i = 0; i < StudentsList.length; i++) {
            var CurrentRow = document.createElement('tr');
            CurrentRow.setAttribute("data-id", StudentsList[i].ID);

            var LastNameCol = document.createElement('td');
            LastNameCol.innerHTML = StudentsList[i].LastName;
            CurrentRow.appendChild(LastNameCol);

            var FirstNameCol = document.createElement('td');
            FirstNameCol.innerHTML = StudentsList[i].FirstName;
            CurrentRow.appendChild(FirstNameCol);

            var EnrollmentDateCol = document.createElement('td');
            EnrollmentDateCol.innerHTML = StudentsList[i].EnrollmentDate;
            CurrentRow.appendChild(EnrollmentDateCol);

            var ManageCol = document.createElement('td');
            var ManageButton = document.createElement('button');
            ManageButton.className = "btn btn-default";
            ManageButton.innerHTML = "Manage";
            ManageButton.setAttribute("data-id", StudentsList[i].ID);
            ManageButton.setAttribute("data-btntype", "Manage");
            ManageCol.appendChild(ManageButton);
            CurrentRow.appendChild(ManageCol);

            ManageButton.addEventListener('click', function (e) {
                var TargetButton = e.target;
                window.location.href = '/Pages/Enrollment.html'
                    + '?id=' + TargetButton.getAttribute("data-id");
            });

            document.getElementById("OutputStudentList").appendChild(CurrentRow);
        };

        document.getElementById("StudentTable").classList.remove("hidden");
        document.getElementById("LoadingMessage").style.display = "none";
    };
});
