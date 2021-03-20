var danhmuc = {
    init: function () {
        danhmuc.registerEvents();

    },
    registerEvents: function () {
        $('#insert').off('click').on('click', function (e) {
            e.preventDefault();
            if ($('#editDM').css('display') == 'block') {
                $('#editDM').css({ 'display': 'none' });
                $('#insertDM').css({ 'display': 'block' });
            } else {
                $('#insertDM').css({ 'display': 'block' });
            }
                
        });
        $('.edit').off('click').on('click', function (e) {
            e.preventDefault(); 
            if ($('#insertDM').css('display') == 'block') {
                $('#insertDM').css({ 'display': 'none' });
                
                $('#editDM').css({ 'display': 'block' });
            } else {
                
                $('#editDM').css({ 'display': 'block' });
            }
            var hientai = $(this);
            $.each($('#editDM option'), function (i, item) {
                if (Number(item.value) == hientai.data('loai')) {
                    item.setAttribute('selected', 'selected');
                } 
            });
            $('#editMaPL').val(hientai.data('mapl'));
            console.log();
            $('#ten').val(hientai.data('tenpl'));
        });


    }
}
danhmuc.init();