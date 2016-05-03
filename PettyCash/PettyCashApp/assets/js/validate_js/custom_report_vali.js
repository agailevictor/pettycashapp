/*
Author : Harishankar
28/04/2016
Custom Edit journal for Withdraw and Deposit
*/

var vali_rpt = function () {
    var runvali_rpt = function () {
        var form = $('#startj_form');
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
            ignore: ':hidden',
            rules: {
                ctl00$ContentPlaceHolder1$start_date: {
                    required: true
                },                
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
            runvali_rpt();
        }
    };
}();
