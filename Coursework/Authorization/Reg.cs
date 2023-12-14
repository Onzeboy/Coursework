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
    public partial class Reg : Form
    {
        DataBase dataBase = new DataBase();
        public Reg()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Reg_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;
            string querystring = $"insert into register(login_user, password_user) values('{login}', '{password}')"; 
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection()); 
            dataBase.openConnection();
            if (checkUser())
            {
                return;
            }
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                Login form_login = new Login();
                this.Hide();
                form_login.ShowDialog();
            }
            else
                MessageBox.Show("Аккаунт не создан!");

            dataBase.closeConnection();

        }
        public Boolean checkUser() 
        {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table  = new DataTable();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{ passUser}'";
            SqlCommand command  = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0) {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
                return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            string text = textBox2.Text;
            textBox2.Text += "1";
            textBox2.Text = text;
        }
    }
}
