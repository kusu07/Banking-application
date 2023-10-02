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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void newAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewAccount nc = new NewAccount();
            nc.MdiParent = this;
            nc.Show();

        }

        private void updatesearchAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateForm uf = new UpdateForm();
            uf.MdiParent = this;
            uf.Show();
        }

        private void allCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customerlist cl = new Customerlist();
            cl.MdiParent = this;
            cl.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            depositform df = new depositform();
            df.MdiParent = this;
            df.Show();
            
            
           


        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            withdraw w = new withdraw();
            w.MdiParent = this;
            w.Show();

        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tranfer t = new tranfer();
            t.MdiParent = this;
            t.Show();

        }

        private void fDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDform fd = new FDform();
            fd.MdiParent = this;
            fd.Show();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            balancesheet bs = new balancesheet();
            bs.MdiParent = this;
            bs.Show();

        }

        private void viewFDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewfd vf = new viewfd();
            vf.MdiParent = this;
            vf.Show();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changepassword cp = new changepassword();
            cp.MdiParent = this;
            cp.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void existToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
