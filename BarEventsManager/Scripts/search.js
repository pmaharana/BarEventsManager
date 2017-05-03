
let searchEvents = () => {
    var _data = {
        needle: $("#needle").val()
    };
    $.ajax({
        url: "/home/search",
        data: JSON.stringify(_data),
        contentType: "application/json",
        type: "POST", 
        dataType: "html",
        success: (newHtml) => {
            $("#results").html(newHtml);
        }

    })
}