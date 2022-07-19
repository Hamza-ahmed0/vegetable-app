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

namespace vegetable_managment_app
{
    public partial class Registration_form : Form
    {
        public Registration_form()
        {
            InitializeComponent();
        }


        IFirebaseConfig con = new FirebaseConfig()
        {
            BasePath = "https://vegetable-app-8a45c-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "ghHuxkkGncDRdVq687pIk4cefeA8IAeFhkOBuG1q"
        };


        IFirebaseClient client;

        

        private void Registration_form_Load(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 loginfrm = new Form1();
            loginfrm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if(String.IsNullOrEmpty(txtbxuser.Text) &&
                String.IsNullOrEmpty(emailtxtbx.Text) &&
                String.IsNullOrEmpty(passtextbx.Text) &&
                String.IsNullOrEmpty(cntextbx.Text) &&
                String.IsNullOrEmpty(shtextbx.Text) &&
                String.IsNullOrEmpty(shaddtxtbx.Text))
            {
                MessageBox.Show("All field must be filled");
                return;
            }



            User user = new User()
            {
                username = txtbxuser.Text,
                email = emailtxtbx.Text,
                password = passtextbx.Text,
                contact = cntextbx.Text,
                shopname = shtextbx.Text,
                shopadd = shaddtxtbx.Text


            };

            SetResponse set = client.Set(@"userlist/" + txtbxuser.Text, user);
            MessageBox.Show("Successfully Registered");

            txtbxuser.Text = "";
            emailtxtbx.Text ="";
            passtextbx.Text = "";
            cntextbx.Text = "";
            shtextbx.Text = "";
            shaddtxtbx.Text = "";
        }

        private void txtbxuser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
