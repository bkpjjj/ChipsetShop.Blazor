let url = location.pathname.split('/');
let urlParams = new URLSearchParams(window.location.search);

let start_caret = 1;
let caret_length = 9;

function getLastURLParam()
{
    return url[url.length - 1];
}

function updateProductData(category, page)
{
    $.ajax(
        '/api/catalog/products',
        {
            dataType: 'json',
            data: { category: category, s: urlParams.get('s'), pageCount: $('#pageCount').val(), page: page },
            error: () => { window.location.href = '/404'; }
        }
    ).done(function(data)
    {
        app.products = data.products;
        app.totalPages = data.totalPages;
        app.currentPage = data.currentPage;
        app.totalProducts = data.totalProducts;
        app.productsCount = data.productsCount;
        app.pages = [];

        updateCaret();

        for (let index = start_caret; index < start_caret + caret_length; index++)
        {
            if(index <= app.totalPages)
                app.pages.push({ number: index, isActive: index === app.currentPage });        
        }
    })
}

function updateFiltersData(category)
{
    $.ajax(
        '/api/catalog/filters',
        {
            dataType: 'json',
            data: { category: category, s: urlParams.get('s') },
            error: () => { window.location.href = '/404'; }
        }
    ).done(function(data)
    {
        app.filters = data;
    })
}

var app = new Vue({
    el: '#app',
    data: {
        filters: [],
        products: [],
        totalPages: 0,
        currentPage: 0,
        totalProducts: 0,
        productsCount: 9,
        pages: [{ number : 1, isActive : true }],
        wishlist: wishlist.list
    },
    methods:
    {
        getPrise: function(product)
        {
            if(!product.inStock)
                return 'Нет в наличии';
            else if(product.discount)
            {
                return product.discount.prise + ' руб.';
            }
            else
            {
                return product.prise + ' руб.';
            }
        },
        pageClick: function(page)
        {
            if(page != this.currentPage)
            {
                updateProductData(getLastURLParam(), page);
                $(window).scrollTop(0);
            }
        },
        addToWishlist: function(key)
        {
            if(!this.wishlist.includes(key))
                this.wishlist.push(key);
            else
            {
                let index = this.wishlist.indexOf(key);

                if (index > -1)
                    this.wishlist.splice(index, 1);
            }

            setCookie("wishlist", this.wishlist, { 'max-age': 3600 });
        }
    },
    created: function() 
    {
        /*let cookie = getCookie('wishlist');
        if(cookie != "")
            this.wishlist = cookie.split(',');*/
        
        updateFiltersData(getLastURLParam());
        updateProductData(getLastURLParam(), 1);
    }
});

$("#pageCount").change(function()
{
    updateProductData(getLastURLParam(), 1);
});

function updateCaret()
{   
    let currentPage = app.currentPage;

    if(currentPage >= start_caret + caret_length - 1)
    {
        if(start_caret + caret_length < app.totalPages - caret_length)
        {
            start_caret +=  4;
        }
        else 
        {
            start_caret = app.totalPages - caret_length + 1;
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