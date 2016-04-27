/*
Author : Agaile
13/04/2016
Custom add journal initial validation script
*/

var addjwinit = function () {
    var runaddjwinitValidator = function () {
        var form = $('#journal_entry');
        var errorHandler = $('.errorHandler', form);
        $.validator.prototype.checkForm = function () {
            //overriden in a specific page
            this.prepareForm();
            for (var i = 0, elements = (this.currentElements = this.elements()) ; elements[i]; i++) {
                if (this.findByName(elements[i].name).length != undefined && this.findByName(elements[i].name).length > 1) {
                    for (var cnt = 0; cnt < this.findByName(elements[i].name).length; cnt++) {
                        this.check(this.findByName(elements[i].name)[cnt]);
                    }
                } else {
                    this.check(elements[i]);
                }
            }
            return this.valid();
        }
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
                ctl00$ContentPlaceHolder1$item_name1: {
                    required :true
                },
                ctl00$ContentPlaceHolder1$price1: {
                    required: true,
                    number:true
                },
                ctl00$ContentPlaceHolder1$desc1: {
                    required : true
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
            runaddjwinitValidator();
        }
    };
}();