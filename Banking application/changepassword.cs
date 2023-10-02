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
    public partial class changepassword : Form
    {
        public changepassword()
        {
            InitializeComponent();
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            banking_dbEntities2 dbe = new banking_dbEntities2();
            if (oldpass.Text != string.Empty || newpass.Text != string.Empty || retypepass.Text != string.Empty)
            {
                admin_table user1 = dbe.admin_table.FirstOrDefault(a => a.Username.Equals(usertxt.Text));
                if (user1 != null)
                {
                    if (user1.Password.Equals(oldpass.Text))
                    {
                        user1.Password = newpass.Text;
                        dbe.SaveChanges();
                        MessageBox.Show("password changes sucessfully");
                    }
                    else
                    {
                        MessageBox.Show("password incorrect");

                    }
                }
            }

        }

    }
    }

