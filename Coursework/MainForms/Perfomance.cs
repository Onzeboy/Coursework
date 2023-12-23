using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework.MainForms
{
    public partial class Perfomance : Form
    {
        DataBase dataBase = new DataBase();
        public int idPerf { get; set; }
        bool isDAte = false;

        public Perfomance(int studentid, string admin)
        {
            InitializeComponent();
            idPerf = studentid;
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (admin != "admin")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
        }
        private void ReadsingleRowSt2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(3), record.GetString(4), record.GetDateTime(5));
        }
        private void RefreshDataGridAcadem(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from  Perfomance where stid = '{idPerf}'";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadsingleRowSt2(dgw, reader);
            }

            reader.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Perfomance_Load(object sender, EventArgs e)
        {
            RefreshDataGridAcadem(dgv);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowIndex = dgv.CurrentCell.RowIndex;
            DataGridViewCell cell = dgv.Rows[rowIndex].Cells[0];
            string value = cell.Value.ToString();
            dgv.Rows.RemoveAt(rowIndex);
            dataBase.openConnection();
            SqlCommand delete = new SqlCommand("delete from perfomance where id=" + value, dataBase.getConnection());
            delete.ExecuteNonQuery();
            MessageBox.Show("Запись удалена!", "", MessageBoxButtons.OK);
            dataBase.closeConnection();
            RefreshDataGridAcadem(dgv);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dgv.CurrentCell.RowIndex;
            int mainid = (int)dgv.Rows[index].Cells[0].Value;
            var sn = dgv.Rows[index].Cells[1].Value.ToString();
            var grade = dgv.Rows[index].Cells[2].Value.ToString();
            CultureInfo provider = CultureInfo.InvariantCulture;
            string s1 = dgv.Rows[index].Cells[3].Value.ToString();
            DateTime.ParseExact(dgv.Rows[index].Cells[3].Value.ToString(), "dd.MM.yyyy H:mm:ss", null);
            DateTime date = DateTime.ParseExact(dgv.Rows[index].Cells[3].Value.ToString(), "dd.MM.yyyy H:mm:ss", null);
            PerfomanceUpd pru = new PerfomanceUpd(idPerf, sn, grade, date);
            var result = pru.ShowDialog();
            if (result == DialogResult.OK)
            {
                dgv.Rows[index].Cells[1].Value = pru.sub;
                dgv.Rows[index].Cells[2].Value = pru.grade;
                dgv.Rows[index].Cells[3].Value = pru.date;
                var changeQuery = $"update perfomance set sbname = '{pru.sub}', grade = '{pru.grade}', datag = '{pru.date}' where id = '{mainid}'";
                var command = new SqlCommand(changeQuery, dataBase.getConnection());
                dataBase.openConnection();
                command.ExecuteNonQuery();
                dataBase.closeConnection();

            }
            RefreshDataGridAcadem(dgv);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerfomanceAdd pra = new PerfomanceAdd(idPerf);
            pra.ShowDialog();
            RefreshDataGridAcadem(dgv);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void RefreshDataGridSearchDate(DataGridView dgw)
        //{
        //    dgw.Rows.Clear();
        //    DateTime first = dateTimePicker1.Value;
        //    DateTime second = dateTimePicker2.Value;
        //    string queryString = $"select * from perfomance where datag > '{first}' AND datag < '{second}'";
        //    SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
        //    dataBase.openConnection();
        //    SqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        ReadsingleRowSt2(dgw, reader);
        //    }

        //    reader.Close();
        //    dataBase.closeConnection();
        //}
        private void RefreshDataGridSearchDate2(DataGridView dgw)
        {
            dgw.Rows.Clear();
            var name = comboBox1.Text;
            DateTime first = dateTimePicker1.Value;
            DateTime second = dateTimePicker2.Value;
            string queryString = $"select * from perfomance where datag > '{first}' AND datag < '{second}' AND sbname = '{name}' AND stid = '{idPerf}'";
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
        private void RefreshDataGridSearchDate3(DataGridView dgw)
        {
            dgw.Rows.Clear();
            var name = comboBox1.Text;
            DateTime first = dateTimePicker1.Value;
            DateTime second = dateTimePicker2.Value;
            string queryString = $"select * from perfomance where datag > '{first}' AND datag < '{second}' AND stid = '{idPerf}'";
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
        private void RefreshDataGridSearchPrp(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from perfomance where grade = 'n' AND stid = '{idPerf}'";
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
        private void RefreshDataGridSearchPrp2(DataGridView dgw)
        {
            PerfomancePrp pp = new PerfomancePrp();
            pp.ShowDialog();
            if (pp.sname == "Предмет" || pp.sname == "Показать все")
            {
                dgw.Rows.Clear();
                string queryString = $"select * from perfomance where grade = 'n' AND stid = '{idPerf}' AND datag > '{pp.FirstDate}' AND datag < '{pp.SecondDate}'";
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
            else
            {
                dgw.Rows.Clear();
                string queryString = $"select * from perfomance where grade = 'n' AND stid = '{idPerf}' AND datag > '{pp.FirstDate}' AND datag < '{pp.SecondDate}' AND sbname = '{pp.sname}' ";
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
        }
        //private void RefreshDataGridSearchSubj(DataGridView dgw)
        //{
        //    dgw.Rows.Clear();
        //    var name = comboBox1.Text;
        //    string queryString = $"select * from perfomance where sbname = '{name}'";
        //    SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
        //    dataBase.openConnection();
        //    SqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        ReadsingleRowSt2(dgw, reader);
        //    }

        //    reader.Close();
        //    dataBase.closeConnection();
        //}
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    if (comboBox1.Text == "Предметы")
        //    {
        //        RefreshDataGridSearchDate(dgv);
        //    }
        //    else
        //        RefreshDataGridSearchDate2(dgv);
        //    isDAte = true;

        //}

        private void button6_Click(object sender, EventArgs e)
        {
            RefreshDataGridAcadem(dgv);
            isDAte = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RefreshDataGridAcadem(dgv);
            comboBox1.Text = "Предметы";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Предметы" || comboBox1.Text == "Все предметы")
            {
                RefreshDataGridAcadem(dgv);
                RefreshDataGridSearchDate3(dgv);
            }
            else
                RefreshDataGridSearchDate2(dgv);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshDataGridSearchPrp(dgv);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RefreshDataGridSearchPrp2(dgv);
        }
    }
}
