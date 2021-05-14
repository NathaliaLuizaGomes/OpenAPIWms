
function JsonPartialTable(tradeId, toId, url) {

    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify({ tradeId: tradeId, toId: toId }),
        contentType: 'application/json',
        success: function (response) {

            if (response.success == false) {

            }

            if (response.success == true) {
                for (var i = 0; i < response.data.length; i++) {
                    response.data[i];
                }


            }

        },
        error: function (error) {

            console.log(error);
        }
    });
}