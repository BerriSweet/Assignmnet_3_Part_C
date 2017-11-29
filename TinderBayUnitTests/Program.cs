using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinderBayUnitTests
{
     public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public bool isLoggedIn = false;
        /// <summary>
        /// Checks if the correct username and password are entered
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login(string username, string password)
        {

            try
            {
                if (username == "martin" && password == "martin")
                {
                    isLoggedIn = true;
                   // StartActivity(typeof(ProfileActivity));
                }
            }
            catch (Exception exception)
            {
               
            }
        }
    }
}
