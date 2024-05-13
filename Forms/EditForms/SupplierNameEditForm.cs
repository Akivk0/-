using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataBase.Forms.AddForms
{
    public partial class SupplierNameEditForm : Form
    {
        Guid code;
        public string name;

        public SupplierNameEditForm()
        {
            InitializeComponent();
        }

        private void SupplierNameEditForm_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            textBoxNameFabricator.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void buttonAddNameFabricator_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                connection.Open();

                if (String.IsNullOrEmpty(textBoxNameFabricator.Text))
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                code = Guid.Parse(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                name = textBoxNameFabricator.Text.ToString();

                string query = $"UPDATE [{main.activeTable}] SET" +
                    "[Название поставщика] = '" + name + "'" +
                    "WHERE [Код поставщика] =" + "{" + code + "}";


                OleDbCommand dbCommand = new OleDbCommand(query, connection);

                try
                {
                    dbCommand.ExecuteNonQuery();
                    MessageBox.Show($"Запись изменена!", "Внимание!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", $"Ошибка! Запись не изменена!");
                }

                connection.Close();

            }
            this.Close();
        }
    }
}
