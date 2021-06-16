let url = location.pathname.split('/');
let urlParams = new URLSearchParams(window.location.search);
let pagentaion = new Pagentaion(9);

function getLastURLParam() {
    return url[url.length - 1];
}

function updateProductData(category, page, minPrise = null, maxPrise = null, filters = []) {
    $.ajax(
        '/api/catalog/products',
        {
            dataType: 'json',
            data: { category: category, s: urlParams.get('s'), pageCount: $('#pageCount').val(), sort: $('#sortMode').val(), page: page, filters: filters, minPrise: minPrise, maxPrise: maxPrise },
            error: () => { window.location.href = '/404'; }
        }
    ).done(function (data) {
        app.products = data.products;
        app.totalPages = data.totalPages;
        app.currentPage = data.currentPage;
        app.totalProducts = data.totalProducts;
        app.productsCount = data.productsCount;
        app.minPrise = data.minPrise;
        app.maxPrise = data.maxPrise;
        app.p_maxPrise = data.maxPrise;
        app.p_maxPrise = data.maxPrise;

        if (priceSlider) {
            priceSlider.noUiSlider.updateOptions({
                range: {
                    'min': data.minPrise,
                    'max': data.maxPrise
                }
            }, true);
        }

        app.pages = [];

        pagentaion.updatePages(app.currentPage, app.totalPages);
        app.pages = pagentaion.pages;
    })
}

function updateFiltersData(category) {
    $.ajax(
        '/api/catalog/filters',
        {
            dataType: 'json',
            data: { category: category, s: urlParams.get('s') },
            error: () => { window.location.href = '/404'; }
        }
    ).done(function (data) {
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
        pages: [{ number: 1, isActive: true }],
        wishlist: wishlist.list,
        showAllFilters: false,
        collapseFilters: false,
        minPrise: 0,
        maxPrise: 0,
        p_minPrise: 0,
        p_maxPrise: 0,
    },
    methods:
    {
        makeRuEndings: function (number, nominativ, genetiv, plural) {
            let titles = [nominativ, genetiv, plural];
            let cases = [2, 0, 1, 1, 1, 2];

            return titles[number % 100 > 4 && number % 100 < 20 ? 2 : cases[(number % 10 < 5) ? number % 10 : 5]];
        },
        getPrise: function (product) {
            if (!product.inStock)
                return 'Нет в наличии';
            else if (product.discount) {
                return product.discount.prise + ' руб.';
            }
            else {
                return product.prise + ' руб.';
            }
        },
        pageClick: function (page) {
            if (page != this.currentPage) {
                updateProductData(getLastURLParam(), page, this.p_minPrise, this.p_maxPrise, this.selectedFilters);
                $(window).scrollTop(0);
            }
        },
        addToWishlist: function (key) {
            if (!this.wishlist.includes(key))
                this.wishlist.push(key);
            else {
                let index = this.wishlist.indexOf(key);

                if (index > -1)
                    this.wishlist.splice(index, 1);
            }

            setCookie("wishlist", this.wishlist, { 'max-age': 3600 });
        },
        setFilter: function (value) {
            if (value.checked)
                this.selectedFilters.push(value.value);
            else {
                let index = this.selectedFilters.indexOf(value.value);
                if (index > -1)
                    this.selectedFilters.splice(index, 1);
            }

            updateProductData(getLastURLParam(), this.currentPage, this.p_minPrise, this.p_maxPrise, this.selectedFilters);
        }
    },
    created: function () {
        /*let cookie = getCookie('wishlist');
        if(cookie != "")
            this.wishlist = cookie.split(',');*/

        this.collapseFilters = $(window).width() < 768;

        updateFiltersData(getLastURLParam());
        updateProductData(getLastURLParam(), 1);
    },
    mounted: function () {
        $(window).resize(function () {
            app.collapseFilters = $(window).width() < 768;
        });
    }
});

$("#pageCount").change(function () {
    updateProductData(getLastURLParam(), app.currentPage, app.p_minPrise, app.p_maxPrise, app.selectedFilters);
});

$("#sortMode").change(function () {
    updateProductData(getLastURLParam(), app.currentPage, app.p_minPrise, app.p_maxPrise, app.selectedFilters);
});

var priceInputMax = document.getElementById('price-max'),
    priceInputMin = document.getElementById('price-min');
var priceSlider = document.getElementById('price-slider');

priceInputMax.addEventListener('change', function () {
    updatePriceSlider($(this).parent(), this.value)
});

priceInputMin.addEventListener('change', function () {
    updatePriceSlider($(this).parent(), this.value)
});

function updatePriceSlider(elem, value) {
    if (elem.hasClass('price-min')) {
        console.log('min')
        priceSlider.noUiSlider.set([value, null]);
    } else if (elem.hasClass('price-max')) {
        console.log('max')
        priceSlider.noUiSlider.set([null, value]);
    }
}
// Price Slider
if (priceSlider) {
    noUiSlider.create(priceSlider, {
        start: [1, 999999],
        connect: true,
        step: 1,
        range: {
            'min': 1,
            'max': 999999
        }
    });

    priceSlider.noUiSlider.on('update', function (values, handle) {
        var value = values[handle];
        handle ? priceInputMax.value = value : priceInputMin.value = value;
    });

   

    priceSlider.noUiSlider.on('change', function (values, handle) {
        app.p_minPrise = parseFloat(values[0]);
        app.p_maxPrise = parseFloat(values[1]);
        updateProductData(getLastURLParam(), app.currentPage, app.p_minPrise, app.p_maxPrise, app.selectedFilters);
    });
}