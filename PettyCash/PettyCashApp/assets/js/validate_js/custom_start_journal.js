/*
Author : Agaile
14/04/2016
Custom start journal  validation script
*/

var startjinit = function () {
    var runstartjinitValidator = function () {
        var form = $('#startj_form');
        var errorHandler = $('.errorHandler', form);
        form.validate({
            ignore: ':hidden',
            rules: {
                ctl00$ContentPlaceHolder1$txtsjdate: {
                    required: true
                }
            },
            submitHandler: function (form) {
                errorHandler.hide();
                form.submit();
            },
            invalidHandler: function (event, validator) { //display error alert on form submit
                errorHandler.show();
            }
        });
    };
    return {
        //main function to initiate template pages
        init: function () {
            runstartjinitValidator();
        }
    };
}();