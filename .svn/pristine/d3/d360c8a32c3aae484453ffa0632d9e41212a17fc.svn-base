<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VersionManagement.aspx.cs" Inherits="Version_VersionManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>版本更新</title>
    <!--#include virtual="../publichtml/pubHead.htm" -->
</head>

<body class="gray-bg">
    <div class="form-horizontal">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-12">
                <ol class="breadcrumb">
                    <li>版本更新</li>
                    <li>版本设置</li>
                </ol>
            </div>
        </div>
        <div class="wrapper wrapper-content animated fadeInRight">
            <div class="col-sm-12">
                <div class="ibox float-e-margins qsearch">
                    <div class="ibox-content">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">版本名称</label>
                            <div class="col-sm-8">
                                <input id="pVersionName" type="text" class="form-control input-sm" placeholder="版本名称" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">版本号</label>
                            <div class="col-sm-8">
                                <input id="pVersionCode" type="text" class="form-control input-sm" placeholder="版本号" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">上传安装包地址</label>
                            <div class="col-sm-8">
                                <input id="UploadFileUrl" type="text" class="form-control input-sm"></input>                                        
                                <input id="pVersionSaveURL" onchange="setVcVideoName()" type="file" class="form-control input-sm" placeholder="上传地址" style="display:none" />
                            </div>
                            <div class="col-sm-1">
                                    <span class="input-group-btn">
                                        <a href="javascript:;" class="btn btn-success btn-sm " onclick="UploadFile()" id="btnUpFile"><i class="fa fa-plus"></i>上传安装包</a>
                                        </span>
                                </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">客户端</label>
                            <div class="col-sm-8">
                                安卓：<input type="radio" name="Client"  id="android" value="0">
                                IOS:<input type="radio" name="Client"  id="ios" value="1">
                            </div>
                        </div>
                        <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-8">
                                    <a class="btn btn-success btn-sm " href="javascript:;" onclick="Update()">保存</a>
                                    <a class=" btn btn-primary btn-sm ml20" href="VersionList.aspx">返回</a>
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        var mInfo = {};
        var mID;
        var pInfo;
        $(function () {
            mID = syUrlParam("id");
            if (mID) {
                Query();
            }
        })
        function Query() {
            var params = {
                pAppID: mID
            };
            syAjax("POST", false, ConApiUrl + 'api/Version/VersionSet/GetOneVersion', puMInfo.appKeyId, params, GetOneByIDBack, syAjaxErrorBack);

        }

        $('input:radio').click(function () {

            var domName = $(this).attr('name');
            var $radio = $(this);
            if ($radio.data('waschecked') == true) {
                $radio.prop('checked', false);
                $("input:radio[name='" + domName + "']").data('waschecked', false);
            } else {
                $radio.prop('checked', true);
                $("input:radio[name='" + domName + "']").data('waschecked', false);
                $radio.data('waschecked', true);
            }
        });


        function GetOneByIDBack(json) {
            if (json && json.Data) {
                mInfo = json.Data.data;
                $("#pVersionName").val(mInfo.FVersionName);
                $("#pVersionCode").val(mInfo.FVersionCode);
                $("#UploadFileUrl").val(mInfo.FVersionSaveURL);
                $('input:radio').eq(mInfo.FType).attr('checked', 'true');
            } else {
                ConShowMsg("获取信息失败", "VersionList.aspx");
            }
        }
        function UploadFile() {
            $("#pVersionSaveURL").click();
        }
        function setVcVideoName() {
            UploadImg();
        }

        function UploadImg() {
            var formData = new FormData();
            var mediaFile = $("#pVersionSaveURL").prop('files')[0];
            formData.append('fileUp', mediaFile);

            $.ajax({
                url: ConApiUrl + "api/Controls/CreateImage/UploadFiles",
                beforeSend: function (request) {
                    request.setRequestHeader("appKeyId", puMInfo.appKeyId);
                },
                type: 'post',
                dataType: 'json',
                data: formData,
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.Data) {
                        $("#UploadFileUrl").val(res.Data.url);
                        ConShowMsg(res.Data.msg);
                    }

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    layer.closeAll();
                    layer.open({
                        content: '网络异常请检查网络', skin: 'msg', time: 3
                    });
                }
            });
        }
        function Update() {
            var oVersionName = $("#pVersionName").val();
            var oVersionCode = $("#pVersionCode").val();
            var oVersionSaveURL = $("#UploadFileUrl").val();
            var oType = $('input:radio:checked').val();
            if (oVersionName && oVersionCode && oVersionSaveURL && oType) {
                if (mID) {
                    mInfo.FAppID = mID;
                    mInfo.FVersionName = oVersionName;
                    mInfo.FVersionCode = oVersionCode;
                    mInfo.FVersionSaveURL = oVersionSaveURL;
                    mInfo.FType = oType;
                    var params = { pInfo: syJsonSafe(mInfo) };
                    syAjax("POST", false, ConApiUrl + 'api/Version/VersionSet/UpdateOne', puMInfo.appKeyId, params, UpdateOneBack, syAjaxErrorBack);
                }
                else {
                    mInfo.FVersionName = oVersionName;
                    mInfo.FVersionCode = oVersionCode;
                    mInfo.FVersionSaveURL = oVersionSaveURL;
                    mInfo.FType = oType;
                    var params = { pInfo: syJsonSafe(mInfo) };
                    syAjax("POST", false, ConApiUrl + 'api/Version/VersionSet/InsertOne', puMInfo.appKeyId, params, UpdateOneBack, syAjaxErrorBack);
                }
            } else {
                ConShowMsg("值不能为空");
            }
        }
        function UpdateOneBack(json) {
            if (json && json.Data) {
                if (json.Data == 1) {
                    ConShowMsg("保存成功", "VersionList.aspx");
                }
                else {
                    ConShowMsg("保存失败，请稍后尝试");
                    Query();
                }
            }
        }
    </script>
</body>
</html>
