<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VersionList.aspx.cs" Inherits="Version_VersionList" %>

<!doctype html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>版本列表</title>
    <!--#include virtual="../publichtml/pubHead.htm" -->
</head>

<body class="gray-bg">
    <div class="form-horizontal">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-12">
                <ol class="breadcrumb">
                    <li>版本更新
                    </li>
                    <li>版本列表
                    </li>
                </ol>
            </div>
        </div>
        <div class="wrapper wrapper-content animated fadeInRight">
            <div class="col-sm-12">
                <div class="ibox float-e-margins qsearch">
                    <div class="ibox-title">
                        <h5>版本列表管理</h5>
                    </div>
                    <div class="ibox-content">
                        <a class=" btn btn-primary btn-sm ml20" href="VersionManagement.aspx">新增 <i class="fa fa-plus"></i></a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-content view-body">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/html" id="tpl">
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>AppID</th>
                    <th>版本名</th>
                    <th>版本号</th>
                    <th>保存地址</th>
                    <th>上传时间</th>
                    <th>客户端</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                {{# if (d && d.length > 0) { }}
                                         {{# for (var i = 0;i< d.length;  i++) { }}
                                             <tr>
                                                 <td>{{d[i].FAppID}}</td>
                                                 <td>{{d[i].FVersionName}}</td>
                                                 <td>{{d[i].FVersionCode}}</td>
                                                 <td>{{d[i].FVersionSaveURL}}</td>
                                                 <td>{{syFormatDate(d[i].FUploadTime,'yyyy-MM-dd hh:mm')}}</td>
                                                 <td>{{d[i].FType==0?'安卓':'IOS'}}</td>
                                                 <td>
                                                     <a href="javascript:;" class="btn btn-primary btn-sm ml5" onclick="Update({{d[i].FAppID}})">编 辑 <i class="fa fa-edit"></i></a>
                                                     <a href="javascript:;" class="btn btn-danger btn-sm ml5" onclick="DeleteOne({{d[i].FAppID}})">删 除 <i class="fa fa-trash-o"></i></a>
                                                 </td>
                                             </tr>
                {{# } }}
                                         {{# } else { }}
                                            <tr>
                                                <td colspan="7" class="tc">未查询到符合条件的记录
                                                </td>
                                            </tr>
                {{# } }}
            </tbody>
        </table>
    </script>
    <script>
        var mAllList = [];//声明一个
        var tpl = document.getElementById("tpl").innerHTML;
        $(function () {
            Query();
        })

        function Query(pPageIndex) {
            mAllList = [];
            var params = {
            };
            syAjax("POST", false, ConApiUrl + 'api/Version/VersionSet/GetVersionList', puMInfo.appKeyId, params, GetVersionListBack, syAjaxErrorBack);
        }
        function GetVersionListBack(json) {
            if (json && json.Data) {
                json = json.Data;
                mAllList = json.data;

                laytpl(tpl).render(mAllList || [], function (html) {
                    $(".view-body").html(html);
                });

            }
        }
        
        function Update(pID) {
            document.location.href = "VersionManagement.aspx?id=" + pID;
        }

        function DeleteOne(pID) {
            var msg = "是否确认删除？"
            layer.confirm(msg, {
                btn: ['确认', '取消'] //按钮
            }, function () {
                var params = {
                    pAppID: pID
                };
                layer.msg('数据删除中', { icon: 16, shade: [0.5, '#393D49'], time: 0 });
                syAjax("POST", false, ConApiUrl + 'api/Version/VersionSet/DeleteOneVersion', puMInfo.appKeyId, params, DeleteOneBack, syAjaxErrorBack);
            });
        }
        function DeleteOneBack(json) {
            if (json && json.Data == 1)
            {
                    ConShowMsg("删除成功");
                    Query();
            }
            else
            {
                    ConShowMsg(json.Info);
            }
        }
    </script>
</body>
</html>
