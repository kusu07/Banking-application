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
    public partial class FDform : Form
    {
        public FDform()
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
            //throw new NotImplementedException();
            //throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            banking_dbEntities2 dbe = new banking_dbEntities2();
            decimal accno = Convert.ToDecimal(accnotxt.Text);
            var account = dbe.UserAccounts.Where(x => x.Account_no == accno).SingleOrDefault();
            FD fdform = new FD();
            fdform.AccountNo = Convert.ToDecimal(accnotxt.Text);
            fdform.Mode = comboBox1.SelectedItem.ToString();
            fdform.Rupees = rupeestxt.Text;
            fdform.Period = Convert.ToInt32(periodstxt.Text);
            fdform.Interest_Rate = Convert.ToDecimal(interesttxt.Text);
            fdform.Start_Date = DateTime.UtcNow.ToString("MM/dd/yyyy");
            fdform.Maturity_Date = DateTime.UtcNow.AddDays(Convert.ToInt32(periodstxt.Text)).ToString("MM/dd/yyyy");
            fdform.Maturity_Amount = (Convert.ToDecimal(rupeestxt.Text) * Convert.ToInt32(periodstxt.Text) * Convert.ToDecimal(interesttxt.Text)) / (100 * 12 * 30) + Convert.ToDecimal(rupeestxt.Text);
            dbe.FDs.Add(fdform);
            decimal amount = Convert.ToDecimal(rupeestxt.Text);
            decimal totalamount = Convert.ToDecimal(account.Balance);
            decimal fdamount = totalamount - amount;
            account.Balance = fdamount;

            dbe.SaveChanges();
            MessageBox.Show("FD Started Now");

        }
    }
}
