using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Linq.SqlClient;
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
            select();
        }
        public void select()
        {
            db = new linqDataContext();

            var cinfo = from t in db.task_struct
                        where (t.Id == TestGoInfo.id)
                        orderby t.Id
                                select t;
            dataGridView3.DataSource = cinfo.ToList();
               headerText();
            sortItem();
        }
        public void sortItem()
        {

            for (int i= 0; i< dataGridView3.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();

            }


        }
        public void headerText()
        {
            if (TestGoInfo.lvl == "Легкий")
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].HeaderText = "code";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
            if (TestGoInfo.lvl == "Середній")
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].HeaderText = "code";
                dataGridView1.Columns[4].HeaderText = "Code";
                dataGridView1.Columns[5].Visible = false;
            }
            if (TestGoInfo.lvl == "Складний")
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].HeaderText = "code";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
