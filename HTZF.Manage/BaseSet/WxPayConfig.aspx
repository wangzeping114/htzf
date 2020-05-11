<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxPayConfig.aspx.cs" Inherits="BaseSet_WxPayConfig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>系统设置</title>
    <!--#include virtual="../publichtml/pubHead.htm" -->
</head>

<body class="gray-bg">
    <div class="form-horizontal">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-12">
                <ol class="breadcrumb">
                    <li>系统设置
                    </li>
                    <li>系统设置
                    </li>
                    <li>微信配置
                    </li>
                </ol>
            </div>
        </div>
        <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-sm-10">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>微信配置信息</h5>
                        </div>
                        <div class="ibox-content">
                             <div class="form-group">
                                <label class="col-sm-2 control-label">微信平台ID：*</label>
                                <div class="col-sm-8">
                                     <input id="txtFAppWI_AppID" type="text" class="form-control input-sm" placeholder="微信平台ID" />
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-sm-2 control-label">应用秘钥：*</label>
                                <div class="col-sm-8">
                                     <input id="txtFAppWI_AppSecret" type="text" class="form-control input-sm" placeholder="应用秘钥" />
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-sm-2 control-label">商户号：*</label>
                                <div class="col-sm-8">
                                     <input id="txtFAppWI_MCHID" type="text" class="form-control input-sm" placeholder="商户号" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">商户支付秘钥：*</label>
                                <div class="col-sm-8">
                                     <input id="txtFAppWI_PayKey" type="text" class="form-control input-sm" placeholder="商户支付秘钥" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">微信结算费率：*</label>
                                <div class="col-sm-8">
                                     <input id="txtSettlementRate" type="text" value="0.006" class="form-control input-sm" placeholder="微信结算费率" />
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-sm-2 control-label">启用子商户：*</label>
                                <div class="col-sm-8">
                                   <select id="selFAppWI_IsBehalfPay" class="form-control" onchange="FAppWI_IsBehalfPayChanged()">
                                            <option value="0">不启用</option>
                                          <option value="1">启用</option>
                                        </select>
                                </div>
                            </div>
                            <div class="form-group svr">
                                <label class="col-sm-2 control-label">服务商appid：</label>
                                <div class="col-sm-8">
                                     <input id="txtFAppWI_SvrAppID" type="text" class="form-control input-sm" placeholder="服务商appid" />
                                </div>
                            </div>
                            <div class="form-group svr">
                                <label class="col-sm-2 control-label">服务商商户号</label>
                                <div class="col-sm-8">
                                   <input id="txtFAppWI_SvrMCHID" type="text" class="form-control input-sm" placeholder="服务商商户号" />
                                </div>
                            </div>
                             <div class="form-group svr">
                                <label class="col-sm-2 control-label">服务商支付密钥：</label>
                                <div class="col-sm-8">
                                     <input id="txtFAppWI_SvrPayKey" type="text" class="form-control input-sm" placeholder="服务商支付密钥" />
                                </div>
                            </div>
                            <div class="form-group svr">
                                <label class="col-sm-2 control-label">子商户商户号</label>
                                <div class="col-sm-8">
                                   <input id="txtFAppWI_Sub_MCHID" type="text" class="form-control input-sm" placeholder="子商户商户号" />
                                </div>
                            </div> 
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-8">
                                    <a class="btn btn-success btn-sm" href="javascript:;" onclick="Update()" id="btnSave"><i class="fa fa-save"></i> 保 存</a>
                                    <a class=" btn btn-primary btn-sm ml20" href="SystemSet.aspx">返 回</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/html" id="tpl">
    </script>
    <script>
        var mInfo = {};
        var mSetID = 10010102; 
        $(function () {
            $(".svr").hide();
            $("#selFAppWI_IsBehalfPay").val(0)
            Query();
        })
        function FAppWI_IsBehalfPayChanged() {
            if ($("#selFAppWI_IsBehalfPay").val() == 0) {
                $(".svr").hide();
            }
            else {
                $(".svr").show();
            }
        }
        function Query() {
            var params = {
                pSetID: mSetID
            };
            syAjax("POST", false, ConApiUrl + 'api/BaseSet/SystemControl/GetOneByID', puMInfo.appKeyId, params, GetOneByIDBack, syAjaxErrorBack);

        }
        function GetOneByIDBack(json) {
            if (json && json.Data) { 
                mInfo = jQuery.parseJSON(json.Data.FSetValue);
                $("#txtFAppWI_AppID").val(mInfo.FAppWI_AppID);
                $("#txtFAppWI_AppSecret").val(mInfo.FAppWI_AppSecret);
                $("#txtFAppWI_MCHID").val(mInfo.FAppWI_MCHID);
                $("#txtFAppWI_PayKey").val(mInfo.FAppWI_PayKey);
                
                $("#txtFAppWI_SvrAppID").val(mInfo.FAppWI_SvrAppID);
                $("#txtFAppWI_SvrMCHID").val(mInfo.FAppWI_SvrMCHID);
                $("#txtFAppWI_SvrPayKey").val(mInfo.FAppWI_SvrPayKey);
                $("#txtFAppWI_Sub_MCHID").val(mInfo.FAppWI_Sub_MCHID);
                $("#txtSettlementRate").val(mInfo.SettlementRate);
            }
        }
        function Update() {
            mInfo.FAppWI_AppID = $("#txtFAppWI_AppID").val();
            if (!mInfo.FAppWI_AppID || mInfo.FAppWI_AppID.length < 1) {
                ConShowMsg("请设置微信平台ID");
                return;
            }
            mInfo.FAppWI_AppSecret = $("#txtFAppWI_AppSecret").val();
            if (!mInfo.FAppWI_AppSecret || mInfo.FAppWI_AppSecret.length < 1) {
                ConShowMsg("请设置应用秘钥");
                return;
            }
            mInfo.FAppWI_MCHID = $("#txtFAppWI_MCHID").val();
            if (!mInfo.FAppWI_MCHID || mInfo.FAppWI_MCHID.length < 1) {
                ConShowMsg("请设置商户号");
                return;
            }

            mInfo.FAppWI_PayKey = $("#txtFAppWI_PayKey").val();
            if (!mInfo.FAppWI_PayKey || mInfo.FAppWI_PayKey.length < 1) {
                ConShowMsg("请设置商户支付秘钥");
                return;
            }
            mInfo.FAppWI_SvrAppID = $("#txtFAppWI_SvrAppID").val();
            mInfo.FAppWI_SvrMCHID = $("#txtFAppWI_SvrMCHID").val();
            mInfo.FAppWI_SvrPayKey = $("#txtFAppWI_SvrPayKey").val();
            mInfo.FAppWI_Sub_MCHID = $("#txtFAppWI_Sub_MCHID").val();


            mInfo.FAppWI_IsBehalfPay = $("#selFAppWI_IsBehalfPay").val();
            if (mInfo.FAppWI_IsBehalfPay == 1) {
                if (!mInfo.FAppWI_SvrAppID || mInfo.FAppWI_SvrAppID.length < 1) {
                    ConShowMsg("请设置服务商appid");
                    return;
                }
                if (!mInfo.FAppWI_SvrMCHID || mInfo.FAppWI_SvrMCHID.length < 1) {
                    ConShowMsg("请设置服务商商户号");
                    return;
                }
                if (!mInfo.FAppWI_SvrPayKey || mInfo.FAppWI_SvrPayKey.length < 1) {
                    ConShowMsg("请设置服务商支付密钥");
                    return;
                }
                if (!mInfo.FAppWI_Sub_MCHID || mInfo.FAppWI_Sub_MCHID.length < 1) {
                    ConShowMsg("请设置子商户商户号");
                    return;
                }
            }

            mInfo.SettlementRate = $("#txtSettlementRate").val();
            var mSystemSetInfo = {};
            mSystemSetInfo.FSetID = mSetID;
            mSystemSetInfo.FSetName = '微支付配置';
            mSystemSetInfo.FSetValue = JSON.stringify(mInfo);
            var params = { pInfo: syJsonSafe(mSystemSetInfo) };
            syAjax("POST", false, ConApiUrl + 'api/BaseSet/SystemControl/UpdateOne', puMInfo.appKeyId, params, UpdateOneBack, syAjaxErrorBack);
        }
        function UpdateOneBack(json) {
            if (json && json.Data) {
                if (json.Data == 1) {
                    ConShowMsg("保存成功", "SystemSet.aspx");
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
