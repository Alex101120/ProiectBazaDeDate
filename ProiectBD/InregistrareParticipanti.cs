using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BazadeDate;
namespace ProiectBD
{
    public partial class InregistrareParticipanti : Form
    {
        BazaDedate bazaDeDate = new BazaDedate();
        public InregistrareParticipanti()
        {
            InitializeComponent();
            EroareCNP.Hide();
            EroareTelefon.Hide();
            EroareMail.Hide();
            EroareVarsta.Hide();
            comboBox1.Items.Add("50 lei/Standard");
            comboBox1.Items.Add("80 lei/Premium");
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

        }
        bool NumeValid = false;
        bool PreNumeValid = false;
        bool CNPValid = false;
        bool TelefonValid = false;
        bool MailValid = false;
        bool OrasValid = false;
        bool DataValida=false;
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int selectedIntValue;
            object selectedItem = comboBox1.SelectedItem;

            if (comboBox1.SelectedItem != null)
            {
                string selectedValue = comboBox1.SelectedItem.ToString();
                if (selectedValue == "50 lei/Standard")
                {
                    selectedIntValue = 50;
                }
                else if (selectedValue == "Valoare 2")
                {
                    selectedIntValue = 50;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - selectedDate.Year;
            dateTimePicker1.MaxDate = DateTime.Now;
            

            // Verificăm dacă data nașterii este înainte de data curentă minus 18 ani
            if (selectedDate > currentDate.AddYears(-18))
            {
                EroareVarsta.Show();
            }
            else
            {
                string ageString = age.ToString();
                
                EroareVarsta.Hide();
                checkBox7.Checked = true;

                DataValida =true;
                Console.WriteLine("DataValida", DataValida);

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxNume.Text;
            string lettersPattern = "^[A-Za-z]+$";
           
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, lettersPattern))
            {
                
                textBoxNume.Text = string.Empty;
            }
            else
            {
                NumeValid = true;
                checkBox1.Checked = true;
                Console.WriteLine("Numevalid", NumeValid);

            }
        }
      

        private void Error1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NumeValid == true && PreNumeValid == true && CNPValid == true && TelefonValid == true && MailValid == true && OrasValid == true && DataValida == true)
            {
               
                string nume = textBoxNume.Text;
                string prenume = textBoxPrenume.Text;
                string cnp = textBoxCNP.Text;
                string telefon = textBoxTelefon.Text;
                string mail = textBoxEmail.Text;
                string oras = textBoxOras.Text;
                string dataNasterii = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                
                bazaDeDate.AddDataToInregistrareParticipantiTable(nume, prenume, cnp, telefon, mail, oras, dataNasterii);

                MessageBox.Show("Datele au fost adăugate cu succes în tabela Oracle.");
                textBoxNume.Text = string.Empty;
                textBoxPrenume.Text = string.Empty;
                textBoxCNP.Text = string.Empty;
                textBoxTelefon.Text = string.Empty;
                textBoxEmail.Text = string.Empty;
                textBoxOras.Text = string.Empty;
                dateTimePicker1.Value = DateTime.Now.Date;
                
            }
            else
            {
              
                MessageBox.Show("Unele informații sunt invalide sau lipsesc. Verifică datele introduse și încearcă din nou.");
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string cnp = textBoxCNP.Text;
            textBoxCNP.MaxLength = 13;

          
            if (cnp.Length < 13)
            {
                EroareCNP.Show();
                return;
            }
            if (cnp.Length == 13)
            {
                CNPValid = true;
                EroareCNP.Hide();
                checkBox2.Checked = true;
                Console.WriteLine("CNPvalid", CNPValid);
            }
            string judetCode = cnp.Substring(7, 2);
            string judetName = GetJudetName(judetCode);           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string phoneNumber = textBoxTelefon.Text;

            textBoxTelefon.MaxLength = 10;
            phoneNumber = Regex.Replace(phoneNumber, "[^0-9]", "");

            
            if (phoneNumber.Length == 10 && phoneNumber.StartsWith("07"))
            {

                TelefonValid = true;
                EroareTelefon.Hide();
                checkBox4.Checked = true;
                Console.WriteLine("TelefonValid", TelefonValid);
            }
            else
            {

                EroareTelefon.Show();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;

            
            bool isValidEmail = Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@(gmail.com|yahoo.com|hotmail.com)$");
            MailValid = true;
            if (isValidEmail)
            {

                EroareMail.Hide();
                bool MailValid = true;
                checkBox5.Checked = true;
                Console.WriteLine("MailVali", MailValid);
            }
            else
            {

                EroareMail.Show();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxOras.Text;
            string lettersPattern = "^[A-Za-z]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, lettersPattern))
            {
                MessageBox.Show("Orasul nu este valid.");
                textBoxOras.Text = string.Empty;
                

            }
            else
            {
                OrasValid = true;
                checkBox6.Checked = true;
                Console.WriteLine("OrasValid", OrasValid);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxPrenume.Text;
            string lettersPattern = "^[A-Za-z]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, lettersPattern))
            {
                
                textBoxPrenume.Text = string.Empty;
            }
            else
            {
                PreNumeValid = true;
                checkBox3.Checked = true;
                Console.WriteLine("PreNumevalid",PreNumeValid);

            }
        }
        private string GetJudetName(string judetCode)
        {
            switch (judetCode)
            {
                case "01":
                    return "Alba";
                case "02":
                    return "Arad";
                case "03":
                    return "Argeș";
                case "04":
                    return "Bacău";
                case "05":
                    return "Bihor";
                case "06":
                    return "Bistrița-Năsăud";
                case "07":
                    return "Botoșani";
                case "08":
                    return "Brașov";
                case "09":
                    return "Brăila";
                case "10":
                    return "Buzău";
                case "11":
                    return "Caraș-Severin";
                case "12":
                    return "Cluj";
                case "13":
                    return "Constanța";
                case "14":
                    return "Covasna";
                case "15":
                    return "Dâmbovița";
                case "16":
                    return "Dolj";
                case "17":
                    return "Galați";
                case "18":
                    return "Gorj";
                case "19":
                    return "Harghita";
                case "20":
                    return "Hunedoara";
                case "21":
                    return "Ialomița";
                case "22":
                    return "Iași";
                case "23":
                    return "Ilfov";
                case "24":
                    return "Maramureș";
                case "25":
                    return "Mehedinți";
                case "26":
                    return "Mureș";
                case "27":
                    return "Neamț";
                case "28":
                    return "Olt";
                case "29":
                    return "Prahova";
                case "30":
                    return "Satu Mare";
                case "31":
                    return "Sălaj";
                case "32":
                    return "Sibiu";
                case "33":
                    return "Suceava";
                case "34":
                    return "Teleorman";
                case "35":
                    return "Timiș";
                case "36":
                    return "Tulcea";
                case "37":
                    return "Vaslui";
                case "38":
                    return "Vâlcea";
                case "39":
                    return "Vrancea";
                case "40":
                    return "București";
                case "41":
                    return "București - Sector 1";
                case "42":
                    return "București - Sector 2";
                case "43":
                    return "București - Sector 3";
                case "44":
                    return "București - Sector 4";
                case "45":
                    return "București - Sector 5";
                case "46":
                    return "București - Sector 6";
                case "51":
                    return "Călărași";
                case "52":
                    return "Giurgiu";
                default:
                    return null; // Cod de județ nevalid
            }
        }

        private void EroareVarsta_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void InregistrareParticipanti_Load(object sender, EventArgs e)
        {

        }
    }
}
