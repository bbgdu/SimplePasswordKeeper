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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int sno;
        string temptitle, tempusername,temppassword;
        pdetails p = new pdetails();
        mdetails mp = new mdetails();
        pdbfunctions func = new pdbfunctions();
        mpfunc mpfunc = new mpfunc();
        private void Manager_Load(object sender, EventArgs e)
        {
            dataGridView1.ForeColor = Color.Black;
            textBox1.Visible = false;
            button1.Visible = false;
            pictureBox1.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            pictureBox2.Visible = false;

            DataTable dt =func.Select();
            dataGridView1.DataSource = dt;

            dataGridView1.Rows[0].Selected = true;
        }
        string temptext;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

          copied.Text = "COPIED!";
           copied.ForeColor = System.Drawing.Color.White;
            Clipboard.SetText(temptext);

            var t = new Timer();
            t.Interval = 2000;
            t.Tick += (s, en) =>
            {
                copied.Text = "";
                t.Stop();

            };
        }


        private void label6_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            p.username = tempusername;
            p.title = temptitle;
            p.password = textBox1.Text.Trim();
            p.sno = sno;
            bool ok = func.Update(p);
            if (ok == true) { MessageBox.Show("Updated!"); }
            else { MessageBox.Show("Not Updated!"); }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            p.username = tempusername;
            p.title = temptitle;
            p.password = textBox1.Text.Trim();
            p.sno = sno;
            bool ok = func.Delete(p);
            if (ok == true)
            {
                copied.Text = "DELETED!";
                copied.ForeColor = System.Drawing.Color.White;
                var t = new Timer();
                t.Interval = 2000;
                t.Tick += (s, en) =>
                {
                    copied.Text = "";
                    t.Stop();

                };
                t.Start();
            }
            else
            {
                MessageBox.Show("Not Deleted!");
            }
            
            
           


        }

        

        private void label4_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            button2.Visible = true;
            pictureBox2.Visible = true;
            textBox2.Text = mpfunc.Getmp();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // add entries 
            //create new form
            var m = new AddingEntries();
            m.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CONTACT DEVELOPER:\ndeepak654123@gmail.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            bool ok = func.Update(p);
            if (ok == true)
            {
                MessageBox.Show("Updated!");
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Not Updated!");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                func.DeleteAll();
                MessageBox.Show("DELETED!");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rownum = e.RowIndex;
            sno = Int32.Parse(dataGridView1.Rows[rownum].Cells[0].Value.ToString());

            textBox1.Text = dataGridView1.Rows[rownum].Cells[3].Value.ToString();
            temptitle = dataGridView1.Rows[rownum].Cells[1].Value.ToString();
            tempusername = dataGridView1.Rows[rownum].Cells[2].Value.ToString();
            p.username = tempusername;
            p.title = temptitle;
            p.password = textBox1.Text.Trim();
            p.sno = sno;
            var t = new Timer();
            t.Interval = 2000;
            t.Tick += (s, en) =>
            {
                copied.Text = "";
                t.Stop();

            };
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rownum = e.RowIndex;
            sno = Int32.Parse(dataGridView1.Rows[rownum].Cells[0].Value.ToString());

            textBox1.Text = dataGridView1.Rows[rownum].Cells[3].Value.ToString();
            temptitle = dataGridView1.Rows[rownum].Cells[1].Value.ToString();
            tempusername = dataGridView1.Rows[rownum].Cells[2].Value.ToString();
            p.username = tempusername;
            p.title = temptitle;
            p.password = textBox1.Text.Trim();
            p.sno = sno;
            var t = new Timer();
            t.Interval = 2000;
            t.Tick += (s, en) =>
            {
                copied.Text = "";
                t.Stop();

            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mp.masterpassword = textBox2.Text.Trim();
            mpfunc.DeleteAll();
            mpfunc.insertintomp(mp);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.UseSystemPasswordChar == false)
            {
                textBox1.UseSystemPasswordChar = true;
            }
            else
            {
                textBox1.UseSystemPasswordChar = false;
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rownum = e.RowIndex;
            sno = Int32.Parse(dataGridView1.Rows[rownum].Cells[0].Value.ToString());

            textBox1.Text = dataGridView1.Rows[rownum].Cells[3].Value.ToString();
            temptitle = dataGridView1.Rows[rownum].Cells[1].Value.ToString();
            tempusername = dataGridView1.Rows[rownum].Cells[2].Value.ToString();
            p.username = tempusername;
            p.title = temptitle;
            p.password = textBox1.Text.Trim();
            p.sno = sno;
            var t = new Timer();
            t.Interval = 2000;
            t.Tick += (s, en) =>
            {
                copied.Text = "";
                t.Stop();

            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Refresh();
            textBox1.Visible = false;
            button1.Visible = false;
            pictureBox1.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            pictureBox2.Visible = false;

            DataTable dt = func.Select();
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
                if (e.ColumnIndex == 3 && e.Value != null)
                {
                    e.Value = new String('*', e.Value.ToString().Length);
                }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(textBox2.UseSystemPasswordChar == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
