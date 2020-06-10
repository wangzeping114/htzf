<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PowerGroupSet.aspx.cs" Inherits="User_PowerGroupSet" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>权限组编辑</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
    <link href="../assets/css/newly.css?v=4.4.0" rel="stylesheet">
    <link href="../assets/css/pintuer.css" rel="stylesheet">
    <link href="../assets/css/style.css?v=4.1.4" rel="stylesheet">
    <style type="text/css">
        h4{padding:10px 0;}
        h5{padding-bottom:10px;}
        .ss{padding:10px 50px;}
        ul li{padding-top:5px;}
        .cx{height:auto;padding:10px;clear:both;}
        .ness_ul{border:1px solid #D4D4D4;padding:10px 15px 0;display:-webkit-flex;display:-moz-flex;display:-ms-flex;display:-o-flex;display:flex;-webkit-align-content:flex-start;-moz-align-content:flex-start;-ms-align-content:flex-start;-o-align-content:flex-start;align-content:flex-start;-webkit-align-items:flex-start;-moz-align-items:flex-start;-ms-align-items:flex-start;-o-align-items:flex-start;align-items:flex-start;-webkit-flex-direction:row;-moz-flex-direction:row;-ms-flex-direction:row;-o-flex-direction:row;flex-direction:row;-webkit-flex-wrap:wrap;-moz-flex-wrap:wrap;-ms-flex-wrap:wrap;-o-flex-wrap:wrap;flex-wrap:wrap;}
        .role-group{width:220px;margin-bottom:10px;}
        .eliminate{clear:both;}
        .Lefts{float:left;}               
    </style>
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
                        <a href="PowerGroupList.aspx">权限组</a>
                    </li>
                    <li>
                        <strong>编辑</strong>
                    </li>
                </ol>
            </div>
            <div class="col-sm-2 tr">
                <a href="PowerGroupList.aspx" class="btn btn-xs btn-primary">返回列表</a>
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
                                <label class="col-sm-2 control-label">权限组名称</label>
                                <div class="col-sm-8">
                                    <input id="txtName" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">权限组说明</label>
                                <div class="col-sm-8">
                                    <input id="txtDescription" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div>
                            <div class="form-group">
                                    <label  class="col-sm-2 control-label">是否为超级管理员:</label>
                                <div class="col-sm-8">
                                    <label for="sm">
                                        <input type="checkbox" name="chkAdmin" id="sm" class="chkadmin"  />
                                        <span class="icon-square-o checkbox text-sub"></span>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                    <label class="col-sm-2 control-label">选择对应权限:</label>
                                <div class="col-sm-8">
                                    <h4>
                                        <label for="qx">
                                            <input type="checkbox" name="chkRole" class="chkRole" value="全选" id="qx" />
                                            <span class="icon-square-o checkbox text-sub"></span>
                                            <b>全选</b>
                                        </label>
                                    </h4>
                                    <div id="chkStqx"></div>
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
 <script type="text/html" id="tpl">
        {{# if (d && d.length > 0 ) { }}
        {{# for (var i = 0;  i < d.length;  i++) { }}
        {{# if(d[i].Id>0){ }}
            <div class="cx">
                <h5>
                    <label for="f{{d[i].Id}}">
                        <input type='checkbox' value='{{d[i].Id}}' class="chkRole" onclick="choice(this, 'name')" id='f{{d[i].Id}}' />
                        <span class="icon-square-o checkbox text-sub"></span>
                        <b style="font-size:16px;">{{d[i].Name}}</b>
                    </label>
                </h5>
                <div class="ness_ul">
                {{# for (var j = 0;j < d[i].Children.length; j++) { }}
                {{# if(d[i].Id==d[i].Children[j].ParentId){ }}
                    <div class="role-group">
                        <label for="f{{d[i].Children[j].Id}}">
                            <input type='checkbox' name='s{{d[i].Id}}' class="chkRole" onclick="choice(this)" value='{{d[i].Children[j].Id}}' id='f{{d[i].Children[j].Id}}' />
                            <span class="icon-square-o checkbox text-sub"></span>
                            <b>{{d[i].Children[j].Name}}</b>
                        </label>
                        
                    </div>
                {{# } }}
                {{# } }}
                </div>
            </div>
        {{# } }}
        {{# } }}
        {{# } }}
    </script>
    <script>


        //选择大类型  小类型都被选中
        function choice(obj, key) {
            var item_id = obj.value,
                checkbox = $(obj);

            if (checkbox.prop('checked')) {
                setChecked(checkbox);
                key && setChecked($("input[" + key + "=s" + item_id + "]"));
            } else {
                setUnChecked(checkbox);
                key && setUnChecked($("input[" + key + "=s" + item_id + "]"));
            }

            validateParentFunc(checkbox, 'name');
        }
        function setChecked(obj) {
            obj.prop('checked', true).next().removeClass('icon-square-o').addClass('icon-check-square-o');
        }

        function setUnChecked(obj) {
            obj.prop('checked', false).next().removeClass('icon-check-square-o').addClass('icon-square-o');
        }
        function validateParentFunc(obj, attr) {
            if (obj.attr(attr)) {
                var parent_func = $('#f' + obj.attr(attr).substring(1));
                if (obj.prop('checked') && !parent_func.prop('checked')) {
                    setChecked(parent_func);
                } else if (!obj.prop('checked')) {
                    var parent_flag = false;
                    $('input:checkbox[' + attr + '="' + obj.attr(attr) + '"]').each(function (i, item) {
                        $(item).prop('checked') && (parent_flag = true);
                    });

                    !parent_flag && setUnChecked(parent_func);
                }
            }
        }

        var mID;
        var mInfo = {};
        $(function () {
            mID = syUrlParam("id");
            GetAllFunction();
            Open();
            $("#qx").click(function () {
                this.checked ? setChecked($("input:checkbox.chkRole")) : setUnChecked($("input:checkbox.chkRole"));
            });
            $("#sm").click(function () {
                this.checked ? setChecked($("input:checkbox.chkadmin")) : setUnChecked($("input:checkbox.chkadmin"));
            });
        })

        function Open() {
            var params = {
                //pFSchoolID: mID
            };
            syAjaxWithHeader(puMInfo,"Get", false, ConApiUrl + 'manage/passprot/getmenusbyroleId/'+mID, "AppManage:123", params, GetInfoBack, syAjaxErrorBack);

        }
        function GetInfoBack(json) {
            if (json && json.Result) {
                mInfo = json.Result;
                $("#txtName").val(mInfo.Name);
                $("#txtDescription").val(mInfo.Description);
               if(mInfo.IsSuperAdmin) {
                   setChecked($("#sm"));
               }
                var wod = json.Result.RoleMenuIds;
                for (var i = 0; i < wod.length; i++) {
                    setChecked($("#f" + wod[i]));
                }
            }
        }
        function GetAllFunction() {
            var params = {
                  
            };
            syAjaxWithHeader(puMInfo,"Get", false, ConApiUrl + 'manage/passprot/getmenus', "AppManage:123", params, AllFunctionBack, syAjaxErrorBack);
        }
        function AllFunctionBack(json) {
            if (json) {
                if (json.StatusCode == "0") {
                    var tpl = document.getElementById("tpl").innerHTML;
                    laytpl(tpl).render(json.Result || [], function (html) {
                        $("#chkStqx").html(html);
                       // id && id != "undefined" && ndividualrights(id);
                    });
                }
                else {
                    ConShowMsg("请管理员分配权限后，刷新本页面！")
                }
            } else {
                ConShowMsg("请检查网络状态");
            }
        }

        function Save() {
            var aggregate = []; //声明一个数组装权限组的id
            $("input:checkbox.chkRole:not([id=qx])").each(function (index) {
                $(this).prop('checked') && aggregate.push($(this).val());
            });
            console.log(aggregate); 
            if (aggregate.length) {
                layerIndex = layer.msg('数据加载中...', { icon: 16 });
 
            
            var params = {
                Name : $("#txtName").val(),
                Description : $("#txtDescription").val(),
                IsSuperAdmin : $("#sm").prop('checked'),
                    MenusId: aggregate
                };
                if (mID > 0) {
                    params.Id = mID;
                    syAjaxWithHeader(puMInfo,"POST", false, ConApiUrl + 'manage/passprot/modifyrolemenu', "AppManage:123", params, SetTPartnerInfofBack, syAjaxErrorBack);
            } else {
                syAjaxWithHeader(puMInfo,"POST", false, ConApiUrl + 'manage/passprot/addrolemenu', "AppManage:123", params, SetTPartnerInfofBack, syAjaxErrorBack);
            }
           
            }
        }
        function SetTPartnerInfofBack(json) {
           
            if (json.StatusCode=="0") {
                ConShowMsg(json.StatusMessage, "PowerGroupList.aspx");
            }
            else {
                ConShowMsg(json.StatusMessage);
            }
            
        }
    </script>
</body>
</html>
