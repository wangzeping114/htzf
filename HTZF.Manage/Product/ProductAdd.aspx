<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductAdd.aspx.cs" Inherits="Product_ProductAdd" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>商品编辑</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
</head>
<body class="gray-bg"> 
<div class="form-horizontal">
    <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-10">
                <ol class="breadcrumb">
                    <li>
                        <a href="../index/index.aspx">商品管理</a>
                    </li>
                    <li>
                        <a href="AdvertList.aspx">商品列表</a>
                    </li>
                    <li>
                        <strong>商品编辑</strong>
                    </li>
                </ol>
            </div>
            <div class="col-sm-2 tr">
                <a href="ProductList.aspx" class="btn btn-xs btn-primary">返回列表</a>
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
                                <label class="col-sm-2 control-label">商品名称</label>
                                <div class="col-sm-8">
                                    <input id="txtTitileOrName" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">商品编号</label>
                                <div class="col-sm-8">
                                    <input id="txtSerialNumber" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">描述</label>
                                <div class="col-sm-8">
                                    <input id="txtDescription" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label class="col-sm-2 control-label">市场价</label>
                                <div class="col-sm-8">
                                    <input id="txtMarketPrice" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">销售价</label>
                                <div class="col-sm-8">
                                    <input id="txtPrice" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">库存</label>
                                <div class="col-sm-8">
                                    <input id="txtQuantity" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">排序</label>
                                <div class="col-sm-8">
                                    <input id="txtSequence" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">状态</label>
                                <div class="col-sm-8">
                                    <select id="txtCommodityStatus"  class="form-control" >
                                        <option value="1">上架</option>
                                        <option value="0">下架</option>
                                    </select>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">商品图片*</label>
                                <div class="col-sm-8">
                                    <div id="img-box" class="img-view-box">
                                        <img class="img-border radius-small" style="height:80px; width:80px"   src="http://www.meizhuwl.net/img/addpic.png"  alt="暂无图片，点击切换图片"  id="imgMain" onclick="ShowUpMainImg()"   />
                                    </div> 
                                    <div class="input-note red">如需修改商品图片，请点击上面图片,建议1：1图片</div>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">类型</label>
                                <div class="col-sm-8">
                                    <select id="txtType"  class="form-control" >
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
                name: "!"
        };
            syAjaxWithHeader(puMInfo,"Get", false, ConApiUrl + 'manage/cdyprot/getcatoriesByName', "AppManage:123", params, AllFunctionBack, syAjaxErrorBack);
        }
        function AllFunctionBack(json) {
            if (json) {
                if (json.StatusCode == "0") {
                    var html = '<option value="">请选择类型</option>';　
                    for (var i = 0; i < json.Result.length; i++) {
                        html += '<option value="' + json.Result[i].Id + '">' + json.Result[i].Name + '</option>';
                    }
                    $("#txtType").html(html);
                }
                
            } else {
                ConShowMsg("请检查网络状态");
            }
        }
        function Open() {
            var params = {
                //pFSchoolID: mID
            };
            syAjaxWithHeader(puMInfo,"Get", false, ConApiUrl + 'manage/cdyprot/getcdyById/'+mID, "AppManage:123", params, GetInfoBack, syAjaxErrorBack);

        }
        function GetInfoBack(json) {
            if (json && json.Result) {
                mInfo = json.Result;
                $("#txtTitileOrName").val(mInfo.TitileOrName);
                $("#txtSerialNumber").val(mInfo.SerialNumber);
                $("#imgMain").val(mInfo.ImagePath);
                $("#txtMarketPrice").val(mInfo.MarketPrice);
                $("#txtPrice").val(mInfo.Price);
                $("#txtType").val(mInfo.CategoryId);
                $("#txtQuantity").val(mInfo.Quantity);
                $("#txtCommodityStatus").val(mInfo.CommodityStatus);
                $("#txtSequence").val(mInfo.Sequence);
            }
        }
        function Save() {
            var Stockdata = {
                Quantity:$("#txtQuantity").val()

            };
            var params = {
                TitileOrName : $("#txtTitileOrName").val(),
                SerialNumber : $("#txtSerialNumber").val(),
                ImagePath: $("#imgMain").val() ,
                MarketPrice : $("#txtMarketPrice").val(),
                Price: $("#txtPrice").val(),
                CategoryId : $("#txtType").val(),
                StockDto: Stockdata,
                CommodityStatus : $("#txtCommodityStatus").val(),
                Sequence: $("#txtSequence").val()
            };
            
            if (mID > 0) {
                params.Id = mID;
                syAjaxWithHeader(puMInfo,"POST", false, ConApiUrl + 'manage/cdyprot/updatecdy', "AppManage:123", params, SetTPartnerInfofBack, syAjaxErrorBack);
            } else {
                syAjaxWithHeader(puMInfo,"POST", false, ConApiUrl + 'manage/cdyprot/addcdy', "AppManage:123", params, SetTPartnerInfofBack, syAjaxErrorBack);
            }

           
        }
        function SetTPartnerInfofBack(json) {
           
                if (json.StatusCode=="0") {
                    ConShowMsg(json.StatusMessage, "ProductList.aspx");
                }
                else {
                    ConShowMsg(json.StatusMessage);
                }
            
        }
     
    </script>
</body>
</html>
