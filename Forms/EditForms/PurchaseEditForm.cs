using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DataBase.Forms.AddForms
{
    public partial class PurchaseEditForm : Form
    {
        public Guid code;
        public DateTime date;

        public PurchaseEditForm()
        {
            InitializeComponent();
        }

        private void PurchaseEditForm_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            maskedTextBoxDate.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void buttonAddNameFabricator_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                connection.Open();

                if (String.IsNullOrEmpty(maskedTextBoxDate.Text))
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                code = Guid.Parse(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                date = Convert.ToDateTime(maskedTextBoxDate.Text.ToString());

                string qu1ery = $"INSERT INTO [{main.activeTable}] " +
                    $"VALUES (" +
                    "{" + Guid.NewGuid() + "}," +
                    "'" + date + "'" +
                    ")";

                string query = $"UPDATE [{main.activeTable}] SET" +
                  "[Дата покупки] ='" + date + "'" +
                  "WHERE [Номер покупки] =" + "{" + code + "}";

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
