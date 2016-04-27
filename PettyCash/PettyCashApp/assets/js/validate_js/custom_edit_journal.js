/*
Author : Harishankar
19/04/2016
Custom Edit journal for Withdraw and Deposit
*/

var vali_edit = function () {
    var runedit_vali = function () {      
        var form = $('#journal_edit');
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

        //Validator for Amount or Price for Zero
        jQuery.validator.addMethod("startnonzero", function (value, element) {
            if (value.charAt(0) == 0) {
                return false;
            }
                return true;            
        }, "Doesn't Accept Zero or Amount starting with It");

        //Validator for Amount starting with 0.
        jQuery.validator.addMethod("alpha", function (value, element) {
            return this.optional(element) || /^[a-zA-Z0-9-]*$/i.test(value);
        }, "Accepts Characters, Numerals and Hyphen(-)");      
       
        //Validator for File Size 
        $.validator.addMethod('filesize', function (value, element, param) {
            // param = size (in bytes) 
            // element = element to validate (<input>)
            // value = value of the element (file name)
            return this.optional(element) || (element.files[0].size <= param)
        }, "File must be less than 3 Mb");
        

        form.validate({            
            ignore: ':hidden',            
            rules: {
                ctl00$ContentPlaceHolder1$txtdate: {
                    required: true                    
                },
                ctl00$ContentPlaceHolder1$txtrcpt: {
                    required: true,
                    maxlength: 30,
                    alpha: true
                },
                ctl00$ContentPlaceHolder1$item_name1: {
                    required: true,
                    maxlength :30
                },
                ctl00$ContentPlaceHolder1$price1: {
                    required: true,
                    number: true,
                    startnonzero: true
                },
                ctl00$ContentPlaceHolder1$txtamount: {
                    required: true,
                    number: true,
                    startnonzero: true
                },
                ctl00$ContentPlaceHolder1$bill_upload: {
                    required: true,
                    filesize: 3145728,
                    accept: "application/pdf"
                },
                ctl00$ContentPlaceHolder1$vhr_upload: {
                    required: true,
                    filesize: 3145728,
                    accept: "application/pdf"
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
            runedit_vali();
        }
    };
}();