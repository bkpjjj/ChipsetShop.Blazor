let url = location.pathname.split('/');

function getLastURLParam() {
    return url[url.length - 1];
}

function getComments() {
    $.ajax(
        '/api/catalog/comments',
        {
            dataType: 'json',
            data: { product: getLastURLParam() },
            error: () => { window.location.href = '/404'; }
        }
    ).done(function(data)
    {
        app.comments = data;
    })
}

var app = new Vue({
    el: '#app',
    data: {
        wishlist: wishlist.list,
        comments: [],
        inWishlist: false
    },
    mounted: function () {
        $("#reviewButton").click(function () {
            $("#pTab2").tab('show');
            $('#pTab2').get(0).scrollIntoView();
        });
    },
    created: function() 
    {
        getComments();
    },
    methods:
    {
        makeRuEndings : function(number, nominativ, genetiv, plural)
        {
            let titles = [nominativ, genetiv, plural];
            let cases = [2,0,1,1,1,2];

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
        }
    },
});
