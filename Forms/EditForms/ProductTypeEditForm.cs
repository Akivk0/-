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
    public partial class ProductTypeEditForm : Form
    {
        Guid code;
        public string typeName;

        public ProductTypeEditForm()
        {
            InitializeComponent();
        }

        private void ProductTypeEditForm_Load(object sender, EventArgs e)
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
                typeName = textBoxNameFabricator.Text.ToString();

                string query = $"UPDATE [{main.activeTable}] SET" +
                    "[Тип товара] = '" + typeName + "'" +
                    "WHERE [Код типа] =" + "{" + code + "}";

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
