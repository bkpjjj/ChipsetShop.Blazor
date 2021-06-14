let url = location.pathname.split('/');
let start_caret = 1;
let caret_length = 5;

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
    ).done(function(data)
    {
        app.comments = data;

        app.pages = [];

        updateCommentCaret();

        for (let index = start_caret; index < start_caret + caret_length; index++)
        {
            if(index <= app.comments.totalPages)
                app.pages.push({ number: index, isActive: index === app.comments.currentPage });        
        }
    })
}

var app = new Vue({
    el: '#app',
    data: {
        wishlist: wishlist.list,
        comments: [],
        pages: [{ number : 1, isActive : true }],
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
        getComments(1);
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
        },
        pageClick: function(page)
        {
            if(page != this.currentPage)
            {
                getComments(page);
                $('#pTab2').get(0).scrollIntoView();
            }
        },
    },
});

function updateCommentCaret()
{   
    let currentPage = app.comments.currentPage;

    if(currentPage >= start_caret + caret_length - 1)
    {
        if(start_caret + caret_length < app.comments.totalPages - caret_length)
        {
            start_caret +=  4;
        }
        else 
        {
            start_caret = app.comments.totalPages - caret_length + 1;
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