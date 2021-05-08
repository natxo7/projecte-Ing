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
    public partial class WebForm2 : System.Web.UI.Page
    {
        public DataTable dt = new DataTable();
        public string DBpath = HttpRuntime.AppDomainAppPath + "basedatos.db";
        public WebService1 ws;
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {

            ws = new WebService1();
            //recivir lo que has enviat en el boto del login client en el redirect
            this.id = String.IsNullOrEmpty(Request.QueryString["id"]) ? "" : Request.QueryString["id"].ToString();

            dt = ws.dataRecepcionist(Int32.Parse(id));

            foreach (DataRow dr in dt.Rows)
            {
                Label4.Text = dr["name"].ToString();
                
                Label5.Text = " " + dr["surname"].ToString();

            }


            dt = ws.dataReserve(Int32.Parse(id), 1);
            String reserve;

            foreach (DataRow dr in dt.Rows)
            {
                reserve = Label4.Text + "\t";
                dt = ws.dataClient(Int32.Parse(dr["idRecepcionist"].ToString()));
                foreach (DataRow dr1 in dt.Rows)
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
}