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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coursework.MainForms
{
    public partial class AchievementAdd : Form
    {
        DataBase dataBase = new DataBase();
        public int idAD { get; set; }
        public AchievementAdd(int studentid)
        {
            InitializeComponent();
            idAD = studentid;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AchievementAdd_Load(object sender, EventArgs e)
        {
          
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxType.Text == "" || textBoxDesc.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                int idd = idAD;
                string name = textBoxName.Text;
                string type = textBoxType.Text;
                string desc = textBoxDesc.Text;
                string querystring = $"insert into achievements(id_student, acName, acType, acDcrp) values('{idd}', '{name}', '{type}', '{desc}')";
                SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                MessageBox.Show("Запись добавлена!", "", MessageBoxButtons.OK);
                textBoxName.Clear(); textBoxDesc.Clear(); textBoxType.Clear();
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxType_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
