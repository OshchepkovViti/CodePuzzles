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
    public partial class TruTest : Form
    {
        linqDataContext db;
        public TruTest()
        {
            InitializeComponent();
        }

        private void TruTest_Load(object sender, EventArgs e)
        {
            select();
          
        }
        public void select()
        {
            db = new linqDataContext();

            var cinfo = from t in db.task_struct
                        where (t.id_test == TestGoInfo.id)
                        orderby t.position
                        select t;
            dataGridView1.DataSource = cinfo.ToList();
            headerText();
       
        }
       
        public void headerText()
        {
            if (TestGoInfo.lvl.Replace(" ", "") == "Легкий")
            {
                

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].HeaderText = "code";
                dataGridView1.Columns[3].Width = 400;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;

            }
            if (TestGoInfo.lvl.Replace(" ", "") == "Середній")
            {



                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].HeaderText = "code";
                dataGridView1.Columns[3].Width = 250;
                dataGridView1.Columns[4].HeaderText = "code";
                dataGridView1.Columns[4].Width = 250;
                dataGridView1.Columns[5].Visible = false;

            }
            if (TestGoInfo.lvl.Replace(" ", "") == "Складний")
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].HeaderText = "code";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
        }
    }
}
