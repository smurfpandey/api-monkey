
var MonkeyApi = function () {
    var editor;
    function _initiateJsonEditor() {

        // create the editor
        var options = {
            "mode": "code",
            "indentation": 2
        };
        var container = document.getElementById("jsoneditor");
        editor = new JSONEditor(container, options);
    }

    function _bindEvent() {

        $('#btnBananaSubmit').on('click', function () {
            //validate json
            try {
                //on json valid
                var json = editor.get();
                var stringJson = JSON.stringify(json);
                $.ajax({
                    url: '/banana',
                    type: 'PUT',
                    contentType: "application/json; charset=utf-8",
                    data: stringJson,
                    success: function (data, textStatus, request) {
                        var bananaLocation = request.getResponseHeader('Location');

                        $('.monkey-banana-loc').append(bananaLocation);

                        $('.banana-loc-div-container').removeClass('hide');

                        $('.editor-container').addClass('hide');
                    },
                    error: function () {
                        $('.monkey-banana-loc').append('Opps! Some error in posting your json. Please try again');

                        $('.banana-loc-div-container').removeClass('hide');

                        $('.editor-container').addClass('hide');
                    }
                });
            }
            catch (e) {
                //on json invalid
                alert("invalid json");
            }
        });

        $('#btnAnotherBanana').on('click', function () {
            $('#jsoneditor').html('');
            _initiateJsonEditor();

            $('.banana-loc-div-container').addClass('hide');

            $('.editor-container').removeClass('hide');
        });
    }

    return {
        init: function () {
            _initiateJsonEditor();
            _bindEvent();
        }
    }
}

var MonkeyGetApi = function () {

    var editor;
    function _initiateJsonEditor() {

        // create the editor
        var options = {
            "mode": "code",
            "indentation": 2
        };
        var container = document.getElementById("jsoneditor");
        editor = new JSONEditor(container, options);
    }

    function _bindEvent() {

        $('#getBanana').on('click', function () {
            //validate json
            try {
                var urlSeg = $('#urlSeg').val();
                //var qwe = url.segment("2");
                var pathname = urlSeg.split("/");
                var filename = pathname[pathname.length - 1];
                $.ajax({

                    url: urlSeg,

                    type: 'GET',
                    contentType: "application/json; charset=utf-8",
                    data: { bananaId: filename },
                    success: function (respData) {      
                            editor.set(respData);
                    },
                    error: function (xhr, textStatus) {
                        if (xhr.status === 404) {
                            alert("Opps! No banana found in the specified location!");
                        }
                    }
                });
            }
            catch (e) {
                //on json invalid
                alert("invalid json");
            }
        });


    };

    return {
        init: function () {
            _initiateJsonEditor();
            _bindEvent();
        }
    }
}