$(document).ready(function(){
    //alert(convertToMoney($('#quarters'),$('#dimes'),$('#nickels'),$('#pennies')));
});

function convertToMoney(quarters,dimes,nickels,pennies) {
    return ((parseInt(quarters.val()) * 25 + parseInt(dimes.val()) * 10 + parseInt(nickels.val()) * 5 + parseInt(pennies.val()) ) * 0.01).toFixed(2);
}


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

function populateItems () {
    'use strict';
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function (data) {
            $('#itemBoxes').text('');
            $.each(data, function(index,item) {
                var itemDiv = '<div class="col-4 px-5 border bg-light" id="item';
                itemDiv += item.id;
                itemDiv += '">';
                itemDiv += '<div class="text-left" style="font-size:10pt">';
                itemDiv += item.id;
                itemDiv += '</div>';
                itemDiv += '<div class="text-center">';
                itemDiv += item.name;
                itemDiv += '<br/>$'
                itemDiv += parseFloat(item.price).toFixed(2);
                itemDiv += '<br/>Quantity Left: ';
                itemDiv += item.quantity;
                itemDiv += '</div>';

                itemDiv += "</div>";
                $('#itemBoxes').append(itemDiv);
            })
        },
        error: function () {
            alert('no u');
        }
    });
}