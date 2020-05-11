<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoaddingInfo.aspx.cs" Inherits="User_VideoaddingInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>视频明细编辑</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
    <style type="text/css">
        #txtFVideoDesc {
            height: 77px;
            width: 308px;
        }
    </style>
</head>
<body class="gray-bg"> 
<div class="form-horizontal">
    <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-10">
                <ol class="breadcrumb">
                    <li>
                        <a href="../index/index.aspx">首页</a>
                    </li>
                    <li>
                        <a href="VideoListItem.aspx">列表</a>
                    </li>
                    <li>
                        <strong>详细信息</strong>
                    </li>
                </ol>
            </div>
            <div class="col-sm-2 tr">
                <a href="VideoListItem.aspx" class="btn btn-xs btn-primary">返回列表</a>
            </div>

      </div>
    <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-sm-10">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>视频信息</h5>
                        </div>
                        <div class="ibox-content">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">前置图片*</label>
                                <div class="col-sm-8">
                                    <div id="img-box" class="img-view-box">
                                     <img class="img-border radius-small" style="height:100px; width:100px" src="http://www.meizhuwl.net/img/addpic.png"  alt="暂无图片，点击切换图片"  id="imgMain" onclick="ShowUpMainImg()"   />
                                 </div> 
                                 <div class="input-note red">如需修改前置图片，请点击上面图片,建议1：1图片</div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">视频上传*</label>
                                <div class="col-sm-8">
                                    <input type="text" id="txtFileUrl" />
                                    <input type="file" style="display:none;" id="vcVideo" onchange="setVcVideoName()" />
                                     <a class=" btn btn-primary btn-sm ml20" href="javascript:;" onclick="UploadFile()" id="btnUpFile"><i class="fa fa-plus"></i>视频上传</a>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">视频描述*</label>
                                <div class="col-sm-8">
                                    <textarea id="txtFVideoDesc" cols="20" rows="4"  placeholder="视频描述"></textarea>
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
</div> <script src="../assets/js/vod/axios.js"></script>
    <script src="../assets/js/vod/es6-promise.auto.js"></script>
    <script src="../assets/js/vod/vod-js-sdk-v6.js"></script>
    <script src="../assets/js/vod/vue.js"></script> 
   <script>
       var mUserID;
       var mInfo = {};
       var mSPSignature;
       $(function () {
           mUserID = syUrlParam("id");
       })
       function getSignature() {
           axios.defaults.headers.common["appKeyId"] = puMInfo.appKeyId;
           return axios.post(ConApiUrl + 'api/BaseSet/SystemControl/GetUploadSignature'
       ).then(function (json) {
           return json.data.Data;
       })
       }

       function ShowUpMainImg() {
           syOpenUploadImgDialog({
               url: '../Controls/UploadImage.aspx',
               method: 'getUploadImg',
               totalGraph: 1
           });
       }
       function getUploadImg(url) {
           $("#imgMain").attr("src", url)
           $("#img-box img").attr("src", url);
           $("#img-box").removeClass("hidden");
           mInfo.FPreImg = url;
           layer.closeAll();
       }
       function Save() {
           mInfo.FVideoID = "";         
           mInfo.FItemDesc = $("#txtFVideoDesc").val();
           mInfo.FUserID = mUserID;
           mInfo.FVideoUrl = $("#txtFileUrl").val();
           if (!mInfo.FVideoUrl) {
               ConShowMsg("请上传视频");
               return;
           }
           var params = { pInfo: syJsonSafe(mInfo) };
           syAjax("POST", false, ConApiUrl + 'api/Videos/VideoControll/SaveVideoItem', puMInfo.appKeyId, params, SaveVideoInfoBack, syAjaxErrorBack);
       }
       function SaveVideoInfoBack(json) {
           if (json && json.Data) {
               if (json.Data.flag) {
                   ConShowMsg(json.Data.msg, "UserList.aspx");
               }
               else {
                   ConShowMsg(json.Data.msg);
               }
           }
       }
       function UploadFile() {
           $("#vcVideo").click();
       }
       function setVcVideoName() {
           RealUploadFile();
       }
       function RealUploadFile() {
           layer.msg('视频上传中', { icon: 16, shade: [0.5, '#393D49'], time: 0 });
           var mediaFile = $("#vcVideo").prop('files')[0];
           var tcVod = new TcVod.default({
               getSignature: getSignature
           })
           var uploader = tcVod.upload({
               mediaFile: mediaFile,
           })
           uploader.on('media_progress', function (info) {
               uploaderInfo.progress = info.percent;
           })
           uploader.on('media_upload', function (info) {
               uploaderInfo.isVideoUploadSuccess = true;
           })

           var uploaderInfo = {
               videoInfo: uploader.videoInfo,
               isVideoUploadSuccess: false,
               isVideoUploadCancel: false,
               progress: 0,
               fileId: '',
               videoUrl: '',
               cancel: function () {
                   layer.closeAll();
                   uploaderInfo.isVideoUploadCancel = true;
                   uploader.cancel()
               },
           }
           uploader.done().then(function (doneResult) {
               layer.closeAll();
               uploaderInfo.fileId = doneResult.fileId;
               mInfo.FFileID = doneResult.fileId;
               $("#txtFileUrl").val(doneResult.video.url);
               $("#txtFileID").val(mInfo.FFileID);
           })
       }
    </script>F
</body>
</html>
