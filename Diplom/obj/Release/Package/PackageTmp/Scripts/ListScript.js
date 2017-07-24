var OpenTab= [];

function brandResult(brand)
{
        bR = brand; 
};

function tab(i)
{
    return OpenTab[i];
};



function bedit(idval,table) {
    if (idval !== null) {
        $.ajax(
            {
                url: '/Credit/Credit'+table,
                data: { idval,table },
                success: function (result) {
                    $('#modDialog').modal('show');
                    $("#dialogContent").html(result);
                }
            });
    }
};

function bdel(id, table) {
    if (id !== null) {
        $.ajax(
            {
                type: 'POST',
                url: '/Credit/Delete',
                data: { id, table },
                success: function (data) {
                    $('#details').load('/List/List'+table);
                }
            });
    }
};

function badd(id,table,namePart,nameBrand,price) {
    if (id !== null) {
        $.ajax(
            {
                url: '/Credit/CreditOrderM',
                data: { id, table, namePart, nameBrand,price },
                success: function (result) {
                    $('#modDialog').modal('show');
                    $("#dialogContent").html(result);
                }
            });
    }
};

function bshop(id, table, namePart, nameBrand, price, count) {
    if (id !== null) {
        $.ajax(
            {
                url: '/Credit/CreditOrderS',
                data: { id, table, namePart, nameBrand, price, count },
                success: function (result) {
                    $('#modDialog').modal('show');
                    $("#dialogContent").html(result);
                }
            });
    }
};

function sendPost(table) {
    $.ajax(
        {
            success: function (data) {
                $("#dialogContent").modal('hide');
                $("#modDialog").modal('hide');
                $('.modal').remove();
                $('.modal-backdrop').remove();
                $('body').removeClass("modal-open");
                $.ajax(
                    {
                        url: '/List/List' + table,
                        data: {},
                        complete: function (result) {
                            $("#myTab").remove();
                            $("#Tab").remove();
                            $('#details').load('/List/List'+table);
                        }
                    });
            }
        });
}

function orderCompleteM(id, nameP, count, table) {
    $.ajax({
        type: 'POST',
        url: '/Credit/CompleteOrderM',
        data: { id, nameP, count, table },
        success: function (result) {
            $('#orderM').load('/List/ListOrderM');
        }
    });
}

function orderCompleteS(id, nameP, count, table) {
    $.ajax({
        type: 'POST',
        url: '/Credit/CompleteOrderS',
        data: { id, nameP, count, table },
        success: function (result) {
            $('#orderS').load('/List/ListOrderS');
        }
    });
}
       