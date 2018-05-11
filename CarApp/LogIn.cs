using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json.Linq;  

namespace CarApp
{
    public partial class LogIn : Form
    {

       public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            GetUserlogin();
        }

        private void GetUserlogin()
        {

            try
            {
         
                //object initialised
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("C:\\Users\\vibha\\Desktop\\C#\\CarApp\\CarApp\\Login.xml");

                foreach (XmlNode xNode in xDoc.SelectNodes("arrayofLogins/login"))

                if (xNode.SelectSingleNode("user").InnerText == txtUser.Text && xNode.SelectSingleNode("pass").InnerText == txtPassword.Text)
                {
                        var objCar = new Mainmenu();
                        objCar.Show();
                }
                else
                {
                        
                       // MessageBox.Show("Invalid Credentials");
                }

            }
            catch (Exception ex)
            {
            }

        }

    }
}
