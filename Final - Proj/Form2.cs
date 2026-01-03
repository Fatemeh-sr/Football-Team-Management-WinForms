using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___Proj
{
    public partial class Form2 : Form
    {
        public string s;  // یک متغیر عمومی


        public Form2(string username)
        {
            InitializeComponent();
            s = username;
            label2.Text = "Welcome " + s;
            label2.Font = new Font("Arial", 14, FontStyle.Bold);
            label2.BackColor = Color.LightGray;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'teamDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.teamDataSet.Players);



            pictureBox1.Dock = DockStyle.Fill;  // کل فرم رو بپوشونه
            pictureBox1.Image = Properties.Resources._2016_05_29_sergio_ramos_champions_league_sieg;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SendToBack(); // تصویر پشت بقیه کنترل ها باشه

            label3.BackColor = Color.LightSkyBlue;
            label7.BackColor = Color.LightSkyBlue;
            Number.BackColor = Color.LightSkyBlue;
            label4.BackColor = Color.LightSkyBlue;
            label5.BackColor = Color.LightSkyBlue;
            label6.BackColor = Color.LightSkyBlue;

            label3.Font = new Font("Arial", 12, FontStyle.Bold);
            label7.Font = new Font("Arial", 12, FontStyle.Bold);
            Number.Font = new Font("Arial", 12, FontStyle.Bold);
            label4.Font = new Font("Arial", 12, FontStyle.Bold);
            label5.Font = new Font("Arial", 12, FontStyle.Bold);
            label6.Font = new Font("Arial", 12, FontStyle.Bold);

            textBox1.BackColor = Color.LightBlue;
            textBox2.BackColor = Color.LightBlue;
            textBox3.BackColor = Color.LightBlue;
            textBox4.BackColor = Color.LightBlue;
            textBox5.BackColor = Color.LightBlue;
            textBox6.BackColor = Color.LightBlue;


            Search.BackColor = Color.LightSkyBlue;

            radioButton1.BackColor = Color.LightSkyBlue;
            radioButton2.BackColor = Color.LightSkyBlue;
            radioButton3.BackColor = Color.LightSkyBlue;

            pictureBox2.BackColor = Color.LightBlue;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Do you want to exit ? ", "Exit", MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void Search_Click(object sender, EventArgs e)
        {

            //  Trim()   :    یک متد برای حذف فاصله‌های خالی
            string name = textBox2.Text.Trim();
            string position = textBox4.Text.Trim();
            string nationality = textBox6.Text.Trim();
            string jersey = textBox3.Text.Trim();
            string id = textBox1.Text.Trim();



            // مقدار پیش‌فرض برای LIKE
            string nameParam = "%";
            string positionParam = "%";
            string nationalityParam = "%";
            string jerseyParam = "%";
            string idParam = "%";


            //  RadioButton جستجو بر طبق
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (radioButton1.Checked)
                    nameParam = name + "%";
                else if (radioButton2.Checked)
                    nameParam = "%" + name + "%";
                else if (radioButton3.Checked)
                    nameParam = name;
            }
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (radioButton1.Checked)
                    idParam = id + "%";
                else if (radioButton2.Checked)
                    idParam = "%" + id + "%";
                else if (radioButton3.Checked)
                    idParam = id;
            }

            if (!string.IsNullOrWhiteSpace(position))
            {
                if (radioButton1.Checked)
                    positionParam = position + "%";
                else if (radioButton2.Checked)
                    positionParam = "%" + position + "%";
                else if (radioButton3.Checked)
                    positionParam = position;
            }

            if (!string.IsNullOrWhiteSpace(nationality))
            {
                if (radioButton1.Checked)
                    nationalityParam = nationality + "%";
                else if (radioButton2.Checked)
                    nationalityParam = "%" + nationality + "%";
                else if (radioButton3.Checked)
                    nationalityParam = nationality;
            }

            if (!string.IsNullOrWhiteSpace(jersey))
            {
                if (radioButton1.Checked)
                    jerseyParam = jersey + "%";
                else if (radioButton2.Checked)
                    jerseyParam = "%" + jersey + "%";
                else if (radioButton3.Checked)
                    jerseyParam = jersey;
            }

            playersTableAdapter.FillBy(teamDataSet.Players, nameParam, idParam, positionParam, nationalityParam, jerseyParam);
            dataGridView1.DataSource = teamDataSet.Players;

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            // شماره پیراهن رو می‌گیریم
            string jersey = textBox3.Text;

            // مسیر تصویر بر اساس شماره پیراهن
            string imagePath = Path.Combine(Application.StartupPath, "Images", jersey + ".jpg");

            // اگر تصویر وجود داشت، نمایش بده
            if (File.Exists(imagePath))
            {
                pictureBox2.Image = Image.FromFile(imagePath);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox2.Image = null;
                MessageBox.Show("No image found for this player.");
            }


        }
    }
    
}
