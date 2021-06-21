
function order(after)
{
    $.ajax(
        '/cart/order',
        {
            method: 'POST',
        }
    ).done(() => {
        after();
    });
}


var app = new Vue({
    el: '#app',
    data: {
        cart: cart,
    },
    created: function()
    {
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
        addOneToCart: function(metaname)
        {
            addToCart(metaname, 1);
        },
        removeOneFromCart: function(metaname)
        {
            addToCart(metaname, -1);
        },
        removeFromCart: function(metaname)
        {
            RemoveFormCart(metaname);
        },
        order: function()
        {
            swal({
                title: "Вы точно хотите закозать эти товары?",
                text: this.cart.list.map(x => x.product.name).join(', '),
                icon: "warning",
                buttons: {
                    cancel: 'отмена',
                    ok: 'да'
                },
                dangerMode: true,
            })
                .then((ac) => {
                    if (ac) {
                        order(() => {
                            swal("Спасибо за покупку!", {
                                icon: "success",
                                text: "Ожидайте ответа нашего сотрудника. Подробности было отправлены вам на почту.",
                                buttons: {
                                    ok: 'да'
                                },
                            });
                        });
                    } else {
                        swal("Отмена!", {
                            buttons: {
                                ok: 'да'
                            },
                        });
                    }
                });
        }
    }
});