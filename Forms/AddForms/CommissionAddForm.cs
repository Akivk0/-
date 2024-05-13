using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase.Forms.AddForms
{
    public partial class CommissionAddForm : Form
    {
        public int code;
        public string weaponNumber;
        public DateTime date;
        public int price;
        public string surname;
        public string name;
        public string patronymic;
        public string passport;


        public CommissionAddForm()
        {
            InitializeComponent();
        }

        private void CommissionAddForm_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                try
                {
                    connection.Open();

                    List<string> tables = new List<string>
                    {
                        "Товары"
                    };

                    OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxCode.Items.Add($"{dbReader[0]}");
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

                if (comboBoxCode.SelectedIndex == -1 ||
                    textBoxWeapon.Text == "" ||
                    maskedTextBoxDate.Text == "" ||
                    textBoxPrice.Text == "" ||
                    textBoxSurname.Text == "" ||
                    textBoxName.Text == "" ||
                    textBoxPatronymic.Text == "" ||
                    textBoxPassport.Text == "" 
                   )
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                code = Convert.ToInt32(comboBoxCode.Text.ToString());
                weaponNumber = textBoxWeapon.Text.ToString();
                date = Convert.ToDateTime(maskedTextBoxDate.Text.ToString());
                price = Convert.ToInt32(textBoxPrice.Text.ToString());
                surname = textBoxSurname.Text.ToString();
                name = textBoxName.Text.ToString();
                patronymic = textBoxPatronymic.Text.ToString();
                passport = textBoxPassport.Text.ToString();

                string query = $"INSERT INTO [{main.activeTable}] " +
                   $"VALUES (" +
                   "" + code + "," +
                   "'" + weaponNumber + "'," +
                   "'" + date + "'," +
                   "" + price + "," +
                   "'" + surname + "'," +
                   "'" + name + "'," +
                   "'" + patronymic + "'," +
                   "'" + passport + "'" +
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
