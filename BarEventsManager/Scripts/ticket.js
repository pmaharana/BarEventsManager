
let addToCart = (itemId) => {
    $.ajax({
        url: "/home/ShoppingCart/" + itemId,
        method: "PUT",
        dataType: "html",
        success: (partial) => {
            $("#shoppingCart").html(partial);
        }
    });
}