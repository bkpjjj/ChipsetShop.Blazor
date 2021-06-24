function getWishlish() {
    $.getJSON('/api/wishlist', function (data) {
        app.products = data;
    })
}

var app = new Vue({
    el: '#app',
    data: {
        products: [],
        wishlist: wishlist.list
    },
    methods:
    {
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
        removeFromWishlist: function(key)
        {
            let index = this.wishlist.indexOf(key);

            if (index > -1)
                this.wishlist.splice(index, 1);

            setCookie("wishlist", this.wishlist, { 'max-age': 3600 });
            getWishlish();
        },
    },
    created: function () {
        getWishlish();
    },
});
