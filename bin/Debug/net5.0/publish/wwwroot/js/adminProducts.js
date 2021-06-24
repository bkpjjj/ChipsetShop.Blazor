let pagentaion = new Pagentaion(5);

function deleteProduct(id, after)
{
    $.ajax(
        '/api/admin/DeleteProduct',
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

function getProducts(page, category, s, avgRate, isNew, InStock, discount) {
    $.ajax(
        '/api/admin/products',
        {
            dataType: 'json',
            data: { page: page, category: category, s: s, avgRate: avgRate, isNew: isNew, InStock: InStock, discount: discount },
            error: () => { }
        }
    ).done(function (data) {
        app.products = data.products;
        app.categories = data.categories;
        app.currentPage = data.currentPage;
        app.totalPages = data.totalPages;
        app.pages = [];

        pagentaion.updatePages(app.currentPage, app.totalPages);
        app.pages = pagentaion.pages;
    })
}

var app = new Vue({
    el: '#app',
    data: {
        products: [],
        categories: [],
        selectedCategory: "all",
        search: "",
        isnew: false,
        instock: false,
        discount: false,
        rate: "0",
        currentPage: 1,
        totalPages: 0,
        pages: [],
    },
    created: function () {
        getProducts(1, "all");
    },
    methods: {
        deleteProduct: function (id, name) {
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
                            getProducts(this.currentPage, this.selectedCategory, this.search, this.rate, this.isnew, this.instock, this.discount);
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
            this.search = $("#search").val();
            this.selectedCategory = $("#categorySelector").val();
            this.isnew = $("#isnew").is(":checked");
            this.instock = $("#instock").is(":checked");
            this.discount = $("#discount").is(":checked");
            let rate = $("#rate").val();
            this.rate = rate == "" ? 0 : rate;
        },
        filter: function()
        {
            this.updateFilters();
            getProducts(this.currentPage, this.selectedCategory, this.search, this.rate, this.isnew, this.instock, this.discount);
        },
        pageClick: function (page) {
            if (page != this.currentPage) {
                getProducts(this.currentPage, this.selectedCategory, this.search, this.rate, this.isnew, this.instock, this.discount);
            }
        },
    }
});