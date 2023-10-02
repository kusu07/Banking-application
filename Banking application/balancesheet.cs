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

namespace Banking_application
{
    public partial class balancesheet : Form
    {
        public balancesheet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            banking_dbEntities2 dbe = new banking_dbEntities2();
            decimal b = Convert.ToDecimal(textBox1.Text);
            var item = (from u in dbe.debits where u.AccountNo== b select u);

            dataGridView1.DataSource = item.ToList();
            var item1 = (from u in dbe.deposits where u.AccountNo == b select u);

            dataGridView2.DataSource = item1.ToList();
            var item2 = (from u in dbe.transfers where u.AccountNo == b select u);

            dataGridView3.DataSource = item2.ToList();



        }

        private void balancesheet_Load(object sender, EventArgs e)
        {

        }
    }
}
