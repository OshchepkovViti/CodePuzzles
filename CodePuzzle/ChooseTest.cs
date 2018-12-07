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
    public partial class ChooseTest : Form
    {
        linqDataContext db;
        int selectedRow;
        int id = -1;
        public ChooseTest()
        {
            InitializeComponent();
        }

        private void ChooseTest_Load(object sender, EventArgs e)
        {
            Select();
            
        }

        public void Select()
        {
            db = new linqDataContext();

            var query = from pe in db.test
                        where SqlMethods.Like(pe.language, "%" + comboBox1.Text + "%") &&
                        SqlMethods.Like(pe.theme, "%" + textBox1.Text + "%")
                        select pe;
            dataGridView1.DataSource = query.ToList();
            headerText();
        }

        public void headerText()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Назва";

            dataGridView1.Columns[2].HeaderText = "Рівень";
            dataGridView1.Columns[3].HeaderText = "Мова";
            dataGridView1.Columns[4].HeaderText = "Тема";
            dataGridView1.Columns[5].HeaderText = "Завдання";
        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (selectedRow > -1)
                {
                    DataGridViewRow row = dataGridView1.Rows[selectedRow];


                    id = Convert.ToInt32(row.Cells[0].Value);
                   
                }
            }
            catch
            {
                MessageBox.Show("CellClick error 1");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Select();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var uinfo = db.test.Where(w => w.Id == id).FirstOrDefault();
                TestGoInfo.id = id;
                TestGoInfo.lvl = uinfo.lvl;
                TestGoInfo.descript = uinfo.description;
              

                var fr = new DoTest();
                fr.Show();
            }
            catch
            {

            }
         
        }
    }
}
