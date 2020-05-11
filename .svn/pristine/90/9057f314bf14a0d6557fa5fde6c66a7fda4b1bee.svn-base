<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PowerGroupList.aspx.cs" Inherits="User_PowerGroupList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>权限组列表</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
</head>

<body class="gray-bg">
    <div class="form-horizontal">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-12">
                <ol class="breadcrumb">
                    <li>
                        <a href="../index/index.html">用户管理</a>
                    </li>
                    <li>
                        权限组列表
                    </li>
                </ol>
            </div>
        </div>
        <div class="wrapper wrapper-content animated fadeInRight">
            <div class="col-sm-12">
                <div class="ibox float-e-margins qsearch">
                    <div class="ibox-title">
                        <h5>教师列表管理</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <div class="col-sm-3">
                                        <input id="txtFTeacherName" type="text" class="form-control input-sm" placeholder="老师名称" />
                                    </div>
                                   <div class="col-sm-1">
                                        <span class="input-group-btn">
                                            <a href="javascript:;" class="btn btn-success btn-sm " onclick="Query()"><i class="fa fa-search m-r-5"></i>搜索</a>
                                            <a class=" btn btn-primary btn-sm ml20" href="TeacherInfo.aspx">新增 <i class="fa fa-plus"></i></a>
                                            </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-content view-body">
                               
                            </div>
                            <div class="ibox-content">
                                <div class="pagelist form-group">
                                    <label class="pageSum col-sm-2 control-label" id="pagesum">总条数：100条</label>
                                     <div id="pages" class="page-box col-sm-8 cen">
                                    </div>
                                </div>
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
                                            <th>
                                                <input type="checkbox" data-id="" class="qx"/>
                                            </th>
                                            <th>老师编号</th>
                                            <th>老师名称</th>
                                            <th>老师电话</th>
                                            <th>老师头像</th>
                                            <th>简要描述</th>
                                            <th>学校编号</th>
                                            <th>用户编号</th>
                                            <th>操作</th>
                                            </tr>
                                    </thead>
                                    <tbody>
                                         {{# if (d && d.length > 0) { }}
                                         {{# for (var i = 0;i< d.length;  i++) { }}
                                             <tr>
                                                <td><input type="checkbox" data-id="{{d[i].FTeacherID}}" class="np"/> </td> 
                                                <td>{{d[i].FTeacherID}}</td>
                                                <td>{{d[i].FTeacherName}}</td>
                                                <td>{{d[i].FTeacherTel}}</td>
                                                <td><img src="{{d[i].FTeacherHeadImg}}" style="height:35px" /></td>
                                                <td>{{d[i].FTeacherDisc}}</td>
                                                <td>{{d[i].FSchoolID}}</td>
                                                <td>{{d[i].FUserID}}</td>
                                                <td>
                                                     <a href="javascript:;" class="btn btn-danger btn-sm ml5" onclick="Update('{{d[i].FTeacherID}}')">编 辑<i class="fa fa-edit"></i></a>
                                                    </td>
                                            </tr>
                                         {{# } }}
                                         {{# } else { }}
                                            <tr>
                                                <td colspan="9" class="tc">
                                                    未查询到符合条件的记录
                                                </td>           
                                            </tr>
                                         {{# } }}
                                    </tbody>
                                </table>
        </script>
    <script>
        var mAllList = [];//声明一个
        var mDefaultRecordCount = 0;
        var mDefaultPages = 0;
        var tpl = document.getElementById("tpl").innerHTML;
        var mPageSize = 10;//页面页数
        var mPageIndex = 1;//默认页数
        $(function () {
           Query();
        })
        function Query(pPageIndex) {
            mPageIndex = pPageIndex ? pPageIndex : 1;
            var params = {
                pPageSize: mPageSize,
                pPageIndex: mPageIndex,
                pFTeacherName: $("#txtFTeacherName").val()
               };
            syAjax("POST", false, ConApiUrl + 'api/User/tteacherControl/GetAllTteacher', puMInfo.appKeyId, params, GetAllTUserBack, syAjaxErrorBack);
        }
        function GetAllTUserBack(json) {
            if (json && json.Data) {
                json = json.Data;
                mAllList = json.data;
                mDefaultPages = json.pages;
                mDefaultRecordCount = json.allcount;
                //分页
                FillData();
                load_xuanze();
            }
        }
        //分页
        function FillData() {
            laytpl(tpl).render(mAllList || [], function (html) {
                $(".view-body").html(html);
            });
            if (mPageIndex == 1) {
                syInitRecordsPage("pages", mDefaultPages, Query);
                $("#pagesum").html("总共：" + mDefaultPages + "页，" + mDefaultRecordCount + "条记录")
            }
        }
        function Update(pID) {
            document.location.href = "TeacherInfo.aspx?id=" + pID;
        }
         </script>
</body>
</html>
