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
    public partial class loginformcs : Form
    {
        public loginformcs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            banking_dbEntities2 dbe = new banking_dbEntities2();

            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {
                var user1 = dbe.admin_table.FirstOrDefault(a => a.Username.Equals(textBox1.Text));

                if (user1 != null)
                {
                    if (user1.Password.Equals(textBox2.Text))
                    {
                        Menu m1 = new Menu();
                        m1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("password incorrect");
                    }

                }
                else
                {
                    MessageBox.Show("null value");
                }

            }
            else
            {
                MessageBox.Show("please enter usename or password");
            }





            }

            
        }
    }
