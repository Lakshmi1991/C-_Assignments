using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarApp
{
    public partial class Mainmenu : Form
    {
        public Mainmenu()
        {
            InitializeComponent();
        }

        private void lblCompanyInfo_Click(object sender, EventArgs e)
        {
            var objCar = new CarCompany();
                        objCar.Show();
        }

        private void lblCarInfo_Click(object sender, EventArgs e)
        {
            var objCar = new CarInfo();
            objCar.Show();
        }
    }
}
