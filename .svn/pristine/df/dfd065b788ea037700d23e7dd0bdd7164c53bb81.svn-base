using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportForm_OperatingAccount : System.Web.UI.Page
{
   public  string mStartDate;
   public string mEndDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            mStartDate = DateTime.Now.ToString("yyyy-MM-01");
            mEndDate = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}