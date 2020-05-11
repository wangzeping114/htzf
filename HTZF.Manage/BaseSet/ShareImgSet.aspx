<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShareImgSet.aspx.cs" Inherits="BaseSet_ShareImgSet" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>合伙人的推广海报</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
    <link href="../assets/css/minstylenew.css" rel="stylesheet" />
    <link href="../assets/css/pintuer.css" rel="stylesheet" />
   <style type="text/css">
        #img-box
        {
            max-height: none;
        }
        .divgift
        {
            padding-top: 20px;
        }
    </style>
</head>
<body class="white-bg">
     <div class="form-horizontal">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-12">
                <ol class="breadcrumb">
                    <li>系统设置
                    </li>
                    <li>系统配置
                    </li>
                    <li class="liFSetName"> 
                    </li>
                </ol>
            </div>
            
        </div>
   <div class="wrapper wrapper-content animated fadeInRight form-x form-auto">
        <div class="form-group">
            <div class="label white-bg">
                <label for="username">
                    上传底图：</label></div>
            <div class="field">
                <div id="img-box" class="img-view-box">
                    <img class="img-border radius-small" title="点击上传图片" src="http://www.meizhuwl.net/img/addpic.png"
                        id="uploadimg" alt="" />
                </div>
                <input type="hidden" id="hidImageURL" />
                <div class="input-note">
                    如需修改二维码背景图片，请点击上面图片</div>
            </div>
        </div>
        <div class="form-group">
            <div class="label white-bg">
                <label for="username">
                    会员头像：</label></div>
            <div class="field ">
                <label for="username">
                    宽度</label>
                <input type="text" class="input input-auto" id="txtHead_W" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
                <label for="username">
                    高度</label>
                <input type="text" class="input input-auto" id="txtHead_H" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
                <label for="username">
                    X坐标</label>
                <input type="text" class="input input-auto" id="txtHead_X" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
                <label for="username">
                    Y坐标</label>
                <input type="text" class="input input-auto" id="txtHead_Y" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
            </div>
        </div>
        <div class="form-group">
            <div class="label white-bg">
                <label for="username">
                    二维码：</label></div>
            <div class="field">
                <label for="username">
                    宽度</label>
                <input type="text" class="input input-auto" id="txtCode_W" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
                <label for="username">
                    高度</label>
                <input type="text" class="input input-auto" id="txtCode_H" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
                <label for="username">
                    X坐标</label>
                <input type="text" class="input input-auto" id="txtCode_X" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
                <label for="username">
                    Y坐标</label>
                <input type="text" class="input input-auto" id="txtCode_Y" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
            </div>
        </div>
        <div class="form-group">
            <div class="label white-bg">
                <label for="username">
                    会员昵称：</label></div>
            <div class="field">
                <label for="username">
                    字号</label>
                <input type="text" class="input input-auto" id="txtNickName_Size" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
                <label for="username">
                    字体</label>
                <select id="txtNickName_Font" class="input input-auto" style="width:83px">
                    <option value="宋体">宋体</option>
                    <option value="黑体">黑体</option>
                    <option value="微软雅黑">微软雅黑</option>
                </select>&nbsp;&nbsp;
                <label for="username">
                    颜&nbsp;&nbsp;色</label>
                <input type="text" class="input input-auto" id="txtNickName_Color" name="username" size="8" onpaste="return false;"
                    maxlength="8" />&nbsp;&nbsp;
                <label for="username">
                    X坐标</label>
                <input type="text" class="input input-auto" id="txtNickName_X" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
                <label for="username">
                    Y坐标</label>
                <input type="text" class="input input-auto" id="txtNickName_Y" name="username"
                    size="8" onkeypress="keyPress()" onpaste="return false;" maxlength="4" />&nbsp;&nbsp;
            </div>
        </div>
        <div class="form-button ">
            <button class="button bg-sub icon-save" type="button" onclick="Save()">
                保 存</button>
            <button class="button bg-sub icon-reply" type="button" onclick="javascript:history.go(-1);">
                返 回</button>
            <button class="button bg-sub" type="button" onclick="Show()"><span class="icon-search"></span>预 览</button>
        </div>
    </div>
    <script>
        var mInfo = {};
        var mSetID = 10010110;
        var mFSetName = '';
        $(function () {
            $("#txtHead_W").val(50);
            $("#txtHead_H").val(50);
            $("#txtHead_X").val(0);
            $("#txtHead_Y").val(0);
            $("#txtCode_W").val(50);
            $("#txtCode_H").val(50);
            $("#txtCode_X").val(0);
            $("#txtCode_Y").val(50);
            $("#txtNickName_Size").val(16);
            $("#txtNickName_Color").val('#ffffff');
            $("#txtNickName_X").val(60);
            $("#txtNickName_Y").val(20);
            mSetID = syUrlParam('setid')
            if (mSetID == 10010110) {
                mFSetName = '推广学校二维码';
            }
            else {
                mFSetName = '推广学生二维码';
            }
            $(".liFSetName").html(mFSetName);
            $("#uploadimg").click(function () {
                ShowUpMainImg();
            });
           
            Query();
        });
        function keyPress() {
            var keyCode = event.keyCode;
            if ((keyCode >= 48 && keyCode <= 57) || keyCode == 116 || keyCode == 8) {
                event.returnValue = true;
            } else {
                event.returnValue = false;
            }
        }
        function Query() {
            layer.load(0, { shade: true });
            var params = {
                pSetID: mSetID
            };
            syAjax("POST", false, ConApiUrl + 'api/BaseSet/SystemControl/GetOneByID', puMInfo.appKeyId, params, GetOneByIDBack, syAjaxErrorBack);
        }
        function GetOneByIDBack(json) {
            layer.closeAll();
            if (json && json.Data) {
                if (json.Data) {
                    mInfo =JSON.parse(json.Data.FSetValue);
                    $("#txtHead_W").val(mInfo.Head_W);
                    $("#txtHead_H").val(mInfo.Head_H);
                    $("#txtHead_X").val(mInfo.Head_X);
                    $("#txtHead_Y").val(mInfo.Head_Y);
                    $("#txtCode_W").val(mInfo.Code_W);
                    $("#txtCode_H").val(mInfo.Code_H);
                    $("#txtCode_X").val(mInfo.Code_X);
                    $("#txtCode_Y").val(mInfo.Code_Y);
                    $("#txtNickName_Size").val(mInfo.NickName_Size);
                    $("#txtNickName_Font").val(mInfo.NickName_Font);
                    $("#txtNickName_Color").val(mInfo.NickName_Color);
                    $("#txtNickName_X").val(mInfo.NickName_X);
                    $("#txtNickName_Y").val(mInfo.NickName_Y);
                    getUploadImg(mInfo.ImageURL);
                }
            }
        }
        function ShowUpMainImg() {
            syOpenUploadImgDialog({
                url: '../Controls/UploadImage.aspx',
                method: 'getUploadImg', 
                totalGraph: 1
            });
        }
        function getUploadImg(url) {
            $("#uploadimg").attr("src", url);
            $("#img-box").removeClass("hidden");
            mInfo.ImageURL = url;
        }
        function check() {
            var MainImageURL = mInfo.ImageURL;  //活动二维码背景图

             var Head_W = $("#txtHead_W").val();
             var Head_H = $("#txtHead_H").val();
             var Head_X = $("#txtHead_X").val();
             var Head_Y = $("#txtHead_Y").val();

             var W = $("#txtCode_W").val();
             var H = $("#txtCode_H").val();
             var X = $("#txtCode_X").val();
             var Y = $("#txtCode_Y").val();

             var NickName_Size = $("#txtNickName_Size").val();
             var NickName_Font = $("#txtNickName_Font").val();
             var NickName_Color = $("#txtNickName_Color").val();
             var NickName_X = $("#txtNickName_X").val();
             var NickName_Y = $("#txtNickName_Y").val();

             if (MainImageURL == null || MainImageURL == '') {
                 layer.msg("请上传二维码背景图片!");
                 return false;
             }

             if (Head_W == null || Head_W == '') {
                 layer.msg("头像宽度必填!");
                 return false;
             }
             if (isNaN(Head_W) || Head_W < 0) {
                 layer.msg("头像宽度必须为数字,且大于0!");
                 return false;
             }
             if (Head_H == null || Head_H == '') {
                 layer.msg("头像高度必填!");
                 return false;
             }
             if (isNaN(Head_H) || Head_H < 0) {
                 layer.msg("头像高度必须为数字,且大于0!");
                 return false;
             }
             if (Head_X == null || Head_X == '') {
                 layer.msg("头像X轴位置必填!");
                 return false;
             }
             if (isNaN(Head_X) || Head_X < 0) {
                 layer.msg("头像X轴位置必须为数字,且大于0!");
                 return false;
             }
             if (Head_Y == null || Head_Y == '') {
                 layer.msg("头像Y轴位置必填!");
                 return false;
             }
             if (isNaN(Head_Y) || Head_Y < 0) {
                 layer.msg("头像Y轴位置必须为数字,且大于0!");
                 return false;
             }

             if (W == null || W == '') {
                 layer.msg("二维码宽度必填!");
                 return false;
             }
             if (isNaN(W) || W < 0) {
                 layer.msg("二维码宽度必须为数字,且大于0!");
                 return false;
             }
             if (H == null || H == '') {
                 layer.msg("二维码高度必填!");
                 return false;
             }
             if (isNaN(H) || H < 0) {
                 layer.msg("二维码高度必须为数字,且大于0!");
                 return false;
             }
             if (X == null || X == '') {
                 layer.msg("二维码X轴位置必填!");
                 return false;
             }
             if (isNaN(X) || X < 0) {
                 layer.msg("二维码X轴位置必须为数字,且大于0!");
                 return false;
             }
             if (Y == null || Y == '') {
                 layer.msg("二维码Y轴位置必填!");
                 return false;
             }
             if (isNaN(Y) || Y < 0) {
                 layer.msg("二维码Y轴位置必须为数字,且大于0!");
                 return false;
             }

             if (NickName_Size != null && NickName_Size != '') {
                 if (isNaN(NickName_Size) || NickName_Size < 0) {
                     layer.msg("会员昵称字号必须为数字,且大于0!");
                     return false;
                 }
             }

             if (NickName_X != null && NickName_X != '') {
                 if (isNaN(NickName_X) || NickName_X < 0) {
                     layer.msg("会员昵称X轴位置必须为数字,且大于0!");
                     return false;
                 }
             }
             if (NickName_Y != null && NickName_Y != '') {
                 if (isNaN(NickName_Y) || NickName_Y < 0) {
                     layer.msg("会员昵称Y轴位置必须为数字,且大于0!");
                     return false;
                 }
             }
             return true;
         }
        function Show() {
            if (check()) {
                var MainImageURL = mInfo.ImageURL; // $("#hidImageURL").val(); //活动二维码背景图
                var Head_W = $("#txtHead_W").val();
                var Head_H = $("#txtHead_H").val();
                var Head_X = $("#txtHead_X").val();
                var Head_Y = $("#txtHead_Y").val();

                var W = $("#txtCode_W").val();
                var H = $("#txtCode_H").val();
                var X = $("#txtCode_X").val();
                var Y = $("#txtCode_Y").val();

                var NickName_Size = $("#txtNickName_Size").val();
                var NickName_Font = $("#txtNickName_Font").val();
                var NickName_Color = $("#txtNickName_Color").val();
                var NickName_X = $("#txtNickName_X").val();
                var NickName_Y = $("#txtNickName_Y").val();
                var myDate = new Date();
                var url = "PreviewCodeImage.aspx?ImageUrl=" + encodeURIComponent(MainImageURL) + "&HeadW=" + Head_W + "&HeadH=" + Head_H + "&HeadX=" + Head_X + "&HeadY=" + Head_Y + "&CodeW=" + W + "&CodeH=" + H + "&CodeX=" + X + "&CodeY=" + Y + "&NickSize=" + NickName_Size + "&NickFont=" + encodeURIComponent(NickName_Font) + "&NickColor=" + encodeURIComponent(NickName_Color) + "&NickX=" + NickName_X + "&NickY=" + NickName_Y + "&mydt=" + myDate.getMinutes() + myDate.getSeconds();
                var index = layer.open({
                    title: '二维码预览',
                    type: 2,
                    area: ['400px', '500px'],
                    fix: false,
                    maxmin: false,
                    scrollbar: false,
                    content: url,
                    end: function () {
                    }
                });
            }
        }
        function Save() {
            if (check()) {
                layer.load(0, { shade: true });
                mInfo.Head_W = $("#txtHead_W").val();
                mInfo.Head_H = $("#txtHead_H").val();
                mInfo.Head_X = $("#txtHead_X").val();
                mInfo.Head_Y = $("#txtHead_Y").val();
                mInfo.Code_W = $("#txtCode_W").val();
                mInfo.Code_H = $("#txtCode_H").val();
                mInfo.Code_X = $("#txtCode_X").val();
                mInfo.Code_Y = $("#txtCode_Y").val();
                mInfo.NickName_Size = $("#txtNickName_Size").val();
                mInfo.NickName_Font =$("#txtNickName_Font").val();
                mInfo.NickName_Color =  $("#txtNickName_Color").val();
                mInfo.NickName_X = $("#txtNickName_X").val();
                mInfo.NickName_Y = $("#txtNickName_Y").val();
                var mSystemSetInfo = {};
                mSystemSetInfo.FSetID = mSetID;
                mSystemSetInfo.FSetName = mFSetName;
              
                mSystemSetInfo.FSetValue = JSON.stringify(mInfo);
                var params = { pInfo: syJsonSafe(mSystemSetInfo) };
                syAjax("POST", false, ConApiUrl + 'api/BaseSet/SystemControl/UpdateOne', puMInfo.appKeyId, params, UpdateOneBack, syAjaxErrorBack);
            }
           

           
        }
        function UpdateOneBack(json) {
            layer.closeAll();
            if (json && json.Data) {
                if (json.Data == 1) {
                    ConShowMsg("保存成功", "SystemSet.aspx");
                }
                else {
                    ConShowMsg("保存失败，请稍后尝试");
                }
            }
        }
    </script>
</body>
</html>
