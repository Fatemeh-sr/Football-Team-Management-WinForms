using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___Proj
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            // TODO: This line of code loads data into the 'teamDataSet.Users' table. You can move, or remove it, as needed.
            //this.usersTableAdapter.Fill(this.teamDataSet.Users);


            this.MaximizeBox = false;          // غیرفعال کردن دکمه بزرگنمایی
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  // غیر قابل تغییر کردن اندازه فرم

            pictureBox1.Dock = DockStyle.Fill;  // کل فرم رو بپوشونه
            pictureBox1.Image = Properties.Resources.Estadio_Santiago_Bernabéu_Madrid;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SendToBack(); // تصویر پشت بقیه کنترل ها باشه

            label1.Font = new Font("Arial", 14, FontStyle.Bold);
            label1.Size = new Size(200, 50);
            label1.BackColor = Color.LightGray;


            label2.Font = new Font("Arial", 14, FontStyle.Bold);
            label2.Size = new Size(200, 50);
            label2.BackColor = Color.LightGray;


            textBox2.Font = new Font("Arial", 14);
            txtPassword.Font = new Font("Arial", 14);


            button1.Font = new Font("Arial", 14, FontStyle.Bold);


            button1.BackColor = Color.Purple;  // بنفش معمولی
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;  

            // تکست‌باکس با پس‌زمینه خاکستری روشن و متن مشکی
            txtPassword.BackColor = Color.LightGray;
            txtPassword.ForeColor = Color.Black;

            textBox2.BackColor = Color.LightGray;
            textBox2.ForeColor = Color.Black;


            pictureBox2.Image = Properties.Resources._7;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = usersTableAdapter.GetDataBy(textBox2.Text, txtPassword.Text);


            if (dt.Rows.Count > 0)
            {
                string role = dt.Rows[0]["Role"].ToString();

                MessageBox.Show("Welcom.. your Role : " + role);

                if (role == "Admin")
                {
                    Form3 f3 = new Form3(textBox2.Text);  // نام کاربری
                    f3.s = textBox2.Text;
                    f3.ShowDialog();
                   

                }
                else
                {
                    Form2 f2 = new Form2(textBox2.Text);  // نام کاربری
                    f2.s = textBox2.Text;
                    f2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("The username or password you entered is incorrect.");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void whatsNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
