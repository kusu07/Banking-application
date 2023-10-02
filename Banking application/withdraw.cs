using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Banking_application
{
    public partial class withdraw : Form
    {
        public withdraw()
        {
            InitializeComponent();
            loaddate();
            loadmode();
        }

        private void loadmode()
        {
            comboBox1.Items.Add("Cash");
            comboBox1.Items.Add("Chque");

            // throw new NotImplementedException();
        }

        private void loaddate()
        {
            datelbl.Text = DateTime.Now.ToString("MM/dd/yyyy");
            // throw new NotImplementedException();
        }

    

        private void GDbtn_Click(object sender, EventArgs e)
        {

            banking_dbEntities2 context = new banking_dbEntities2();
            decimal b = Convert.ToDecimal(accnotxt.Text);
            var item = (from u in context.UserAccounts where u.Account_no == b select u).FirstOrDefault();
            nametxt.Text = item.Name;
            oldbalancetxt.Text = Convert.ToString(item.Balance);

           
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {

            banking_dbEntities2 dbe = new banking_dbEntities2();
            NewAccount nacc = new NewAccount();
            debit dp = new debit();
            dp.Date = datelbl.Text;
            dp.AccountNo = Convert.ToDecimal(accnotxt.Text);
            dp.Name = nametxt.Text;
            dp.OldBalance = Convert.ToDecimal(oldbalancetxt.Text);
            dp.Mode = comboBox1.SelectedItem.ToString();
            dp.DebAmount = Convert.ToDecimal(amounttxt.Text);
            dbe.debits.Add(dp);
            dbe.SaveChanges();
            decimal b = Convert.ToDecimal(accnotxt.Text);
            var item = (from u in dbe.UserAccounts where u.Account_no == b select u).FirstOrDefault();
            item.Balance = item.Balance - Convert.ToDecimal(amounttxt.Text);
            dbe.SaveChanges();
            MessageBox.Show("Debit Money");
        }

    }
    }
