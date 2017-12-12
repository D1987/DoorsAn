/*back to top*/
$(window).scroll(function () {
    if ($(this).scrollTop()) {
        $('.back-to-top').fadeIn();
    } else {
        $('.back-to-top').fadeOut();
    }
});

/*check a file's extension*/
function fileValidation() {
    var fileInput = document.getElementById('file');
    var filePath = fileInput.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif)$/i;
    if (!allowedExtensions.exec(filePath)) {
        document.getElementById("validation").innerHTML = 'Вы загрузили не изображение, пожалуйста выберите файл с разрешением .jpeg, .jpg, .png или .gif';
        fileInput.value = '';
        return false;
    } else {
        var a = document.getElementById("validation").value
        if (document.getElementById("validation").value !== null || document.getElementById("validation").value !== undefined) {
            document.getElementById("validation").innerHTML = '';
        }
    }
}