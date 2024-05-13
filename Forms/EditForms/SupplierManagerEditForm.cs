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

namespace DataBase.Forms.AddForms
{
    public partial class SupplierManagerEditForm : Form
    {
        Guid code;
        public string name;
        public string telephoneNumber;
        
        public SupplierManagerEditForm()
        {
            InitializeComponent();
        }

        private void SupplierManagerEditForm_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            textBoxNameFabricator.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString();
            maskedTextBox1.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void buttonAddNameFabricator_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                connection.Open();

                if (String.IsNullOrEmpty(textBoxNameFabricator.Text) 
                    || String.IsNullOrEmpty(maskedTextBox1.Text))
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                code = Guid.Parse(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                name = textBoxNameFabricator.Text.ToString();
                telephoneNumber = maskedTextBox1.Text.ToString();

                string query = $"UPDATE [{main.activeTable}] SET" +
                    "[Имя менеджера] = '" + name + "'," +
                    "[Телефон менеджера] = '" + telephoneNumber + "'" +
                    "WHERE [Код менеджера] =" + "{" + code + "}";


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
