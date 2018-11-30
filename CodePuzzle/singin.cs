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
    public partial class singin : Form
    {
        static linqDataContext db = new linqDataContext();
        public singin()
        {
           
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            var fr = new singup();
            fr.Show();
        }
        public void get_info()
        {
            var uinfo = db.users.Where(w => w.login == textBox1.Text).FirstOrDefault();
            user.id_user = Convert.ToInt32(uinfo.Id);
            user.access = Convert.ToInt32(uinfo.access);
            user.name = uinfo.name;
            user.surname = uinfo.surname;
        }

            private void button1_Click(object sender, EventArgs e)
        {
            users t = null;
            try
            {


                t = db.users.Single(p => p.login == textBox1.Text && p.password == textBox2.Text);

                if (t != null)
                {
                    get_info();
                    var fr = new main();
                    fr.Show();

                    Hide();

                }
            }
            catch { MessageBox.Show("Не вірний логін чи пароль"); }
        }

        private void singin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
