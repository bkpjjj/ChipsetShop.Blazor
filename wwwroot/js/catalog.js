let url = location.pathname.split('/');
let urlParams = new URLSearchParams(window.location.search);

let start_caret = 1;
let caret_length = 9;

function getLastURLParam()
{
    return url[url.length - 1];
}

function updateProductData(category, page, filters = [])
{
    $.ajax(
        '/api/catalog/products',
        {
            dataType: 'json',
            data: { category: category, s: urlParams.get('s'), pageCount: $('#pageCount').val(),sort: $('#sortMode').val(), page: page, filters: filters },
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
        selectedFilters: [],
        products: [],
        totalPages: 0,
        currentPage: 0,
        totalProducts: 0,
        productsCount: 9,
        pages: [{ number : 1, isActive : true }],
        wishlist: wishlist.list,
        showAllFilters: false,
        collapseFilters: false,
    },
    methods:
    {
        makeRuEndings : function(number, nominativ, genetiv, plural)
        {
            let titles = [nominativ, genetiv, plural];
            let cases = [2,0,1,1,1,2];

            return titles[number % 100 > 4 && number % 100 < 20 ? 2 : cases[(number % 10 < 5) ? number % 10 : 5]];
        },
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
        },
        setFilter: function(value)
        {
            if(value.checked)
                this.selectedFilters.push(value.value);
            else
            {
                let index = this.selectedFilters.indexOf(value.value);
                if (index > -1)
                    this.selectedFilters.splice(index, 1);
            }   

            updateProductData(getLastURLParam(), this.currentPage, this.selectedFilters);
        }
    },
    created: function() 
    {
        /*let cookie = getCookie('wishlist');
        if(cookie != "")
            this.wishlist = cookie.split(',');*/
        
        this.collapseFilters = $(window).width() < 768;
        
        updateFiltersData(getLastURLParam());
        updateProductData(getLastURLParam(), 1);
    },
    mounted: function()
    {
        $( window ).resize(function() {
            app.collapseFilters = $(window).width() < 768;
        });
    }
});

$("#pageCount").change(function()
{
    updateProductData(getLastURLParam(), 1);
});

$("#sortMode").change(function()
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