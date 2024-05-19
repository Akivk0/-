using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace DataBase.Forms.AddForms
{
    public partial class PurchaseReturnEditForm : Form
    {
        public Guid codeTable;
        public string surname;
        public string name;
        public string patronymic;
        public string reasonReturn;


        public PurchaseReturnEditForm()
        {
            InitializeComponent();
        }

        private void PurchaseListAddForm_Load(object sender, EventArgs e)
        {

            MainForm main = this.Owner as MainForm;

            textBoxSurname.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString();
            textBoxName.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[2].Value.ToString();
            textBoxPatronymic.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[3].Value.ToString();
            richTextBoxReturn.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[4].Value.ToString();

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
                    String.IsNullOrEmpty(textBoxSurname.Text) ||
                    String.IsNullOrEmpty(textBoxName.Text) ||
                    String.IsNullOrEmpty(textBoxPatronymic.Text) ||
                    String.IsNullOrEmpty(richTextBoxReturn.Text))
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                codeTable = Guid.Parse(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                surname = textBoxSurname.Text.ToString();
                name = textBoxName.Text.ToString();
                patronymic = textBoxPatronymic.Text.ToString();
                reasonReturn = richTextBoxReturn.Text.ToString();

                string query = $"UPDATE [{main.activeTable}] SET" +
                   "[Фамилия] ='" + surname + "'," +
                   "[Имя] ='" + name + "'," +
                   "[Отчество] ='" + patronymic + "'," +
                   "[Причина возварта] ='" + reasonReturn + "'" +
                   "WHERE [Номер покупки] =" + "{" + codeTable + "}";

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