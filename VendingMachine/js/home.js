

function buyItem(money, itemID) {
    'use strict';
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/money/' + money + '/item/' + itemID,
        success: function (data) {
            alert('' + data.quarters + ' quarter(s), ' + data.dimes + ' dime(s), ' + data.nickels + ' nickel(s), and ' + data.pennies + ' penn' + ((data.pennies === 1) ? 'y' : 'ies') + ' is your change.');
        },
        statusCode: {
            422: function (xhr) {
                alert($.parseJSON(xhr.responseText).message);
            }
        }
    });
}