var CourseModule = (function () {

    return {
        getCourses: function (callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Courses",
                success: function (data) {
                    callback(data);
                }
            });
        },

        getCourseById: function (id, callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Courses/" + id,
                async: false,
                success: function (data) {
                    callback(data);
                }
            });
        },

        addCourse: function (Course, callback) {
            $.ajax({
                type: "POST",
                data: Course,
                url: "http://consotoapileo.azurewebsites.net/api/Courses",
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });
        },

        updateCourse: function (Courseid, Course, callback) {
            $.ajax({
                type: "PUT",
                data: Course,
                url: "http://consotoapileo.azurewebsites.net/api/Courses/" + Courseid,
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });
        },

        deleteCourse: function (Courseid, callback) {
            $.ajax({
                type: "DELETE",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Courses/" + Courseid,
                success: function (data) {
                    callback();
                }
            });
        }

    };

}());