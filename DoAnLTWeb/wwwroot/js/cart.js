var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/san-pham";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        $('.btnUpdate').off('click').on('click', function () {
            var cartList = [];
            $('.txtQuantity').each(function () {
                cartList.push({
                    Quantity: $(this).val(),
                    Product: {
                        Idproduct: $(this).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/UpdateCart',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            });
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/RemoveFromCart',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            });
        });
    }
};
cart.init();