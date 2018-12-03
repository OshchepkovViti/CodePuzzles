using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodePuzzle
{
    public partial class DoTest : Form
    {
        linqDataContext db;
        int selectedRow1;
        int id1 = -1;
        int selectedRow2;
        int id2 = -1;
        public DoTest()
        {
            InitializeComponent();
        }

        private void DoTest_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Завдання : " + TestGoInfo.descript;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
