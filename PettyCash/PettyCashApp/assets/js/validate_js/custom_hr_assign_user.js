/*
Author : Agaile
13/04/2016
Custom assign user validation script
*/

var Assign = function () {

    var runAssignValidator = function () {
        var form = $('#assign_form');
        var errorHandler = $('.errorHandler', form);

        form.validate({
            rules: {
                ctl00$ContentPlaceHolder1$ddl_assign_user: {
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
            runAssignValidator();
        }
    };
}();