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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            
            pictureBox1.Image = Image.FromFile(@"img\i" + user.access + ".png");
            if (user.access == 0) { label1.Text = "Admim"; }
            if (user.access == 1) { label1.Text = "Викладач"; button5.Enabled = false; }
            if (user.access == 2) { label1.Text = "Студент"; button5.Enabled = false; button6.Enabled = false; button4.Enabled = false; }
            label2.Text = user.surname; 
               label3.Text= user.name;



        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            var fr = new singin();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var fr = new TestInfo();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fr = new ChooseTest();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fr = new Result();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fr = new theory();
            fr.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var fr = new userres();
            fr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var fr = new DelTest();
            fr.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var fr = new changePass();
            fr.Show();
        }
    }
}
