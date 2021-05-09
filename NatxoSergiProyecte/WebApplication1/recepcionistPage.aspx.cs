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
        public List<Reserve> listaReservas;
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            listaReservas = new List<Reserve>();
            ws = new WebService1();
            //recibir lo que has enviat en el boto del login client en el redirect
            this.id = String.IsNullOrEmpty(Request.QueryString["id"]) ? "" : Request.QueryString["id"].ToString();

            dt = ws.dataRecepcionist(Int32.Parse(id));

            foreach (DataRow dr in dt.Rows)
            {
                Label4.Text = dr["name"].ToString();
                
                Label5.Text = " " + dr["surname"].ToString();

            }

            dt = ws.dataReserve(Int32.Parse(id), 1);
            String reserveString;

            foreach (DataRow dr in dt.Rows)
            {
                reserveString = "";
                dt = ws.dataClient(Int32.Parse(dr["idRecepcionist"].ToString()));
                foreach (DataRow dr1 in dt.Rows)
                {

                    reserveString = "Id Reserve: " + dr["id"].ToString();
                    reserveString += " Client Name: " + dr1["name"].ToString() + "\t";
                    //ListBox1.Items.Add(dr1["name"].ToString());

                    Reserve reserve = new Reserve(Int32.Parse(dr["id"].ToString()), Int32.Parse(dr["idRecepcionist"].ToString()), Int32.Parse(dr["idClient"].ToString()), dr["arrivaldate"].ToString(), dr["finishdate"].ToString(), dr["typeRoom"].ToString());
                    listaReservas.Add(reserve);

                }

                
                reserveString += " Arrival Date: " + dr["arrivaldate"].ToString() + "\t";
                reserveString += " Finish Date: " + dr["finishdate"].ToString() + "\t";
                reserveString += " Type Room: " + dr["typeRoom"].ToString() + "\t";
                

                ListBox1.Items.Add(reserveString);
            }

            
        }

        protected void btnAddReserve_Click(object sender, EventArgs e)
        {
             
            string name = clientName.Text;
            string pass = clientPassword.Text;
            string sur = clientSurname.Text;
            int card = Int32.Parse(clientCard.Text);
            int idn = Int32.Parse(clientIdn.Text);

            int idClient = 0;
            string arrivaldate = arrivalDate.Text;
            string finishDate = finishdate.Text;
            string typeRoom = typeroom.Text;

            ws.addClient(idn, name, pass, sur, card);
            dt = ws.searchClientWithName(name);
            foreach(DataRow dr in dt.Rows)
            {
                if(name == dr["name"].ToString())
                {
                    idClient = Int32.Parse(dr["id"].ToString());
                }
            }

            ws.addReserve(Int32.Parse(this.id), idClient, arrivaldate, finishDate, typeRoom);

          
        }

        protected void btnDeleteReserve_Click(object sender, EventArgs e)
        {

            string idToDelete = deleteTxBox.Text;
            ws.deleteReserve(Int32.Parse(idToDelete));

            ListBox1.Items.Clear();

            string reserveString = "";
            dt = ws.dataReserve(Int32.Parse(id), 1);
            

            foreach (DataRow dr in dt.Rows)
            {
                reserveString = "";
                dt = ws.dataClient(Int32.Parse(dr["idRecepcionist"].ToString()));
                foreach (DataRow dr1 in dt.Rows)
                {

                    reserveString = "Id Reserve: " + dr["id"].ToString();
                    reserveString += " Client Name: " + dr1["name"].ToString() + "\t";
                    //ListBox1.Items.Add(dr1["name"].ToString());

                    Reserve reserve = new Reserve(Int32.Parse(dr["id"].ToString()), Int32.Parse(dr["idRecepcionist"].ToString()), Int32.Parse(dr["idClient"].ToString()), dr["arrivaldate"].ToString(), dr["finishdate"].ToString(), dr["typeRoom"].ToString());
                    listaReservas.Add(reserve);

                }


                reserveString += " Arrival Date: " + dr["arrivaldate"].ToString() + "\t";
                reserveString += " Finish Date: " + dr["finishdate"].ToString() + "\t";
                reserveString += " Type Room: " + dr["typeRoom"].ToString() + "\t";


                ListBox1.Items.Add(reserveString);
            }

        }

        protected void btnModifyReserve_Click(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            foreach(Reserve res in listaReservas)
            {
                infoBox.Items.Add("hola");
                if (res.IdReserve.ToString() == ListBox1.SelectedItem.Value)
                {
                    dt = ws.dataClient(res.IdClient);
                    infoBox.Text += res.IdClient.ToString();
                }
            }
            */
        }

        protected void deleteTxBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            string name = clientName.Text;
            string pass = clientPassword.Text;
            string sur = clientSurname.Text;
            int card = Int32.Parse(clientCard.Text);
            int idn = Int32.Parse(clientIdn.Text);

            ws.addClient(idn, name, pass, sur, card);
        }
    }
}