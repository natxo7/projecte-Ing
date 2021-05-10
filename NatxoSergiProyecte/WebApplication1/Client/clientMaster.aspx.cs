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
    public partial class clientMaster : System.Web.UI.Page
    {
        public DataTable dtClient = new DataTable();
        public DataTable dtReserve = new DataTable();
        public string DBpath = HttpRuntime.AppDomainAppPath + "basedatos.db";
        public WebService1 ws;
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new WebService1();
            //recivir lo que has enviat en el boto del login client en el redirect
            //this.id = String.IsNullOrEmpty(Request.QueryString["id"]) ? "" : Request.QueryString["id"].ToString();
            if (User.Identity.IsAuthenticated)
            {
                this.id = Session["clientId"].ToString();
                int idnClient = -1;
                dtClient = ws.dataClient(Int32.Parse(id));

                foreach (DataRow dr in dtClient.Rows)
                {
                    Label4.Text = dr["name"].ToString();
                    Label6.Text = " " + dr["idn"].ToString();
                    Label5.Text = " " + dr["surname"].ToString();

                    idnClient = Int32.Parse(dr["idn"].ToString());



                }

                dtReserve = ws.dataReserve(idnClient, 0);
                String reserve;

                foreach (DataRow dr in dtReserve.Rows)
                {
                    reserve = Label4.Text + "\t";
                    dtReserve = ws.dataRecepcionist(Int32.Parse(dr["idRecepcionist"].ToString()));
                    foreach (DataRow dr1 in dtReserve.Rows)
                    {
                        reserve += dr1["name"].ToString() + "\t";
                    }
                    reserve += dr["arrivaldate"].ToString() + "\t";
                    reserve += dr["finishdate"].ToString() + "\t";
                    reserve += dr["typeRoom"].ToString() + "\t";

                    ListBox1.Items.Add(reserve);
                }
            }
            
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void nameBox(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}
