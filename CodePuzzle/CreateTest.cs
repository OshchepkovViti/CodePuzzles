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
        linqDataContext db;
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

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {


                db = new linqDataContext();
                test pinfo = new test();
                pinfo.lvl = TestInf.lvl;
                pinfo.language = TestInf.language;
                pinfo.theme = TestInf.theme;
                pinfo.description = TestInf.descript;
                pinfo.name = TestInf.name;
                db.SubmitChanges();


                var uinfo = db.test.Where(w => w.name == TestInf.name &&  w.theme == TestInf.theme && w.description == TestInf.descript).FirstOrDefault();

                task_struct pcode = new task_struct();
                for (int i = 0;i < dataGridView1.RowCount;i++)
                {
                    pcode.id_test = uinfo.Id;
                    pcode.position = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());

                    if (TestInf.lvl == "Легкий")
                    {
                        pcode.code_text=dataGridView1.Rows[i].Cells[1].Value.ToString();

                    }
                    if (TestInf.lvl == "Середній")
                    {
                        pcode.code_text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        pcode.code_text2 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    }
                    if (TestInf.lvl == "Складний")
                    {
                        pcode.handwork = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        pcode.code_text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    }

                }
               

                MessageBox.Show("Тест успішно додано");
                this.Close();


            }
            catch { }
        }
    }
}
