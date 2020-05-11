
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForSelectLinker.aspx.cs" Inherits="publichtml_ForSelectLinker" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <!--#include virtual="../publichtml/pubHead.htm" --> 
</head>
<body class="gray-bg"> 
<div class="form-horizontal">
    <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-sm-10">
                 <div class="ibox float-e-margins">
                  <div class="col-sm-1">
                         <div class="form-group">
                         <label class="col-sm-2 control-label"></label>
                         <div class="col-sm-8">
                             <div><a class="btn btn-primary btn-sm ml20" href="javascript:;"style="width:100px"onclick="btnclick(1)">视频列表</a></div>
                            <div><a class="btn btn-primary btn-sm ml20" href="javascript:;"style="width:100px"onclick="btnclick(2)">视频类型</a> </div>                                                        
                             <div style="margin-left:20px"><a class="btn btn-primary btn-sm m120" href="javascript:;"style="width:100px"onclick="btnclick(3)">赛事列表</a></div>
                              <div style="margin-left:20px"><a class="btn btn-primary btn-sm m120" href="javascript:;"style="width:100px"onclick="btnclick(5)">课件类型</a></div>
                              <div style="margin-left:20px"><a class="btn btn-primary btn-sm m120" href="javascript:;"style="width:100px"onclick="btnclick(6)">课件列表</a></div>
                             <a class="btn btn-primary btn-sm ml20" href="javascript:;" onclick="btnclick(4)">用户注册<i class="fa fa-plus"></i></a>
                            </div><label class="col-sm-2 control-label"></label>
                         </div>
                  </div>
                </div>
               </div>
            </div>
        </div>
</div> 
    <script>
        function btnclick(pType) {
            if (pType == 1) {
                parent.SelectedLinker('../BaseSet/Videoselection.aspx?sel=1', false, 600, 600);
            }
            else if (pType == 2) {
                parent.SelectedLinker('../spManage/VideoTypeList.aspx?sel=1&pub=1', false, 600, 500);
            }
            else if (pType == 3)
            {
                parent.SelectedLinker('../Competition/TournamentListAdd.aspx?sel=1', false, 600, 600);
            }
            else if (pType == 4) {
                parent.SelectedLinker('/pages/base/login', true, 600, 500);
            }
            else if (pType == 5) {
                parent.SelectedLinker('../Customere/CoursewareTypeAdd.aspx?sel=1', false, 600, 600);
            }
            else if (pType == 6) {
                parent.SelectedLinker('../Customere/CoursewareListAdd.aspx?sel=1', false, 600, 600);
            }
        }
    </script>
</body>
</html>
