/*back to top*/
$(window).scroll(function () {
    if ($(this).scrollTop()) {
        $('#back-to-top').fadeIn();
    } else {
        $('#back-to-top').fadeOut();
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

/*delete product */
$(document).ready(function () {
    //start of the document ready function
    //delcaring global variable to hold primary key value.
    var ProId;
    $('.delete-prompt').click(function () {
        ProId = $(this).attr('id');
        $('#myModal').modal('show');       
    });

    $('.delete-confirm').click(function () {
        if (ProId != '') {
            $.ajax({
                url: '/Product/Delete',
                data: { 'id': ProId },
                type: 'post',
                success: function (data) {
                    if (data) {
                        $('#myModal').modal('hide');
                        $('#myModal').on('hidden.bs.modal', function () {
                            location.reload();
                        });                        
                    }
                }, error: function (err) {
                    if (!$('.modal-header').hasClass('alert-danger')) {
                        $('.modal-header').removeClass('alert-success').addClass('alert-danger');
                        $('.delete-confirm').css('display', 'none');
                    }
                    $('.success-message').html(err.statusText);
                }
            });
        }
    });
});