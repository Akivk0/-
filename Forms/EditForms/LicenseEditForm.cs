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

namespace DataBase.Forms.EditForms
{
    public partial class LicenseEditForm : Form
    {
        int code;
        public int licenseNumber;
        public string surname;
        public string name;
        public string patronymic;
        public string passportNumber;
        public DateTime dateOfIssue;
        public DateTime expirationDate;

        public LicenseEditForm()
        {
            InitializeComponent();
        }

        private void LicenseEditForm_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            textBoxLicenseNumber.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString();
            textBoxSurname.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString();
            textBoxName.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[2].Value.ToString();
            textBoxPatronymic.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[3].Value.ToString();
            textBoxPassport.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[4].Value.ToString();
            maskedTextBoxExpiration.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[5].Value.ToString();
            maskedTextBoxDateOfIssue.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[6].Value.ToString();

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

                code = Convert.ToInt32(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                licenseNumber = Convert.ToInt32(textBoxLicenseNumber.Text);
                surname = textBoxSurname.Text.ToString();
                name = textBoxName.Text.ToString();
                patronymic = textBoxPatronymic.Text.ToString();
                passportNumber = textBoxPassport.Text.ToString();
                dateOfIssue = Convert.ToDateTime(maskedTextBoxDateOfIssue.Text.ToString());
                expirationDate = Convert.ToDateTime(maskedTextBoxExpiration.Text.ToString());

            
                string query = $"UPDATE [{main.activeTable}] SET" +
                    "[Номер лицензии] = " + licenseNumber + "," +
                    "[Фамилия] ='" + surname + "'," +
                    "[Имя] ='" + name + "'," +
                    "[Отчество] ='" + patronymic + "'," +
                    "[Номер паспорта] ='" + passportNumber + "'," +
                    "[Дата выдачи] ='" + expirationDate + "'," +
                    "[Дата окончания лицензии] ='" + dateOfIssue + "'" +
                    "WHERE [Номер лицензии] =" + "" + code + "";

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
