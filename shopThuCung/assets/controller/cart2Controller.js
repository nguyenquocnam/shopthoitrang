var cart = {
    init: function () {
        cart.event();
    },
    event: function () {
        $('#btnContinue').off('click').on('click',function () {
            window.location.href = '/';
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = '/cart/payment';
        });
        $('#btnUpdate').off('click').on('click', function () {
            var cart = $('.quantity');
            var cartList = [];
            $.each(cart, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    product: {
                        MaSp:$(item).data('id')
                    } 

                });
            });
            $.ajax({
                url: '/cart/cartUpdate',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href='/cart/Index'
                    } else {

                    }
                }
            });
        });
        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/cart/deleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/cart/Index'
                    } else {

                    }
                }
            });
        });
        $('.btnDelete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                url: '/cart/delete',
                data: { MaSp: $(this).data('id') },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/cart/Index'
                    } else {

                    }
                }
            });
        });
    }
}
cart.init();