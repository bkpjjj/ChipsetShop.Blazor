let url = location.pathname.split('/');
let urlParams = new URLSearchParams(window.location.search);

let makeRuEndings = function(number, nominativ, genetiv, plural)
{
    let titles = [nominativ, genetiv, plural];
    let cases = [2,0,1,1,1,2];

    return titles[number % 100 > 4 && number % 100 < 20 ? 2 : cases[(number % 10 < 5) ? number % 10 : 5]];
}

let getlast = function(ar)
{
    return ar[ar.length - 1];
}

let getproducts = function(category, page)
{
    $.ajax(
        '/api/catalog/getproducts',
        {
            dataType: 'json',
            data: { category: category, s: urlParams.get('s'), pageCount: $('#pageCount').val(), page: page },
            success: getproductsSuccess,
            error: getproductsError
        }
    )
}

let vm = {
    products: ko.observable(),
    totalpages : ko.observable(),
    currentpage : ko.observable(),
    totalproducts : ko.observable(),
    productscount : ko.observable(),
    pages : ko.observableArray([ ]),
    addToWishlist: function()
    {
        if(wishlist.includes(this.key))
            removeFromWishlist(this.key);
        else
            addToWishlist(this.key);
            
        getWishlist();

        getproducts(getlast(url), vm.currentpage());
    },
    showWishlistButton: function(data)
    {
        if(wishlist.includes(data))
            return { color : 'red' };
        return {};
    }
}

let getproductsSuccess = function(data)
{
    vm.products(data.products);
    vm.totalpages(data.totalPages);
    vm.currentpage(data.currentPage);
    vm.totalproducts(data.totalProducts);
    vm.productscount(data.productsCount);
    vm.pages([]);

    updateCaret();

    for (let index = start_caret; index < start_caret + caret_length; index++)
    {
        if(index <= vm.totalpages())
        vm.pages.push({ number: index, isactive: index === vm.currentpage() });        
    }

    //vm.pages.push({ number: counter + chunk, isactive: counter + chunk === vm.currentpage() });
    $("[id*=pageButton]").click(function()
    {
        let page = parseInt($(this).html());

        if(page !== vm.currentpage())
        {
            getproducts(getlast(url), page);
            $(window).scrollTop(0);
        }
    });
}

let getproductsError = function()
{
    window.location.href = '/404';
}


getproducts(getlast(url), 1);

ko.applyBindings(vm);

$("#pageCount").change(function()
{
    getproducts(getlast(url), 1);
});


let start_caret = 1;
let caret_length = 9;

function updateCaret()
{   
    let currentPage = vm.currentpage();

    if(currentPage >= start_caret + caret_length - 1)
    {
        if(start_caret + caret_length < vm.totalpages() - caret_length)
        {
            start_caret +=  4;
        }
        else 
        {
            start_caret = vm.totalpages() - caret_length + 1;
        }
    }
    

    if(currentPage <= start_caret)
    {
        if(start_caret - caret_length > 1)
        {
            start_caret -=  4;
        }
        else
        {
            start_caret = 1;
        }
    }
}