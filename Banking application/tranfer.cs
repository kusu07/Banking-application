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
    public partial class tranfer : Form
    {
      
        public tranfer()
        {
            InitializeComponent();
            loaddate();

        }

        private void loaddate()
        {

            datelbl.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
            //throw new NotImplementedException();
        }

        private void showbtn_Click(object sender, EventArgs e)
        {
            banking_dbEntities2 context = new banking_dbEntities2();
            decimal b = Convert.ToDecimal(Fantxt.Text);
            var item = (from u in context.UserAccounts where u.Account_no == b select u).FirstOrDefault();
            nametxt.Text = item.Name;
            catxt.Text = Convert.ToString(item.Balance);

        }

        private void transferbtn_Click(object sender, EventArgs e)
        {
            banking_dbEntities2 context = new banking_dbEntities2();
            decimal b = Convert.ToDecimal(Fantxt.Text);
            var item = (from u in context.UserAccounts where u.Account_no == b select u).FirstOrDefault();
            decimal b1 = Convert.ToDecimal(item.Balance);
            decimal totalbalance = Convert.ToDecimal(amounttxt.Text);
            decimal transferacc = Convert.ToDecimal(datxt.Text);
            if (b1 > totalbalance)
            {
              UserAccount item2= (from u in context.UserAccounts where u.Account_no == transferacc select u).FirstOrDefault();
                item2.Balance = item2.Balance + totalbalance;
                item.Balance = item.Balance - totalbalance;
                transfer transfer = new transfer();
                transfer.AccountNo = Convert.ToDecimal(Fantxt.Text);
                transfer.ToTransfer = Convert.ToDecimal(datxt.Text);
                transfer.Name = nametxt.Text;
                transfer.Balance = Convert.ToDecimal(amounttxt.Text);


                context.transfers.Add(transfer);
                context.SaveChanges();
                MessageBox.Show("transfer money successfully");
                
            }
        }
    }
}
