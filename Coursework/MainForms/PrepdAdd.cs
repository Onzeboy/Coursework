using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework.MainForms
{
    public partial class PrepdAdd : Form
    {
        DataBase dataBase = new DataBase();
        public int idPRA { get; set; }
        public PrepdAdd(int subid)
        {
            InitializeComponent();
            idPRA = subid;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == ""|| textBox4.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                string sname = textBox4.Text;
                string name = textBox3.Text;
                string midn = textBox1.Text;
                int th = Convert.ToInt32(textBox2.Text);
                string querystring = $"insert into academsubject(id_subject, TeachingHours, TeacherSurname, TeacherName, TeacherPatronymic) values( '{idPRA}', '{th}','{sname}', '{name}', '{midn}')";
                SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                MessageBox.Show("Запись добавлена!", "", MessageBoxButtons.OK);
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear();textBox4.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
