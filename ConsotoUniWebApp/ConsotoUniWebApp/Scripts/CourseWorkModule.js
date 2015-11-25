var CourseWorkModule = (function () {

    return {
        getCourseWorks: function (callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/CourseWorks",
                success: function (data) {
                    callback(data);
                }
            });
        },

        getCourseWorkById: function (id, callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/CourseWorks/" + id,
                success: function (data) {
                    callback(data);
                }
            });
        },

        addCourseWork: function (CourseWork, callback) {
            $.ajax({
                type: "POST",
                data: CourseWork,
                url: "http://consotoapileo.azurewebsites.net/api/CourseWorks",
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });
        },

        updateCourseWork: function (CourseWorkid, CourseWork, callback) {
            $.ajax({
                type: "PUT",
                data: CourseWork,
                url: "http://consotoapileo.azurewebsites.net/api/CourseWorks/" + CourseWorkid,
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });
        },

        deleteCourseWork: function (CourseWorkid, callback) {
            $.ajax({
                type: "DELETE",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/CourseWorks/" + CourseWorkid,
                success: function (data) {
                    callback();
                }
            });
        }

    };

}());