using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Coursework.MainForms
{
    public partial class PredUpd : Form
    {
        public string pusname { get; private set; }
        public string puname { get; private set; }
        public string pumname { get; private set; }
        public int puth { get; private set; }

        public PredUpd(int s1, string s2, string s3, string s4)
        {
            InitializeComponent();
            t1.Text = s2;
            t4.Text = s1.ToString(); 
            t2.Text = s3;
            t3.Text = s4;
        }

        private void PredUpd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t3.Text == "" || t4.Text == "" || t2.Text == "" || t1.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.pusname = t1.Text;
                this.puname = t2.Text;
                this.pumname = t3.Text;
                this.puth = Convert.ToInt32(t4.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
