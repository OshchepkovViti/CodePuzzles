using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodePuzzle
{
    public partial class Result : Form
    {
        linqDataContext db;
        int selectedRow;
        int id = -1;
        public Result()
        {
            InitializeComponent();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            Select();
           

        }
        public void Select()
        {
            db = new linqDataContext();
            if (user.access == 2)
            {
                var dbb = from t1 in db.result
                          join t2 in db.users on t1.id_user equals t2.Id
                          join t3 in db.test on t1.id_test equals t3.Id
                          where (t2.Id == user.id_user) &&
                          SqlMethods.Like(t1.datatime, "%" + textBox2.Text + "%") &&
                          SqlMethods.Like(t2.surname, "%" + textBox1.Text + "%")
                          &&
                          SqlMethods.Like(t3.t_name, "%" + textBox3.Text + "%")
                          select new { t1.Id, t2.name, t2.surname, t3.t_name, t3.theme, t1.point };
                dataGridView1.DataSource = dbb;
                headerText();
            }

            else
            {
                var dbb = from t1 in db.result
                          join t2 in db.users on t1.id_user equals t2.Id
                          join t3 in db.test on t1.id_test equals t3.Id
                          where SqlMethods.Like(t1.datatime, "%" + textBox2.Text + "%") &&
                          SqlMethods.Like(t2.surname, "%" + textBox1.Text + "%")
                          &&
                          SqlMethods.Like(t3.t_name, "%" + textBox3.Text + "%")
                          select new { t1.Id, t2.name, t2.surname, t3.t_name, t3.theme, t1.point };
                dataGridView1.DataSource = dbb;
                headerText();
            }

         

        
            headerText();
        }
        public void headerText()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Прізвище";
            dataGridView1.Columns[2].HeaderText = "І мя";
            dataGridView1.Columns[3].HeaderText = "Назва тесту";
            dataGridView1.Columns[4].HeaderText = "Тема";
            dataGridView1.Columns[5].HeaderText = "Оцінка";

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            Select();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n = DateTime.Now.ToString();
            string r;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.ShowDialog();

            using (StreamWriter w = new StreamWriter(dialog.FileName))
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    r = "";
                    for (int j = 1; j < 6; j++)
                    {
                        w.WriteLine(textBox2.Text);

                    }
                }
                w.Flush();
                w.Close();
            }


            /* for(int i=0; i < dataGridView1.RowCount; i++)
            {
               r = "";
                for (int j= 1; j < 6; j++)
                {
                    r = dataGridView1.Rows[i].Cells[j].Value.ToString().Replace(" ", "") + "  ";
                }
                File.AppendAllText("result" + n + ".txt", Convert.ToString(r) + "\n");
            }*/
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Select();
        }
    }
}
