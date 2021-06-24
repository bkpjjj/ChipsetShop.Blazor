let pagentaion = new Pagentaion(5);

function deleteComment(id, after) {
    $.ajax(
        '/api/profile/DeleteComment',
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

function getComments(page, product) {
    $.ajax(
        '/api/profile/comments',
        {
            dataType: 'json',
            data: { product: product, page: page },
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
        product: "",
        comments: [],
        pages: [{ number: 1, isActive: true }],
    },
    created: function () {
        getComments(1, this.product);
    },
    methods:
    {
        changeFilter: function () {
            this.product = $("#selectProduct").val();
            getComments(this.comments.currentPage, this.product);
        },
        deleteComment: function (id) {
            swal({
                title: "Вы точно хотите удалить комментарий?",
                text: "Как только вы удалите комментарий его уже нельзя будет вернуть!",
                icon: "warning",
                buttons: {
                    cancel: 'отмена',
                    ok: 'да'
                },
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        deleteComment(id, () => {
                            getComments(this.comments.currentPage, this.product);
                            swal("Комментарий был удален!", {
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
        pageClick: function (page) {
            if (page != this.currentPage) {
                getComments(page, this.product);
            }
        },
    },
});