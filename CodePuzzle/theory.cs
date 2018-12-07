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
using System.Diagnostics;

namespace CodePuzzle
{
    public partial class theory : Form
    {
        linqDataContext db;
        int selectedRow;
        int id = -1;
        string url;
        public theory()
        {
            InitializeComponent();
        }
        public void Select()
        {


            db = new linqDataContext();

            var dbb = from t1 in db.lib
                      where SqlMethods.Like(t1.theme, "%" + textBox1.Text + "%")
                      select new { t1.Id,t1.theme,t1.url };
            dataGridView1.DataSource = dbb;
            headerText();
        }
        public void headerText()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Тема";
            dataGridView1.Columns[2].HeaderText = "Посилання";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 500;

        }
        private void theory_Load(object sender, EventArgs e)
        {
            Select();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                    url = row.Cells[2].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("CellClick error 1");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {

                if( textBox2.Text != "" && textBox3.Text != "" )
                {

                    db = new linqDataContext();
                  lib pinfo = new lib();
                  
                    pinfo.theme = textBox2.Text;
                    pinfo.url = textBox3.Text;
                   
                    db.lib.InsertOnSubmit(pinfo);
                    db.SubmitChanges();

                    Select();
                }
                else
                {
                    MessageBox.Show("Заповніть всі дані");
                }
            }
            catch
            {
               
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                db = new linqDataContext();
                var pinfo = db.lib.Where(w => w.Id == id).FirstOrDefault();
                db.lib.DeleteOnSubmit(pinfo);
                db.SubmitChanges();
                Select();
            }
            catch { MessageBox.Show("Помилка видалення"); }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("IExplore.exe", url);
            }
            catch { }
        }
    }
}
