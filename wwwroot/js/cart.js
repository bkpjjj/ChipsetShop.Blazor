function addToCartOne(metaname)
{
    $.ajax(
        '/api/cart/addOne',
        {
            method: 'POST',
            dataType: 'json',
            data: { metaname: metaname },
        }
    ).always(() => {
        getCart();
    });
}

function addToCart(metaname, count)
{
    $.ajax(
        '/api/cart/add',
        {
            method: 'POST',
            dataType: 'json',
            data: { metaname: metaname, qountity: count },
        }
    ).always(() => {
        getCart();
    });
}

function RemoveFormCart(metaname)
{
    $.ajax(
        '/api/cart/remove',
        {
            method: 'POST',
            dataType: 'json',
            data: { metaname: metaname },
        }
    ).always(() => {
        getCart();
    });
}

function getCart()
{
    $.ajax(
        '/api/cart',
        {
            method: 'POST',
            dataType: 'json',
            success: (data) => {
                cart.list = data.cart;
                cart.totalPrise = data.totalPrise;
            }
        }
    );
}

var cart = new Vue({
    name: 'cart',
    el: '#cart',
    data: {
        list: [],
        totalPrise: 0
    },
    created: function()
    {
        getCart();
    },
});