using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Coursework
{
    class DataBase
    {
        Form Form1 = new Form();
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-7OJDDMS\MSSQL;Initial Catalog=CourseDB;Integrated Security=True;TrustServerCertificate=True");

        public void openConnection()
        {
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
            }
            catch (SqlException exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void closeConnection() {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection() {
            {
                return sqlConnection;
            }

        }
    }
}