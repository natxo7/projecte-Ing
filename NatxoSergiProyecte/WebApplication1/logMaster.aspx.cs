using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using WebApplication1.localhost;
using System.Web.Security;

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
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
                pass = BitConverter.ToString(data).Replace("-", string.Empty);
            }

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
                    using (MD5 md5Hash = MD5.Create())
                    {

                        string passHash = dr["password"].ToString().ToUpper();
                        if (pass == passHash)
                        {
                            FormsAuthentication.SetAuthCookie("user", true);
                            Session["clientId"] = dr["id"];
                            Response.Redirect("Client/clientMaster.aspx");
                            //Response.Redirect("./clientMaster.aspx?id=" + dr["id"].ToString());

                        }
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
                        FormsAuthentication.SetAuthCookie("admin", true);

                        if (dr["rol"].ToString() == "1")
                        {

                            //Response.Redirect("./recepcionistPage.aspx");
                            //tiene que llevar a una admin en caso de crearla
                        }
                        else
                        {
                            //Response.Redirect("./recepcionistMaster.aspx?id=" + dr["id"].ToString());
                            Session["recepcionistId"] = dr["id"];
                            Response.Redirect("Recepcionist/recepcionistMaster.aspx");
                        }
                    }
                }
            }
        }
    }
}