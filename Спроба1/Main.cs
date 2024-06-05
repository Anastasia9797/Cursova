using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Спроба1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        


        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recipes recipesForm = new Recipes();
            recipesForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registration regForm = new Registration();
            regForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Log_in loginForm = new Log_in();
            loginForm.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
