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
            if (user.access == 1) { label1.Text = "Викладач"; }
            if (user.access == 2) { label1.Text = "Студент"; }
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
    }
}
