$('.hidden-file-input').change(function () {
    if ($(this).val() != '')
        $('#UploadForm').submit();
});