var product = {
    init: function () {
        product.registerEvents();
    },
    registerEvents: function () {
        var editor = CKEDITOR.replace('mota', {
            customConfig: '/assets/ckeditor/config.js',
        });
        
        $('#loai').off('click').on('click', function (e) {
            let loai = $(this).val();
            if (loai == '11' || loai == '12' || loai == '13' || loai == '14') {
                console.log($('#mausac').parent);
                $('#mausac').parent().parent().css('display', 'none');
                $('#male').parent().parent().css('display', 'none');
                $('#tuoi').parent().parent().css('display', 'none');
                $('#tinhtrang').parent().parent().css('display', 'none');
                $('#vacxin').parent().parent().css('display', 'none');
                $('#taygiun').parent().parent().css('display', 'none');
                $('#xuatxu').parent().parent().css('display', 'none');
                $('#imgChooseDetail').parent().parent().css('display', 'none');
                $('#mota').parent().parent().css('display', 'block');
            } else {
                $('#mausac').parent().parent().css('display', 'block');
                $('#male').parent().parent().css('display', 'block');
                $('#tuoi').parent().parent().css('display', 'block');
                $('#tinhtrang').parent().parent().css('display', 'block');
                $('#vacxin').parent().parent().css('display', 'block');
                $('#taygiun').parent().parent().css('display', 'block');
                $('#xuatxu').parent().parent().css('display', 'block');
                $('#imgChooseDetail').parent().parent().css('display', 'block');
                $('#mota').parent().parent().css('display', 'none');
            }
        });
        $('#imgDFChoose').off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                if ($('#imagelist1')[0].children.length < 2) {
                    $('#imagelist1').append('<div style="float:left;"><img src="' + url + '" width="100px" /><a href="#" class="btn-delImg"><i class="fa fa-times"></i></a></div>');
                    $('.btn-delImg').off('click').on('click', function (e) {
                        e.preventDefault();
                        $(this).parent().remove();
                    });
                }
            };
            finder.popup();
        });
        $('#imgChooseDetail').off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                if ($('#imagelist2')[0].children.length < 10) {
                    $('#imagelist2').append('<div style="float:left;"><img src="' + url + '" width="100px" /><a href="#" class="btn-delImg"><i class="fa fa-times"></i></a></div>');
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
            

            if ($('#MaSp').val().length > 0) {
                var sp = [];
                sp.push($('#MaSp').val());
                sp.push($('#TenSp').val());
                sp.push($('#loai').val());
                sp.push($('#mausac').val());
                let sex = document.getElementsByName('gender');
                for (var i = 0; i < sex.length; i++) {
                    if (sex[i].checked === true) {
                        if (i == 0)
                            sp.push("đực");
                        else {
                            sp.push("Cái");
                        }
                        break;
                    }
                }
                sp.push($('#tuoi').val());
                if ($('#tinhtrang').checked === false) {
                    sp.push("Không có sẵn");
                }
                else {
                    sp.push("Có hàng");
                }
                if ($('#vacxin').checked === false) {
                    sp.push("0");
                }
                else {
                    sp.push("1");
                }
                if ($('#taygiun').checked === false) {
                    sp.push("0");
                }
                else {
                    sp.push("1");
                }
                sp.push($('#xuatxu').val());
                console.log();
                sp.push(escapeHtml(editor.getData()));
                console.log(sp);
                $.ajax({
                    url: "/admin/admin/saveInfoSP",
                    data: {
                        sp: JSON.stringify(sp)
                    },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response);
                        if (response.status) {
                            var image = [];
                            var imageDetail = [];
                            var divImg = document.getElementById('imagelist1');
                            var divImgDetail = document.getElementById('imagelist2');
                            console.log();
                            for (var i = 0; i < divImg.children.length; i++) {
                                image.push($(divImg.children[i].children[0]).attr('src'));
                            }
                            for (var i = 0; i < divImgDetail.children.length; i++) {
                                imageDetail.push($(divImgDetail.children[i].children[0]).attr('src'));
                            }
                            console.log($('#loai').val());
                            $.ajax({
                                url: "/admin/admin/saveImageSP",
                                data: {
                                    MaSp: $('#MaSp').val(),
                                    image: JSON.stringify(image),
                                    imageDetail: JSON.stringify(imageDetail)
                                },
                                dataType: "json",
                                type: "POST",
                                success: function (response) {
                                    if (response.status == true) {
                                        location.href = "/admin/admin/SanPham";
                                    } else if (response.status == false && response.id == 0) {
                                        alert('Lỗi thêm ảnh hiển thị');
                                        location.href = "/admin/admin/SanPham";
                                    } else if (response.status == false && response.id == 1) {
                                        alert('Lỗi thêm ảnh chi tiết');
                                        location.href = "/admin/admin/SanPham";
                                    } else {
                                        alert('Không thêm được ảnh');
                                        location.href = "/admin/admin/SanPham";
                                    }
                                }
                            });
                        } else {
                            alert('loi them san pham');
                        }
                        
                    }
                });
            } else {
                alert('chua them ma san pham');
            }
        });


    },

}
product.init();

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
