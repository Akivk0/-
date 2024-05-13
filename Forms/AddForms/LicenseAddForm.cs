using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase.Forms.AddForms
{
    public partial class LicenseAddForm : Form
    {
 
        public int licenseNumber;
        public string surname;
        public string name;
        public string patronymic;
        public string passportNumber;
        public DateTime dateOfIssue;
        public DateTime expirationDate;

        public LicenseAddForm()
        {
            InitializeComponent();
        }

        private void buttonAddNameFabricator_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                connection.Open();

                if (String.IsNullOrEmpty(textBoxLicenseNumber.Text) 
                    || String.IsNullOrEmpty(textBoxSurname.Text)
                    || String.IsNullOrEmpty(textBoxName.Text)
                    || String.IsNullOrEmpty(textBoxPassport.Text)
                    || String.IsNullOrEmpty(maskedTextBoxDateOfIssue.Text)
                    || String.IsNullOrEmpty(maskedTextBoxExpiration.Text)
                    )
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                licenseNumber = Convert.ToInt32(textBoxLicenseNumber.Text);
                surname = textBoxSurname.Text.ToString();
                name = textBoxName.Text.ToString();
                patronymic = textBoxPatronymic.Text.ToString();
                passportNumber = textBoxPassport.Text.ToString();
                dateOfIssue = Convert.ToDateTime(maskedTextBoxDateOfIssue.Text.ToString());
                expirationDate = Convert.ToDateTime(maskedTextBoxExpiration.Text.ToString());

                string query = $"INSERT INTO [{main.activeTable}] " +
                    $"VALUES (" +
                    $"" + licenseNumber + "," +
                    "'" + surname + "',"+
                    "'" + name + "'," +
                    "'" + patronymic + "'," +
                    "'" + passportNumber + "'," +
                    "'" + dateOfIssue + "'," +
                    "'" + expirationDate + "'" +
                    ")";

                OleDbCommand dbCommand = new OleDbCommand(query, connection);

                try
                {
                    dbCommand.ExecuteNonQuery();
                    MessageBox.Show($"Запись добавлена!", "Внимание!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", $"Ошибка! Запись не добавлена!");
                }

                connection.Close();

            }
            this.Close();
        }
    }
}
