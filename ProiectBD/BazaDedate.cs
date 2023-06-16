using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Oracle.DataAccess.Client;

namespace BazadeDate
{
    public class BazaDedate
    {
        private string connectionString;

        public BazaDedate()
        {
            connectionString = "Data Source=80.96.123.131:1521/oracle09;User Id=hr;Password=oracletest;";

        }

        public void ParticipantiTargView(ListView listView)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            string sqlQuery = "SELECT * FROM InregistrareParticipantiTarg";
            OracleCommand command = new OracleCommand(sqlQuery, connection);
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["Id"].ToString());
                item.SubItems.Add(reader["Nume"].ToString());
                item.SubItems.Add(reader["Prenume"].ToString());
                item.SubItems.Add(reader["CNP"].ToString());
                item.SubItems.Add(reader["NumarTelefon"].ToString());
                item.SubItems.Add(reader["Email"].ToString());
                item.SubItems.Add(reader["Oras"].ToString());
                item.SubItems.Add(reader["DataNasterii"].ToString());
                listView.Items.Add(item);
            }

            reader.Close();
            connection.Close();
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        public void CompanieTargView(ListView listView)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            string sqlQuery = "SELECT * FROM CompaniiTarg";
            OracleCommand command = new OracleCommand(sqlQuery, connection);
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["IdLocuinta"].ToString());
                item.SubItems.Add(reader["NumeCompanie"].ToString());
                item.SubItems.Add(reader["MetriiPatrati"].ToString());
                item.SubItems.Add(reader["Pret"].ToString());
                item.SubItems.Add(reader["CategorieLocuinta"].ToString());
                item.SubItems.Add(reader["Oras"].ToString());
                item.SubItems.Add(reader["StadiuLocuinta"].ToString());
                listView.Items.Add(item);
            }

            reader.Close();
            connection.Close();
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        public void TargDeLocuinteView(ListView listView)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            string sqlQuery = "SELECT * FROM TargDeLocuinte";
            OracleCommand command = new OracleCommand(sqlQuery, connection);
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["IdTarg"].ToString());
                item.SubItems.Add(reader["NumeTarg"].ToString());
                item.SubItems.Add(reader["NumarLocuinte"].ToString());
                item.SubItems.Add(reader["OrasulTargului"].ToString());
                item.SubItems.Add(reader["NumarParticipanti"].ToString());
                item.SubItems.Add(reader["DataTargului"].ToString());
                listView.Items.Add(item);
            }


            reader.Close();
            connection.Close();
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        public void CreateTables()
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();

            // Create "InregistrareParticipanti" table
            string createInregistrareParticipantiTableQuery = @"
            CREATE TABLE InregistrareParticipantiTarg (
                Id NUMBER PRIMARY KEY,
                Nume VARCHAR2(50),
                Prenume VARCHAR2(50),
                CNP VARCHAR2(13),
                NumarTelefon VARCHAR2(20),
                Email VARCHAR2(50),
                Oras VARCHAR2(50),
                DataNasterii DATE
            )";

            using (OracleCommand command = new OracleCommand(createInregistrareParticipantiTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            string createCompaniiTableQuery = @"
            CREATE TABLE CompaniiTarg (
                IdLocuinta NUMBER PRIMARY KEY,
                NumeCompanie VARCHAR2(50),
                MetriiPatrati NUMBER,
                Pret VARCHAR2(50),
                CategorieLocuinta VARCHAR2(50),
                Oras VARCHAR2(50),
                StadiuLocuinta VARCHAR2(50)
            )";

            using (OracleCommand command = new OracleCommand(createCompaniiTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
            // Create "TargDeLocuinte" table
            string createTargDeLocuinteTableQuery = @"
            CREATE TABLE TargDeLocuinte (
                IdTarg NUMBER PRIMARY KEY,
                NumeTarg VARCHAR2(50),
                NumarLocuinte NUMBER,
                OrasulTargului VARCHAR2(50),
                NumarParticipanti NUMBER,
                DataTargului DATE
                
            )";

            using (OracleCommand command = new OracleCommand(createTargDeLocuinteTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            
          

            connection.Close();
        }
        public void DeleteTables()
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();

          
            string deleteCompaniiTableQuery = "DROP TABLE TargDeLocuinte";

            using (OracleCommand command = new OracleCommand(deleteCompaniiTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            
            string deleteTargDeLocuinteTableQuery = "DROP TABLE InregistrareParticipantiTarg";

            using (OracleCommand command = new OracleCommand(deleteTargDeLocuinteTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            
            string deleteInregistrareParticipantiTableQuery = "DROP TABLE CompaniiTarg";

            using (OracleCommand command = new OracleCommand(deleteInregistrareParticipantiTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
        public void AddDataToInregistrareParticipantiTable(string nume, string prenume, string cnp, string numarTelefon, string email, string oras, string dataNasterii)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();

            string idQuery = $"SELECT MAX(Id) FROM InregistrareParticipantiTarg";
            int nextId;
            using (OracleCommand idCommand = new OracleCommand(idQuery, connection))
            {
                object result = idCommand.ExecuteScalar();
                nextId = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1;
            }

            string insertQuery = $@"
    INSERT INTO InregistrareParticipantiTarg (Id, Nume, Prenume, CNP, NumarTelefon, Email, Oras, DataNasterii)
    VALUES ({nextId}, '{nume}', '{prenume}', '{cnp}', '{numarTelefon}', '{email}', '{oras}', TO_DATE('{dataNasterii}', 'YYYY-MM-DD'))";

            using (OracleCommand command = new OracleCommand(insertQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Data added successfully!");

            connection.Close();
        }
        public void AddDataToCompanieTargTable(string numeCompanie, string metriPatrati, string pret, string categorieLocuinta, string oras, string stadiuLocuinta)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();

            string idQuery = $"SELECT MAX(idLocuinta) FROM CompaniiTarg";
            int nextId;
            using (OracleCommand idCommand = new OracleCommand(idQuery, connection))
            {
                object result = idCommand.ExecuteScalar();
                nextId = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1;
            }

            string insertQuery = $@"
    INSERT INTO CompaniiTarg ( IdLocuinta,NumeCompanie, MetriiPatrati, Pret, CategorieLocuinta, Oras, StadiuLocuinta)
    VALUES ({nextId},'{numeCompanie}', {metriPatrati}, '{pret}', '{categorieLocuinta}', '{oras}', '{stadiuLocuinta}')";


            using (OracleCommand command = new OracleCommand(insertQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Data added successfully!");

            connection.Close();
        }
        public void AddDataToTargDeLocuinteTable(string targ, string orasulTargului, string dataTargului)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();

            string idQuery = "SELECT MAX(IdTarg) FROM TargDeLocuinte";
            int nextId;
            using (OracleCommand idCommand = new OracleCommand(idQuery, connection))
            {
                object result = idCommand.ExecuteScalar();
                nextId = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1;
            }

            string insertQuery = $@"
    INSERT INTO TargDeLocuinte (IdTarg, NumeTarg, OrasulTargului, DataTargului)
    VALUES ({nextId}, '{targ}', '{orasulTargului}', TO_DATE('{dataTargului}', 'YYYY-MM-DD'))";

            using (OracleCommand command = new OracleCommand(insertQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Data added successfully!");

            connection.Close();
        }


    }

}

    







