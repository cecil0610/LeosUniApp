var EnrollmentModule = (function () {

    return {
        getEnrollments: function (callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Enrollments",
                success: function (data) {
                    callback(data);
                }
            });
        },

        getEnrollmentById: function (id, callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Enrollments/" + id,
                success: function (data) {
                    callback(data);
                }
            });
        },

        addEnrollment: function (Enrollment, callback) {
            $.ajax({
                type: "POST",
                data: Enrollment,
                url: "http://consotoapileo.azurewebsites.net/api/Enrollments",
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });
        },

        updateEnrollment: function (Enrollmentid, Enrollment, callback) {
            $.ajax({
                type: "PUT",
                data: Enrollment,
                url: "http://consotoapileo.azurewebsites.net/api/Enrollments/" + Enrollmentid,
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });
        },

        deleteEnrollment: function (Enrollmentid, callback) {
            $.ajax({
                type: "DELETE",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Enrollments/" + Enrollmentid,
                success: function (data) {
                    callback();
                }
            });
        }

    };

}());