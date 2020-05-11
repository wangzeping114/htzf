using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UploadImageTest : System.Web.UI.Page
{
    public string callback;

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

            callback = Request.QueryString["method"];
        }
    }
}