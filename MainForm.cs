using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Krokhin Egor");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
