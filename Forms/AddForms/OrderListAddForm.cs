using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase.Forms.AddForms
{
    public partial class OrderListAddForm : Form
    {

        public int productCode;
        public int productPrice;
        public int productAmount;
        public Guid orderCode;

        public OrderListAddForm()
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
                        "Товары",
                        "Заказы на поставку товара"
                    };

                    OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxProduct.Items.Add($"{dbReader[0]}");
                    }

                    dbCommand = new OleDbCommand($"SELECT * FROM [{tables[1]}]", connection);
                    dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxOrder.Items.Add($"{dbReader[0]}");
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
                if (comboBoxProduct.SelectedIndex == -1 ||
                    textBoxPrice.Text == "" ||
                    textBoxAmount.Text == "" ||
                    comboBoxOrder.SelectedIndex == -1
                    )
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                productCode = Convert.ToInt32(comboBoxProduct.Text.ToString());
                productPrice = Convert.ToInt32(textBoxPrice.Text.ToString());
                productAmount = Convert.ToInt32(textBoxAmount.Text.ToString());
                orderCode = Guid.Parse(comboBoxOrder.Text.ToString());

                string query = $"INSERT INTO [{main.activeTable}]" +
                    $" VALUES (" +
                    "" + productAmount + "," +
                    "" + productPrice + "," +
                    "" + productCode + "," +
                    "{" + orderCode + "}" +
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
