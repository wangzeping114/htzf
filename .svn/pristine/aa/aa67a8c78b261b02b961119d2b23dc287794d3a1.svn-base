<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadImageTest.aspx.cs" Inherits="UploadImageTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="<%= ResolveUrl("~/styles/style.css?Version=1") %>" />
    <link type="text/css" rel="Stylesheet" href="<%= ResolveUrl("~/styles/pintuer.css") %>" />
    <link type="text/css" rel="Stylesheet" href="<%= ResolveUrl("~/Controls/styles/jquery.Jcrop.css") %>" />
    <link type="text/css" rel="Stylesheet" href="<%= ResolveUrl("~/Controls/styles/layout.css?v=1.0") %>" />
    
    <script type="text/javascript" src="<%= ResolveUrl("~/Controls/scripts/jquery.form.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Controls/scripts/jquery.color.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Controls/scripts/jquery.Jcrop.js") %>"></script>
    <style type="text/css">
        html,body { margin: 0; padding: 0; height: auto; }
        p { margin-bottom: 5px; font-size: 12px;line-height:18px;}
        .up-box {padding: 0 10px;}
        .btn-box {margin: 5px 0;}
        #uploadImage{opacity:0;}
        #preview-pane .preview-imgsize{width:220px;white-space:normal;word-wrap:break-word;font-size:12px;margin-top:5px;}
    </style>
</head>
<body>    
    <div class="up-box">
        <div class="btn-box">
            <a class="button input-file border-main" href="javascript:void(0);">+ 选择上传图片
                <form id='formFile' name='formFile' method="post" target="formFile" action="CreateTempImage.ashx" enctype="multipart/form-data">
                    <input id="fileUp" size="100" type="file" name="fileUp" />

                    <input type="hidden" id="x" name="x" />
                    <input type="hidden" id="y" name="y" />
                    <input type="hidden" id="w" name="w" />
                    <input type="hidden" id="h" name="h" />

                    <input type="hidden" id="xscale" name="xscale" runat="server" />
                    <input type="hidden" id="yscale" name="yscale" runat="server" />

                    <input type="hidden" id="boundx" name="boundx" />
                    <input type="hidden" id="boundy" name="boundy" />
                </form>
            </a>
            <a id="submit" class="button input-file bg-sub hidden" href="javascript:void(0);" disabled="disabled"><span class="icon-upload"></span>确认图片上传</a>
            <p id="msg"></p>
        </div>
        <img id="uploadImage" runat="server" src="" alt="" />
        <div id="preview-pane">
            <div class="preview-container">
                <img src="" class="jcrop-preview" alt="Preview" />
            </div>
            <div class="preview-imgsize"></div>
            <div class="preview-imgsize"></div>
        </div>
        <p>上传图片格式只支持(.gif、.jpg、.png、.bmp)四种格式，且大小不超过2M。</p>
        <p id="load_desc" class="hidden">点击“<b class="text-red">确认图片上传</b>”按钮或“<b class="text-red">双击选择区域</b>”上传图片。</p>
    </div>
</body>

<script type="text/javascript">
    var index = parent.layer.getFrameIndex(window.name),
        callback = '<%= callback %>',
        original = {
            w: 0, 
            h: 0
        };

    (function (window) {
        if (!callback) {
            parent.layer.open({
                content: '图片上传缺少回调方法名',
                scrollbar: false
            });
            parent.layer.close(index);
        }

        var file = $("#fileUp"),
            uploadImage = $("#<%= uploadImage.ClientID %>"),
            xscale = $("#<%= xscale.ClientID %>").val(),
            yscale = $("#<%= yscale.ClientID %>").val(),
            jcrop_api,
            boundx,
            boundy,
            $preview = $('#preview-pane'),
            $pcnt = $('#preview-pane .preview-container'),
            $pimg = $('#preview-pane .preview-container img');

        $pcnt.width(parseInt(xscale) * 20).height(parseInt(yscale) * 20);
        $preview.hide();

        if (xscale && yscale) {
            $("#load_desc").removeClass("hidden");
        }

        function initJcrop(sw, sh) {
            original.w = sw;
            original.h = sh;

            if (jcrop_api) {
                jcrop_api.destroy();
                uploadImage[0].style.cssText = "";
            }
            boundx = 0;
            boundy = 0;

            uploadImage.Jcrop({
                createHandles: ['nw', 'ne', 'se', 'sw'],
                boxWidth: 400,
                boxHeight: 400,
                bgColor: '#000',
                aspectRatio: parseInt(xscale) / parseInt(yscale),
                onChange: updatePreview,
                onSelect: updatePreview,
                onDblClick: doUpload
            }, function () {
                var bounds = this.getBounds();
                boundx = parseInt(bounds[0]);
                boundy = parseInt(bounds[1]);
                $("#boundx").val(boundx);
                $("#boundy").val(boundy);

                var selectArea = {
                    x: 0,
                    y: 0,
                    w: 0,
                    h: 0,
                    boundScale: boundx / boundy,
                    cutScale: xscale / yscale
                };

                if ((boundx >= boundy && selectArea.boundScale >= selectArea.cutScale) || (boundx < boundy && selectArea.boundScale >= selectArea.cutScale)) {
                    selectArea.w = parseInt(boundy / yscale * xscale);
                    selectArea.h = boundy;

                    if (selectArea.w < boundx) {
                        selectArea.x = parseInt((boundx - selectArea.w) / 2);
                    }
                } else {
                    selectArea.w = boundx;
                    selectArea.h = parseInt(boundx / xscale * yscale);

                    if (selectArea.h < boundy) {
                        selectArea.y = parseInt((boundy - selectArea.h) / 2);
                    }
                }

                jcrop_api = this;
                jcrop_api.setSelect([selectArea.x, selectArea.y, selectArea.w, selectArea.h]);

                $(".preview-imgsize:eq(0)", $preview).html('原始尺寸--宽：<b class="text-red">' + original.w + '</b>；高：<b class="text-red">' + original.h + '</b>');
                $(".preview-imgsize:eq(1)", $preview).html('裁切尺寸--宽：<b class="text-red">' + parseInt(selectArea.w * original.w / boundx) + '</b>；高：<b class="text-red">' + parseInt(selectArea.h * original.h / boundy) + '</b>');
                $preview.appendTo(jcrop_api.ui.holder);
            });
        }

        function updatePreview(c) {
            if (parseInt(c.w) > 0) {
                var rx = $pcnt.width() / c.w;
                var ry = $pcnt.height() / c.h;

                $('#x').val(parseInt(c.x));
                $('#y').val(parseInt(c.y));
                $('#w').val(parseInt(c.w));
                $('#h').val(parseInt(c.h));

                $pimg.css({
                    width: Math.round(rx * boundx) + 'px',
                    height: Math.round(ry * boundy) + 'px',
                    marginLeft: '-' + Math.round(rx * c.x) + 'px',
                    marginTop: '-' + Math.round(ry * c.y) + 'px'
                });

                $(".preview-imgsize:eq(1)", $preview).html('裁切尺寸--宽：<b class="text-red">' + parseInt(c.w * original.w / boundx) + '</b>；高：<b class="text-red">' + parseInt(c.h * original.h / boundy) + '</b>');
            }
        }

        file.bind('change', function () {
            if (xscale && yscale) {
                doTemp();
            } else {
                doUpload();
            }
        });

        $("#submit").click(function () {
            doUpload();
        });

        function doTemp() {
            $("#formFile").ajaxSubmit({
                url: 'CreateTempImage.ashx',
                type: "post",
                dataType: "text",
                data: {
                    groupid: localStorage.MGroupID,
                    action: 'temp'
                },
                success: function (data) {
                    var res_arr = data.split('|');

                    if (res_arr[0] == "true") {
                        // 按比例切割图片
                        $("#msg").hide();
                        $preview.show();

                        uploadImage.attr("src", res_arr[1]);
                        $(".jcrop-preview").attr("src", res_arr[1]);
                        $("#submit").removeAttr("disabled").removeClass('hidden');

                        initJcrop(res_arr[2], res_arr[3]);
                        if (jcrop_api) {
                            jcrop_api.setImage(res_arr[1]);
                        }
                    } else {
                        $("#msg").addClass("red").html("图片打开失败").show();
                        var timer = setTimeout(function () {
                            $("#msg").removeClass("red").html("请选择要上传的图片").hide();
                            clearTimeout(timer);
                        }, 5000);
                    }
                },
                error: function (error) { }
            });
        }

        function doUpload() {
            $("#formFile").ajaxSubmit({
                url: 'CreateTempImageTest.ashx',
                type: "post",
                dataType: "text",
                data: {
                    groupid: localStorage.MGroupID,
                    action: 'upload'
                },
                success: function (data) {
                    var res_arr = data.split('|');

                    if (res_arr[0] == "true") {
                        parent[callback](res_arr[1]);
                        parent.layer.close(index);
                    } else {
                        $("#msg").addClass("red").html("图片上传失败").show();
                        var timer = setTimeout(function () {
                            $("#msg").removeClass("red").html("请选择要上传的图片").hide();
                            clearTimeout(timer);
                        }, 5000);
                    }
                },
                error: function (error) { }
            });
        }
    })(window);
</script>
</html>
