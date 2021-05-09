using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.localhost;
using System.Data;
using System.Data.SQLite;

namespace WebApplication1
{
    public partial class homeMaster : System.Web.UI.Page
    {
        public DataTable dt = new DataTable();
        public string DBpath = HttpRuntime.AppDomainAppPath + "basedatos.db";
        public WebService1 ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new WebService1();
        }

        protected void goLogin(object sender, EventArgs e)
        {
            Response.Redirect("./logMaster.aspx");
        }
    }
}