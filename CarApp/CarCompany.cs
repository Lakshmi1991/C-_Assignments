using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Web;
using System.Xml.Serialization;
using System.IO;

namespace CarApp
{
    public partial class CarCompany : Form
    {
        XmlSerializer xs;
        List<CarCompanyDetails> CC;
        public CarCompany()
        {
            InitializeComponent();
           
            CC = new List<CarCompanyDetails>();
            xs = new XmlSerializer(typeof(List<CarCompanyDetails>));
            BindGrid();
        }
        public class CarCompanyDetails
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public string Year { get; set; }
            public string Mileage { get; set; }
            public string Price { get; set; }
            public string Availablity { get; set; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C:\\Users\\vibha\\Desktop\\C#\\CarApp\\CarApp\\CarCompany.xml", FileMode.Create, FileAccess.Write);
            CarCompanyDetails carComp = new CarCompanyDetails();
            carComp.Brand = txtBrand.Text;
            carComp.Model = txtModel.Text;
            carComp.Mileage = txtMileage.Text;
            carComp.Price = txtPrice.Text;
            carComp.Availablity = txtAvailable.Text;
            CC.Add(carComp);

            xs.Serialize(fs, CC);
            fs.Close();
            BindGrid();
        }

        private void BindGrid()
        {
            FileStream fs = new FileStream("C:\\Users\\vibha\\Desktop\\C#\\CarApp\\CarApp\\CarCompany.xml", FileMode.Open, FileAccess.Read);
            CC = (List<CarCompanyDetails>)xs.Deserialize(fs);
            dgvCarComp.DataSource = CC;
            fs.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("C:\\Users\\vibha\\Desktop\\C#\\CarApp\\CarApp\\CarCompany.xml");
            foreach (XmlNode xNode in xDoc.SelectNodes("ArrayOfCarCompanyDetails/CarCompanyDetails"))
                if(xNode.SelectSingleNode("Brand").InnerText == txtBrand.Text) xNode.ParentNode.RemoveChild(xNode);
            xDoc.Save("C:\\Users\\vibha\\Desktop\\C#\\CarApp\\CarApp\\CarCompany.xml");
            BindGrid();
        }
    }
}
