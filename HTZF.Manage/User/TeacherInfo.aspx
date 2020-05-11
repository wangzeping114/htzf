<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherInfo.aspx.cs" Inherits="BaseSet_AdvertInfo" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Banner编辑</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
</head>
<body class="gray-bg"> 
<div class="form-horizontal">
    <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-10">
                <ol class="breadcrumb">
                    <li>
                        <a href="../index/index.aspx">首页</a>
                    </li>
                    <li>
                        <a href="AdvertList.aspx">列表</a>
                    </li>
                    <li>
                        <strong>详细信息</strong>
                    </li>
                </ol>
            </div>
            <div class="col-sm-2 tr">
                <a href="AdvertList.aspx" class="btn btn-xs btn-primary">返回列表</a>
            </div>

      </div>
    <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-sm-10">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>单页信息</h5>
                        </div>
                        <div class="ibox-content">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">老师编号</label>
                                <div class="col-sm-8">
                                    <input id="txtFTeacherID" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">老师名称</label>
                                <div class="col-sm-8">
                                    <input id="txtFTeacherName" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div>
                           <div class="form-group">
                                <label class="col-sm-2 control-label">老师电话</label>
                                <div class="col-sm-8">
                                    <input  type="text" value="" id="txtFTeacherTel" class="form-control valid" placeholder="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">老师头像</label>
                                <div class="col-sm-8">
                                    <div id="img-box" class="img-view-box">
                                     <img class="img-border radius-small" style="height:80px; width:80px"   src="http://www.meizhuwl.net/img/addpic.png"  alt="暂无图片，点击切换图片"  id="imgMain" onclick="ShowUpMainImg()"   />
                                 </div> 
                                 <div class="input-note">如需修改作品，请点击上面图片</div>
                                </div>
                            </div> 
                             <div class="form-group">
                                <label class="col-sm-2 control-label">学校编号</label>
                                <div class="col-sm-8">
                                    <input id="txtFSchoolID" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div>
                           <div class="form-group">
                                <label class="col-sm-2 control-label">用户编号</label>
                                <div class="col-sm-8">
                                    <input  type="text" value="" id="txtFUserID" class="form-control valid" placeholder="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-8">
                                    <a class=" btn btn-primary btn-sm ml20" href="javascript:;" onclick="Save()" id="btnSave"><i class="fa fa-save"></i> 保 存</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</div> 
    <script>
        var mID;
        var mInfo = {};
        $(function () {
            mID = syUrlParam("id");
            IntialType();
        })

        function IntialType() {
            var params = {};
            syAjax("POST", false, ConApiUrl + 'api/BaseSet/tadvertControl/GetAllTadverttype', puMInfo.appKeyId, params, GetAllTadverttypeBack, syAjaxErrorBack);
        }
        function GetAllTadverttypeBack(json) {
            if (json && json.Data) {
                var oHtml = '';
                for (var i = 0; i < json.Data.length; i++) {
                    oHtml += '<option value="' + json.Data[i].FAdType_ID + '">' + json.Data[i].FAdTypeName + '</option>';
                }
                $("#selType").append(oHtml);
                if (mID) {
                    Open();
                }
            }
            else {
                $("#btnSave").hide();
                ConShowMsg("");
            }
        }
        function Open() {
            var params = {
                FTeacherID: mID
            };
            syAjax("POST", false, ConApiUrl + 'api/User/tteacherControl/GetTteacherInfo', puMInfo.appKeyId, params, GetTeacherInfoBack, syAjaxErrorBack);

        }
        function GetTeacherInfoBack(json) {
            if (json && json.Data) {
                mInfo = json.Data;
                $("#txtFTeacherID").val(mInfo.FTeacherID);
                $("#txtFTeacherName").val(mInfo.FTeacherName);
                $("#txtFTeacherTel").val(mInfo.FTeacherTel);
                $("#txtFUserID").val(mInfo.FUserID);
                $("#imgMain").attr("src", mInfo.FTeacherHeadImg);
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
            $("#imgMain").attr("src", url)
            $("#img-box img").attr("src", url);
            $("#img-box").removeClass("hidden");
            mInfo.FTeacherHeadImg = url;
            layer.closeAll();
        }
        function Save() {
            mInfo.FTeacherID = $("#txtFTeacherID").val();
            mInfo.FTeacherName = $("#txtFTeacherName").val();
            mInfo.FTeacherTel = $("#txtFTeacherTel").val();
            mInfo.FSchoolID = $("#txtFSchoolID").val();
            mInfo.FUserID = $("#txtFUserID").val();
            if (!mInfo.FTeacherID) { 
                ConShowMsg("请填写老师编号");
                return;
            }
            if (!mInfo.FTeacherName) {
                ConShowMsg("请填写老师名称");
                return;
            }
            if (!mInfo.FTeacherTel) {
                ConShowMsg("请填写老师电话");
                return;
            }
            if (!mInfo.FSchoolID) {
                ConShowMsg("请填写学校编号");
                return;
            }
            if (!mInfo.FUserID) {
                ConShowMsg("请填写用户编号");
                return;
            }
            var params = { pInfo: syJsonSafe(mInfo) };
            syAjax("POST", false, ConApiUrl + 'api/User/tteacherControl/SaveTteacherInfo', puMInfo.appKeyId, params, SaveTteacherInfoBack, syAjaxErrorBack);
        }
        function SaveTteacherInfoBack(json) {
            if (json && json.Data) {
                if (json.Data.flag) {
                    ConShowMsg(json.Data.msg, "TeacherList.aspx");
                }
                else {
                    ConShowMsg(json.Data.msg);
                }
            }
        }
    </script>
</body>
</html>
