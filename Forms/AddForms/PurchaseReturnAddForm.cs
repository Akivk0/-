using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataBase.Forms.AddForms
{
    public partial class PurchaseReturnAddForm : Form
    {
        public Guid code;
        public string surname;
        public string supplier;
        public string patronymic;
        public string reasonReturn;


        public PurchaseReturnAddForm()
        {
            InitializeComponent();
        }

        private void PurchaseListAddForm_Load(object sender, EventArgs e)
        {

            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                try
                {
                    connection.Open();

                    List<string> tables = new List<string>
                    {
                        "Покупки"
                    };

                    OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {

                        comboBoxPurch.Items.Add($"{dbReader[0]}");
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Сообщение: {ex.Message}", "Ошибка!");
                }
                finally
                {
                    connection.Close();
                }
            }

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.ComboBox comboBox)
                {
                    comboBox.DropDownWidth = main.DropDownWidth(comboBox);
                }
            }
        }

        private void buttonAddNameFabricator_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                connection.Open();

                if (String.IsNullOrEmpty(comboBoxPurch.Text) ||
                    String.IsNullOrEmpty(textBoxSurname.Text) ||
                    String.IsNullOrEmpty(textBoxName.Text) ||
                    String.IsNullOrEmpty(textBoxPatronymic.Text) ||
                    String.IsNullOrEmpty(richTextBoxReturn.Text))
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                code = Guid.Parse(comboBoxPurch.Text.ToString());
                surname = textBoxSurname.Text.ToString();
                supplier = textBoxName.Text.ToString();
                patronymic = textBoxPatronymic.Text.ToString();
                reasonReturn = richTextBoxReturn.Text.ToString();

                string query = $"INSERT INTO [{main.activeTable}] " +
                    $"VALUES (" +
                    "'" + surname + "'," +
                    "'" + supplier + "'," +
                    "'" + patronymic + "'," +
                    "'" + reasonReturn + "'," +
                    "{" + code + "}" +
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