var SanPham = {
    init: function () {
        this.registerEvents();
    },
    registerEvents: function () {
        $(".link-active").off("click").on("click", function (e) {
            e.preventDefault();
            var box = this.parentElement.parentElement.parentElement.children[1].children;
            var id = $(this).data("id");
            $.ajax({
                url: "/Home/productIndexChange",
                data: { MaPL : id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    let rp = response.listSP;
                    if (response.count != 0) {
                        for (let i = 0; i < box.length; i++) {
                            if (box[i].className.indexOf("box-select") != -1) {

                                $(box[i]).children().remove();
                                let id = null;
                                $.each(rp, function (index, vl) {
                                    if (id != vl.MaSp) {
                                        let kt = false;
                                        $('').appendTo(box[i]);
                                        $('<div class="sp"></div>').appendTo(box[i]);
                                        let boxChild = box[i].children[box[i].children.length - 1];
                                        $('<a href="/Chi-Tiet-San-Pham/' + vl.MaPL + '/' + vl.MaSp + '" title=""></a>').appendTo(boxChild);
                                        let taga = boxChild.children[0];
                                        $('<div class="img-sp"></div>').appendTo(taga);
                                        let boxImg = taga.children[0];
                                        $.each(rp, function (index1, vl1) {
                                            if (kt == false && vl1.MaSp == vl.MaSp) {
                                                $('<div class="anh-1"></div>').appendTo(boxImg);
                                                let boxImgChild = boxImg.children[boxImg.children.length - 1];
                                                $(' <img src="' + vl1.url + '" alt="" width="100%" height="100%" >').appendTo(boxImgChild);
                                                kt = true;

                                            } else if (kt == true && vl1.MaSp == vl.MaSp) {
                                                $('<div class="anh-2"></div>').appendTo(boxImg);
                                                let boxImgChild = boxImg.children[boxImg.children.length - 1];
                                                $('<img src="' + vl1.url + '" alt="" width="100%" height="100%" >').appendTo(boxImgChild);
                                                return false;
                                            }
                                        })
                                        $('<div class="name-sp"></div>').appendTo(taga);
                                        $('<h5>' + vl.tenSP + '</h5>').appendTo(taga.children[1]);
                                    }
                                    id = vl.MaSp;
                                });
                            }
                        }
                    } else if (response.count == 0) {
                        for (let i = 0; i < box.length; i++) {
                            if (box[i].className.indexOf("box-select") != -1) {
                                $(box[i]).children().remove();
                                $('<h1 style="margin:auto;">SẢN PHẨM KHÔNG CÓ SẴN</h1>').appendTo(box[i]);
                            }
                        }
                       
                    }
                }
            });
        });
    }
}
SanPham.init();