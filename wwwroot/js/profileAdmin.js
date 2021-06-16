let productPagentaion = new Pagentaion(4);

function deleteCommentAjax(id) {
    $.ajax(
        '/api/admin/deletecomment',
        {
            dataType: 'json',
            method: 'DELETE',
            data: { id: id },
            error: () => { console.log("error while delete comment") },
        }
    ).always(function () {
        getComments(app.commentsPanel.currentPage);
    });
}

function getProducts(page, category, s, isNew, inStock, discount, avgRate) {
    $.ajax(
        '/api/admin/products',
        {
            dataType: 'json',
            data: { category: category, s: s, page: page, isNew: isNew, inStock: inStock, discount: discount, avgRate: avgRate },
            error: () => { window.location.href = '/404'; }
        }
    ).done(function (data) {
        app.productsPanel.products = data.products;
        app.productsPanel.totalPages = data.totalPages;
        app.productsPanel.currentPage = data.currentPage;
        app.productsPanel.totalProducts = data.totalProducts;
        app.productsPanel.productsCount = data.productsCount;
        app.productsPanel.isLoaded = true;

        productPagentaion.updatePages(app.productsPanel.currentPage, app.productsPanel.totalPages);
        app.productsPanel.pages = productPagentaion.pages;
    })
}

function getComments(page) {
    $.ajax(
        '/api/admin/comments',
        {
            dataType: 'json',
            data: { page: page },
        }
    ).done(function (data) {
        app.commentsPanel.comments = data.comments;
        app.commentsPanel.totalPages = data.totalPages;
        app.commentsPanel.currentPage = data.currentPage;
        app.commentsPanel.isLoaded = true;

        productPagentaion.updatePages(app.commentsPanel.currentPage, app.commentsPanel.totalPages);
        app.commentsPanel.pages = productPagentaion.pages;
    })
}

function getPartialProducts(url)
{
    console.log(1);
    $.ajax(
        url,
        {
            dataType: 'json',
            method: 'PATCH',
        }
    ).always(function (data) {
        $('#adminTab1').html(data.responseText);
    })
}


var app = new Vue({
    el: "#app",
    data: {
        productsPanel: {
            isLoaded: false,
            isNew: false,
            inStock: false,
            discount: false,
            avgRate: 0,
            category: "all",
            search: null,
            products: [],
            totalPages: 0,
            currentPage: 0,
            totalProducts: 0,
            productsCount: 9,
            pages: [{ number: 1, isActive: true }],
        },
        commentsPanel: {
            comments: [],
            currentPage: 0,
            totalPages: 0,
            isLoaded: false,
            pages: [{ number: 1, isActive: true }],
        },
        categoryPanel: {
            categories: [],
            currentPage: 0,
            totalPages: 0,
            isLoaded: false,
            pages: [{ number: 1, isActive: true }],
        }
    },
    created: function () {
        this.loadProductData();
    },
    mounted: function (){
        getPartialProducts("/account/getproductpartial");
    },
    methods:
    {
        updateProductData: function (page) {
            getProducts(page, this.productsPanel.category, this.productsPanel.search, this.productsPanel.isNew, this.productsPanel.inStock, this.productsPanel.discount, parseInt(this.productsPanel.avgRate));
        },
        updateCommentsData: function (page) {
            getComments(page);
        },
        loadProductData: function () {
            if (!this.productsPanel.isLoaded)
                getProducts(1, this.productsPanel.category, this.productsPanel.search, false, false, false, 0);
        },
        loadCommentsData: function () {
            if (!this.commentsPanel.isLoaded)
                getComments(1);
        },
        pageClick: function (page) {
            if (page != this.productsPanel.currentPage) {
                this.updateProductData(page);
            }
        },
        commentPageClick: function (page) {
            if (page != this.commentsPanel.currentPage) {
                this.updateCommentsData(page);
            }
        },
        deleteComment: function (id) {
            deleteCommentAjax(id);
        }
    },
});