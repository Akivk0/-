using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataBase.Forms.AddForms
{
    public partial class SupplierAddForm : Form
    {
        public Guid name;
        public Guid country;
        public Guid city;
        public Guid managerName;

        private List<Guid> codesSupplier = new List<Guid>();
        private List<Guid> codesCountry = new List<Guid>();
        private List<Guid> codesCity = new List<Guid>();
        private List<Guid> codesManager = new List<Guid>();

        public SupplierAddForm()
        {
            InitializeComponent();
        }

        private void SupplierCountryAddForm_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                try
                {
                    connection.Open();

                    List<string> tables = new List<string>
                    {
                        "Менеджеры поставщиков",
                        "Страна поставщика",
                        "Название поставщиков",
                        "Города поставщиков"
                    };

                    OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxManager.Items.Add($"{dbReader[1]}");
                        codesManager.Add(Guid.Parse($"{dbReader[0]}"));
                    }

                    dbCommand = new OleDbCommand($"SELECT * FROM [{tables[1]}]", connection);
                    dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxCountry.Items.Add($"{dbReader[1]}");
                        codesCountry.Add(Guid.Parse($"{dbReader[0]}"));
                    }

                    dbCommand = new OleDbCommand($"SELECT * FROM [{tables[2]}]", connection);
                    dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxName.Items.Add($"{dbReader[1]}");
                        codesSupplier.Add(Guid.Parse($"{dbReader[0]}"));
                    }

                    dbCommand = new OleDbCommand($"SELECT * FROM [{tables[3]}]", connection);
                    dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxCity.Items.Add($"{dbReader[1]}");
                        codesCity.Add(Guid.Parse($"{dbReader[0]}"));
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
                var a = comboBoxName.SelectedIndex;
                if (comboBoxName.SelectedIndex == -1 
                    || comboBoxCity.SelectedIndex == -1
                    || comboBoxCountry.SelectedIndex == -1
                    || comboBoxManager.SelectedIndex == -1
                    )
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                name = codesSupplier[comboBoxName.SelectedIndex];
                city = codesCity[comboBoxCity.SelectedIndex];
                country = codesCountry[comboBoxCountry.SelectedIndex];
                managerName = codesManager[comboBoxManager.SelectedIndex];

                string query = $"INSERT INTO [{main.activeTable}]" +
                    $" VALUES (" +
                    "{" + name + "}," +
                    "{" + country + "}," +
                    "{" + city + "}," +
                    "{" + managerName + "})";

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
