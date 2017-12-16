/* Transparent navbar when scrolling down */
$(document).ready(function () {
    $(window).scroll(function () {
        if ($(window).scrollTop() > 70)
            $("div.navbar.navbar-fixed-top").hide();
        else
            $("div.navbar.navbar-fixed-top").show();
    });
});

/**
 * addBookmark -
   On button click - Ajax call to controller
   will add the item with the specified id to the
   users Session.
 * @param {any} id
 */
function addBookmark(id) {
    $.ajax({
        type: "POST",
        url: "/Home/AddBookmark",
        data: { RepoId: id },
        success: function () {
            console.log("success");
            //hide the added item from view
            $('div.' + id).hide();
        },
        error: function () {
            console.log("error");
        }
    });
}