let url = location.pathname.split('/');
let urlParams = new URLSearchParams(window.location.search);

let getlast = function(ar)
{
    return ar[ar.length - 1];
}

let getproducts = function(category)
{
    $.ajax(
        '/api/catalog/getproducts',
        {
            dataType: 'json',
            data: { category: category, s: urlParams.get('s') },
            success: getproductsSuccess,
            error: getproductsError
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

let getproductsError = function()
{
    window.location.href = '/404';
}

getproducts(getlast(url));

ko.applyBindings(vm);
