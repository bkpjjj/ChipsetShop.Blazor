function sendData() {
    $.ajax(
        '/administration/editproduct',
        {
            method: 'POST',
            dataType: 'json',
            data: { id: product_id, name: app.name, metaName: app.key, prise: app.prise.toString().replace(".", ","), isNew: app.isNew, inStock: app.inStock, discount: app.discount, quontity: app.quontity, category: app.category, tags: app.tags, attributes: app.attributes },
            statusCode: {
                400: (data) => { app.errorMessage = data.responseJSON; app.successMsg = false; },
                200: () => { app.successMsg = true;app.errorMessage = []; },
            },
        }
    );
}


function getData() {
    $.ajax(
        '/administration/getproduct',
        {
            method: 'POST',
            dataType: 'json',
            data: { id: product_id },
            success: (data) => { 
                app.name = data.name;
                app.key = data.metaName;
                app.prise = data.prise;
                app.isNew = data.isNew;
                app.inStock = data.inStock;
                app.discount = data.discount;
                app.category = data.category;
                app.attributes = data.attributes;
                app.quontity = data.quontity;
                app.tags = data.tags;
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
        attributes: [{ name: "", value: "", isGeneral: false }],
        errorMessage: [],
        successMsg: false,
    },
    mounted: function () {
        getData();
    },
    methods:
    {
        addAttr: function () {
            this.attributes.push({ name: "", value: "", isGeneral: false });
        },
        removeAttr: function () {
            this.attributes.pop();
        },
        sendData: function () {
            sendData();
        },
    }
});