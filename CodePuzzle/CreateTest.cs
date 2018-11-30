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
    public partial class CreateTest : Form
    {
        public CreateTest()
        {
            InitializeComponent();
        }

        private void CreateTest_Load(object sender, EventArgs e)
        {
           
            if (TestInf.lvl == "Легкий") {

                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name="Position";
                dataGridView1.Columns[1].Name = "Code";
            }
            if (TestInf.lvl == "Середній") {
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Position";
                dataGridView1.Columns[1].Name = "CodePart1";
                dataGridView1.Columns[2].Name = "CodePart2";
            }
            if (TestInf.lvl == "Складний") {
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Position";
                dataGridView1.Columns[2].Name = "Code";
                dataGridView1.Columns[1].Name = "Handwork";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
