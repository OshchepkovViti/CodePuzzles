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
        int selectedRow2;
        int selectCol;
        int grid=0;
        int cell;
        int row1;
        
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
                        where (t.id_test == TestGoInfo.id)
                        orderby t.Id
                                select t;
            dataGridView3.DataSource = cinfo.ToList();
               headerText();
            sortItem();
        }
        public void sortItem()
        {

            if (TestGoInfo.lvl.Replace(" ","") == "Легкий")
            {
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                   
                    dataGridView1.Rows.Add();
                    dataGridView2.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dataGridView3.Rows[i].Cells[3].Value.ToString();
                    dataGridView2.Rows[i].Cells[3].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                }
            }
            if (TestGoInfo.lvl.Replace(" ", "") == "Середній")
            {
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {

                    dataGridView1.Rows.Add();
                    dataGridView2.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dataGridView3.Rows[i].Cells[3].Value.ToString();
                    dataGridView2.Rows[i].Cells[6].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();



                }
               
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    
                    if (dataGridView3.Rows[i].Cells[4].Value.ToString().Replace(" ", "") != "")
                    {
                       
                        dataGridView1.Rows.Add();

                        dataGridView1.Rows[dataGridView1.RowCount-1].Cells[2].Value = dataGridView3.Rows[i].Cells[4].Value.ToString();
                    }

                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                }

                }


            }
        public void headerText()
        {
            if (TestGoInfo.lvl.Replace(" ", "") == "Легкий")
            {
                dataGridView1.ColumnCount = 3;

                dataGridView1.Columns[0].Name = "id";
                dataGridView1.Columns[1].Name = "Position";
                dataGridView1.Columns[2].Name = "Code";


                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "code";
                dataGridView1.Columns[2].Width = 400;
                dataGridView2.ColumnCount = 4;

                dataGridView2.Columns[0].Name = "id";
                dataGridView2.Columns[1].Name = "Position";
                dataGridView2.Columns[2].Name = "Code";
                dataGridView2.Columns[3].Name = "pose";
                
                dataGridView2.Columns[2].Width = 400;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[2].HeaderText = "code";
                dataGridView2.Columns[3].Visible = false;

            }
            if (TestGoInfo.lvl.Replace(" ", "") == "Середній")
            {
                dataGridView1.ColumnCount = 3;

                dataGridView1.Columns[0].Name = "id";
                dataGridView1.Columns[1].Name = "Position";
                dataGridView1.Columns[2].Name = "Code";
                

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "code";
                dataGridView1.Columns[2].Width = 400;
                dataGridView2.ColumnCount = 7;

                dataGridView2.Columns[0].Name = "id";
                dataGridView2.Columns[1].Name = "Position";
                dataGridView2.Columns[2].Name = "Code";
                dataGridView2.Columns[2].Width = 200;
                dataGridView2.Columns[3].Name = "Code2";
                dataGridView2.Columns[3].Width = 200;
                dataGridView2.Columns[4].Name = "id2";
                dataGridView2.Columns[5].Name = "position2";
                dataGridView2.Columns[6].Name = "pose";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[2].HeaderText = "code";
                dataGridView2.Columns[3].HeaderText = "code2";
                dataGridView2.Columns[4].Visible = false;
                dataGridView2.Columns[5].Visible = false;
                dataGridView2.Columns[6].Visible = false;
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TestGoInfo.lvl.Replace(" ", "") == "Легкий")
            {
                try
                {
                    selectedRow1 = e.RowIndex;
                    if (selectedRow1 > -1)
                    {

                        DataGridViewRow row = dataGridView1.Rows[selectedRow1];
                        if (grid == 0 )
                        {
                            grid = 1;
                            row1 = selectedRow1;
                            cin.id = Convert.ToInt32(row.Cells[0].Value);
                            cin.position = Convert.ToInt32(row.Cells[1].Value);
                            cin.code = row.Cells[2].Value.ToString();

                        }
                        else
                        {
                            if (grid == 1)
                            {
                                dataGridView1.Rows[row1].Cells[0].Value =  row.Cells[0].Value;
                                dataGridView1.Rows[row1].Cells[1].Value = row.Cells[1].Value;
                                dataGridView1.Rows[row1].Cells[2].Value = row.Cells[2].Value;


                                row.Cells[0].Value = cin.id;
                                row.Cells[1].Value = cin.position;
                                row.Cells[2].Value = cin.code;

                                row1 = -1;
                                grid = 0;

                            }
                            if (grid == 2)
                            {
                                dataGridView2.Rows[row1].Cells[0].Value = row.Cells[0].Value;
                                dataGridView2.Rows[row1].Cells[1].Value = row.Cells[1].Value;
                                dataGridView2.Rows[row1].Cells[2].Value = row.Cells[2].Value;


                                row.Cells[0].Value = cin.id;
                                row.Cells[1].Value = cin.position;
                                row.Cells[2].Value = cin.code;
                                row1 = -1;
                                grid = 0;

                            }
                        }

                    }
                }
                catch
                {
                    grid = 0;
                   
                }
            }
            if (TestGoInfo.lvl.Replace(" ", "") == "Середній")
            {
                try
                {
                    selectedRow1 = e.RowIndex;
                    if (selectedRow1 > -1)
                    {

                        DataGridViewRow row = dataGridView1.Rows[selectedRow1];
                        if (grid == 0)
                        {
                            grid = 1;
                            row1 = selectedRow1;
                            cin.id = Convert.ToInt32(row.Cells[0].Value);
                            cin.position = Convert.ToInt32(row.Cells[1].Value);
                            cin.code = row.Cells[2].Value.ToString();

                        }
                        else
                        {
                            if (grid == 1)
                            {
                                dataGridView1.Rows[row1].Cells[0].Value = row.Cells[0].Value;
                                dataGridView1.Rows[row1].Cells[1].Value = row.Cells[1].Value;
                                dataGridView1.Rows[row1].Cells[2].Value = row.Cells[2].Value;


                                row.Cells[0].Value = cin.id;
                                row.Cells[1].Value = cin.position;
                                row.Cells[2].Value = cin.code;

                                row1 = -1;
                                grid = 0;

                            }
                            if (grid == 2)
                            {
                                if (cell==2) {
                                    dataGridView2.Rows[row1].Cells[0].Value = row.Cells[0].Value;
                                    dataGridView2.Rows[row1].Cells[1].Value = row.Cells[1].Value;
                                    dataGridView2.Rows[row1].Cells[2].Value = row.Cells[2].Value;


                                    row.Cells[0].Value = cin.id;
                                    row.Cells[1].Value = cin.position;
                                    row.Cells[2].Value = cin.code;
                                    
                                }
                                else
                                {
                                    dataGridView2.Rows[row1].Cells[4].Value = row.Cells[0].Value;
                                    dataGridView2.Rows[row1].Cells[5].Value = row.Cells[1].Value;
                                    dataGridView2.Rows[row1].Cells[3].Value = row.Cells[2].Value;


                                    row.Cells[0].Value = cin.id;
                                    row.Cells[1].Value = cin.position;
                                    row.Cells[2].Value = cin.code;


                                }

                                row1 = -1;
                                grid = 0;
                            }
                        }

                    }
                }
                catch
                {
                    grid = 0;

                }
            }
            if (TestGoInfo.lvl.Replace(" ", "") == "Складний")
            {

            }


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (TestGoInfo.lvl.Replace(" ", "") == "Легкий")
            {
                  try
                    {
                        selectedRow1 = e.RowIndex;
                        if (selectedRow1 > -1)
                        {

                            DataGridViewRow row = dataGridView2.Rows[selectedRow1];
                            if (grid == 0)
                            {
                                grid = 2;
                                row1 = selectedRow1;
                                cin.id = Convert.ToInt32(row.Cells[0].Value);
                                cin.position = Convert.ToInt32(row.Cells[1].Value);
                                cin.code = row.Cells[2].Value.ToString();

                            }
                            else
                            {
                                if (grid == 1)
                                {
                                    dataGridView1.Rows[row1].Cells[0].Value = row.Cells[0].Value;
                                    dataGridView1.Rows[row1].Cells[1].Value = row.Cells[1].Value;
                                    dataGridView1.Rows[row1].Cells[2].Value = row.Cells[2].Value;


                                    row.Cells[0].Value = cin.id;
                                    row.Cells[1].Value = cin.position;
                                    row.Cells[2].Value = cin.code;

                                    row1 = -1;
                                    grid = 0;

                                }
                                if (grid == 2)
                                {
                                    dataGridView2.Rows[row1].Cells[0].Value = row.Cells[0].Value;
                                    dataGridView2.Rows[row1].Cells[1].Value = row.Cells[1].Value;
                                    dataGridView2.Rows[row1].Cells[2].Value = row.Cells[2].Value;


                                    row.Cells[0].Value = cin.id;
                                    row.Cells[1].Value = cin.position;
                                    row.Cells[2].Value = cin.code;
                                    row1 = -1;
                                    grid = 0;

                                }
                            }

                        }
                    }
                    catch
                {
                    grid = 0;
                    
                    }
                }
            if (TestGoInfo.lvl.Replace(" ", "") == "Середній")
            {
                try
                {
                    selectedRow1 = e.RowIndex;
                    selectCol = e.ColumnIndex;
                    if (selectedRow1 > -1)
                    {

                        DataGridViewRow row = dataGridView2.Rows[selectedRow1];
                       
                        if (grid == 0)
                        {
                            grid = 2;
                            row1 = selectedRow1;
                            cell = selectCol;
                            if (cell == 2)
                            {
                                cin.id = Convert.ToInt32(row.Cells[0].Value);
                                cin.position = Convert.ToInt32(row.Cells[1].Value);
                                cin.code = row.Cells[2].Value.ToString();
                            }
                            else
                            {
                                cin.id = Convert.ToInt32(row.Cells[4].Value);
                                cin.position = Convert.ToInt32(row.Cells[5].Value);
                                cin.code = row.Cells[3].Value.ToString();
                            }


                        }
                        else
                        {
                            if (grid == 1)
                            {
                                if (cell == 2)
                                {
                                    dataGridView1.Rows[row1].Cells[0].Value = row.Cells[0].Value;
                                    dataGridView1.Rows[row1].Cells[1].Value = row.Cells[1].Value;
                                    dataGridView1.Rows[row1].Cells[2].Value = row.Cells[2].Value;


                                    row.Cells[0].Value = cin.id;
                                    row.Cells[1].Value = cin.position;
                                    row.Cells[2].Value = cin.code;
                                }
                                else
                                {
                                    dataGridView1.Rows[row1].Cells[0].Value = row.Cells[4].Value;
                                    dataGridView1.Rows[row1].Cells[1].Value = row.Cells[5].Value;
                                    dataGridView1.Rows[row1].Cells[2].Value = row.Cells[3].Value;


                                    row.Cells[4].Value = cin.id;
                                    row.Cells[5].Value = cin.position;
                                    row.Cells[3].Value = cin.code;
                                }

                                row1 = -1;
                                grid = 0;

                            }
                            if (grid == 2)
                            {
                                if (cell == 2)
                                {
                                    dataGridView2.Rows[row1].Cells[0].Value = row.Cells[0].Value;
                                    dataGridView2.Rows[row1].Cells[1].Value = row.Cells[1].Value;
                                    dataGridView2.Rows[row1].Cells[2].Value = row.Cells[2].Value;


                                    row.Cells[0].Value = cin.id;
                                    row.Cells[1].Value = cin.position;
                                    row.Cells[2].Value = cin.code;
                                }
                                else
                                {
                                    dataGridView2.Rows[row1].Cells[0].Value = row.Cells[4].Value;
                                    dataGridView2.Rows[row1].Cells[1].Value = row.Cells[5].Value;
                                    dataGridView2.Rows[row1].Cells[2].Value = row.Cells[3].Value;


                                    row.Cells[4].Value = cin.id;
                                    row.Cells[5].Value = cin.position;
                                    row.Cells[3].Value = cin.code;
                                }
                                row1 = -1;
                                grid = 0;

                            }
                        }

                    }
                }
                catch
                {
                    grid = 0;
                  
                }
            }
            if (TestGoInfo.lvl.Replace(" ", "") == "Складний")
            {

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (TestGoInfo.lvl.Replace(" ", "") == "Легкий")
            {
                sort1();
                for (int i = 0; i < dataGridView2.RowCount;i++)
                {
                    if (Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value)== Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value))
                    {
                        count++;
                        dataGridView2.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Lime;

                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Red;
                    }



                }



            }

            if (TestGoInfo.lvl.Replace(" ", "") == "Середній")
            {

                sort2();
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if (Convert.ToInt32(dataGridView2.Rows[i].Cells[6].Value) == Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value))
                    {
                        count++;
                        dataGridView2.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Lime;

                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Red;
                    }



                }
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if (dataGridView2.Rows[i].Cells[3].Value.ToString().Replace(" ", "") != "")
                    {
                        if (Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value) == Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value))
                        {
                            count++;
                            dataGridView2.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.Lime;

                        }
                        else
                        {
                            dataGridView2.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.Red;
                        }


                    }
                }


            }





                int point = Convert.ToInt32(100 / dataGridView1.RowCount * count);
            MessageBox.Show("Набрано"+count.ToString()+"/"+dataGridView1.RowCount.ToString()+"балів("+point+"%)", "Результат");
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
            button2.Enabled = false;

            db = new linqDataContext();
            result pinfo = new result();
            pinfo.id_user = user.id_user;
            pinfo.id_test = TestGoInfo.id;
            pinfo.point =point;
            pinfo.datatime = DateTime.Now.ToString();
           
            db.result.InsertOnSubmit(pinfo);
            db.SubmitChanges();

        }
        public void sort1()
        {
            for (int i = 0; i < dataGridView2.RowCount-1; i++)
            {
                
                int min = i;
                for (int j = i + 1; j < dataGridView2.RowCount; j++)
                {
            
                    if (Convert.ToInt32(dataGridView2.Rows[j].Cells[3].Value) < Convert.ToInt32(dataGridView2.Rows[min].Cells[3].Value))
                    {
                        min = j;
                    }
                }
               
                int temp = Convert.ToInt32(dataGridView2.Rows[min].Cells[3].Value);
               dataGridView2.Rows[min].Cells[3].Value = Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value);
                dataGridView2.Rows[i].Cells[3].Value = temp;
            }
        }
        public void sort2()
        {
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {

                int min = i;
                for (int j = i + 1; j < dataGridView2.RowCount; j++)
                {

                    if (Convert.ToInt32(dataGridView2.Rows[j].Cells[6].Value) < Convert.ToInt32(dataGridView2.Rows[min].Cells[6].Value))
                    {
                        min = j;
                    }
                }

                int temp = Convert.ToInt32(dataGridView2.Rows[min].Cells[6].Value);
                dataGridView2.Rows[min].Cells[6].Value = Convert.ToInt32(dataGridView2.Rows[i].Cells[6].Value);
                dataGridView2.Rows[i].Cells[6].Value = temp;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var fr = new DoTest();
            fr.Show();
        }
    }
}
