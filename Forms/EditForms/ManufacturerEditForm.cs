using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DataBase.Forms.AddForms
{
    public partial class ManufacturerEditForm : Form
    {
        Guid code;
        public Guid companyName;
        public Guid country;
        public string products;

        private List<Guid> codesName = new List<Guid>();
        private List<Guid> codesCountry = new List<Guid>();

        public ManufacturerEditForm()
        {
            InitializeComponent();
        }

        private void ManufacturerEditForm_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                try
                {
                    connection.Open();

                    List<string> tables = new List<string>
                    {
                        "Компании производителей",
                        "Страны производителей"
                    };

                    OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();

                    dbCommand = new OleDbCommand($"SELECT * FROM [{tables[1]}]", connection);
                    dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxCountry.Items.Add($"{dbReader[1]}");
                        codesCountry.Add(Guid.Parse($"{dbReader[0]}"));
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

                comboBoxCountry.SelectedItem = main.mainDataBaseGrid.SelectedRows[0].Cells[2].Value.ToString();
                textBoxProducts.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[3].Value.ToString();
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

                if (
                   comboBoxCountry.SelectedIndex == -1
                   || textBoxProducts.Text == ""
                   )
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                code = Guid.Parse(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                country = codesCountry[comboBoxCountry.SelectedIndex];
                products = textBoxProducts.Text.ToString();

                string query = $"UPDATE [{main.activeTable}] SET" +
                   "[Код страны производителя] ={" + country + "}," +
                   "[Товары производителя] ='" + products + "'" +
                   "WHERE [Код компании производителя] =" + "{" + code + "}";

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
