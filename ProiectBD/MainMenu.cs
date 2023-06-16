using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectBD
{
    public partial class MainMenu : Form
    {
        
        public MainMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new InregistrareParticipanti();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new InregistrareCompanii();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void AfisareTabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new AfiseazaTabela();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new CreareTabele();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new AdaugaTarg();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
