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
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace vegetable_managment_app
{
    public partial class inventory : Form
    {
        public inventory()
        {
            InitializeComponent();
        }

        IFirebaseConfig con = new FirebaseConfig()
        {
            BasePath = "https://vegetable-app-8a45c-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "ghHuxkkGncDRdVq687pIk4cefeA8IAeFhkOBuG1q"
        };


        IFirebaseClient client;

        private void inventory_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(con);
            }
            catch
            {
                MessageBox.Show("No Internet");
            }




        }

        private void button1_Click(object sender, EventArgs e)


        {
            item invetory = new item()
            {
                id = itemid.Text,
                name = itemnm.Text,
                quantity = itemQ.Text
            };


            SetResponse setr = client.Set(@"ItemList/" + itemid.Text, invetory);


            MessageBox.Show("list created");

            itemid.Text = "";
            itemnm.Text = "";
            itemQ.Text = "";

            
            
            
            

        }


        

        private void button2_Click(object sender, EventArgs e)
        {
            



            

        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            


           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void itemnm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            welcome wel = new welcome();
            wel.Show();
            this.Hide();
        }
    }
}