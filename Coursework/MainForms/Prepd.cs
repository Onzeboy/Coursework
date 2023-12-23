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
    public partial class Prepd : Form
    {
        DataBase dataBase = new DataBase();
        public int idPR { get; set; }
        public Prepd(int subid, string admin)
        {
            InitializeComponent();
            idPR = subid;
            if(admin != "admin")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrepdAdd pa = new PrepdAdd(idPR);
            pa.ShowDialog();
            RefreshDataGridAcadem(dgv);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dgv.CurrentCell.RowIndex;
            int mainid = (int)dgv.Rows[index].Cells[0].Value;
            int th = (int)dgv.Rows[index].Cells[2].Value;
            var sname = dgv.Rows[index].Cells[3].Value.ToString();
            var name = dgv.Rows[index].Cells[4].Value.ToString();
            var mname = dgv.Rows[index].Cells[5].Value.ToString();
            PredUpd pu = new PredUpd(th, sname, name, mname);
            var result = pu.ShowDialog();
            if (result == DialogResult.OK)
            {
                dgv.Rows[index].Cells[2].Value = pu.puth;
                dgv.Rows[index].Cells[3].Value = pu.pusname;
                dgv.Rows[index].Cells[4].Value = pu.puname;
                dgv.Rows[index].Cells[5].Value = pu.pumname;
                var changeQuery = $"update academsubject set id_subject = '{idPR}', TeachingHours = '{pu.puth}', TeacherSurname = '{pu.pusname}', TeacherName = '{pu.puname}', TeacherPatronymic  = '{pu.pusname}' where id = '{mainid}'";
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
            SqlCommand delete = new SqlCommand("delete from academsubject where id=" + value, dataBase.getConnection());
            delete.ExecuteNonQuery();
            MessageBox.Show("Запись удалена!", "", MessageBoxButtons.OK);
            dataBase.closeConnection();
            RefreshDataGridAcadem(dgv);
        }

        private void Prepd_Load(object sender, EventArgs e)
        {
            RefreshDataGridAcadem(dgv);
        }
        private void ReadsingleRowSt2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3), record.GetString(4), record.GetString(5));
        }
        private void RefreshDataGridAcadem(DataGridView dgw)
        {
            dgw.Rows.Clear();
            
            string queryString = $"SELECT  academsubject.id, subject.SubName, academsubject.TeachingHours , academsubject.TeacherSurname, academsubject.TeacherName, academsubject.TeacherPatronymic  FROM subject  INNER JOIN academsubject ON {idPR} = academsubject.id_subject WHERE {idPR} = subject.id ";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadsingleRowSt2(dgw, reader);
            }

            reader.Close();
        }
    }
}
