﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemSet.aspx.cs" Inherits="BaseSet_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>系统设置</title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
</head>

<body class="gray-bg">
    <div class="form-horizontal">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-sm-12">
                <ol class="breadcrumb">
                    <li>
                        <a href="../index/index.html">首页</a>
                    </li>
                    <li>
                        系统设置
                    </li>
                    <li>
                        首页配置
                    </li>
                </ol>
            </div>
        </div>
         <div class="wrapper wrapper-content animated fadeInRight">
            <div class="col-sm-12">
                <div class="ibox float-e-margins qsearch">
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                       <span>微信菜单配置：</span><a href="javascript:;" onclick="outWin('ResetWXMenu.aspx')">设置</a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>微信配置：</span><a href="javascript:;" onclick="outWin('WxPayConfig.aspx')">设置</a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>用户使用协议：</span><a href="javascript:;" onclick="outWin('UserNotice.aspx')">设置</a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>免责声明：</span><a href="javascript:;" onclick="outWin('Disclaimer.aspx')">设置</a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3" style="width:300px;text-align:right">
                                        <span>学币购买配置：</span><a href="javascript:;" onclick="outWin('ScoreSet.aspx')">设置</a>
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>短视频设置：</span><a href="javascript:;" onclick="outWin('SmallVideoSet.aspx')">设置</a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>学币奖励机制：</span><a href="javascript:;" onclick="outWin('ScoreRewardMechanism.aspx')">设置</a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>杂项设置：</span><a href="javascript:;" onclick="outWin('OtherSystemSet.aspx')">设置</a>
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>合伙人申请说明：</span><a href="javascript:;" onclick="outWin('Partnere.aspx?setid=10010109')">设置</a>
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>邀请学生的展示设置：</span><a href="javascript:;" onclick="outWin('Partnere.aspx?setid=10010112')">设置</a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>邀请学校的展示设置：</span><a href="javascript:;" onclick="outWin('Partnere.aspx?setid=10010113')">设置</a>
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>推广学校二维码：</span><a href="javascript:;" onclick="outWin('ShareImgSet.aspx?setid=10010110')">设置</a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3" style=" width:300px;text-align:right">
                                        <span>推广学生二维码：</span><a href="javascript:;" onclick="outWin('ShareImgSet.aspx?setid=10010111')">设置</a>
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
    
</script>
    <script>
        outWin = function (url) {
            document.location.href = url;
        }; 

    </script>
</body>
</html>
