using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BazadeDate;

namespace ProiectBD
{
    public partial class CreareTabele : Form
    {
        BazaDedate bazaDeDate = new BazaDedate();
        public CreareTabele()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bazaDeDate.CreateTables();
            MessageBox.Show("Tabele create cu succes");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bazaDeDate.DeleteTables();
            MessageBox.Show("Tabele sterse cu succes");
        }
    }
}
