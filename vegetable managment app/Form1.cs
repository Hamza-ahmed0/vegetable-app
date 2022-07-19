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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IFirebaseConfig con = new FirebaseConfig()
        {
            BasePath = "https://vegetable-app-8a45c-default-rtdb.asia-southeast1.firebasedatabase.app/",
            AuthSecret = "ghHuxkkGncDRdVq687pIk4cefeA8IAeFhkOBuG1q"
        };
       
    
        IFirebaseClient client;


        Registration_form rgstrfrm = new Registration_form();

        private void Form1_Load(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtbxuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            rgstrfrm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(emailtxtbx.Text) &&
               String.IsNullOrEmpty(txtbxpass.Text))
            {
                MessageBox.Show("All field must be filled");
                return;
            }



            FirebaseResponse response = client.Get(@"userlist/"  + emailtxtbx.Text );

            User resuser = response.ResultAs<User>();

            User curuser = new User()
            {
                username = emailtxtbx.Text,
                password = txtbxpass.Text
            };


            if(User.IsEqual(curuser, resuser))
            {
                welcome wel = new welcome();
                wel.Show();
                this.Hide();
            }

            else
            {
                User.ShowError();
            }
        }
    }
}
