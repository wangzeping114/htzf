<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderInfo.aspx.cs" Inherits="Order_OrderInfo" %>
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
                <a href="SchoolList.aspx" class="btn btn-xs btn-primary">返回列表</a>
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
                                <label class="col-sm-2 control-label">学校名称</label>
                                <div class="col-sm-8">
                                    <input id="txtFSchoolName" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label class="col-sm-2 control-label">简称</label>
                                <div class="col-sm-8">
                                    <input id="txtFAbbreviation" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label class="col-sm-2 control-label">法人代表</label>
                                <div class="col-sm-8">
                                    <input id="txtFOwner" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label class="col-sm-2 control-label">所属省</label>
                                <div class="col-sm-8">
                                    <input id="txtFProvince" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label class="col-sm-2 control-label">所属市</label>
                                <div class="col-sm-8">
                                    <input id="txtFCity" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label class="col-sm-2 control-label">所属区域</label>
                                <div class="col-sm-8">
                                    <input id="txtFCounty" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label class="col-sm-2 control-label">联系电话</label>
                                <div class="col-sm-8">
                                    <input id="txtFSchoolTel" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label class="col-sm-2 control-label">联系人</label>
                                <div class="col-sm-8">
                                    <input id="txtFSchoolLinker" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">返利额度</label>
                                <div class="col-sm-8">
                                    <input id="txtFRebate" type="text" required class="form-control" placeholder=""/>
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
        var mID = 0;
        var mInfo = {};
        $(function () {
            mID = syUrlParam("id");
            if (mID)
            {
                Open();
            }
        })
        function Open() {
            var params = {
                pFSchoolID: mID
            };
            console.log(params)
            syAjax("POST", false, ConApiUrl + 'api/BaseSet/tadvertControl/GetTschoolInfo', puMInfo.appKeyId, params, GetTschoolInfoBack, syAjaxErrorBack);

        }
        function GetTschoolInfoBack(json) {
            console.log(json);
            if (json && json.Data) {
                mInfo = json.Data;
                $("#txtFSchoolName").val(mInfo.FSchoolName);
                $("#txtFAbbreviation").val(mInfo.FAbbreviation);
                $("#txtFOwner").val(mInfo.FOwner);
                $("#txtFProvince").val(mInfo.FProvince);
                $("#txtFCity").val(mInfo.FCity);
                $("#txtFCounty").val(mInfo.FCounty);
                $("#txtFSchoolTel").val(mInfo.FSchoolTel);
                $("#txtFSchoolLinker").val(mInfo.FSchoolLinker);
                $("#txtFRebate").val(mInfo.FRebate);
                //if (mInfo.FFlag == 1) {
                //    $("#txtFPartnerType").attr("disabled", true);
                //}
                if (mInfo.FFlag == 1) {
                    $("#txtFRebate").attr("disabled", true);
                }
                else {
                    $("#btnSave").html("<i class='fa fa-save'></i>审核通过");
                }
            }
        }
        function Save() {
            mInfo.FSchoolName = $("#txtFSchoolName").val();
            mInfo.FAbbreviation = $("#txtFAbbreviation").val();
            mInfo.FOwner = $("#txtFOwner").val();
            mInfo.FProvince = $("#txtFProvince").val();
            mInfo.FCity = $("#txtFCity").val();
            mInfo.FCounty = $("#txtFCounty").val();
            mInfo.FSchoolTel = $("#txtFSchoolTel").val();
            mInfo.FSchoolLinker = $("#txtFSchoolLinker").val();
            mInfo.FRebate = $("#txtFRebate").val();
            if (mInfo.FFlag == 0) {
                mInfo.FFlag = 1;
            }
            //if (!mInfo.FFlag) {
            //    ConShowMsg("请选择状态");
            //    return;
            //}
            //if (!mInfo.FAddress) {
            //    ConShowMsg("请填写老师激活码");
            //}
            var params = { pInfo: syJsonSafe(mInfo) };
            syAjax("POST", false, ConApiUrl + 'api/User/tschoolsControl/SaveTschoolsInfo', puMInfo.appKeyId, params, SetTPartnerInfofBack, syAjaxErrorBack);
        }
        function SetTPartnerInfofBack(json) {
            if (json && json.Data) {
                if (json.Data.flag) {
                    ConShowMsg(json.Data.msg, "SchoolList.aspx");
                }
                else {
                    ConShowMsg(json.Data.msg);
                }
            }
        }
        //function ShowUpMainImg() {
        //    syOpenUploadImgDialog({
        //        url: '../Controls/UploadImage.aspx',
        //        method: 'getUploadImg',
        //        totalGraph: 1
        //    });
        //}
        //function getUploadImg(url) {
        //    $("#imgMain").attr("src", url)
        //    $("#img-box img").attr("src", url);
        //    $("#img-box").removeClass("hidden");
        //    mInfo.FAd_Img = url;
        //    layer.closeAll();
        //}
    </script>
</body>
</html>
