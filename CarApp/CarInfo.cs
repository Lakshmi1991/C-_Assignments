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
using System.Xml.Serialization;

namespace CarApp
{
    public partial class CarInfo : Form
    {

        XmlSerializer xs;
        List<CompanyInfo> CompInfo;

        public CarInfo()
        {
            InitializeComponent();
            CompInfo = new List<CompanyInfo>();
            xs = new XmlSerializer(typeof(List<CompanyInfo>));
            BindGrid();
        }

        private void BindGrid()
        {
            FileStream fs = new FileStream("C:\\Users\\vibha\\Desktop\\C#\\CarApp\\CarApp\\CompanyInfo.xml", FileMode.Open, FileAccess.Read);
            CompInfo = (List<CompanyInfo>)xs.Deserialize(fs);
            dgvComp.DataSource = CompInfo;
            fs.Close();
        }


        public class CompanyInfo
        {
            public string Name { get; set; }
            public string address { get; set; }
            public string Phone { get; set; }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C:\\Users\\vibha\\Desktop\\C#\\CarApp\\CarApp\\CompanyInfo.xml", FileMode.Create, FileAccess.Write);
            CompanyInfo cc = new CompanyInfo();
            cc.Name = txtName.Text;
            cc.address = txtAddress.Text;
            cc.Phone = txtPhone.Text;

            CompInfo.Add(cc);

            xs.Serialize(fs, CompInfo);
            fs.Close();
            BindGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("C:\\Users\\vibha\\Desktop\\C#\\CarApp\\CarApp\\CompanyInfo.xml");
            foreach (XmlNode xNode in xDoc.SelectNodes("ArrayOfCompanyInfo/CompanyInfo"))
                if (xNode.SelectSingleNode("Name").InnerText == txtName.Text) xNode.ParentNode.RemoveChild(xNode);
            xDoc.Save("C:\\Users\\vibha\\Desktop\\C#\\CarApp\\CarApp\\CompanyInfo.xml");
            BindGrid();
        }
    }
}
