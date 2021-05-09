using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.localhost;
using System.IO;
using System.Threading.Tasks;


namespace WebApplication1
{
    public partial class recepcionistMaster : System.Web.UI.Page
    {
        public DataTable datosRecepcionista = new DataTable();
        public DataTable datosCliente = new DataTable();
        public DataTable dtR = new DataTable();

        public string DBpath = HttpRuntime.AppDomainAppPath + "basedatos.db";
        public WebService1 ws;
        public List<Reserve> listaReservas;
        private String id;
        private string newfile;
        protected void Page_Load(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            listaReservas = new List<Reserve>();
            ws = new WebService1();

            this.id = String.IsNullOrEmpty(Request.QueryString["id"]) ? "" : Request.QueryString["id"].ToString();

            datosRecepcionista = ws.dataRecepcionist(Int32.Parse(id));

            foreach (DataRow dr in datosRecepcionista.Rows)
            {
                Label4.Text = dr["name"].ToString();

                Label5.Text = " " + dr["surname"].ToString();

            }

            dtR = ws.dataReserve(Int32.Parse(id), 1);
            String reserveString;

            foreach (DataRow dr in dtR.Rows)
            {
                reserveString = "";
                reserveString = "Reserve id: " + dr["id"].ToString();
                reserveString += "IDN Client: " + dr["idnClient"].ToString();
                reserveString += " Arrival Date: " + dr["arrivaldate"].ToString() + "\t";
                reserveString += " Finish Date: " + dr["finishdate"].ToString() + "\t";
                reserveString += " Type Room: " + dr["typeRoom"].ToString() + "\t";

                ListBox1.Items.Add(reserveString);
                Reserve reserve = new Reserve(Int32.Parse(dr["id"].ToString()), Int32.Parse(id), Int32.Parse(dr["idnClient"].ToString()), dr["arrivaldate"].ToString(), dr["finishdate"].ToString(), dr["typeRoom"].ToString());
                listaReservas.Add(reserve);
            }


        }

        protected void btnAddReserve_Click(object sender, EventArgs e)
        {
            try
            {


                int idn = Int32.Parse(clientIdn.Text);
                string name = clientName.Text;
                string pass = clientPassword.Text;
                string sur = clientSurname.Text;
                int card = Int32.Parse(clientCard.Text);
                int idRecepcionist = Int32.Parse(id);



                string arrivaldate = arrivalDate.Text;
                string finishDate = finishdate.Text;
                string typeRoom = typeroom.Text;

                ws.addClient(idn, name, pass, sur, card);


                ws.addReserve(idRecepcionist, idn, arrivaldate, finishDate, typeRoom);
                Page_Load(this, null);

            }
            
            catch 
            {
                Response.Write("<script>alert('Incorrect input in the textbox');</script>");
            }


            





        }

        protected void btnDeleteReserve_Click(object sender, EventArgs e)
        {
            try
            {
                string idToDelete = deleteTxBox.Text;
                ws.deleteReserve(Int32.Parse(idToDelete));
                ListBox1.Items.Clear();
                Page_Load(this, null);
            }
            catch
            {
                Response.Write("<script>alert('Please introduce a valid id in the textbox');</script>");
            }
            

        }

        protected void btnModifyReserve_Click(object sender, EventArgs e)
        {
            try
            {
                int idReserve = Int32.Parse(inputModify.Text);
                int idnClient = Int32.Parse(modIdn.Text);
                string arrivalDate = modArrivalDate.Text;
                string finishdate = modFinishDate.Text;
                string typeRoom = modTypeRoom.Text;

                ws.modifyReserve(idReserve, idnClient, arrivalDate, finishdate, typeRoom);
                clearModifyTextbox();
                Page_Load(this, null);
            }
            catch
            {
                Response.Write("<script>alert('Make sure your modified data is correct');</script>");
                clearModifyTextbox();
            }
            


        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        { }

        protected void deleteTxBox_TextChanged(object sender, EventArgs e) { }

        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            string name = clientName.Text;
            string pass = clientPassword.Text;
            string sur = clientSurname.Text;
            int card = Int32.Parse(clientCard.Text);
            int idn = Int32.Parse(clientIdn.Text);

            ws.addClient(idn, name, pass, sur, card);
        }

        protected void clearModify_Click(object sender, EventArgs e)
        {
            clearModifyTextbox();
        }

        public void clearModifyTextbox()
        {
            modIdn.Text = "";
            modArrivalDate.Text = "";
            modFinishDate.Text = "";
            modTypeRoom.Text = "";
            inputModify.Text = "";
        }

        protected void exportBtn_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Sergi\Desktop\ProjecteIngles\projecte-Ing\NatxoSergiProyecte\NatxoSergiProyecte\reservesList.txt";
            string listJSON = JsonConvert.SerializeObject(listaReservas);



            try
            {
                
                StreamWriter sw = new StreamWriter(path);
                
                sw.WriteLine(listJSON);
                
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            
        }
    }
}
