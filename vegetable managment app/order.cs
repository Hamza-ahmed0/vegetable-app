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
    public partial class order : Form
    {
        public order()
        {
            InitializeComponent();
        }
        IFirebaseConfig con = new FirebaseConfig()
        {
            BasePath = "https://vegetable-app-8a45c-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "ghHuxkkGncDRdVq687pIk4cefeA8IAeFhkOBuG1q"
        };


        IFirebaseClient client;

        public static String itid = "";
        public static String itnm = "";
        public static String itqn = "";
        public static String itpr = "";
        public static String itdat = "";
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void order_Load(object sender, EventArgs e)
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


                foreach (var item in record)
                {
                    comboBox1.Items.Add(item.Value.id);
                }


            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var res = client.Get(@"ItemList/" + comboBox1.Text);
            item itm = res.ResultAs<item>();

            itemname.Text = itm.name;
            totalQuan.Text = itm.quantity;
        }

        private void ORDRBTN_Click(object sender, EventArgs e)


        {

            DateTime dt = DateTime.Now;
            
            
            //price cal
            var a = Convert.ToInt32(prcbx.Text);
            var b = Convert.ToInt32(enterQuan.Text);
            var c = a * b;


            //save all value in a var for billing form
            itid = comboBox1.Text;
            itnm = itemname.Text;
            itqn = enterQuan.Text;
            itpr = c.ToString();
            itdat = dt.ToString();


            //list view
            ListViewItem lisv = new ListViewItem(itid);
            lisv.SubItems.Add(itnm);
            lisv.SubItems.Add(itqn);
            lisv.SubItems.Add(itpr);
            lisv.SubItems.Add(itdat);
            listView1.Items.Add(lisv);
            comboBox1.Text = "";
            itemname.Text = "";
            totalQuan.Text = "";
            enterQuan.Text = "";
            prcbx.Text = "";



            var tot = Convert.ToInt32(totalQuan.Text);
            var mnc = tot - b;
            var Total = mnc.ToString();

            item itm = new item()
            {
                quantity = Total
            };

            SetResponse set = client.Set(@"ItemList/" + itid, itm);
           
        }
    }
}
