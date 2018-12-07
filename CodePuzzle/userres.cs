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
    public partial class userres : Form
    {
        linqDataContext db;
        public userres()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {

                    db = new linqDataContext();
                    users pinfo = new users();
                    pinfo.login = textBox1.Text;
                    pinfo.password = textBox2.Text;
                    pinfo.name = textBox3.Text;
                    pinfo.access = comboBox1.SelectedIndex;
                    pinfo.surname = textBox4.Text;
                    db.users.InsertOnSubmit(pinfo);
                    db.SubmitChanges();
                    MessageBox.Show("Додано");
                }
                else
                {
                    MessageBox.Show("Заповніть всі дані");
                }
            }
            catch
            {
                MessageBox.Show("Такий логін вже існує");
            }


        }

        private void userres_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 2;
        }
    }
}
