using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Banking_application
{
    public partial class UpdateForm : Form
    {
        banking_dbEntities2 BSE;
        MemoryStream ms;
        BindingList<UserAccount> bi;
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bi = new BindingList<UserAccount>();
            BSE = new banking_dbEntities2();
            decimal accno = Convert.ToDecimal(accnotxt.Text);
            var item = BSE.UserAccounts.Where(a => a.Account_no == accno);
            foreach (var item1 in item)
            {
                bi.Add(item1);
            }
            dataGridView1.DataSource = bi;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bi = new BindingList<UserAccount>();
            BSE = new banking_dbEntities2();
            var item = BSE.UserAccounts.Where(a => a.Name == nametxt.Text);
            foreach (var item1 in item)
            {
                bi.Add(item1);
            }
            dataGridView1.DataSource = bi;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            BSE = new banking_dbEntities2();

            decimal accno = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            var item = BSE.UserAccounts.Where(a => a.Account_no == accno).FirstOrDefault();
            accnotxt.Text = item.Account_no.ToString();
            nametxt.Text = item.Name;
            phonetxt.Text = item.PhoneNumber;

            addresstxt.Text = item.Address;
            disttxt.Text = item.District;
            statetxt.Text = item.State;

            mothertxt.Text = item.Mother_Name;
            fathertxt.Text = item.Father_Name;
            byte[] img = item.Picture;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            if (item.Gender == "male")
            {
                malebtn.Checked = true;
            }
            else if (item.Gender == "female")
            {
                femalebtn.Checked = true;
            }
            else if (item.Gender == "other")
            {
                otherbtn.Checked = true;
            }
            if (item.Marriage_Status == "married")
            {
                marriedbtn.Checked = true;
            }
            else if (item.Marriage_Status == "unmarried")
            {
                unmarriedbtn.Checked = true;


            }


        }

        private void photobtn_Click(object sender, EventArgs e)
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

        private void deletebtn_Click(object sender, EventArgs e)
        {
            bi.RemoveAt(dataGridView1.SelectedRows[0].Index);
            BSE = new banking_dbEntities2();
            decimal accno = Convert.ToDecimal(accnotxt.Text);
            UserAccount acc = BSE.UserAccounts.First(s => s.Account_no.Equals(accno));
            BSE.UserAccounts.Remove(acc);
            BSE.SaveChanges();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            BSE = new banking_dbEntities2();
            decimal accountno = Convert.ToDecimal(accnotxt.Text);
            UserAccount userAccount= BSE.UserAccounts.First(s => s.Account_no.Equals(accountno));
            userAccount.Account_no = Convert.ToDecimal(accnotxt.Text);
            userAccount.Name = nametxt.Text;
            userAccount.DOB = dateTimePicker1.Text;
            userAccount.PhoneNumber = phonetxt.Text;
            userAccount.Address = addresstxt.Text;
            userAccount.District = disttxt.Text;
            userAccount.Address = addresstxt.Text;
            userAccount.Mother_Name = mothertxt.Text;
            userAccount.Father_Name = fathertxt.Text;
            userAccount.Date = dateTimePicker1.Value.ToString();
            if (malebtn.Checked = true)
            {
                userAccount.Gender = "male";
            }
            else
            {
                if (femalebtn.Checked = true)
                    userAccount.Gender = "female";
            }
            if(marriedbtn.Checked= true)
            {
                userAccount.Marriage_Status = "married";
            }
            else
            {
                if (unmarriedbtn.Checked = true)
                    userAccount.Marriage_Status = "unmarried";
            }
            Image img = pictureBox1.Image;
            if(img.RawFormat!= null)
            {
                if(ms!= null)
                {
                    img.Save(ms, img.RawFormat);
                    userAccount.Picture = ms.ToArray();
                }
            }
            BSE.SaveChanges();
            MessageBox.Show("updated successfully");

        




        }
    }
}