var ttEit = {
    init: function () {
        ttEit.registerEvents();
    },
    registerEvents: function () {
        var editor = CKEDITOR.replace('mota', {
            customConfig: '/assets/ckeditor/config.js',
        });
        $('.btn-delImg').off('click').on('click', function (e) {
            e.preventDefault();
            $(this).parent().remove();
        });
        $('#imgDFChoose').off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                if ($('#imagelist1')[0].children.length < 1) {
                    $('#imagelist1').append('<div style="float:left;"><img src="' + url + '" width="100px" /><a href="#" class="btn-delImg"><i class="fa fa-times"></i></a></div>');
                    $('.btn-delImg').off('click').on('click', function (e) {
                        e.preventDefault();
                        $(this).parent().remove();
                    });
                }
            };
            finder.popup();
        });
        $('#saveSP').off('click').on('click', function (e) {
            e.preventDefault();
            var image = [];
            var divImg = document.getElementById('imagelist1');
            console.log();
            if (divImg.children.length != 0) {
                for (var i = 0; i < divImg.children.length; i++) {
                    image.push($(divImg.children[i].children[0]).attr('src'));
                }
                if ($('#MaBaiViet').val().length > 0) {
                    var sp = [];
                    sp.push($('#MaBaiViet').val());
                    sp.push($('#TieuDe').val());
                    sp.push($('#motangan').val());
                    sp.push(image[0]);
                    sp.push(escapeHtml(editor.getData()));
                    console.log(sp);
                    $.ajax({
                        url: "/admin/admin/editInfoTT",
                        data: {
                            sp: JSON.stringify(sp)
                        },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            console.log(response);
                            if (response.status) {
                                location.href = "/admin/admin/TinTuc";
                            } else {
                                alert('loi them tin tuc');
                            }

                        }
                    });
                } else {
                    alert('chua them ma san pham');
                }
            } else {
                alert('bạn phải thêm ảnh');
            }


        });


    },

}
ttEit.init();

function escapeHtml(text) {
    var map = {
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        '"': '&quot;',
        "'": '&#039;'
    };

    return text.replace(/[&<>"']/g, function (m) { return map[m]; });
}
function decodeHtml(str) {
    var map =
    {
        '&amp;': '&',
        '&lt;': '<',
        '&gt;': '>',
        '&quot;': '"',
        '&#039;': "'"
    };
    return str.replace(/&amp;|&lt;|&gt;|&quot;|&#039;/g, function (m) { return map[m]; });
}
