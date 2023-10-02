using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_application
{
    public partial class depositform : Form
    {
        public depositform()
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
            datelbl.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
            // throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            banking_dbEntities2 context = new banking_dbEntities2();
            decimal b = Convert.ToDecimal(acctxt.Text);
            var item = (from u in context.UserAccounts where u.Account_no == b select u).FirstOrDefault();
            nametxt.Text = item.Name;
            oldtxt.Text = Convert.ToString(item.Balance);

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

            banking_dbEntities2 context = new banking_dbEntities2();
            NewAccount acc = new NewAccount();
            deposit db = new deposit();
            db.Date = datelbl.Text;
            db.AccountNo = Convert.ToDecimal(acctxt.Text);
            db.Name = nametxt.Text;
            db.OldBalance = Convert.ToDecimal(oldtxt.Text);
            db.Mode = comboBox1.SelectedItem.ToString();
            db.DipAmount = Convert.ToDecimal(dptxt.Text);
            context.deposits.Add(db);
            context.SaveChanges();
            decimal b = Convert.ToDecimal(acctxt.Text);
            var item = (from u in context.UserAccounts where u.Account_no == b select u).FirstOrDefault();
            item.Balance = item.Balance + Convert.ToDecimal(dptxt.Text);
            context.SaveChanges();
            MessageBox.Show("Deposit Money Successfully");
        }
    }
}
