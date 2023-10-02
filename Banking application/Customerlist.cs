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
    public partial class Customerlist : Form
    {
        public Customerlist()
        {
            InitializeComponent();
            bindgrid();




        }

        private void bindgrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            banking_dbEntities2 bd = new banking_dbEntities2();
            var item = bd.UserAccounts.ToList(); 
            dataGridView1.DataSource = item;
            //throw new NotImplementedException();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
