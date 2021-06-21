function sendData() {
    let fd = new FormData();
    fd.append("name", app.name);
    fd.append("metaname", app.key);
    fd.append("prise", app.prise.toString().replace(".", ","));
    fd.append("isNew", app.isNew);
    fd.append("inStock", app.inStock);
    fd.append("discount", app.discount);
    fd.append("quontity", app.quontity);
    fd.append("category", app.category);
    fd.append("tags", app.tags);

    for (let index = 0; index < app.attributes.length; index++) {
        let attr = app.attributes[index];
        fd.append("attributes["+index+"][name]", attr.name);
        fd.append("attributes["+index+"][value]", attr.value);
        fd.append("attributes["+index+"][isGeneral]", attr.general);
    }

    for (var i = 0; i < app.images.length; i++) {
        let file = app.images[i];

        fd.append('images', file);
    }


    $.ajax(
        '/administration/addproduct',
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
        prise: 0,
        isNew: false,
        inStock: false,
        discount: 0,
        quontity: 0,
        category: "",
        tags: "",
        attributes: [{ name: "", value: "", general: false }],
        images: [{}],
        errorMessage: [],
        successMsg: false,
    },
    mounted: function () {
        this.category = $("#category_select option:first").val();
    },
    methods:
    {
        addAttr: function () {
            this.attributes.push({ name: "", value: "", general: false });
        },
        removeAttr: function () {
            this.attributes.pop();
        },
        addImg: function () {
            this.images.push({});
        },
        removeImg: function () {
            this.images.pop();
        },
        sendData: function () {
            sendData();
        },
        processFile(data) {
            this.images = [];

            this.images = data.files;
        }
    }
});