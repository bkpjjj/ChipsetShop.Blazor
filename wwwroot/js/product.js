$("#reviewButton").click(function () {
    $("#pTab2").tab('show');
    $('#pTab2').get(0).scrollIntoView();
});

let url = location.pathname.split('/');

function getLastURLParam() {
    return url[url.length - 1];
}


var app = new Vue({
    el: '#app',
    data: {
        wishlist: wishlist.list,
        inWishlist: false
    },
    mounted: function () {
       // main();
    },
    methods:
    {
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
