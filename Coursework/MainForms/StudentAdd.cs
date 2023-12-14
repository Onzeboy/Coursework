using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coursework.MainForms
{
    public partial class StudentAdd : Form
    {
        DataBase dataBase = new DataBase();
        public StudentAdd()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                var photo = ms.ToArray();
                string Name = textBox2.Text;
                int Class = Convert.ToInt32(textBox4.Text);
                string Surname = textBox1.Text;
                string MidName = textBox3.Text;

                string querystring = $"insert into students(surname, name, midname, class, image) values(@surname, @name, @midname, @class, @image)";
                SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
                dataBase.openConnection();
                adapter.SelectCommand = command;
                command.Parameters.AddWithValue("@surname", Surname);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@midname", MidName);
                command.Parameters.AddWithValue("@class", Class);
                command.Parameters.AddWithValue("@image", photo);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена!", "", MessageBoxButtons.OK);
                dataBase.closeConnection();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void SubAdding_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK && Path.GetExtension(ofd.FileName) == ".png" || Path.GetExtension(ofd.FileName) == ".jpeg" || Path.GetExtension(ofd.FileName) == ".jpg")
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
