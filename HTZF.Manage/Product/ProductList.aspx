﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Product_ProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>广告列表</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
</head>
<body class="gray-bg">
    <div class="form-horizontal">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-12">
                <ol class="breadcrumb">
                    <li>
                        <a href="../index/index.html">商品管理</a>
                    </li>
                    <li>
                        商品列表
                    </li>
                </ol>
            </div>
        </div>
        <div class="wrapper wrapper-content animated fadeInRight">
            <div class="col-sm-12">
                <div class="ibox float-e-margins qsearch">
                    <div class="ibox-title">
                        <h5>商品列表管理</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <div class="col-sm-3">
                                        <input id="txtTitle" type="text" class="form-control input-sm" placeholder="商品名称" />
                                    </div>
                                   <div class="col-sm-1">
                                        <span class="input-group-btn">
                                            <a href="javascript:;" class="btn btn-success btn-sm " onclick="Query()"><i class="fa fa-search m-r-5"></i>搜索</a>
                                            <a class=" btn btn-primary btn-sm ml20" href="ProductAdd.aspx">新增 <i class="fa fa-plus"></i></a>
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
                                            <th>商品名称</th>
                                            <th>商品编号</th>
                                            <th>图片</th>
                                            <th>市场价</th>
                                            <th>销售价</th>
                                            <th>排序</th>
                                            <th>类型</th>                                        
                                            <th>库存</th>
                                            <th>已售</th> 
                                            <th>创建日期</th>
                                            <th>状态</th>        
                                            <th>操作</th>
                                          
                                        </tr>
                                    </thead>
                                    <tbody>
                                         {{# if (d && d.length > 0) { }}
                                         {{# for (var i = 0;i< d.length;  i++) { }}
                                             <tr>
                                                <td><input type="checkbox" data-id="{{d[i].FSchoolID}}" class="np"/> </td> 
                                                <td>{{d[i].TitileOrName}}</td>
                                                <td>{{d[i].SerialNumber}}</td>
                                                <td>{{d[i].ImagePath}}</td>
                                                <td>{{d[i].MarketPrice}}</td>
                                                <td>{{d[i].Price}}</td>
                                                <td>{{d[i].Sequence}}</td>
                                                <td>{{d[i].CategoryName}}</td>                                          
                                                 <td>{{d[i].Quantity}}</td>
                                                <td>{{d[i].HaveSalesQuantity}}</td>  
                                                 <td>{{syFormatDate(d[i].CreateTime,'yyyy-MM-dd hh:mm')}}</td>  
                                                 <td>{{d[i].CommodityStatus==0?"下架":"上架"}}</td>        
                                                <td>
                                                    <a href="javascript:;" class="btn btn-danger btn-sm ml5" onclick="Detail('{{d[i].Id}}')">详情<i class="fa fa-edit"></i> </a>
                                                     <a href="javascript:;" class="btn btn-danger btn-sm ml5" onclick="Update('{{d[i].Id}}')">修改 <i class="fa fa-edit"></i> </a>
                                                   <a href="javascript:;" class="btn btn-danger btn-sm ml5"  data-id="{{d[i].Id}}" onclick="DeleteOne(this)">删除<i class="fa fa-trash-o"></i></a>
                                                 </td>
                                            </tr>
                                         {{# } }}
                                         {{# } else { }}
                                            <tr>
                                                <td colspan="14" class="tc">
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
         var puMInfo;
         $(function () {
             if (localStorage.MInfo) {
                 puMInfo = JSON.parse(localStorage.MInfo);
             }
           Query();
         })
         var name = "!";
        function Query(pPageIndex) {
            mPageIndex = pPageIndex ? pPageIndex : 1;
            if ($("#txtTitle").val() != null && $("#txtTitle").val() != "") {
                name = $("#txtTitle").val();
            } else {
                name = "!";
            }
            var params = {
                //pPageSize: mPageSize,
                //pPageIndex: mPageIndex,
                name: name
            };
            syAjaxWithHeader(puMInfo,"Get", false, ConApiUrl + 'manage/cdyprot/getcdyByName', "AppManage:123", params, GetAllTUserBack, syAjaxErrorBack);
        }
        function GetAllTUserBack(json) {
            if (json && json.Result) {
               
                mAllList = json.Result;
                mDefaultPages = 1;
                mDefaultRecordCount = json.Result.length;
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

        function Update(id) {
            document.location.href = "ProductAdd.aspx?id=" + id;
         }
        function Detail(id) {
            document.location.href = "ProductDetail.aspx?id=" + id;
        }
        function DeleteOne(pObj) {
            var id = $(pObj).attr("data-id");
            var msg = "是否确认删除？"
            layer.confirm(msg, {
                btn: ['确认', '取消'] //按钮
            }, function () {
                var params = {
                    pFSchoolID: id
                };
                layer.msg('数据删除中', { icon: 16, shade: [0.5, '#393D49'], time: 0 });
                syAjaxWithHeader(puMInfo,"Get", false, ConApiUrl + 'manage/passprot/delaccount/'+id, "AppManage:123", params, GetDeleteInfoBacke, syAjaxErrorBack);
            });
        }
        function GetDeleteInfoBacke(json) {
            console.log(json);
            layer.closeAll();
            if (json ) {
                if (json.StatusCode == "0") {
                    ConShowMsg("删除成功！");
                    Query();
                }
                else {
                    ConShowMsg(json.StatusMessage);
                }
            }
        }
         </script>
       </body>
</html>
