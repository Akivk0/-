using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataBase.Forms.AddForms
{
    public partial class PurchaseAddForm : Form
    {
        public DateTime date;

        public PurchaseAddForm()
        {
            InitializeComponent();
        }

        private void buttonAddNameFabricator_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                connection.Open();

                if (String.IsNullOrEmpty(maskedTextBoxDate.Text))
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                date = Convert.ToDateTime(maskedTextBoxDate.Text.ToString());

                string query = $"INSERT INTO [{main.activeTable}] " +
                    $"VALUES (" +
                    "{" + Guid.NewGuid() + "}," +
                    "'" + date + "'" +
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
