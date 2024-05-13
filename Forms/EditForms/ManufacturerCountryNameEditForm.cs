using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DataBase.Forms.EditForms
{
    public partial class ManufacturerCountryNameEditForm : Form
    {
        Guid code;
        public string city;

        public ManufacturerCountryNameEditForm()
        {
            InitializeComponent();
        }

        private void ManufacturerCountryNameEditForm_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            textBoxСity.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                connection.Open();

                if (String.IsNullOrEmpty(textBoxСity.Text))
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                code = Guid.Parse(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                city = textBoxСity.Text.ToString();

                string query = $"UPDATE [{main.activeTable}] SET" +
                     "[Страна производителя] = '" + city + "'" +
                     "WHERE [Код страны производителя] =" + "{" + code + "}";

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
