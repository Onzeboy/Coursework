using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Coursework
{
    public partial class Log : Form
    {
        DataBase dataBase = new DataBase();
        public string LoginUser { get; private set; }

        public Log()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var LoginUser = textBox1.Text;
            var passUser = textBox2.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            dataBase.openConnection();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{LoginUser}' and password_user ='{passUser}'";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = new Form1(LoginUser);
                form1.ShowDialog();
                this.Close();
                dataBase.closeConnection();
            }
            else
            {
                dataBase.closeConnection();
               MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Log_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 58;
            textBox2.MaxLength = 50;
            textBox2.UseSystemPasswordChar = true;

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
                textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            string text = textBox2.Text;
            textBox2.Text += "1";
            textBox2.Text = text;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            string text = textBox2.Text;
            textBox2.Text += "1";
            textBox2.Text = text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reg rg = new Reg();
            rg.Show();
        }
    }
}
