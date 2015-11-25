var CorrelationModule = (function () {

    return {
        getCorrelations: function (callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Correlations",
                success: function (data) {
                    callback(data);
                }
            });
        },

        getCorrelationById: function (id, callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Correlations/" + id,
                success: function (data) {
                    callback(data);
                }
            });
        },

        addCorrelation: function (Correlation, callback) {
            $.ajax({
                type: "POST",
                data: Correlation,
                url: "http://consotoapileo.azurewebsites.net/api/Correlations",
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });
        },

        updateCorrelation: function (Correlationid, Correlation, callback) {
            $.ajax({
                type: "PUT",
                data: Correlation,
                url: "http://consotoapileo.azurewebsites.net/api/Correlations/" + Correlationid,
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });
        },

        deleteCorrelation: function (Correlationid, callback) {
            $.ajax({
                type: "DELETE",
                dataType: "json",
                url: "http://consotoapileo.azurewebsites.net/api/Correlations/" + Correlationid,
                success: function (data) {
                    callback();
                }
            });
        }

    };

}());