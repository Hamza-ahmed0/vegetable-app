using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vegetable_managment_app
{
    public partial class bill : Form
    {
        public bill()
        {
            InitializeComponent();
        }

        public static string ordrno = "";
        public static string custnm = "";
        public static string custph = "";
        public static string totalamt = "";
        public static string items = "";


        private void bill_Load(object sender, EventArgs e)
        {
            ListViewItem rview = new ListViewItem(order.itid);
            rview.SubItems.Add(order.itnm);
            rview.SubItems.Add(order.itpr);
            rview.SubItems.Add(order.itqn);
            rview.SubItems.Add(order.itdat);
            listView1.Items.Add(rview);

            totalamt = order.total;
            label5.Text = totalamt;

            


           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            
        }

        private void edt_Click(object sender, EventArgs e)
        {
            order ord = new order();
            ord.Show();
            this.Hide();
        }

        private void chkot_Click(object sender, EventArgs e)
        {

            ordrno = ordnotxt.Text;
            custnm = custnametxt.Text;
            custph = custphntxt.Text;

            if(ordnotxt.Text != null)
            {
                billreciept rcp = new billreciept();
                rcp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("First fill all fields");
            }
        }
    }
}
