using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Banking_application
{
    public partial class NewAccount : Form
    {
        string gender = string.Empty;
        string m_status = string.Empty;
        decimal no;
        banking_dbEntities2 BSE;
        MemoryStream ms;
        public NewAccount()
        {
            InitializeComponent();
            loaddate();
            loadstate();
            loadaccount();


        }

        private void loadaccount()
        {
            BSE = new banking_dbEntities2();
            var item = BSE.UserAccounts.ToArray();
            no = item.LastOrDefault().Account_no + 1;
            accnotxt.Text = Convert.ToString(no);





            //throw new NotImplementedException();
        }

        private void loadstate()
        {
            comboBox1.Items.Add("Bagmati");
            // throw new NotImplementedException();
        }

        private void loaddate()
        {
            datelbl.Text = DateTime.Now.ToString("MM/dd/yyyy");
            // throw new NotImplementedException();
        }

        private void accnotxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                pictureBox1.Image = img;
                ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (malebtn.Checked)
            {
                gender = "male";
            }
            else if (femalebtn.Checked)
            {
                gender = "female";
            }
            else if (otherbtn.Checked)
            {
                gender = "other";
            }
            if (marriedbtn.Checked)
            {
                m_status = "married";
            }
            else if (unmarriedbtn.Checked)
            {
                m_status = "unmarried";
            }
            BSE = new banking_dbEntities2();
            UserAccount acc = new UserAccount();
            acc.Account_no = Convert.ToDecimal(accnotxt.Text);
            acc.Name = nametxt.Text;
            acc.DOB = dateTimePicker1.Text;
            acc.PhoneNumber= phonetxt.Text;
            acc.Address = addresstxt.Text;
            acc.District = disttxt.Text;
            acc.State = comboBox1.Text;
            acc.Gender = gender;
            acc.Marriage_Status = m_status;
            acc.Mother_Name = mothertxt.Text;
            acc.Father_Name = fathertxt.Text;
            acc.Balance = Convert.ToDecimal(balancetxt.Text);
            acc.Date = datelbl.Text;
            acc.Picture = ms.ToArray();
            BSE.UserAccounts.Add(acc);
            BSE.SaveChanges();
            MessageBox.Show("file saved");
        }
    }
}
