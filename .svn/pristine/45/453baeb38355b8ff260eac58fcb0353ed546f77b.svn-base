<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingRush.aspx.cs" Inherits="Active_ShoppingRush" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>抢购列表</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
</head>
<body class="gray-bg">
    <div class="form-horizontal">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-12">
                <ol class="breadcrumb">
                    <li>
                        <a href="../index/index.html">活动管理</a>
                    </li>
                    <li>
                        抢购
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
                                        <input id="txtTitle" type="text" class="form-control input-sm" placeholder="学校名称" />
                                    </div>
                                   <div class="col-sm-1">
                                        <span class="input-group-btn">
                                            <a href="javascript:;" class="btn btn-success btn-sm " onclick="Query()"><i class="fa fa-search m-r-5"></i>搜索</a>
                                            <a class=" btn btn-primary btn-sm ml20" href="SchoolInfo.aspx">新增 <i class="fa fa-plus"></i></a>
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
                                            <th>学校编号</th>
                                            <th>学校名称</th>
                                            <th>简称</th>
                                            <th>法人代表</th>
                                            <th>所属省</th>
                                            <th>所属市</th>
                                            <th>所属区域</th>                                        
                                            <th>联系电话</th>
                                            <th>联系人</th>
                                            <th>审核</th>
                                            <th>返利金额</th>                                                                              
                                            <th>操作</th>
                                          
                                        </tr>
                                    </thead>
                                    <tbody>
                                         {{# if (d && d.length > 0) { }}
                                         {{# for (var i = 0;i< d.length;  i++) { }}
                                             <tr>
                                                <td><input type="checkbox" data-id="{{d[i].FSchoolID}}" class="np"/> </td> 
                                                <td>{{d[i].FSchoolID}}</td>
                                                <td>{{d[i].FSchoolName}}</td>
                                                <td>{{d[i].FAbbreviation}}</td>
                                                <td>{{d[i].FOwner}}</td>
                                                <td>{{d[i].FProvince}}</td>
                                                <td>{{d[i].FCity}}</td>
                                                <td>{{d[i].FCounty}}</td>                                          
                                                 <td>{{d[i].FSchoolTel}}</td>
                                                <td>{{d[i].FSchoolLinker}}</td>
                                                <td>{{d[i].FFlag <1?"待审核":"已审核"}}</td> 
                                                <td>{{d[i].FRebate}}</td>                                             
                                                <td>
                                                     <a href="javascript:;" class="btn btn-danger btn-sm ml5" onclick="Update('{{d[i].FSchoolID}}')">{{d[i].FFlag<1?"审核":"修改"}} <i class="fa fa-edit"></i> </a>
                                                   <a href="javascript:;" class="btn btn-danger btn-sm ml5"  data-id="{{d[i].FSchoolID}}" onclick="DeleteOne(this)">删除<i class="fa fa-trash-o"></i></a>
                                                 <%-- {{# if(d[i].FFlag<1){}}
                                                    <a href="javascript:;" class="btn btn-success btn-sm" onclick="UpdateSchoolFlag('{{d[i].FSchoolID}}')">审 核 <i class="fa fa-trash-o"></i></a>
                                                 {{# }else{ }}
                                                    {{# } }}--%>
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
        $(function () {
           Query();
        })
        function Query(pPageIndex) {
            mPageIndex = pPageIndex ? pPageIndex : 1;
            var params = {
                pPageSize: mPageSize,
                pPageIndex: mPageIndex,
                pFSchoolName: $("#txtTitle").val()
            };
            syAjax("POST", false, ConApiUrl + 'api/User/tschoolsControl/GetAllTschools', puMInfo.appKeyId, params, GetAllTUserBack, syAjaxErrorBack);
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

         //学校审核
      
           
        //function UpdateSchoolFlag(FID)
        //{
        //    var schoolID = FID;
        //    var msg = "确认审核通过?"
        //    layer.confirm(msg,{
        //    btn:['确认','取消']//按钮
        //    },function(){
        //        var params={
        //            pFSchoolID: schoolID
        //        };           
        //        syAjax("POST", false, ConApiUrl + 'api/User/tschoolsControl/GetRALLTshools', puMInfo.appKeyId, params, UpdateSchoolFlagBack, syAjaxErrorBack);
        //    });   
        //}
        //function UpdateSchoolFlagBack(json) {
        //    layer.closeAll();
        //    layer.close()
        //    console.log(json);
        //    if (json && json.Data) {
        //        Query();
        //    }
        //}
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
        //function Update(sID) {
        //    document.location.href = "SchoolInfo.aspx?id=" + sID;
        //}
        function Update(id) {
                      
            alert(id)
            document.location.href = "SchoolInfo.aspx?id=" + id;
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
                syAjax("POST", false, ConApiUrl + 'api/User/tschoolsControl/GettschoolsDeleteInfo', puMInfo.appKeyId, params, GettschoolsDeleteInfoBacke, syAjaxErrorBack);
            });
        }
        function GettschoolsDeleteInfoBacke(json) {
            console.log(json);
            layer.closeAll();
            if (json && json.Data) {
                if (json.Data.flag) {
                    Query();
                }
                else {
                    ConShowMsg(json.Data.msg);
                }
            }
        }
        function DeleteBack(json) {
            layer.closeAll();
            Query();
        }
         </script>
       </body>
</html>
