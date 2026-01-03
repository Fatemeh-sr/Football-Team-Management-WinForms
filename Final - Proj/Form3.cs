using Final___Proj.teamDataSetTableAdapters;
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
using System.Xml.Linq;

namespace Final___Proj
{
    public partial class Form3 : Form
    {
        public string s;  // یک متغیر عمومی


        public Form3(string username)
        {
            InitializeComponent();
            s = username;
            label1.Text = "welcome " + s;
            label1.Font = new Font("Arial", 14, FontStyle.Bold);
            label1.BackColor = Color.LightGray;


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'teamDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.teamDataSet.Players);
            // TODO: This line of code loads data into the 'teamDataSet1.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.teamDataSet.Players);
            // TODO: This line of code loads data into the 'teamDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.teamDataSet.Players);



            pictureBox1.Dock = DockStyle.Fill;  // کل فرم رو بپوشونه
            pictureBox1.Image = Properties.Resources.re;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SendToBack(); // تصویر پشت بقیه کنترل ها باشه

            label3.BackColor = Color.LightSkyBlue;
            Label2.BackColor = Color.LightSkyBlue;
            Number.BackColor = Color.LightSkyBlue;
            label4.BackColor = Color.LightSkyBlue;
            label5.BackColor = Color.LightSkyBlue;
            label6.BackColor = Color.LightSkyBlue;

            label3.Font = new Font("Arial", 12, FontStyle.Bold);
            Label2.Font = new Font("Arial", 12, FontStyle.Bold);
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

            button1.BackColor = Color.LightSkyBlue;
            Add.BackColor = Color.LightSkyBlue;
            Delete.BackColor = Color.LightSkyBlue;
            Edit.BackColor = Color.LightSkyBlue;
            Search.BackColor = Color.LightSkyBlue;

            radioButton1.BackColor = Color.LightSkyBlue;
            radioButton2.BackColor = Color.LightSkyBlue;
            radioButton3.BackColor = Color.LightSkyBlue;

            pictureBox2.BackColor = Color.LightBlue;

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Do you want to exit ? ", "Exit", MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

                string jerseyNumber = textBox3.Text;

                // ذخیره در فولدر Images
                string destDir = Path.Combine(Application.StartupPath, "Images");
                Directory.CreateDirectory(destDir);

                string destPath = Path.Combine(destDir, jerseyNumber + ".jpg");
                File.Copy(openFileDialog1.FileName, destPath, true); // overwrite if exists

            }



            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            playersTableAdapter.FillBy(teamDataSet.Players, nameParam, idParam,positionParam, nationalityParam, jerseyParam);
            dataGridView1.DataSource = teamDataSet.Players;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void playersBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.Trim();

            // بررسی تکراری‌نبودن Id
            var existing = teamDataSet.Players.FindByCodeID(id);
            if (existing != null)
            {
                MessageBox.Show("This ID has already been registered.");
                return;
            }
            if (id == "")
            {
                MessageBox.Show("The ID field cannot be null.");
                return;
            }
            else
            {
                string name = textBox2.Text.Trim();
                string position = textBox4.Text.Trim();
                string nationality = textBox6.Text.Trim();
                string jersey = textBox3.Text.Trim();
                string birthDate = textBox5.Text.Trim();

                playersTableAdapter.InsertQuery(id, name, jersey, position, birthDate, nationality);
                MessageBox.Show("Player added successfully.");
                playersTableAdapter.Fill(teamDataSet.Players);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {

            string id = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string position = textBox4.Text.Trim();
            string nationality = textBox6.Text.Trim();
            string jersey = textBox3.Text.Trim();
            string birthDate = textBox5.Text.Trim();

            int updated = playersTableAdapter.UpdateQuery(name, jersey, position, birthDate, nationality, id);
            if (updated > 0)
                MessageBox.Show("Edit completed successfully.");
            else
                MessageBox.Show("No player found with this ID.");

            playersTableAdapter.Fill(teamDataSet.Players);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.Trim();

            DialogResult r = MessageBox.Show("Are you sure you want to delete it?", "Delete", MessageBoxButtons.YesNo);
            if (r == DialogResult.No) return;

            int deleted = playersTableAdapter.DeleteQuery(id);
            if (deleted > 0)
                MessageBox.Show("Deletion completed successfully.");
            else
                MessageBox.Show("No player found with this ID.");

            playersTableAdapter.Fill(teamDataSet.Players);
        }
    }
}


