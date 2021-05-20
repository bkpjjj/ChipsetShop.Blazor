let getproducts = function(category)
{
    $.ajax(
        '/api/catalog/getproducts',
        {
            dataType: 'json',
            data: { category: 'gpu' },
            success: getproductsSuccess,
        }
    )
}

let vm = {
    products: ko.observable(),
}

let getproductsSuccess = function(data)
{
    vm.products(data);
}


getproducts();

ko.applyBindings(vm);
