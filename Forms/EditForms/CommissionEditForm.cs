using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase.Forms.EditForms
{
    public partial class CommissionEditForm : Form
    {
        public int codeTable;
        public string weaponNumber;
        public DateTime date;
        public int price;
        public string surname;
        public string name;
        public string patronymic;
        public int passport;


        public CommissionEditForm()
        {
            InitializeComponent();
        }

        private void CommissionAddForm_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {

                textBoxWeapon.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[1].Value.ToString();
                maskedTextBoxDate.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[2].Value.ToString();
                textBoxPrice.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[3].Value.ToString();
                textBoxSurname.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[4].Value.ToString();
                textBoxName.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[5].Value.ToString();
                textBoxPatronymic.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[6].Value.ToString();
                textBoxPassport.Text = main.mainDataBaseGrid.SelectedRows[0].Cells[7].Value.ToString();
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

                if (
                    textBoxWeapon.Text == "" ||
                    maskedTextBoxDate.Text == "" ||
                    textBoxPrice.Text == "" ||
                    textBoxSurname.Text == "" ||
                    textBoxName.Text == "" ||
                    textBoxPatronymic.Text == "" ||
                    textBoxPassport.Text == "" 
                   )
                {
                    MessageBox.Show("Введены не все данные", "Ошибка");
                    return;
                }

                codeTable = Convert.ToInt32(main.mainDataBaseGrid.SelectedRows[0].Cells[0].Value.ToString());
                weaponNumber = textBoxWeapon.Text.ToString();
                date = Convert.ToDateTime(maskedTextBoxDate.Text.ToString());
                price = Convert.ToInt32(textBoxPrice.Text.ToString());
                surname = textBoxSurname.Text.ToString();
                name = textBoxName.Text.ToString();
                patronymic = textBoxPatronymic.Text.ToString();
                passport = Convert.ToInt32(textBoxPassport.Text.ToString());

                string query = $"UPDATE [{main.activeTable}] SET" +
                   "[Номер оружия] ='" + weaponNumber + "'," +
                   "[Когда приняли] ='" + date + "'," +
                   "[Стоимость покупки] =" + price + "," +
                   "[Фамилия] ='" + surname + "'," +
                   "[Имя] ='" + name + "'," +
                   "[Отчество] ='" + patronymic + "'," +
                   "[Номер паспорта] =" + passport + " " +
                   "WHERE [Код товара] =" + "" + codeTable + "";

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
