using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataBase.Forms.AddForms
{
    public partial class SupplierCityAddForm : Form
    {
        public string city;

        public SupplierCityAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                connection.Open();

                if (String.IsNullOrEmpty(textBoxСity.Text))
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                city = textBoxСity.Text.ToString();

                string query = $"INSERT INTO [{main.activeTable}] VALUES (" + "{" + Guid.NewGuid() + "}" + ",'" + city + "')";
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
