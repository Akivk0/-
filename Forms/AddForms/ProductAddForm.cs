using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataBase.Forms.AddForms
{
    public partial class ProductAddForm : Form
    {
        public int code;
        public string name;
        public int price;
        public int shelf;
        public int storage;
        public DateTime date;
        public Guid type;
        public Guid manuf;

        private List<Guid> codesType = new List<Guid>();
        private List<Guid> codesManufacturer = new List<Guid>();

        public ProductAddForm()
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
                        "Типы товаров",
                        "Производители"
                    };

                    OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxType.Items.Add($"{dbReader[1]}");
                        codesType.Add(Guid.Parse($"{dbReader[0]}"));
                    }

                    dbCommand = new OleDbCommand(
                        $"SELECT" +
                        $"[Производители].[Код компании производителя]," +
                        $"[Компании производителей].[Производитель]" +
                            $"FROM " +
                            $"[Производители]," +
                            $"[Компании производителей]" +
                                $"WHERE" +
                                $"[Производители].[Код компании производителя] = [Компании производителей].[Код компании производителя]",
                        connection);
                    dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxManuf.Items.Add($"{dbReader[1]}");
                        codesManufacturer.Add(Guid.Parse($"{dbReader[0]}"));
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

                if (textBoxCode.Text == "" ||
                    textBoxName.Text == "" ||
                    textBoxPrice.Text == "" ||
                    textBoxShelf.Text == "" ||
                    textBoxStorage.Text == "" ||
                    maskedTextBoxDate.Text == "" ||
                    comboBoxType.SelectedIndex == -1 ||
                    comboBoxManuf.SelectedIndex == -1
                   )
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                code = Convert.ToInt32(textBoxCode.Text.ToString());
                name = textBoxName.Text.ToString();
                price = Convert.ToInt32(textBoxPrice.Text.ToString());
                shelf = Convert.ToInt16(textBoxShelf.Text.ToString());
                storage = Convert.ToInt16(textBoxStorage.Text.ToString());
                date = Convert.ToDateTime(maskedTextBoxDate.Text.ToString());
                type = codesType[comboBoxType.SelectedIndex];
                manuf = codesManufacturer[comboBoxManuf.SelectedIndex];

                string query = $"INSERT INTO [{main.activeTable}] " +
                   $"VALUES (" +
                   "" + code + "," +
                   "'" + name + "'," +
                   "" + price + "," +
                   "" + shelf + "," +
                   "" + storage + "," +
                   "'" + date + "'," +
                   "{" + type + "}," +
                   "{" + manuf + "}" +
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
