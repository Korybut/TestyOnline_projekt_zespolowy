function myFunction() {
    var query = $('#UserPopup');
    var isVisible = query.is(':visible');
    if (isVisible === true) $('#UserPopup').hide(500);
    else $('#UserPopup').show(500);
}