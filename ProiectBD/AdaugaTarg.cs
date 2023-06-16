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
    public partial class AdaugaTarg : Form
    {
        BazaDedate bazaDeDate = new BazaDedate();
        public AdaugaTarg()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

        }
        bool NumeValid = false;
        bool NumeOrasValid = false;

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
                NumeValid = true;
               
                Console.WriteLine("Numevalid", NumeValid);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string lettersPattern = "^[A-Za-z]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, lettersPattern))
            {
                MessageBox.Show("Orasul nu este valid.");
                textBox1.Text = string.Empty;


            }
            else
            {
                NumeOrasValid = true;
               
                Console.WriteLine("OrasValid", NumeOrasValid);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NumeValid == true && NumeOrasValid == true )
            {

                string nume = textBoxNume.Text;           
                string oras = textBox1.Text;
                string dataTarg = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                bazaDeDate.AddDataToTargDeLocuinteTable(nume,oras,dataTarg);

                MessageBox.Show("Datele au fost adăugate cu succes în tabela Oracle.");
                textBoxNume.Text = string.Empty;
                textBox1.Text = string.Empty;
   
                dateTimePicker1.Value = DateTime.Now.Date;

            }
            else
            {

                MessageBox.Show("Unele informații sunt invalide sau lipsesc. Verifică datele introduse și încearcă din nou.");
            }


        }

        private void AdaugaTarg_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
    }

