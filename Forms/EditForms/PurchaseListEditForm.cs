using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataBase.Forms.AddForms
{
    public partial class PurchaseListEditForm : Form
    {
        public Guid codePurchase;
        public int productCode;
        public Guid code;
        public int amount;
        public int codeProduct;

        private List<Guid> codesPurchase = new List<Guid>();

        public PurchaseListEditForm()
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
                        "Покупки",
                        "Товары"
                    };

                    OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxPurch.Items.Add($"{dbReader[0]}");
                    }

                    dbCommand = new OleDbCommand($"SELECT * FROM [{tables[1]}]", connection);
                    dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxProduct.Items.Add($"{dbReader[0]}");
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

                comboBoxPurch.SelectedItem = main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString();
                comboBoxProduct.SelectedItem = main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString();
                textBoxAmount.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[2].Value.ToString();
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

                if (String.IsNullOrEmpty(comboBoxPurch.Text)
                    || String.IsNullOrEmpty(textBoxAmount.Text)
                    || String.IsNullOrEmpty(comboBoxProduct.Text))
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }


                codePurchase = Guid.Parse(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                productCode = Convert.ToInt32(main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString());
                code = Guid.Parse(comboBoxPurch.Text.ToString());
                amount = Convert.ToInt16(textBoxAmount.Text.ToString());
                codeProduct = Convert.ToInt32(comboBoxProduct.Text.ToString());

                string query = $"UPDATE [{main.activeTable}] SET" +
                   "[Номер покупки] ={" + code + "}," +
                   "[Код товара] =" + productCode + "," +
                   "[Количество] =" + amount + " " +
                   "WHERE [Номер покупки] =" + "{" + codePurchase + "} AND" +
                   "[Код товара] =" + "" + codeProduct + "";

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
