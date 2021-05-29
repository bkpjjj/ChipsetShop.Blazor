function setCookie(name, value, options = {}) {

    options = {
        path: '/',
        // при необходимости добавьте другие значения по умолчанию
        ...options
    };

    if (options.expires instanceof Date) {
        options.expires = options.expires.toUTCString();
    }

    let updatedCookie = encodeURIComponent(name) + "=" + encodeURIComponent(value);

    for (let optionKey in options) {
        updatedCookie += "; " + optionKey;
        let optionValue = options[optionKey];
        if (optionValue !== true) {
            updatedCookie += "=" + optionValue;
        }
    }

    document.cookie = updatedCookie;
}

function getCookie(name) {
    let matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}

let addToWishlist = function (key) {

    wishlist.push(key);

    setCookie("wishlist", wishlist, { 'max-age': 3600 });
}

let removeFromWishlist = function (key) {


    let index = wishlist.indexOf(key);

    if (index > -1)
        wishlist.splice(index, 1);


    setCookie("wishlist", wishlist, { 'max-age': 3600 });
}

let getWishlist = function () {

    let data = getCookie('wishlist');

    if (data == undefined || data === "")
    {
        $("#wishlistCounter").html(0);
        return [];
    }

    data = data.split(",");

    $("#wishlistCounter").html(data.length);

    return data;
}

let wishlist = getWishlist();