document.addEventListener("DOMContentLoaded", function () {
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

        });

        document.getElementById("OutputCourseList").appendChild(CurrentRow);
    };

    document.getElementById("CourseTable").classList.remove("hidden");
    document.getElementById("LoadingMessage").style.display = "none";

};