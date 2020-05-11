<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberLevelSet.aspx.cs" Inherits="Member_MemberLevelSet" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户列表</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
</head>

<body class="gray-bg">
    <div class="form-horizontal">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-12">
                <ol class="breadcrumb">
                    <li>
                        <a href="../index/index.html">会员管理</a>
                    </li>
                    <li>
                        会员等级设置
                    </li>
                </ol>
            </div>
        </div>
        <div class="wrapper wrapper-content animated fadeInRight">
            <div class="col-sm-12">
                <div class="ibox float-e-margins qsearch">
                    <div class="ibox-title">
                        <h5>用户列表管理</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <div class="col-sm-3">
                                        <input id="txtTitle" type="text" class="form-control input-sm" placeholder="用户名称" />
                                    </div>
                                   <div class="col-sm-1">
                                        <span class="input-group-btn">
                                            <a href="javascript:;" class="btn btn-success btn-sm " onclick="Query()"><i class="fa fa-search m-r-5"></i>搜索</a>
                                            <a class=" btn btn-primary btn-sm ml20" onclick="SelectOnClick()" id="btnSelect">选 择</a>
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
                                            <th>用户编号</th>
                                            {{# if(!mIsForSelect){}}
                                            <th>用户名称</th>
                                          {{# } }}
                                            <th>手机号码</th>
                                            <th>呢称</th>
                                            <th>头像</th>
                                             {{# if(!mIsForSelect){}}
                                            <th>性别</th>
                                            <th>微信认证</th>
                                            <th>VIP会员</th>
                                            <th>金豆余额</th>
                                            <th>过期日期</th>
                                            <th>操作</th>
                                            {{# } }}
                                        </tr>
                                    </thead>
                                    <tbody>
                                         {{# if (d && d.length > 0) { }}
                                         {{# for (var i = 0;i< d.length;  i++) { }}
                                             <tr>
                                                <td><input type="checkbox" data-id="{{i}}" class="np"/> </td> 
                                                <td>{{d[i].FUserID}}</td>
                                                   {{# if(!mIsForSelect){}}
                                                <td>{{d[i].FUserName}}</td>
                                                  {{# } }}
                                                <td>{{d[i].FTelphone}}</td>
                                                <td>{{d[i].FRealName}}</td>
                                                 <td>
                                                     <img src="{{d[i].FheadImg}}" style="height: 35px" /></td>
                                                    {{# if(!mIsForSelect){}}
                                                <td>{{d[i].FSex}}</td>
                                                <td>{{d[i].FOpenID}}</td>
                                                <td>{{d[i].FIsVip <1?"是":"否"}}</td>
                                                <td>{{d[i].FScoreBalance}}</td>
                                                  <td>{{syFormatDate(d[i].FExpDate,'yyyy-MM-dd hh:mm')}}</td>
                                                <td>
                                                  <a class=" btn btn-primary btn-sm ml20" href="VideoaddingInfo.aspx?id={{d[i].FUserID}}">添加视频 <i class="fa fa-plus"></i></a>
                                                  </td>
                                                  {{# } }}
                                            </tr>
                                         {{# } }}
                                         {{# } else { }}
                                            <tr>
                                                <td colspan="{{mColNum}}" class="tc">
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
         var mIsForSelect = false;
         var mSelNum = 1;
         var mColNum = 12;
         $(function () {

             if (syUrlParam("sel")) {
                 mColNum = 5;
                 if (syUrlParam("num"))
                     mSelNum = syUrlParam("num");

                 mIsForSelect = true;
                 $("#btnSelect").show();
                 $("#btnAdd").hide();
             }
             Query();
         })
         function Query(pPageIndex) {
             mPageIndex = pPageIndex ? pPageIndex : 1;
             var params = {
                 pPageSize: mPageSize,
                 pPageIndex: mPageIndex,
                 pFUserName: $("#txtTitle").val()
             };
             syAjax("POST", false, ConApiUrl + 'api/User/tuserControl/GetAllTuser', puMInfo.appKeyId, params, GetAllTUserBack, syAjaxErrorBack);
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

         function SelectOnClick() {
             var ids = '';
             var names = '';
             var oCount = 0;
             $.each($(".np"), function (obj) {
                 var checked = $(this).prop("checked") || $(this).attr("checked");
                 if (checked) {
                     oCount++;
                     var oindex = $(this).attr("data-id");
                     var oInfo = mAllList[oindex];
                     if (ids) {

                         ids += "," + oInfo.FUserID;
                         names += ',' + oInfo.FRealName;
                     }
                     else {
                         ids += oInfo.FUserID;
                         names += oInfo.FRealName;
                     }
                 }
             });
             if (!ids) {
                 ConShowMsg("请选择会员");
                 return;
             }
             if (oCount > mSelNum) {
                 ConShowMsg("最多只能选择"+mSelNum+"个会员");
                 return;
             }
             var oUrl = "/pages/base/VideoList?typeid=" + ids;
             parent.SelectedLinker(oUrl, true, 0, 0, names, ids);
         }
         </script>
       </body>
</html>
