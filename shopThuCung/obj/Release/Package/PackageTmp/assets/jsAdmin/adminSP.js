var hot = {
    init: function () {
        hot.registerEvents();
    },
    registerEvents: function () {
        $('#hot').off('click').on('click', function (e) {
            
            var id = $(this).data('id');
            $.ajax({
                url: '/admin/admin/changeHot',
                data: {MaSp:id},
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
hot.init();