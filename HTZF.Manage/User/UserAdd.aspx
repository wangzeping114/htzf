<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAdd.aspx.cs" Inherits="User_UserAdd" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户编辑</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
</head>
<body class="gray-bg"> 
<div class="form-horizontal">
    <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-10">
                <ol class="breadcrumb">
                    <li>
                        <a href="../index/index.aspx">用户管理</a>
                    </li>
                    <li>
                        <a href="AdvertList.aspx">用户列表</a>
                    </li>
                    <li>
                        <strong>用户编辑</strong>
                    </li>
                </ol>
            </div>
            <div class="col-sm-2 tr">
                <a href="UserList.aspx" class="btn btn-xs btn-primary">返回列表</a>
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
                                <label class="col-sm-2 control-label">用户账号</label>
                                <div class="col-sm-8">
                                    <input id="txtUserName" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 



                            <div class="form-group">
                                <label class="col-sm-2 control-label">姓名</label>
                                <div class="col-sm-8">
                                    <input id="txtFullName" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 

                           

                            <div class="form-group">
                                <label class="col-sm-2 control-label">用户密码</label>
                                <div class="col-sm-8">
                                    <input id="txtPassword" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label class="col-sm-2 control-label">确认密码</label>
                                <div class="col-sm-8">
                                    <input id="txtPassword2" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">权限组</label>
                                <div class="col-sm-8">
                                    <select id="txtRole"  class="form-control" >
                                    </select>
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
        var puMInfo;
        $(function () {
            mID = syUrlParam("id");
            GetAllRole();
            if (localStorage.MInfo) {
                puMInfo = JSON.parse(localStorage.MInfo);
            }
            if (mID)
            {
                Open();
            }
        })
        function GetAllRole() {
            var params = {
                  
            };
            syAjaxWithHeader(puMInfo,"Get", false, ConApiUrl + 'manage/passprot/getroles', "AppManage:123", params, AllFunctionBack, syAjaxErrorBack);
        }
        function AllFunctionBack(json) {
            if (json) {
                if (json.StatusCode == "0") {
                    var html = '<option value="">请选择权限</option>';　
                    for (var i = 0; i < json.Result.length; i++) {
                        html += '<option value="' + json.Result[i].Id + '">' + json.Result[i].Name + '</option>';
                    }
                    $("#txtRole").html(html);
                }
                
            } else {
                ConShowMsg("请检查网络状态");
            }
        }
        function Open() {
            var params = {
                //pFSchoolID: mID
            };
            syAjaxWithHeader(puMInfo,"Get", false, ConApiUrl + 'manage/passprot/getaccountbyId/'+mID, "AppManage:123", params, GetInfoBack, syAjaxErrorBack);

        }
        function GetInfoBack(json) {
            if (json && json.Result) {
                mInfo = json.Result;
                $("#txtUserName").val(mInfo.UserName);
                $("#txtFullName").val(mInfo.FullName);
                $("#txtPassword").val(mInfo.Password);
                $("#txtPassword2").val(mInfo.Password);
                $("#txtRole").val(mInfo.RoleId);
            }
        }
        function Save() {
            if ($("#txtPassword").val()!=$("#txtPassword2").val()) {
                ConShowMsg("确认密码与用户密码不同，请重新输入！");
                return;
            }
            var params = {
                UserName : $("#txtUserName").val(),
                FullName : $("#txtFullName").val(),
                RoleId: $("#txtRole").val()
            };
            if ($("#txtPassword").val()) {
                params.Password = $("#txtPassword").val();
            }
            if (mID > 0) {
                params.Id = mID;
                syAjaxWithHeader(puMInfo,"POST", false, ConApiUrl + 'manage/passprot/modifyaccount', "AppManage:123", params, SetTPartnerInfofBack, syAjaxErrorBack);
            } else {
                syAjaxWithHeader(puMInfo,"POST", false, ConApiUrl + 'manage/passprot/addappuser', "AppManage:123", params, SetTPartnerInfofBack, syAjaxErrorBack);
            }

           
        }
        function SetTPartnerInfofBack(json) {
           
                if (json.StatusCode=="0") {
                    ConShowMsg(json.StatusMessage, "UserList.aspx");
                }
                else {
                    ConShowMsg(json.StatusMessage);
                }
            
        }
     
    </script>
</body>
</html>
