document.addEventListener("DOMContentLoaded", function () {
    CurrentCourseId = getUrlParameters("id", "", true);
    CorrelationModule.getCorrelations(function (Correlations) {
        setupCourseWorkTable(Correlations);
    });
    setupForm();
});

function setupForm() {
    var form = document.forms.edit;
    form.onsubmit = function (e) {
        e.preventDefault();
        var newCourseWork = {
            CourseWorkID: CurrentCourseWorkId,
            Title: document.getElementById("TitleInput").value,
            WorkType: document.getElementById("WorkTypeInput").value,
            DueDate: document.getElementById("DueDateInput").value
        }

        CourseWorkModule.updateCourseWork(CurrentCourseWorkID, newCourseWork, function () {
            document.getElementById("UpdateForm").className = "hidden";
            window.location.href = "../index.html";
        });
    };
};

function setupCourseWorkTable(CorrelationsList) {
    for (i = 0; i < CorrelationsList.length; i++) {
        if (parseInt(CorrelationsList[i].CourseID) == parseInt(CurrentCourseId)) {
            var CurrentCourseWorkId = CorrelationsList[i].CourseWorkID;
            CourseWorkModule.getCourseWorkById(CurrentCourseWorkId, function (CourseWork) {
                var CurrentRow = document.createElement('tr');
                CurrentRow.setAttribute("data-id", CurrentCourseWorkId);

                var TitleCol = document.createElement('td');
                TitleCol.innerHTML = CourseWork["Title"];
                CurrentRow.appendChild(TitleCol);

                var WorkTypeCol = document.createElement('td');
                switch (CourseWork["WorkType"]) {
                    case 0:
                        WorkTypeCol.innerHTML = "Assignment";
                        break;
                    case 1:
                        WorkTypeCol.innerHTML = "Test";
                }
                CurrentRow.appendChild(WorkTypeCol);

                var DueDateCol = document.createElement('td');
                DueDateCol.innerHTML = CourseWork["DueDate"];
                CurrentRow.appendChild(DueDateCol);

                var UpdateCol = document.createElement('td');
                var UpdateButton = document.createElement('button');
                UpdateButton.className = "btn btn-default";
                UpdateButton.innerHTML = "Update";
                UpdateButton.setAttribute("data-id", CurrentCourseWorkId);
                UpdateButton.setAttribute("data-btntype", "Update");
                UpdateCol.appendChild(UpdateButton);
                CurrentRow.appendChild(UpdateCol);
                
                UpdateButton.addEventListener('click', function (e) {
                    document.getElementById("UpdateForm").classList.remove("hidden");
                });

                document.getElementById("OutputCourseWorkList").appendChild(CurrentRow);
            });
        };
    };
    document.getElementById("CourseWorkTable").classList.remove("hidden");
    document.getElementById("LoadingMessage").style.display = "none";
}

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