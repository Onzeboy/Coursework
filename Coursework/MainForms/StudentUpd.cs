using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coursework.MainForms
{
    public partial class StudentUpd : Form
    {
        public string stsurn { get; set; }
        public string stnm { get; set; }
        public string stmidnm { get; set; }
        public int stclass { get; set; }
        public Image stphoto { get; set; }
        public StudentUpd(string s1, string s2, string s3, int s4, Image image)
        {
            InitializeComponent();
            textBox1.Text = s1;
            textBox2.Text = s2;
            textBox3.Text = s3;
            textBox4.Text = s4.ToString();
            pictureBox1.Image = image;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void StudentUpd_Load(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.stsurn = textBox1.Text;
                this.stnm = textBox2.Text;
                this.stmidnm = textBox3.Text;
                this.stclass = Convert.ToInt32(textBox4.Text);
                this.stphoto = pictureBox1.Image;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
