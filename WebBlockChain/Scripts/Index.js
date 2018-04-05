$(function () {
    $(document).ready(function () {
        var select = $('#curr').val(),
            count = $('#currency-' + select).val();
        console.log(select);
        console.log(count);
        $('#count').attr('max', count);
    });

    $('#curr').change(function () {
        var name = $(this).val(),
            count = $('#currency-' + name).val();
        console.log(name);
        console.log(count);
        $('#count').attr('max', count);
    });

    $('#mining').click(function () {
        var select = $(this),
            UserId = $(this).attr("UserId");
        select.prop('disabled', 'disabled');
        console.log(UserId);
        var data = {
            userId: UserId
        };

        $.ajax({
            url: '/Home/StartMining',
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",

            success: function (data) {
                if (data==true) {
                    $('#message').show();
                }
                else {
                    $('#errormessage').show();
                }               
                console.log(data);
                select.prop('disabled', false);
                change.prop('disabled', false);
            },

            failure: function (data) {
                console.log(data);
                select.prop('disabled', false);
                change.prop('disabled', false);
            }
        });
    });
});