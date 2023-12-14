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
    public partial class AchievementsUpd : Form
    {
        public string auname { get; set; }
        public string autype { get; set; }
        public string audesc { get; set; }

        public AchievementsUpd(string s1, string s2, string s3)
        {
            InitializeComponent();
            textBoxName.Text = s1;
            textBoxType.Text = s2;
            textBoxDesc.Text = s3;
        }

        private void AchievementsUpd_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxType.Text == "" || textBoxDesc.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.auname = textBoxName.Text;
                this.autype = textBoxType.Text;
                this.audesc = textBoxDesc.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBoxDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
