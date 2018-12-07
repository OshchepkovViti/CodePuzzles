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
    public partial class TestInfo : Form
    {
        public TestInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                TestInf.name = textBox1.Text;
                TestInf.theme = textBox2.Text;
                TestInf.descript = textBox3.Text;
                TestInf.language = comboBox1.Text;
                TestInf.lvl = comboBox2.Text;

                var fr = new CreateTest();
                fr.Show();
                Hide();
            }
            else { MessageBox.Show("Заповніть всі поля"); }

             

        }

        private void TestInfo_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0; comboBox2.SelectedIndex = 0;
        }
    }
}
