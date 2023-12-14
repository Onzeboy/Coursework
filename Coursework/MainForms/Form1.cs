using Coursework.MainForms;
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
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.IO;
using System.Drawing.Imaging;
using System.Transactions.Configuration;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;
namespace Coursework
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        private string login = "";

        public Form1(string s1)
        {
            login = s1;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.dataGridViewAcademy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAchStd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvperf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (login != "admin")
            {
                button7.Visible = false;
                
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
               
            }
            RefreshDataGridStudents(dataGridViewStudents);
            RefreshDataGridStudents2(dgvAchStd);
            RefreshDataGridStudents2(dgvperf);
            RefreshDataGridAcadem(dataGridViewAcademy);
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel4.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel5.Visible = false;
            panel7.Visible = true;
            RefreshDataGridStudents(dataGridViewStudents);
        }
        private void ReadsingleRowAc(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2));
        }
        private void ReadsingleRowSt2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4));
        }
        private void ReadsingleRowSt(DataGridView dgw, IDataRecord record)
        {
            int length = checked((int)record.GetBytes(5, 0, null, 0, 0));
            byte[] array = new byte[length];

            record.GetBytes(5, 0, array, 0, length);

            MemoryStream mstream = new MemoryStream(array);

            Image imagest = Image.FromStream(mstream);
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4), imagest);
        }

        private void RefreshDataGridAcadem(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = "select * from subject";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadsingleRowAc(dgw, reader);
            }

            reader.Close();
        }
        private void RefreshDataGridStudents(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = "select * from students";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadsingleRowSt(dgw, reader);
            }

            reader.Close();
            dataBase.closeConnection();
        }
        private void RefreshDataGridStudents2(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = "select * from students";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadsingleRowSt2(dgw, reader);
            }

            reader.Close();
            dataBase.closeConnection();
        }
        private void RefreshDataGridAcademySearch(DataGridView dgw)
        {
            dgw.Rows.Clear();
            var search = comboBox1.Text;
            string queryString = $"select * from subject where subname = '{search}'";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadsingleRowAc(dgw, reader);
            }

            reader.Close();
            dataBase.closeConnection();
        }
        private void RefreshDataGridStudentsSearch(DataGridView dgw)
        {
            dgw.Rows.Clear();
            var search = textBox1.Text;
            string queryString = $"select * from students where surname = '{search}'";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadsingleRowSt2(dgw, reader);
            }

            reader.Close();
            dataBase.closeConnection();
        }
        private void RefreshDataGridStudentsSearch2(DataGridView dgw)
        {
            dgw.Rows.Clear();
            var search = textBox2.Text;
            string queryString = $"select * from students where surname = '{search}'";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadsingleRowSt(dgw, reader);
            }

            reader.Close();
            dataBase.closeConnection();
        }
        private void RefreshDataGridStudentsSearch3(DataGridView dgw)
        {
            dgw.Rows.Clear();
            var search = textBox2.Text;
            string queryString = $"select * from students where surname = '{search}'";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadsingleRowSt(dgw, reader);
            }

            reader.Close();
            dataBase.closeConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SubAdding sa = new SubAdding();
            sa.ShowDialog();
            RefreshDataGridAcadem(dataGridViewAcademy);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            RefreshDataGridAcadem(dataGridViewAcademy);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel5.Visible = false;
            panel7.Visible = false;
            RefreshDataGridStudents2(dgvAchStd);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = true;
            panel7.Visible = false;
            RefreshDataGridStudents2(dgvperf);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewAcademy.CurrentCell.RowIndex;
            DataGridViewCell cell = dataGridViewAcademy.Rows[rowIndex].Cells[0];
            string value = cell.Value.ToString();
            dataGridViewAcademy.Rows.RemoveAt(rowIndex);
            dataBase.openConnection();
            SqlCommand delete = new SqlCommand("delete from subject where id=" + value, dataBase.getConnection());
            delete.ExecuteNonQuery();
            MessageBox.Show("Запись удалена!", "", MessageBoxButtons.OK);
            dataBase.closeConnection();
            RefreshDataGridAcadem(dataGridViewAcademy);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = dataGridViewAcademy.CurrentCell.RowIndex;
            var id = dataGridViewAcademy.Rows[index].Cells[0].Value.ToString();
            var sname = dataGridViewAcademy.Rows[index].Cells[1].Value.ToString();
            int TH = (int)dataGridViewAcademy.Rows[index].Cells[2].Value;
            SubUpd su = new SubUpd(TH);
            var result = su.ShowDialog();
            if (result == DialogResult.OK)
            {
                dataGridViewAcademy.Rows[index].Cells[2].Value = su.thours;
                var changeQuery = $"update subject set subth = '{su.thours}' where id = '{id}'";
                var command = new SqlCommand(changeQuery, dataBase.getConnection());
                dataBase.getConnection();
                command.ExecuteNonQuery();
                dataBase.closeConnection();
                result = DialogResult.Cancel;
                RefreshDataGridAcadem(dataGridViewAcademy);
            }
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            StudentAdd sad = new StudentAdd();
            sad.ShowDialog();
            RefreshDataGridStudents(dataGridViewStudents);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewStudents.CurrentCell.RowIndex;
            DataGridViewCell cell = dataGridViewStudents.Rows[rowIndex].Cells[0];
            string value = cell.Value.ToString();
            dataGridViewStudents.Rows.RemoveAt(rowIndex);
            dataBase.openConnection();
            SqlCommand delete = new SqlCommand("delete from students where id=" + value, dataBase.getConnection());
            delete.ExecuteNonQuery();
            MessageBox.Show("Запись удалена!", "", MessageBoxButtons.OK);
            dataBase.closeConnection();
            RefreshDataGridStudents(dataGridViewStudents);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int index = dataGridViewStudents.CurrentCell.RowIndex;
            var id = dataGridViewStudents.Rows[index].Cells[0].Value.ToString();
            var name = dataGridViewStudents.Rows[index].Cells[1].Value.ToString();
            var surname = dataGridViewStudents.Rows[index].Cells[2].Value.ToString();
            var midname = dataGridViewStudents.Rows[index].Cells[3].Value.ToString();
            int Class = (int)dataGridViewStudents.Rows[index].Cells[4].Value;
            MemoryStream ms = new MemoryStream();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            Bitmap img = (Bitmap)dataGridViewStudents.CurrentRow.Cells[5].Value;
            img.Save(ms, ImageFormat.Jpeg);
            Image image = Image.FromStream(ms);
            
            StudentUpd stu = new StudentUpd(name, surname, midname, Class, image);
            var result = stu.ShowDialog();
            if (result == DialogResult.OK)
            {
                dataGridViewStudents.Rows[index].Cells[1].Value = stu.stsurn;
                dataGridViewStudents.Rows[index].Cells[2].Value = stu.stnm;
                dataGridViewStudents.Rows[index].Cells[3].Value = stu.stmidnm;
                dataGridViewStudents.Rows[index].Cells[4].Value = stu.stclass;
                dataGridViewStudents.Rows[index].Cells[5].Value = stu.stphoto;
                byte[] sph;
                using (MemoryStream mss = new MemoryStream())
                {
                    stu.stphoto.Save(mss, ImageFormat.Jpeg);
                    sph = mss.ToArray();

                }
                string querystring = $"update students set surname = @surname, name = @name, midname = @midname, class = @class, image = @image where id = '{id}'";
                SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
                dataBase.openConnection();
                adapter.SelectCommand = command;
                command.Parameters.AddWithValue("@surname", stu.stsurn);
                command.Parameters.AddWithValue("@name", stu.stnm);
                command.Parameters.AddWithValue("@midname", stu.stmidnm);
                command.Parameters.AddWithValue("@class", stu.stclass);
                command.Parameters.AddWithValue("@image", sph);
                command.ExecuteNonQuery();
                adapter.Fill(table);
                MessageBox.Show("Запись обновлена!", "", MessageBoxButtons.OK);
                dataBase.closeConnection();
                result = DialogResult.Cancel;
                RefreshDataGridStudents(dataGridViewStudents);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Показать все")
            {
                RefreshDataGridAcadem(dataGridViewAcademy);
            }
            else
                RefreshDataGridAcademySearch(dataGridViewAcademy);

        }
        private void dgvs2script(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAchStd.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvAchStd.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvAchStd.Rows[selectedrowindex];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                achievements ac = new achievements(id);
                ac.ShowDialog();
            }
        }

        private void tb1(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                RefreshDataGridStudents2(dgvAchStd);
            }
            else
            RefreshDataGridStudentsSearch(dgvAchStd);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                RefreshDataGridStudents(dataGridViewStudents);
            }
            else
                RefreshDataGridStudentsSearch2(dataGridViewStudents);
        }

        private void tb2sp(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvAchStd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvacademysp(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAcademy.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridViewAcademy.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewAcademy.Rows[selectedrowindex];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                Prepd pr = new Prepd(id);
                pr.ShowDialog();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPerfScript(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvperf.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvperf.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvperf.Rows[selectedrowindex];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                Perfomance pf = new Perfomance(id);
                pf.ShowDialog();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel4.Visible = true;
            panel1.Visible = true;

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewStudents.CurrentCell.RowIndex;
            pictureBox1.Image = (Image)dataGridViewStudents.Rows[index].Cells[5].Value;
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }
    }
}
