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
    public partial class InregistrareCompanii : Form
    {
        BazaDedate bazaDeDate = new BazaDedate();
        public InregistrareCompanii()
        {
            InitializeComponent();
            comboBox1.Items.Add("Rurala");
            comboBox1.Items.Add("Urbana");
            comboBox2.Items.Add("In constructie");
            comboBox2.Items.Add("Terminata");
            comboBox3.Items.Add("Euro");
            comboBox3.Items.Add("Lei");
            comboBox3.Items.Add("Dolari");
        }
        bool NumeCompanieValid = false;
        bool NumeOrasValid = false;
        private void InregistrareCompanii_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void textBoxNume_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxNume.Text;
            string lettersPattern = "^[A-Za-z]+$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(input, lettersPattern))
            {
                MessageBox.Show("Numele Participantului nu este valid.");
                textBoxNume.Text = string.Empty;
            }
            else
            {
                NumeCompanieValid = true;
                
                Console.WriteLine("Numevalid", NumeCompanieValid);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxNume.Text;
            string lettersPattern = "^[A-Za-z]+$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(input, lettersPattern))
            {
                MessageBox.Show("Numele Participantului nu este valid.");
                textBoxNume.Text = string.Empty;
            }
            else
            {
                NumeOrasValid = true;
                
                Console.WriteLine("Numevalid", NumeOrasValid);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox2.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (NumeCompanieValid == true && NumeOrasValid == true )
            {
                string nume = textBoxNume.Text;
                string MetriPatrati = textBox1.Text;
                string Pret = textBox2.Text + comboBox3.SelectedItem.ToString(); 
                string Categorie = comboBox1.SelectedItem.ToString();
                string Oras = textBox3.Text;
                string StadiuLocuinta = comboBox2.SelectedItem.ToString();

                bazaDeDate.AddDataToCompanieTargTable(nume, MetriPatrati, Pret, Categorie, Oras, StadiuLocuinta);
                MessageBox.Show("Datele au fost adăugate cu succes în tabela Oracle.");
            }

            }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

