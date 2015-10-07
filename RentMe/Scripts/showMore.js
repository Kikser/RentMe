function showMore() {
    $('.hide:lt(4)').removeClass('hide');
};

$(document).ready(function () {
    $('.hide:lt(4)').removeClass('hide');
    $('#show-more').on('click', showMore);
});