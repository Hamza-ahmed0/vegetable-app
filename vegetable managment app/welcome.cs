using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        IFirebaseConfig con = new FirebaseConfig()
        {
            BasePath = "https://vegetable-app-8a45c-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "ghHuxkkGncDRdVq687pIk4cefeA8IAeFhkOBuG1q"
        };


        IFirebaseClient client;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 logout = new Form1();
            logout.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void welcome_Load(object sender, EventArgs e)
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
                    label10.Text = User.Value.username;
                    label11.Text = User.Value.shopname;
                }


            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void plcordr_Click(object sender, EventArgs e)
        {
            order od = new order();
            od.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inventory inv = new inventory();
            inv.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stock stk = new stock();
            stk.Show();
            this.Hide();
        }
    }
}
