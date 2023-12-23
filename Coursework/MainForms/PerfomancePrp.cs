using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coursework.MainForms
{
    public partial class PerfomancePrp : Form
    {
        public DateTime FirstDate { get; private set; }
        public DateTime SecondDate { get; private set; }
        public string sname { get; private set; }
        public PerfomancePrp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FirstDate = dateTimePicker1.Value;
            this.SecondDate = dateTimePicker2.Value;
            this.sname= comboBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
