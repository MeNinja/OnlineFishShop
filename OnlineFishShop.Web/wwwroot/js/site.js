// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addToCart(prodId, prodName, prodThumbnailSource, prodPrice, quantity) {
    $.ajax(
            {
                type: "POST",
                traditional: true,
                url: "shopping/home/addToCart",
                data: {
                    productId: prodId,
                    quantity: quantity
                }
            })
        .done(function(resp) {
            addAlert("Success", resp);
//            addHtmlSidebarCartItem(prodThumbnailSource, prodName, prodPrice, parseInt(quantity));
        })
        .fail(function(resp) {
            console.dir(resp);
            addAlert("danger", resp.responseText);
        });
}

function addAlert(alertStyle, message) {
    //The required URL parameter specifies the URL you wish to load.
    //The optional data parameter specifies a set of querystring key/value pairs to send along with the request.
    // data -> {string alertStyle, string message, bool dismissable}

    $(".alert-dismissable").delay(2000).fadeOut(3000);
    $("html, body").animate({ scrollTop: $("body").offset().top }, 1000);
}