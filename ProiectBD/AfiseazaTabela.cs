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
using Oracle.DataAccess.Client;
namespace ProiectBD
{
    public partial class AfiseazaTabela : Form
    {
        BazaDedate bazaDeDate = new BazaDedate();
        private string connectionString;
        public AfiseazaTabela()
        {
            InitializeComponent();

            connectionString = "Data Source=80.96.123.131:1521/oracle09;User Id=hr;Password=oracletest;";
            comboBox1.Items.Add("Nume");
            comboBox1.Items.Add("Prenume");
            comboBox1.Items.Add("CNP");
            comboBox1.Items.Add("ID");
            comboBox1.Items.Add("Numar de telefon");
            comboBox1.Items.Add("Email");
            comboBox1.Items.Add("Oras");
            comboBox1.Items.Add("Categorie Locuinta");
            listView1.FullRowSelect = true;
        }

        bool tabel1= false;
        bool tabel2 =false;
        bool tabel3 = false;





        private void AfiseazaTabela_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


       

       
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();
            
            listView1.View = View.Details;
            listView1.Columns.Add("ID");
            listView1.Columns.Add("Nume");
            listView1.Columns.Add("Prenume");
            listView1.Columns.Add("CNP");
            listView1.Columns.Add("NumarTelefon");
            listView1.Columns.Add("Email");
            listView1.Columns.Add("Oras");
            listView1.Columns.Add("DataNasterii");
            bazaDeDate.ParticipantiTargView(listView1);
            tabel1 = true;
            tabel2 = false;
            tabel3 = false;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();
            
            listView1.View = View.Details;
            listView1.Columns.Add("ID Locuinta");
            listView1.Columns.Add("Nume Companie");
            listView1.Columns.Add("Metri Patrati");
            listView1.Columns.Add("Pret");
            listView1.Columns.Add("Categorie Locuinta");
            listView1.Columns.Add("Oras");
            listView1.Columns.Add("Stadiu Locuinta");
            bazaDeDate.CompanieTargView(listView1);
            tabel1 = false;
            tabel2 = true;
            tabel3 = false;
        }
        
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateButton_Click_1(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                
                // Retrieve the unique identifier for the row (e.g., primary key value)
                string rowId = selectedItem.SubItems[0].Text; // Adjust the column index as needed
                string tableName = string.Empty;
                string ID = string.Empty;

                if (tabel1 && !tabel2 && !tabel3)
                {
                    tableName = "InregistrareParticipantiTarg";
                    ID = "Id";
                }
                else if (!tabel1 && tabel2 && !tabel3)
                {
                    tableName = "CompaniiTarg";
                    ID = "IdLocuinta";
                }
                else if (tabel1 && tabel2 && !tabel3)
                {
                    tableName = "TargDeLocuinte";
                    ID = "IdTarg";
                }


                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    // Delete the row from the database
                    string deleteQuery = $"DELETE FROM {tableName} WHERE {ID} = :paramRowId";
                    OracleCommand deleteCommand = new OracleCommand(deleteQuery, connection);
                    deleteCommand.Parameters.Add("paramRowId", OracleDbType.Varchar2).Value = rowId;
                    deleteCommand.ExecuteNonQuery();

                    // Refresh the ListView after deletion
                   
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchName = SearchBox.Text;
            bool found = false;
            
           
           
            if (tabel1 && !tabel2 && !tabel3)
            {
                if (comboBox1.SelectedItem.ToString() == "Nume")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[1].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "CNP")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[2].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Prenume")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[3].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "ID")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[0].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Numar de telefon")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[4].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Email")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[5].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Oras")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[6].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
                if (!found)
                {
                    MessageBox.Show("Name not found in the list.");
                }
            }
            else if (!tabel1 && tabel2 && !tabel3)
            {
                if (comboBox1.SelectedItem.ToString() == "Nume")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[1].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }


                if (comboBox1.SelectedItem.ToString() == "ID")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[0].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Categorie Locuinta")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[4].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }

                if (comboBox1.SelectedItem.ToString() == "Oras")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[5].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Stadiu Locuinta")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[8].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
                if (!found)
                {
                    MessageBox.Show("Name not found in the list.");
                }

            }
            else if (tabel1 && tabel2 && !tabel3)
            {
                if (comboBox1.SelectedItem.ToString() == "ID")
                {


                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[0].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            item.Selected = true;
                            listView1.Focus();
                            found = true;

                        }
                    }
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Nume")
            {


                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[1].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                    {
                        item.Selected = true;
                        listView1.Focus();
                        found = true;

                    }
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Oras")
            {


                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[3].Text.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                    {
                        item.Selected = true;
                        listView1.Focus();
                        found = true;

                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            if (tabel1 && !tabel2 && !tabel3)
            {
                bazaDeDate.ParticipantiTargView(listView1);
            }
            else if (!tabel1 && tabel2 && !tabel3)
            {
                bazaDeDate.CompanieTargView(listView1);
            }
            else if (tabel1 && tabel2 && !tabel3)
            {
                bazaDeDate.TargDeLocuinteView(listView1);
            }



            


            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();
            
            listView1.View = View.Details;
            listView1.Columns.Add("ID Targ");
            listView1.Columns.Add("Nume Proprietar");
            listView1.Columns.Add("ID Locuinta");
            listView1.Columns.Add("Orasul Targului");
            listView1.Columns.Add("Numar Participanti");
            listView1.Columns.Add("Data Targului");
            bazaDeDate.TargDeLocuinteView(listView1);
            tabel1 = false;
            tabel2 = false;
            tabel3 = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MainMenu();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                // Calculate the number of participants for a specific city
                string calculateParticipantsCountQuery = @"
    UPDATE TargDeLocuinte
    SET NumarParticipanti = (
        SELECT COUNT(*)
        FROM InregistrareParticipantiTarg
        WHERE Oras = TargDeLocuinte.OrasulTargului
    )";
   

                using (OracleCommand command = new OracleCommand(calculateParticipantsCountQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                string calculateIflocuintaCountQuery = @"
    UPDATE TargDeLocuinte
    SET NumarLocuinte = (
        SELECT COUNT(*)
        FROM CompaniiTarg
        WHERE Oras = TargDeLocuinte.OrasulTargului)";
    
   

                using (OracleCommand command = new OracleCommand(calculateIflocuintaCountQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
