using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace civilreg1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainSc m = new MainSc();
            if (userTXT.Text == "amal" && passTXT.Text == "123")
            {
                this.Hide();
                m.Show();

            }
            else
            {
                userTXT.Clear();
                passTXT.Clear();
                MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحة");
                userTXT.Focus();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            userTXT.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
