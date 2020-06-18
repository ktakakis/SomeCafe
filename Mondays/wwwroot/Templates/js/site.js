// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Initialize Select2 Elements
$('.select2').each(function (i, obj) {
    if (!$(obj).hasClass("select2-hidden-accessible")) {
        $(obj).select2({
            dropdownAutoWidth: 'true',
            width: '100%'
        });
    }
});

