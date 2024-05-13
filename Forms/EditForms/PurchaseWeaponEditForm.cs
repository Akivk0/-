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
    public partial class PurchaseWeaponEditForm : Form
    {
        public Guid code;
        public string surname;
        public string name;
        public string patronymic;
        public DateTime date;
        public Guid purchase;
        public int license;

        private List<Guid> codesPurchase = new List<Guid>();

        public PurchaseWeaponEditForm()
        {
            InitializeComponent();
        }

        private void PurchaseWeaponEditForm_Load(object sender, EventArgs e)
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
                        "Лицензии на приобретение"
                    };

                    OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxPurchase.Items.Add($"{dbReader[0]}");
                        codesPurchase.Add(Guid.Parse($"{dbReader[0]}"));
                    }

                    dbCommand = new OleDbCommand($"SELECT * FROM [{tables[1]}]", connection);
                    dbReader = dbCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        comboBoxLicense.Items.Add($"{dbReader[0]}");
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

                comboBoxPurchase.SelectedItem = main.mainDataBaseGrid.SelectedRows[0].Cells[4].Value.ToString();
                textBoxSurname.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString();
                textBoxName.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[2].Value.ToString();
                textBoxPatronymic.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[3].Value.ToString();
                comboBoxLicense.SelectedItem = main.mainDataBaseGrid.SelectedRows[0].Cells[5].Value.ToString();
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

                if (String.IsNullOrEmpty(textBoxSurname.Text) ||
                    String.IsNullOrEmpty(textBoxName.Text) ||
                    String.IsNullOrEmpty(textBoxSurname.Text) ||
                    comboBoxLicense.SelectedIndex == -1 ||
                    comboBoxPurchase.SelectedIndex == -1
                    )
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                code = Guid.Parse(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                surname = textBoxSurname.Text.ToString();
                name = textBoxName.Text.ToString();
                patronymic = textBoxPatronymic.Text.ToString();
                purchase = codesPurchase[comboBoxPurchase.SelectedIndex];
                license = Convert.ToInt32(comboBoxLicense.Text.ToString());

                string query = $"UPDATE [{main.activeTable}] SET" +
                   "[Номер лицензии] = " + license + "," +
                   "[Фамилия] ='" + surname + "'," +
                   "[Имя] ='" + name + "'," +
                   "[Отчество] ='" + patronymic + "'," +
                   "[Номер покупки] ={" + purchase + "}" +
                   "WHERE [Номер покупки оружия] =" + "{" + code + "}";

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