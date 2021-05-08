using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.localhost;

namespace WebApplication1
{

    public partial class loginPage : System.Web.UI.Page
    {
        public DataTable dt = new DataTable();
        public string DBpath = HttpRuntime.AppDomainAppPath + "basedatos.db";
        public WebService1 ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new WebService1();
        }

        protected void btnInitiateSesion_Click(object sender, EventArgs e)
        {
            string user = txtBoxName.Text;
            string pass = txtBoxPass.Text;
            dt= ws.initiateSesion(user, pass);
            Response.Redirect("./clientPage.aspx");
        }
    }
}