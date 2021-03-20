var statusCT = {
    init: function () {
        statusCT.registerEvents();

    },
    registerEvents: function () {
        
        $('#status').off('click').on('click', function (e) {
            console.log("sss");
            var id = $(this).data('id');
            $.ajax({
                url: '/admin/hoadon/changeStatusHD',
                data: { MAHD: id },
                dataType: 'json',
                type: 'POST',
                success: function (respone) {
                    console.log(respone);
                    if (respone.status == false)
                        alert('that bai');
                }
            });
        });
    }
}
statusCT.init();