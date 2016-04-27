/*
Author : Agaile
13/04/2016
Custom add journal initial validation script
*/

var addjdinit = function () {

    var runaddjdinitValidator = function () {
        var form = $('#journal_entry');
        var errorHandler = $('.errorHandler', form);
        form.validate({
            rules: {
                ctl00$ContentPlaceHolder1$txtdate: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$txtrcpt: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$ddltype: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$txtamountd: {
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
            runaddjdinitValidator();
        }
    };
}();