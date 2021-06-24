function sendData() {
    let fd = new FormData();
    fd.append("name", app.name);
    fd.append("metaname", app.key);
    fd.append('image', app.image);

    $.ajax(
        '/administration/AddCategory',
        {
            method: 'POST',
            dataType: 'json',
            data: fd,
            contentType: false,
            processData: false,
            statusCode: {
                400: (data) => { app.errorMessage = data.responseJSON; app.successMsg = false; },
                200: () => { app.successMsg = true;app.errorMessage = []; },
            },
        }
    );
}

var app = new Vue({
    el: "#app",
    data: {
        name: "",
        key: "",
        image: {},
        errorMessage: [],
        successMsg: false,
    },
    methods:
    {
        sendData: function () {
            sendData();
        },
        processFile(data) {
            this.image   = data.files[0];
        }
    }
});