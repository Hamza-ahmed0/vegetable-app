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

        private void bill_Load(object sender, EventArgs e)
        {
            ListViewItem rview = new ListViewItem(order.itid);
            rview.SubItems.Add(order.itnm);
            rview.SubItems.Add(order.itpr);
            rview.SubItems.Add(order.itqn);
            rview.SubItems.Add(order.itdat);
            listView1.Items.Add(rview);

            label5.Text = order.total;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            
        }
    }
}
