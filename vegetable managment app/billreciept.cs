using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Newtonsoft.Json;
namespace vegetable_managment_app
{
    public partial class billreciept : Form
    {
        public billreciept()
        {
            InitializeComponent();
        }


        IFirebaseConfig con = new FirebaseConfig()
        {
            BasePath = "https://vegetable-app-8a45c-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "ghHuxkkGncDRdVq687pIk4cefeA8IAeFhkOBuG1q"
        };


        IFirebaseClient client;


        private void Print(Panel panl)
        {
            PrinterSettings ps = new PrinterSettings();
            pnl = panl;
            getprintarea(panl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();


        }

        private Bitmap memomryimg;

        private void getprintarea(Panel panl)
        {
            memomryimg = new Bitmap(panl.Width, panl.Height);
            panl.DrawToBitmap(memomryimg, new Rectangle(0, 0, panl.Width, panl.Height));
        }
        private void billreciept_Load(object sender, EventArgs e)
        {

            try
            {
                client = new FireSharp.FirebaseClient(con);
            }
            catch
            {
                MessageBox.Show("No Internet");
            }

            FirebaseResponse result = client.Get(@"userlist/");


            Dictionary<String, User> data = JsonConvert.DeserializeObject<Dictionary<String, User>>(result.Body.ToString());
            PopulatedDataGrid(data);


            void PopulatedDataGrid(Dictionary<String, User> record)
            {


                foreach (var User in record)
                {
                    label6.Text = User.Value.shopname;
                }


            }


            DateTime date = DateTime.Now;
            label7.Text = date.ToString("M/d/yyyy");

            label8.Text = bill.ordrno;
            label9.Text = bill.custnm;
            label10.Text = bill.custph;

            label14.Text = bill.totalamt;

            ListViewItem lst = new ListViewItem(order.itqn);
            lst.SubItems.Add(order.itnm);
            lst.SubItems.Add(order.itpr);
            listView1.Items.Add(lst);


            

        }

        private void ORDRBTN_Click(object sender, EventArgs e)
        {
            Print(this.pnl);
        }

        private void pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memomryimg, (pagearea.Width / 2) - (this.pnl.Width / 2), this.pnl.Location.Y); ;
        }
    }
}
