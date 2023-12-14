using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coursework.MainForms
{
    public partial class PerfomanceUpd : Form
    {
        public int idperupd { get; private set; }
        public string sub { get; private set; }
        public string grade { get; private set; }
        public DateTime date { get; private set; }

        public PerfomanceUpd(int s1, string s2, string s3, DateTime s4)
        {
            InitializeComponent();
            idperupd = s1;
            dateTimePicker1.Value = s4;

            comboBox1.Text = s2;
            textBoxType.Text= s3;
        }

        private void PerfomanceUpd_Load(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxType.Text == "" || comboBox1.Text == "" || dateTimePicker1 == null)
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.sub = comboBox1.Text;
                this.grade = textBoxType.Text;
                this.date = dateTimePicker1.Value;
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
