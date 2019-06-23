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
    public partial class Form2 : Form
    {
        mdetails mp = new mdetails();
        mpfunc mfunc = new mpfunc();
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            mp.masterpassword = passwordbox.Text.Trim();
            if(mfunc.verify(mp) == true)
            {
                var n = new Manager();
                n.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password!");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}
