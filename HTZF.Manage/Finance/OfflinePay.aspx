<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfflinePay.aspx.cs" Inherits="Finance_OfflinePay" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>赛组</title>
    <!--#include virtual="../publichtml/pubHead.htm" -->
      <script src="<%= ResolveUrl("~/assets/js/My97DatePicker/WdatePicker.js") %>" type="text/javascript"></script>
</head>

<body class="gray-bg">
    <div class="form-horizontal">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-12">
                <ol class="breadcrumb">
                    <li>
                        <a href="../index/index.html">财务管理</a>
                    </li>
                    <li>线下支付
                    </li>
                </ol>
            </div>
        </div> <%--class="col-sm-3"--%>
        <div class="wrapper wrapper-content animated fadeInRight">
            <div class="col-sm-12">
                <div class="ibox float-e-margins qsearch">
                    <div class="ibox-title" style="padding-left:30px">
                        <h5>变更记录</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group"> 
                                     <div style="width:120px;float:left;margin-left:20px">
                                        <input id="txtFRealName" type="text" class="form-control input-sm width120" placeholder="用户姓名" />
                                    </div> 
                                     <div style="width:120px;float:left;margin-left:20px">
                                        <input id="txtFTelphone" type="text" class="form-control input-sm width120" placeholder="手机号码" />
                                    </div>                                 
                                  <div style="width:120px;float:left;margin-left:20px">
                                        <input id="txtTitle" type="text" class="form-control input-sm width120" placeholder="变更原因" />
                                    </div>      
                                    
                                     <div style="float:left;margin-left:20px;line-height:32px;display:flex;">
                                         时间段
                                        <input style="width:190px" class="form-control input-sm width120" id="startDate"  placeholder="开始时间"  type="text"  onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})"/>   
                                           <input style="width:190px" class="form-control input-sm width120" id="endDate" placeholder="结束时间"  type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}',maxDate:'2120-10-01'})"/>       
                                    </div>      
                                    <div style="width:120px;float:left;margin-left:20px">
                                        <span class="input-group-btn">
                                            <a href="javascript:;" class="btn btn-success btn-sm " onclick="Query()"><i class="fa fa-search m-r-5"></i>搜索</a>  
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
                                    <label class="pageSum col-sm-2 control-label" id="pagesum">总条数：0</label>
                                    <div id="pages" class="page-box col-sm-8 cen">
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
                    <th>名称</th>  
                    <th>手机号码</th>
                    <th>金额</th>                                
                    <th>变更日期</th>
                    <th>变更原因</th>
                    <th>状态</th>
                  <th>操作</th>
                </tr>
            </thead>
            <tbody>
                {{# if (d && d.length > 0) { }}
                                         {{# for (var i = 0;i< d.length;  i++) { }}
                                             <tr>   
                                                 <td>{{d[i].FRealName}}</td>
                                                  <td>{{d[i].FTelphone}}</td>   
                                                  <td>{{d[i].FBalance}}</td>  
                                                  <td>{{syFormatDate(d[i].FCreateTime,'yyyy-MM-dd hh:mm')}}</td>                                                                                                                                                                       
                                                  <td>{{d[i].FRemark}}</td>
                                                 <td>{{d[i].FFlag<1?"待审核":"以支付"}}</td>                                                                                              
                                                 <td>
                                                        {{# if(d[i].FFlag<1){}}
                                                      <a href="javascript:;" class="btn btn-primary btn-sm ml5" data-id="{{d[i].FChangeID}}" onclick="Update({{i}})">发放<i class="fa fa-edit"></i></a>
                                                 {{# }else{ }}
                                                    {{# } }}
                                                    
                                                     <a href="javascript:;" class="btn btn-danger btn-sm ml5"  data-id="{{d[i].FChangeID}}" onclick="DeleteOne(this)">删除<i class="fa fa-trash-o"></i></a>
                                                 </td>
                                             </tr>
                {{# } }}
                                         {{# } else { }}
                                            <tr>
                                                <td colspan="6" class="tc">未查询到符合条件的记录
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
            $("#startDate").val("<%= mStartDate%>");
            $("#endDate").val("<%= mEndDate%>");
            Query();
        })
        function Query(pPageIndex) {
            mPageIndex = pPageIndex ? pPageIndex : 1
            var params = {
                pPageSize: mPageSize,
                pPageIndex: mPageIndex,
                pFRemark: $("#txtTitle").val(),
                pFRealName: $("#txtFRealName").val(),
                pFTelphone: $("#txtFTelphone").val(),
                pstartDate: $("#startDate").val(),
                pendDate: $("#endDate").val(),
            };
            console.log(params);
            syAjax("POST", false, ConApiUrl + 'api/ReportForm/AccountControl/GetuserbalancechangeList', puMInfo.appKeyId, params, GetuserbalancechangeListBack, syAjaxErrorBack);
        }
        function GetuserbalancechangeListBack(json) {
            //console.log('aaa',json)
            json = json.Data;
            mAllList = json.data;
            mDefaultPages = json.pages;
            mDefaultRecordCount = json.allcount;
            //分页
            FillData();
            load_xuanze();
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
      
        function Update(index) {
            layer.open({
                type: 2,
                area: ['400px', '300px'],
                title: '会员订单明细',
                content: 'AccountAdd.aspx?id=' + mAllList[index].FChangeID
            });
        }
        //function Update(pObj) {
        //    var id = $(pObj).attr("data-id");

        //    document.location.href = "CompetitionGroupAdd.aspx?id=" + id;
        //}
        //function AddNext(pObj) {
        //    var id = $(pObj).attr("data-id");

        //    document.location.href = "DewlyAdd.aspx?upid=" + id;
        //}
        function DeleteOne(pObj) {
            var id = $(pObj).attr("data-id");
            var msg = "是否确认删除？"
            layer.confirm(msg, {
                btn: ['确认', '取消'] //按钮
            }, function () {
                var params = {
                    pFChangeID: id
                };
                layer.msg('数据删除中', { icon: 16, shade: [0.5, '#393D49'], time: 0 });
                syAjax("POST", false, ConApiUrl + 'api/ReportForm/AccountControl/GetTuserbalancechangelistDeleteInfo', puMInfo.appKeyId, params, GetTuserbalancechangelistDeleteInfoBacke, syAjaxErrorBack);
            });
        }
        function GetTuserbalancechangelistDeleteInfoBacke(json) {
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
