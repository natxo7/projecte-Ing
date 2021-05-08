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
    public partial class home : System.Web.UI.Page
    {
        public DataTable dt = new DataTable();
        public string DBpath = HttpRuntime.AppDomainAppPath + "basedatos.db";
        public WebService1 ws;

        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new WebService1();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int user = Int32.Parse(TextBox1.Text);

            dt = ws.Login(user);

            foreach (DataRow dr in dt.Rows)
            {
                TextBox2.Text = dr["name"].ToString();
            }
        }
    }
}