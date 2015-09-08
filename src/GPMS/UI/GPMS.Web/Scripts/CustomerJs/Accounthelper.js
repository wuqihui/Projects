$(document).ready(function () {
    //* boxes animation
    var formWrapper = $('.loginRegister_box');
    function boxHeight() {
        formWrapper.animate({ marginTop: (-(formWrapper.height() / 2) - 24) }, 400);
    };
    formWrapper.css({ marginTop: (-(formWrapper.height() / 2) - 24) });
});
//Asp.net MVC 3 中 Unobtrusive JavaScript， 简化我们Web开发，提高了开发效率。
////* validation
    //$('#login_form').validate({
    //    onkeyup: false,
    //    errorClass: 'field-validation-error',
    //    validClass: 'valid',
    //    rules: {
    //        UserName: { required: true, minlength: 3, rangelength: [3, 18] },
    //        EmailAddress: { required: true, email: true },
    //        OldPassword: { required: true, minlength: 6, rangelength: [6, 16] },
    //        Password: { required: true, minlength: 6, rangelength: [6, 16] },
    //        ConfirmPassword: { required: true, rangelength: [6, 16], equalTo: "#Password" }
    //    }
    //});
    //$('#UserName').focus();
    //$('#OldPassword').focus();