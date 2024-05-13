using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DataBase.Forms.AddForms
{
    public partial class SupplierCountryEditForm : Form
    {
        Guid code;
        public string country;

        public SupplierCountryEditForm()
        {
            InitializeComponent();
        }

        private void SupplierCountryEditForm_Load(object sender, EventArgs e)
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
                country = textBoxNameFabricator.Text.ToString();

                string query = $"UPDATE [{main.activeTable}] SET" +
                    "[Страна поставщика] = '" + country + "'" +
                    "WHERE [Код страны поставщика] =" + "{" + code + "}";

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
