let pagentaion = new Pagentaion(5);

function deleteProduct(id, after)
{
    $.ajax(
        '/api/admin/DeleteComment',
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

function getComments(page, user_id) {
    $.ajax(
        '/api/admin/comments',
        {
            dataType: 'json',
            data: { page: page, user_id: user_id },
            error: () => { }
        }
    ).done(function (data) {
        app.comments = data.comments;
        app.currentPage = data.currentPage;
        app.totalPages = data.totalPages;
        app.pages = [];

        pagentaion.updatePages(app.currentPage, app.totalPages);
        app.pages = pagentaion.pages;
    })
}

function getUsers() {
    $.ajax(
        '/api/admin/getusers',
        {
            dataType: 'json',
            error: () => { }
        }
    ).done(function (data) {
        app.users = data;
    })
}

var app = new Vue({
    el: '#app',
    data: {
        comments: [],
        user_id: "",
        users: "",
        currentPage: 1,
        totalPages: 0,
        pages: [],
    },
    created: function () {
        getUsers();
        getComments(1);
    },
    methods: {
        deleteComment: function (id, name) {
            swal({
                title: "Вы точно хотите удалить "+name+"?",
                text: "Как только вы удалите товар его уже нельзя будет вернуть!",
                icon: "warning",
                buttons: {
                    cancel: 'отмена',
                    ok: 'да'
                },
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        deleteProduct(id, () => {
                            getComments(this.currentPage, this.user_id);
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
        updateFilters: function()
        {
            this.user_id = $("#users").val();
        },
        filter: function()
        {
            this.updateFilters();
            getComments(this.currentPage, this.user_id);
        },
        pageClick: function (page) {
            if (page != this.currentPage) {
                getComments(this.currentPage, this.user_id);
            }
        },
    }
});