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
    public partial class achievements : Form
    {
        DataBase dataBase = new DataBase();
        public int idAc { get; set;}
        public achievements(int studentid)
        {
            InitializeComponent();
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            idAc = studentid;
        }
        private void ReadsingleRowSt2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(2), record.GetString(3), record.GetString(4));
        }
        private void RefreshDataGridAcadem(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from  achievements where id_student = '{idAc}'";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadsingleRowSt2(dgw, reader);
            }

            reader.Close();
        }

        private void achievements_Load(object sender, EventArgs e)
        {
            RefreshDataGridAcadem(dgv);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AchievementAdd ad = new AchievementAdd(idAc);
            ad.ShowDialog();
            RefreshDataGridAcadem(dgv);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dgv.CurrentCell.RowIndex;
            var idd = dgv.Rows[index].Cells[0].Value.ToString();
            var name = dgv.Rows[index].Cells[1].Value.ToString();
            var type = dgv.Rows[index].Cells[2].Value.ToString();
            var desc = dgv.Rows[index].Cells[3].Value.ToString();
            AchievementsUpd au = new AchievementsUpd(name,type,desc);
            var result = au.ShowDialog();
            if (result == DialogResult.OK)
            {
                dgv.Rows[index].Cells[1].Value = au.auname;
                dgv.Rows[index].Cells[2].Value = au.autype;
                dgv.Rows[index].Cells[3].Value = au.audesc;
                var changeQuery = $"update achievements set Acname = '{au.auname}', Actype = '{au.autype}',Acdcrp = '{au.audesc}' where id = '{idd}'";
                var command = new SqlCommand(changeQuery, dataBase.getConnection());
                result = DialogResult.Cancel;
                dataBase.getConnection();
                command.ExecuteNonQuery();
                dataBase.closeConnection();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowIndex = dgv.CurrentCell.RowIndex;
            DataGridViewCell cell = dgv.Rows[rowIndex].Cells[0];
            string value = cell.Value.ToString();
            dgv.Rows.RemoveAt(rowIndex);
            dataBase.openConnection();
            SqlCommand delete = new SqlCommand("delete from achievements where id=" + value, dataBase.getConnection());
            delete.ExecuteNonQuery();
            MessageBox.Show("Запись удалена!", "", MessageBoxButtons.OK);
            dataBase.closeConnection();
            RefreshDataGridAcadem(dgv);
        }
    }
}
