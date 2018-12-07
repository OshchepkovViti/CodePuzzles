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
    public partial class singup : Form
    {
       linqDataContext db;
        public singup()
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
                    pinfo.access = 2;
                    pinfo.surname = textBox4.Text;
                    db.users.InsertOnSubmit(pinfo);
                    db.SubmitChanges();

                    this.Close();
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
    }
}
