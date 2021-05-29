// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#search").submit(function () {
    let url = $(this).attr('action');
    let q = $(this).serialize();
    let c = $(this).find('select').val();

    window.location = url + '/' + c + '?' + q;

    return false;
});

