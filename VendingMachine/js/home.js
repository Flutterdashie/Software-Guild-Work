$(document).ready(function () {
    'use strict';
    $('#goAwayFloatingPoint').val(0);
    populateItems();
});

function makePurchase() {
    'use strict';
    if(!(/\b\d+/).test($('#itemId').val())) {
        $('#messageBox').val('Invalid item ID, please choose a valid item and try again.');
    } else {
        buyItem(($('#goAwayFloatingPoint').val() * 0.01).toFixed(2), parseInt($('#itemId').val()));
    }
}

function setItem(newId) {
    'use strict';
    $('#itemId').val(newId);
}

function buyItem(money, itemID) {
    'use strict';
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/money/' + money + '/item/' + itemID,
        success: function (data) {
            $('#messageBox').val("Thank you!!!");
            $('#changeBox').val('' + data.quarters + ' quarter(s), ' + data.dimes + ' dime(s), ' + data.nickels + ' nickel(s), and ' + data.pennies + ' penn' + ((data.pennies === 1) ? 'y' : 'ies') + ' is your change.');
            $('#goAwayFloatingPoint').val(0);
            addMoney(0);
        },
        statusCode: {
            422: function (xhr) {
                $('#messageBox').val($.parseJSON(xhr.responseText).message);
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
                var itemDiv = '<div class="col-4 border bg-light item-option" onclick="setItem(';
                itemDiv += item.id;
                itemDiv += ')">';
                itemDiv += '<div class="text-left" style="font-size:10pt;">';
                itemDiv += item.id;
                itemDiv += '</div>';
                itemDiv += '<div class="text-center">';
                itemDiv += item.name;
                itemDiv += '<br/>$';
                itemDiv += parseFloat(item.price).toFixed(2);
                itemDiv += '<br/>Quantity Left: ';
                itemDiv += item.quantity;
                itemDiv += '</div>';

                itemDiv += "</div>";
                $('#itemBoxes').append(itemDiv);
            });
        },
        error: function () {
            alert('Out of Order!');
        }
    });
}

function addMoney(amount) {
    $('#goAwayFloatingPoint').val(parseInt($('#goAwayFloatingPoint').val()) + amount);
    $('#money').text(($('#goAwayFloatingPoint').val() * 0.01).toFixed(2));
}

function takeChange() {
    $('#itemID').val('');
    $('#messageBox').val('');
    populateItems();
    if($('#goAwayFloatingPoint').val() == 0) {
        //Purchase has been made already, this is just to clear change and update
        $('#changeBox').val('');
    } else {
        var quarter = Math.floor(parseInt($('#goAwayFloatingPoint').val()) / 25);
        $('#goAwayFloatingPoint').val(parseInt($('#goAwayFloatingPoint').val()) % 25);
        var dime = Math.floor(parseInt($('#goAwayFloatingPoint').val()) / 10);
        $('#goAwayFloatingPoint').val(parseInt($('#goAwayFloatingPoint').val()) % 10);
        var nickel = Math.floor(parseInt($('#goAwayFloatingPoint').val()) / 5);
        var penny = parseInt($('#goAwayFloatingPoint').val()) % 5;
        $('#changeBox').val('' + quarter + ' quarter(s), ' + dime + ' dime(s), ' + nickel + ' nickel(s), and ' + penny + ' penn' + ((penny === 1) ? 'y' : 'ies') + ' is your change.');
        $('#goAwayFloatingPoint').val(0);
        addMoney(0);
    }
}