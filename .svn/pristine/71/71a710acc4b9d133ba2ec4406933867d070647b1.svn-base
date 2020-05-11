var ConWebSiteName = '海豚智付管理后台';
var ConApiUrl = 'http://localhost:51528/';
var ConWebUrl = 'http://localhost:1647';
if (document.domain.indexOf("localhost") < 0)
{
    ConApiUrl = 'http://www.meizhuwl.net/spapi/';
    ConWebUrl = 'http://www.meizhuwl.net/zhxc/';
}
function ConShowMsg(pMsg, pUrl, pIsBack) {
    layer.msg(pMsg, {time: 2000,  end: function (e) {
        if (pIsBack) {
            history.back(-1);
        }
        else {
            if (pUrl) {
                window.document.location.href = pUrl;
            }
        }
    }});
}
 
