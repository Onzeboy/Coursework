using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{

        internal static class Program
        {
            /// <summary>
            /// Главная точка входа для приложения.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Log());
            }
        }
   
}