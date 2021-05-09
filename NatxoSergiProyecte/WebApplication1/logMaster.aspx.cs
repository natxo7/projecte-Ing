using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using WebApplication1.localhost;

namespace WebApplication1
{
    public partial class logMaster : System.Web.UI.Page
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


            if (user.Length == 0 || pass.Length == 0)
            {
                return;
            }
            else
            {
                dt = ws.initiateSesion(user, pass);
            }

            

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["name"].ToString() == user)
                {

                    string passHash = dr["password"].ToString().ToUpper();
                    if (pass.ToString().ToUpper() == passHash)
                    {
                        Response.Redirect("./clientMaster.aspx?id=" + dr["id"].ToString());

                    }
                }
            }
        }

        protected void recepcionistSesion_Click(object sender, EventArgs e)
        {
            string user = txtBoxNameRecepcionist.Text;
            string pass = txtBoxPassRec.Text;


            if (user.Length == 0 || pass.Length == 0)
            {
                return;
            }

            dt = ws.initiateSesionRecepcionist(user, pass);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["name"].ToString() == user)
                {

                    string passHash = dr["password"].ToString().ToUpper();
                    if (pass.ToString().ToUpper() == passHash)
                    {
                        FormsAuthentication.SetAuthCookie(user, true);

                        if (dr["rol"].ToString() == "1")
                        {

                            //Response.Redirect("./recepcionistPage.aspx");
                            //tiene que llevar a una admin en caso de crearla
                        }
                        else
                        {
                            Response.Redirect("./recepcionistMaster.aspx?id=" + dr["id"].ToString());

                        }
                    }
                }
            }
        }
    }
}