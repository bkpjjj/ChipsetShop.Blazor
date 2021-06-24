let pagentaion = new Pagentaion(5);
let url = location.pathname.split('/');

function getLastURLParam() {
    return url[url.length - 1];
}

function getComments(page) {
    $.ajax(
        '/api/catalog/comments',
        {
            dataType: 'json',
            data: { product: getLastURLParam(), page: page },
            error: () => { window.location.href = '/404'; }
        }
    ).done(function (data) {
        app.comments = data;

        app.pages = [];

        pagentaion.updatePages(app.comments.currentPage, app.comments.totalPages);
        app.pages = pagentaion.pages;
    })
}

var app = new Vue({
    el: '#app',
    data: {
        wishlist: wishlist.list,
        comments: [],
        pages: [{ number: 1, isActive: true }],
        inWishlist: false,
    },
    mounted: function () {
        $("#reviewButton").click(function () {
            $("#pTab2").tab('show');
            $('#pTab2').get(0).scrollIntoView();
        });

        // Product Main img Slick
        $('#product-main-img').slick({
            infinite: true,
            centerMode: true,
            speed: 300,
            dots: false,
            arrows: false,
            fade: true,
            asNavFor: '#product-imgs',
        });

        // Product imgs Slick
        $('#product-imgs').slick({
            slidesToShow: 3,
            slidesToScroll: 1,
            arrows: true,
            centerMode: true,
            focusOnSelect: true,
            centerPadding: 0,
            vertical: true,
            asNavFor: '#product-main-img',
            responsive: [{
                breakpoint: 991,
                settings: {
                    vertical: false,
                    arrows: false,
                    dots: true,
                }
            },
            ]
        });

        // Product img zoom
        var zoomMainProduct = document.getElementById('product-main-img');
        if (zoomMainProduct) {
            $('#product-main-img .product-preview').zoom({ magnify: 1.25 });
        }
    },
    created: function () {
        getComments(1);
    },
    methods:
    {
        makeRuEndings: function (number, nominativ, genetiv, plural) {
            let titles = [nominativ, genetiv, plural];
            let cases = [2, 0, 1, 1, 1, 2];

            return titles[number % 100 > 4 && number % 100 < 20 ? 2 : cases[(number % 10 < 5) ? number % 10 : 5]];
        },
        options: function () {
            return {
                options: {
                    rewind: true,
                    width: 800,
                    perPage: 1,
                    gap: '1rem',
                },
            };
        },
        getWishlistButtonName: function () {
            let key = getLastURLParam();

            if (this.wishlist.includes(key)) {
                this.inWishlist = true;
                return "Убрать из списка желаемого";
            }
            else {
                this.inWishlist = false;
                return "Добавить в список желаемого";
            }
        },
        addToWishlist: function () {
            let key = getLastURLParam();
            if (!this.wishlist.includes(key))
                this.wishlist.push(key);
            else {
                let index = this.wishlist.indexOf(key);

                if (index > -1)
                    this.wishlist.splice(index, 1);
            }

            setCookie("wishlist", this.wishlist, { 'max-age': 3600 });
        },
        pageClick: function (page) {
            if (page != this.currentPage) {
                getComments(page);
                $('#pTab2').get(0).scrollIntoView();
            }
        },
        addToCart: function()
        {
            let value = $("#cartCount").val();
            addToCart(getLastURLParam(), value);
        }
    },
});