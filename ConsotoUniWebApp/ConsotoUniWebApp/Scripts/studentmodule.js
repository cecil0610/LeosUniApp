var StudentModule = (function () {

    return {
        getStudents: function (callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Students",
                success: function (data) {
                    console.log(data);
                    callback(data);
                }
            });
        },

        getStudentById: function (id, callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Students" + id,
                success: function (data) {
                    console.log(data);
                    callback(data);
                }
            });
        },

        addStudent: function (student, callback) {
            $.ajax({
                type: "POST",
                data: student,
                url: "http://consotoapileo.azurewebsites.net/api/Students",
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });
        },

        updateStudent: function (studentid, student, callback) {
            $.ajax({
                type: "PUT",
                data: student,
                url: "http://consotoapileo.azurewebsites.net/api/Students" + studentid,
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });
        },

        deleteStudent: function (studentid, callback) {
            $.ajax({
                type: "DELETE",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Students" + studentid,
                success: function (data) {
                    callback();
                }
            });
        }

    };

}());