using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class AddingEntries : Form
    {
        public AddingEntries()
        {
            InitializeComponent();
        }
        pdbfunctions Func = new pdbfunctions();
        pdetails p = new pdetails();
        private void AddingEntries_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Password can't be empty!");
            }
            else
            {
                p.title = textBox1.Text.Trim();
                p.username = textBox3.Text.Trim();
                p.password = textBox2.Text.Trim();
                bool ok = Func.Insert(p);
                if(ok == true)
                {
                    MessageBox.Show("ADDED!\nRefresh Helps!Please Click that.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Can't be added!");
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
