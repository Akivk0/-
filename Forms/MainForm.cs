using DataBase.Forms;
using DataBase.Forms.AddForms;
using DataBase.Forms.EditForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataBase
{
    public partial class MainForm : Form
    {
        public string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = WeaponShop.mdb";

        public string activeTable;
        public string activeQuery;

        public MainForm()
        {
            InitializeComponent();
        }

        public int DropDownWidth(System.Windows.Forms.ComboBox myCombo)
        {
            int maxWidth = 1;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in myCombo.Items)
            {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            return maxWidth;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            //Заполнение выпадабщего списка названиями таблиц
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                List<string> tables = new List<string>();

                foreach (DataRow r in connection.GetSchema("Tables").Select("TABLE_TYPE = 'TABLE'"))
                    tables.Add(r["TABLE_NAME"].ToString());

                foreach (var i in tables)
                {
                    comboBoxTables.Items.Add(i);
                }
                activeTable = comboBoxTables.Items[0].ToString();

                comboBoxTables.SelectedIndex = 0;

                connection.Close();
            }

            List<string> help = new List<string>
            {
                "поиск товара по артикулу",
                "поиск поставщиков по стране",
                "поиск производителя по типу товара",
                "поиск менеджера поставщика",
                "стеллаж комиссионного оружия",
                "количество покупок оружия",
                "выбор всех заказов с датой после определенного периода",
                "выбор всех товаров с ценой выше определенной суммы",
                "выбор всех заказов с деталями товаров",
                "выбор всех клиентов, сделавших более одной покупки оружия",
                "выбор всех заказов, содержащих определенный товар",
                "самый продаваемый товар",
                "выбор всех товаров, которых осталось меньше N единиц на складе",
                "ежемесячные траты",
                "выбор всех покупок с датой, попадающей в определенный период",
                "количество товаров каждого производителя",
                "количество товаров каждого типа",
                "выбор всех заказов, содержащих определенный товар",
                "подсчет общего количества товаров в магазине",
                "действующие лицензии",
                "последние поступления товаров за период",
                "общая сумма товаров",
                "сумма товаров каждого типа",
                "продажи по каждому товару",
                "продажи по каждому типу",
                "продажи по каждому производителю",
                "сумма возвратов",
                "сумма заказов"
            };

            foreach (var i in help)
            {
                comboBoxQuery.Items.Add(i);
            }

            comboBoxQuery.SelectedIndex = 0;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.ComboBox comboBox)
                {
                    comboBox.DropDownWidth = DropDownWidth(comboBox);
                }
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeTable = comboBoxTables.SelectedItem.ToString();
            PrintMainTable();
        }

        public void PrintMainTable()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "";

                switch (activeTable)
                {
                    case "Перечни заказов":
                        query =
                        $"SELECT " +
                        $"[Перечни заказов].[Код поставки]," +
                        $"[Перечни заказов].[Код товара]," +
                        $"[Перечни заказов].[Цена единицы товара]," +
                        $"[Перечни заказов].[Количество]" +
                            $"FROM " +
                            $"[Перечни заказов]";

                        break;

                    case "Возвраты товаров":
                        query =
                            $"SELECT " +
                            $"[Возвраты товаров].[Номер покупки]," +
                            $"[Возвраты товаров].[Фамилия]," +
                            $"[Возвраты товаров].[Имя]," +
                            $"[Возвраты товаров].[Отчество]," +
                            $"[Возвраты товаров].[Причина возварта]" +
                                $"FROM " +
                                $"[Возвраты товаров]";
                        break;

                    case "Поставщики":
                        query =
                            $"SELECT " +
                            $"[Поставщики].[Код поставщика]," +
                            $"[Название поставщиков].[Название поставщика]," +
                            $"[Страна поставщика].[Страна поставщика]," +
                            $"[Города поставщиков].[Город поставщика]," +
                            $"[Менеджеры поставщиков].[Имя менеджера]" +
                                $"FROM " +
                                $"[Поставщики]," +
                                $"[Название поставщиков]," +
                                $"[Страна поставщика]," +
                                $"[Города поставщиков]," +
                                $"[Менеджеры поставщиков]" +
                                    $"WHERE" +
                                    $"[Поставщики].[Код поставщика] = [Название поставщиков].[Код поставщика] AND" +
                                    $"[Поставщики].[Код страны поставщика] = [Страна поставщика].[Код страны поставщика] AND" +
                                    $"[Поставщики].[Код города поставщика] = [Города поставщиков].[Код города поставщика] AND" +
                                    $"[Поставщики].[Код менеджера] = [Менеджеры поставщиков].[Код менеджера]";
                        break;

                    case "Производители":
                        query =
                        $"SELECT " +
                        $"[Производители].[Код компании производителя]," +
                        $"[Компании производителей].[Производитель]," +
                        $"[Страны производителей].[Страна производителя]," +
                        $"[Производители].[Товары производителя]" +
                            $"FROM " +
                            $"[Производители]," +
                            $"[Компании производителей]," +
                            $"[Страны производителей]" +
                                $"WHERE" +
                                $"[Производители].[Код компании производителя] = [Компании производителей].[Код компании производителя] AND" +
                                $"[Производители].[Код страны производителя] = [Страны производителей].[Код страны производителя]";
                        break;

                    case "Товары":
                        query =
                        $"SELECT " +
                        $"[Товары].[Код товара]," +
                        $"[Товары].[Наименование]," +
                        $"[Товары].[Цена]," +
                        $"[Товары].[Номер стеллажа/сейфа]," +
                        $"[Товары].[Количество на складе]," +
                        $"[Товары].[Дата последнего пополнения]," +
                        $"[Типы товаров].[Тип товара]," +
                        $"[Компании производителей].[Производитель]" +
                            $"FROM " +
                            $"[Товары]," +
                            $"[Типы товаров]," +
                            $"[Компании производителей]" +
                                $"WHERE" +
                                $"[Товары].[Код типа] = [Типы товаров].[Код типа] AND" +
                                $"[Товары].[Код компании производителя] = [Компании производителей].[Код компании производителя]";
                        break;

                    case "Заказы на поставку товара":
                        query =
                        $"SELECT " +
                        $"[Заказы на поставку товара].[Код поставки]," +
                        $"[Заказы на поставку товара].[Дата доставки]," +
                        $"[Заказы на поставку товара].[Дата составления заказа]," +
                        $"[Название поставщиков].[Название поставщика]" +
                            $"FROM " +
                            $"[Заказы на поставку товара]," +
                            $"[Название поставщиков]" +
                                $"WHERE" +
                                $"[Заказы на поставку товара].[Код поставщика] = [Название поставщиков].[Код поставщика]";
                        break;

                    default:
                        query = $"SELECT * FROM [{activeTable}]";
                        break;
                }

                try
                {
                    connection.Open();
                    DataSet dataSet = new DataSet();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    adapter.Fill(dataSet, "table");
                    mainDataBaseGrid.DataSource = dataSet.Tables["table"].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сообщение: {ex.Message}", "Ошибка!");
                }
                finally
                {
                    connection.Close();
                }

            }

        }

        private void buttonAddNewItem_Click(object sender, EventArgs e)
        {
            var addForm = new Form();

            switch (activeTable)
            {
                case "Перечни заказов":
                    addForm = new OrderListAddForm();
                    break;
                case "Заказы на поставку товара":
                    addForm = new OrderAddForm();
                    break;
                case "Поставщики":
                    addForm = new SupplierAddForm();
                    break;
                case "Города поставщиков":
                    addForm = new SupplierCityAddForm();
                    break;
                case "Название поставщиков":
                    addForm = new SupplierNameAddForm();
                    break;
                case "Страна поставщика":
                    addForm = new SupplierCountryAddForm();
                    break;
                case "Менеджеры поставщиков":
                    addForm = new SupplierManagerAddForm();
                    break;
                case "Товары":
                    addForm = new ProductAddForm();
                    break;
                case "Комиссионное огнестрельное оружие":
                    addForm = new CommissionAddForm();
                    break;
                case "Типы товаров":
                    addForm = new ProductTypeAddForm();
                    break;
                case "Перечни покупок":
                    addForm = new PurchaseListAddForm();
                    break;
                case "Покупки":
                    addForm = new PurchaseAddForm();
                    break;
                case "Возвраты товаров":
                    addForm = new PurchaseReturnAddForm();
                    break;
                case "Клиенты_ купившие оружие":
                    addForm = new PurchaseWeaponAddForm();
                    break;
                case "Лицензии на приобретение":
                    addForm = new LicenseAddForm();
                    break;
                case "Производители":
                    addForm = new ManufacturerAddForm();
                    break;
                case "Компании производителей":
                    addForm = new ManufacturerNameAddForm();
                    break;
                case "Страны производителей":
                    addForm = new ManufacturerNameAddForm();
                    break;
            }

            addForm.Owner = this;
            addForm.ShowDialog();
            PrintMainTable();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (mainDataBaseGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку", "Ошибка");
                return;
            }

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = $"DELETE FROM [{activeTable}] " +
                        $"WHERE ";

                switch (activeTable)
                {
                    case "Товары":
                        query += $"[{mainDataBaseGrid.Columns[0].HeaderText}] = " + $"{(mainDataBaseGrid.SelectedRows[0].Cells[0].Value)}";
                        break;

                    case "Комиссионное огнестрельное оружие":
                        query += $"[{mainDataBaseGrid.Columns[0].HeaderText}] = " + $"{(mainDataBaseGrid.SelectedRows[0].Cells[0].Value)}";
                        break;

                    case "Перечни заказов":
                        query += $"[{mainDataBaseGrid.Columns[0].HeaderText}] = {{" + $"{(mainDataBaseGrid.SelectedRows[0].Cells[0].Value)}" + $"}}" +
                        $"AND" +
                        $"[{mainDataBaseGrid.Columns[1].HeaderText}] = " + $"{(mainDataBaseGrid.SelectedRows[0].Cells[1].Value)}" + $"";
                        break;

                    case "Перечни покупок":
                        query += $"[{mainDataBaseGrid.Columns[0].HeaderText}] = {{" + $"{(mainDataBaseGrid.SelectedRows[0].Cells[0].Value)}" + $"}}" +
                        $"AND" +
                        $"[{mainDataBaseGrid.Columns[1].HeaderText}] = " + $"{(mainDataBaseGrid.SelectedRows[0].Cells[1].Value)}" + $"";
                        break;

                    default:
                        query += $"[{mainDataBaseGrid.Columns[0].HeaderText}] ={{" + $"{(mainDataBaseGrid.SelectedRows[0].Cells[0].Value)}" + $"}}";

                        break;
                }

                OleDbCommand dbCommand = new OleDbCommand(query, connection);
                try
                {
                    dbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", $"Ошибка! Запись не удалена!");
                }
                connection.Close();

                PrintMainTable();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (mainDataBaseGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку", "Ошибка");
                return;
            }

            if (mainDataBaseGrid.SelectedRows[0].Index == mainDataBaseGrid.RowCount - 1)
            {
                MessageBox.Show("Выберите не пустую строку", "Ошибка");
                return;
            }

            var editForm = new Form();

            switch (activeTable)
            {
                case "Перечни заказов":
                    editForm = new OrderListEditForm();
                    break;
                case "Заказы на поставку товара":
                    editForm = new OrderEditForm();
                    break;
                case "Поставщики":
                    editForm = new SupplierEditForm();
                    break;
                case "Города поставщиков":
                    editForm = new SupplierCityEditForm();
                    break;
                case "Название поставщиков":
                    editForm = new SupplierNameEditForm();
                    break;
                case "Страна поставщика":
                    editForm = new SupplierCountryEditForm();
                    break;
                case "Менеджеры поставщиков":
                    editForm = new SupplierManagerEditForm();
                    break;
                case "Товары":
                    editForm = new ProductEditForm();
                    break;
                case "Комиссионное огнестрельное оружие":
                    editForm = new CommissionEditForm();
                    break;
                case "Типы товаров":
                    editForm = new ProductTypeEditForm();
                    break;
                case "Перечни покупок":
                    editForm = new PurchaseListEditForm();
                    break;
                case "Покупки":
                    editForm = new PurchaseEditForm();
                    break;
                case "Возвраты товаров":
                    editForm = new PurchaseReturnEditForm();
                    break;
                case "Клиенты_ купившие оружие":
                    editForm = new PurchaseWeaponEditForm();
                    break;
                case "Лицензии на приобретение":
                    editForm = new LicenseEditForm();
                    break;
                case "Производители":
                    editForm = new ManufacturerEditForm();
                    break;
                case "Компании производителей":
                    editForm = new ManufacturerNameEditForm();
                    break;
                case "Страны производителей":
                    editForm = new ManufacturerCountryNameEditForm();
                    break;
            }

            editForm.Owner = this;
            editForm.ShowDialog();
            PrintMainTable();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            activeQuery = comboBoxQuery.SelectedItem.ToString();

            QueryForm queryForm = new QueryForm();
            queryForm.Owner = this;
            queryForm.Text = activeQuery;
            queryForm.Show();
        }
    }
}
