let pagentaion = new Pagentaion(5);

function deleteCategory(id, after)
{
    $.ajax(
        '/api/admin/DeleteCategory',
        {
            method: 'DELETE',
            dataType: 'json',
            data: { id: id },
            error: () => { }
        }
    ).always(() => {
        after();
    });
}

function getCategories() {
    $.ajax(
        '/api/admin/GetCategories',
        {
            dataType: 'json',
            error: () => { }
        }
    ).done(function (data) {
        app.categories = data;
    })
}

var app = new Vue({
    el: '#app',
    data: {
        categories: [],
    },
    created: function () {
        getCategories();
    },
    methods: {
        deleteCategory: function (id, name) {
            swal({
                title: "Вы точно хотите удалить "+name+"?",
                text: "Все связаные с этой категорией товары будут удалены!",
                icon: "warning",
                buttons: {
                    cancel: 'отмена',
                    ok: 'да'
                },
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        deleteCategory(id, () => {
                            getCategories();
                            swal("Товар был удален!", {
                                icon: "success",
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
        },
    }
});