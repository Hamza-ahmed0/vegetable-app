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


            FirebaseResponse result = client.Get(@"ItemList/");

            Dictionary<String, item> data = JsonConvert.DeserializeObject<Dictionary<String, item>>(result.Body.ToString());
            PopulatedDataGrid(data);


            void PopulatedDataGrid(Dictionary<String, item> record)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("id", "id");
                dataGridView1.Columns.Add("name", "name");
                dataGridView1.Columns.Add("quantity", "quantity");

                foreach (var item in record)
                {
                    dataGridView1.Rows.Add(item.Value.id, item.Value.name, item.Value.quantity);
                }

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
            var result = client.Get(@"ItemList/" + itemid.Text);
            item itm = result.ResultAs<item>();
            itemid.Text = itm.id;
            itemnm.Text = itm.name;
            itemQ.Text = itm.quantity;




            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            item invetory = new item()
            {
                id = itemid.Text,
                name = itemnm.Text,
                quantity = itemQ.Text
            };


            var setr = client.Update(@"ItemList/" + itemid.Text, invetory);


            MessageBox.Show("Update Item");

            itemid.Text = "";
            itemnm.Text = "";
            itemQ.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = client.Delete(@"ItemList/" + itemid.Text);
            MessageBox.Show("Item deleted");

            itemid.Text = "";
            itemnm.Text = "";
            itemQ.Text = "";


           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 logout = new Form1();
            logout.Show();
            this.Hide();
        }
    }
}