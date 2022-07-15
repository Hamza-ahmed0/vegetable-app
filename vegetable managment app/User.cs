using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vegetable_managment_app
{
    internal class User
    {

        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string contact { get; set; }
        public string shopname { get; set; }
        public string shopadd { get; set; }

        private static string error = "User Does NOt Exist";

        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool IsEqual (User user1, User user2)
        {
            if(user1 == null || user2 == null)
            {
                return false;
            }

            if(user1.email != user2.email)
            {
                error = "user does not exist";
            }

            else if (user1.password != user2.password)
            {
                error = "Wrong Password";
            }

            return true;
        }
    }
}
