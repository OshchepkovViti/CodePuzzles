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
    public partial class changePass : Form
    {
       linqDataContext db;
        public changePass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == user.pass.Replace(" ",""))
                {
                    if (textBox2.Text != "")
                    {

                        db = new linqDataContext();
                        var pinfo = db.users.Where(w => w.Id  == user.id_user).FirstOrDefault();

                        pinfo.password = textBox2.Text;

                        db.SubmitChanges();

                        MessageBox.Show("Пароль змінено");
                    }
                    else
                    {
                        MessageBox.Show("Заповніть всі дані");
                    }
                }
                else
                {
                    MessageBox.Show("Не вірний старий пароль");
                }
            }
            catch
            {
                MessageBox.Show("Не вірний формат ");
            }
        }
    }
}
