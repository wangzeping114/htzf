using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_UploadImage : System.Web.UI.Page
{
    public string callback;

    public string totalGraph = "0";

    public string path;
    public string IsCompress = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int x_scale, y_scale;
            if (!string.IsNullOrWhiteSpace(Request.QueryString["xscale"]) && !string.IsNullOrWhiteSpace(Request.QueryString["yscale"]) 
                && int.TryParse(Request.QueryString["xscale"], out x_scale) && int.TryParse(Request.QueryString["yscale"], out y_scale))
            {
                xscale.Value = Request.QueryString["xscale"];
                yscale.Value = Request.QueryString["yscale"];
            }
            if (!string.IsNullOrWhiteSpace(Request.QueryString["totalGraph"]))
            {
                totalGraph = Request.QueryString["totalGraph"];
            }
            if (!string.IsNullOrWhiteSpace(Request.QueryString["Compress"]))
            {
                IsCompress = Request.QueryString["Compress"];
            }
            callback = Request.QueryString["method"];
            path=Server.MapPath("~/Controls/images/");
            path = path.Replace(@"\\", "|").Replace(@"\", "|").Replace("//", "|").Replace("/","|");
        }
    }
}