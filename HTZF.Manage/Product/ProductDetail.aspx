<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="Product_ProductDetail" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>商品详情</title>
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
                        <strong>商品详情</strong>
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
                                <label class="col-sm-2 control-label">商品简介</label>
                                <div class="col-sm-8">
                                    <input id="txtIntroduction" type="text" required class="form-control" placeholder=""/>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-sm-2 control-label">商品描述</label>
                                <div class="col-sm-8">
                                    <input id="txtDescription" type="text" required class="form-control" placeholder=""/>
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
        $(function () {
            mID = syUrlParam("id");

            if (mID)
            {
                Open();
            }
        })
        
        function Open() {
            var params = {
                //pFSchoolID: mID
            };
            syAjaxWithHeader(puMInfo,"Get", false, ConApiUrl + 'manage/cdyprot/getCdyDById/'+mID, "AppManage:123", params, GetInfoBack, syAjaxErrorBack);

        }
        function GetInfoBack(json) {
            if (json && json.Result) {
                mInfo = json.Result;
                $("#txtIntroduction").val(mInfo.Introduction);
                $("#txtDescription").val(mInfo.Description);
                $("#imgMain").val(mInfo.ImagePath);
              
            }
        }
        function Save() {
            

           var cddata = {
                Path:$("#imgMain").val()

            };
            var params = {
                Introduction : $("#txtIntroduction").val(),
                Description : $("#txtDescription").val(),
                //CdyDPrictureDtos: CdyDPricturedata ,
               
            };
            
            if (mID > 0) {
                params.CommdiyId = mID;
                syAjaxWithHeader(puMInfo,"POST", false, ConApiUrl + 'manage/cdyprot/updatecdyDetail', "AppManage:123", params, SetTPartnerInfofBack, syAjaxErrorBack);
            } else {
                syAjaxWithHeader(puMInfo,"POST", false, ConApiUrl + 'manage/cdyprot/addcdyDetail', "AppManage:123", params, SetTPartnerInfofBack, syAjaxErrorBack);
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
