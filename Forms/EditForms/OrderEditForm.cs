using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase.Forms.AddForms
{
    public partial class OrderEditForm : Form
    {
        Guid code;
        public DateTime dateSupply;
        public DateTime datePreparation;
        public Guid supplier;

        private List<Guid> codesSupplier = new List<Guid>();

        public OrderEditForm()
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
                        "Поставщики"
                    };

                    OleDbCommand dbCommand = new OleDbCommand(
                       $"SELECT" +
                       $"[Поставщики].[Код поставщика]," +
                       $"[Название поставщиков].[Название поставщика]" +
                           $"FROM " +
                           $"[Поставщики]," +
                           $"[Название поставщиков]" +
                               $"WHERE" +
                               $"[Поставщики].[Код поставщика] = [Название поставщиков].[Код поставщика]",
                       connection);

                    OleDbDataReader dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxSupplier.Items.Add($"{dbReader[1]}");
                        codesSupplier.Add(Guid.Parse($"{dbReader[0]}"));
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

                comboBoxSupplier.SelectedItem = main.mainDataBaseGrid.SelectedRows[0].Cells[3].Value.ToString();
                maskedTextBoxPreparation.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[2].Value.ToString();
                maskedTextBoxSupply.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString();
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
                var a = comboBoxSupplier.SelectedIndex;
                if (comboBoxSupplier.SelectedIndex == -1 ||
                    maskedTextBoxSupply.Text == "" ||
                    maskedTextBoxPreparation.Text == ""
                    )
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                code = Guid.Parse(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                dateSupply = Convert.ToDateTime(maskedTextBoxSupply.Text.ToString());
                datePreparation = Convert.ToDateTime(maskedTextBoxPreparation.Text.ToString());
                supplier = codesSupplier[comboBoxSupplier.SelectedIndex];

                string query = $"UPDATE [{main.activeTable}] SET" +
                    "[Дата доставки] ='" + dateSupply + "'," +
                    "[Дата составления заказа] ='" + datePreparation + "'," +
                    "[Код поставщика] ={" + supplier + "}" +
                    "WHERE [Код поставки] =" + "{" + code + "}";

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
