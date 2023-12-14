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
    public partial class PerfomanceAdd : Form
    {
        DataBase dataBase = new DataBase();

        public int idPA { get; set; }

        public PerfomanceAdd(int studentid)
        {
            InitializeComponent();
            idPA = studentid;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxType.Text == "" || comboBox1.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                string name = comboBox1.Text;
                int grd = Convert.ToInt32(textBoxType.Text);
                DateTime date = dateTimePicker1.Value;
                string querystring = $"insert into Perfomance(stid, sbid, sbname,  grade, datag) values('{idPA}', (SELECT id FROM subject WHERE subname = '{name}'),  '{name}', '{grd}', '{date}')";
                SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                MessageBox.Show("Запись добавлена!", "", MessageBoxButtons.OK);
                textBoxType.Clear(); dateTimePicker1.Refresh(); comboBox1.Refresh(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
