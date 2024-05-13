using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;

namespace DataBase.Forms
{
    public partial class QueryForm : Form
    {
        MainForm main;
        public string query = "";
        public string findValueFirst;
        public string findValueSecond;


        private List<Guid> codes = new List<Guid>();

        public QueryForm()
        {
            InitializeComponent();

        }

        private void QueryForm_Load(object sender, EventArgs e)
        {
            main = this.Owner as MainForm;

            monthCalendar1.Visible = false;

            switch (main.activeQuery)
            {
                case "поиск товара по артикулу":
                   
                    comboBox1.Visible = false;
                    break;

                case "поиск поставщиков по стране":
                   
                    textBox1.Visible = false;

                    using (OleDbConnection connection = new OleDbConnection(main.connectionString))
                    {
                        try
                        {
                            connection.Open();

                            List<string> tables = new List<string>
                            {
                                "Страна поставщика"
                            };

                            OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                            OleDbDataReader dbReader = dbCommand.ExecuteReader();
                            while (dbReader.Read())
                            {
                                comboBox1.Items.Add($"{dbReader[1]}");
                                codes.Add(Guid.Parse($"{dbReader[0]}"));
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
                    }
                    break;

                case "поиск производителя по типу товара":
                   
                    textBox1.Visible = false;
                    using (OleDbConnection connection = new OleDbConnection(main.connectionString))
                    {
                        try
                        {
                            connection.Open();

                            List<string> tables = new List<string>
                            {
                                "Производители"
                            };

                            OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                            OleDbDataReader dbReader = dbCommand.ExecuteReader();
                            while (dbReader.Read())
                            {
                                comboBox1.Items.Add($"{dbReader[2]}");
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
                    }
                    break;

                case "стеллаж комиссионного оружия":
                   
                    textBox1.Visible = false;
                    using (OleDbConnection connection = new OleDbConnection(main.connectionString))
                    {
                        try
                        {
                            connection.Open();

                            List<string> tables = new List<string>
                            {
                                "Комиссионное огнестрельное оружие"
                            };

                            OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                            OleDbDataReader dbReader = dbCommand.ExecuteReader();
                            while (dbReader.Read())
                            {
                                comboBox1.Items.Add($"{dbReader[0]}");
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
                    }
                    break;

                case "выбор всех заказов с датой после определенного периода":
                    comboBox1.Visible = false;
                   
                    textBox1.Visible = false;
                    monthCalendar1.Visible = true;
                    break;

                case "выбор всех товаров с ценой выше определенной суммы":
                    comboBox1.Visible = false;
                    break;

                case "выбор всех заказов, содержащих определенный товар":
                   
                    textBox1.Visible = false;
                    using (OleDbConnection connection = new OleDbConnection(main.connectionString))
                    {
                        try
                        {
                            connection.Open();

                            List<string> tables = new List<string>
                            {
                                "Товары"
                            };

                            OleDbCommand dbCommand = new OleDbCommand($"SELECT * FROM [{tables[0]}]", connection);
                            OleDbDataReader dbReader = dbCommand.ExecuteReader();
                            while (dbReader.Read())
                            {
                                comboBox1.Items.Add($"{dbReader[0]}");
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
                    }
                    break;

                case "выбор всех товаров, которых осталось меньше N единиц на складе":
                    comboBox1.Visible = false;
                    break;

                case "выбор всех покупок с датой, попадающей в определенный период":
                    comboBox1.Visible = false;
                    textBox1.Visible = false;
                    monthCalendar1.Visible = true;
                    break;

                case "последние поступления товаров за период":
                    comboBox1.Visible = false;

                    textBox1.Visible = false;
                    monthCalendar1.Visible = true;
                    break;

                default:
                    comboBox1.Visible = false;
                    textBox1.Visible = false;
                    break;
            }

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.ComboBox comboBox)
                {
                    comboBox.DropDownWidth = main.DropDownWidth(comboBox);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            findValueFirst = textBox1.Text.ToString();

        }

        private void ExecuteQuery()
        {
            DateTime dateToFormat;
            DateTime dateToFormat1;
            string formattedDate;
            string formattedDate1;

            switch (main.activeQuery)
            {
                case "поиск по артикулу":
                    query =
                    $"SELECT " +
                    $"*" +
                        $"FROM" +
                        $"[Товары]" +
                            $"WHERE" +
                            $"[Код товара] =" + Convert.ToInt32(findValueFirst);
                    break;

                case "поиск поставщиков по стране":
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
                                "[Поставщики].[Код страны поставщика] ={" + codes[comboBox1.SelectedIndex] + "} AND" +
                            $"[Поставщики].[Код страны поставщика] = [Страна поставщика].[Код страны поставщика] AND" +
                            $"[Поставщики].[Код города поставщика] = [Города поставщиков].[Код города поставщика] AND" +
                            $"[Поставщики].[Код менеджера] = [Менеджеры поставщиков].[Код менеджера]";
                    break;

                case "поиск производителя по типу товара":

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
                            "[Производители].[Товары производителя] ='" + comboBox1.SelectedItem.ToString() + "' AND" +
                            $"[Производители].[Код компании производителя] = [Компании производителей].[Код компании производителя] AND" +
                            $"[Производители].[Код страны производителя] = [Страны производителей].[Код страны производителя]";
                    break;

                case "стеллаж комиссионного оружия":
                    query =
                    $"SELECT " +
                    $"[Комиссионное огнестрельное оружие].[Код товара]," +
                    $"[Товары].[Номер стеллажа/сейфа]" +
                        $"FROM " +
                        $"[Комиссионное огнестрельное оружие]," +
                        $"[Товары]" +
                            $"WHERE" +
                            $"[Комиссионное огнестрельное оружие].[Код товара] = [Товары].[Код товара] AND" +
                            "[Комиссионное огнестрельное оружие].[Код товара] =" + comboBox1.SelectedItem.ToString();
                    break;

                case "количество покупок оружия":
                    query =
                    $"SELECT " +
                    $"COUNT(*) AS Количетсво покупкок оружия " +
                        $"FROM " +
                        $"[Клиенты_ купившие оружие]";
                    break;

                case "выбор всех заказов с датой после определенного периода":

                    dateToFormat = monthCalendar1.SelectionStart;
                    formattedDate = "#" + dateToFormat.ToString("yyyy-MM-dd") + "#";

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
                            $"[Заказы на поставку товара].[Код поставщика] = [Название поставщиков].[Код поставщика] AND" +
                            $"[Заказы на поставку товара].[Дата доставки] > " + formattedDate + "";
                    break;

                case "выбор всех товаров с ценой выше определенной суммы":
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
                            $"[Товары].[Код компании производителя] = [Компании производителей].[Код компании производителя] AND" +
                            $"[Товары].[Цена] >" + findValueFirst;
                    break;

                case "выбор всех заказов с деталями товаров":
                    query =
                    $"SELECT " +
                    $"[Перечни заказов].[Код поставки]," +
                    $"[Перечни заказов].[Цена единицы товара]," +
                    $"[Перечни заказов].[Количество]," +
                    $"[Товары].[Код товара]," +
                    $"[Товары].[Наименование]," +
                    $"[Товары].[Цена]," +
                    $"[Типы товаров].[Тип товара]," +
                    $"[Компании производителей].[Производитель]" +
                        $"FROM " +
                        $"[Товары]," +
                        $"[Типы товаров]," +
                        $"[Перечни заказов]," +
                        $"[Компании производителей]" +
                            $"WHERE" +
                            $"[Товары].[Код типа] = [Типы товаров].[Код типа] AND" +
                            $"[Товары].[Код компании производителя] = [Компании производителей].[Код компании производителя] AND" +
                            $"[Товары].[Код товара] = [Перечни заказов].[Код товара]";
                    break;

                case "выбор всех клиентов, сделавших более одной покупки оружия":
                    query =
                    $"SELECT " +
                    $"[Клиенты_ купившие оружие].[Номер лицензии]," +
                    $"COUNT(*) AS [Количество покупок]" +
                        $"FROM [Клиенты_ купившие оружие] " +
                        $"GROUP BY [Клиенты_ купившие оружие].[Номер лицензии] " +
                        $"HAVING COUNT(*) > 1";
                    break;

                case "выбор всех заказов, содержащих определенный товар":
                    query =
                    $"SELECT " +
                    $"[Перечни заказов].[Код поставки]," +
                    $"[Перечни заказов].[Код товара]," +
                    $"[Перечни заказов].[Цена единицы товара]," +
                    $"[Перечни заказов].[Количество]" +
                        $"FROM " +
                        $"[Перечни заказов]" +
                            $"WHERE" +
                            "[Перечни заказов].[Код товара] = " + comboBox1.SelectedItem;
                    break;

                case "самый продаваемый товар":
                    query =
                    $"SELECT TOP 1 [Товары].[Код товара], SUM([Перечни покупок].Количество) AS TotalSales " +
                        $"FROM " +
                        $"[Товары] " +
                        $"INNER JOIN [Перечни покупок] ON [Товары].[Код товара] = [Перечни покупок].[Код товара] " +
                        "GROUP BY [Товары].[Код товара] " +
                        "ORDER BY SUM([Перечни покупок].Количество) DESC ";
                    break;

                case "выбор всех товаров, которых осталось меньше N единиц на складе":
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
                            $"[Товары].[Код компании производителя] = [Компании производителей].[Код компании производителя] AND" +
                            $"[Товары].[Количество на складе] <" + findValueFirst;
                    break;

                case "выбор всех покупок с датой, попадающей в определенный период":
                    dateToFormat = monthCalendar1.SelectionStart;
                    formattedDate = "#" + dateToFormat.ToString("yyyy-MM-dd") + "#";

                    dateToFormat1 = monthCalendar1.SelectionEnd;
                    formattedDate1 = "#" + dateToFormat1.ToString("yyyy-MM-dd") + "#";

                    query =
                    $"SELECT " +
                    $"* " +
                        $"FROM " +
                        $"[Покупки]" +
                            $"WHERE" +
                            $"[Покупки].[Дата покупки] > " + formattedDate + " AND" +
                            $"[Покупки].[Дата покупки] < " + formattedDate1;
                    break;

                case "количество товаров каждого производителя":
                    query = @"
                    SELECT 
                        [Производители].[Код компании производителя],
                        COUNT([Товары].[Код товара]) AS [Всего товаров]
                    FROM 
                        [Производители]
                    INNER JOIN 
                        [Товары] ON [Производители].[Код компании производителя] = [Товары].[Код компании производителя]
                    GROUP BY 
                        [Производители].[Код компании производителя]";
                    break;

                case "количество товаров каждого типа":
                    query = @"
                    SELECT 
                        [Типы товаров].[Код типа],
                        COUNT([Товары].[Код товара]) AS [Всего товаров]
                    FROM 
                        [Типы товаров]
                    INNER JOIN 
                        [Товары] ON [Типы товаров].[Код типа] = [Товары].[Код типа]
                    GROUP BY 
                        [Типы товаров].[Код типа]";
                    break;

                case "действующие лицензии":
                    dateToFormat = DateTime.Now;
                    formattedDate = "#" + dateToFormat.ToString("yyyy-MM-dd") + "#";

                    query =
                    $"SELECT " +
                    $"* " +
                        $"FROM " +
                        $"[Лицензии на приобретение]" +
                            $"WHERE" +
                            $"[Лицензии на приобретение].[Дата окончания лицензии] > " + formattedDate;
                    break;

                case "подсчет общего количества товаров в магазине":
                    query =
                    $"SELECT " +
                    $"COUNT(*) AS [Количетсво товаров] " +
                        $"FROM " +
                        $"[Товары]";
                    break;

                case "последние поступления товаров за период":
                    dateToFormat = monthCalendar1.SelectionStart;
                    formattedDate = "#" + dateToFormat.ToString("yyyy-MM-dd") + "#";

                    dateToFormat1 = monthCalendar1.SelectionEnd;
                    formattedDate1 = "#" + dateToFormat1.ToString("yyyy-MM-dd") + "#";

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
                            $"[Товары].[Код компании производителя] = [Компании производителей].[Код компании производителя] AND" +
                            $"[Товары].[Дата последнего пополнения] > " + formattedDate + " AND" +
                            $"[Товары].[Дата последнего пополнения] < " + formattedDate1;
                    break;

                case "общая сумма товаров":
                    query = @"
                    SELECT SUM([Товары].[Цена] * [Товары].[Количество на складе]) AS [Сумма товаров]
                    FROM [Товары]";
                    break;

                case "сумма товаров каждого типа":
                    query = @"
                    SELECT 
                        [Типы товаров].[Код типа],
                        SUM([Товары].[Цена]) AS [Сумма товаров]
                    FROM 
                        [Типы товаров]
                    INNER JOIN 
                        [Товары] ON [Типы товаров].[Код типа] = [Товары].[Код типа]
                    GROUP BY 
                        [Типы товаров].[Код типа]";
                    break;

                case "продажи по каждому товару":
                    query = @"
                    SELECT 
                        [Товары].[Код товара],
                        SUM([Товары].[Цена] * [Перечни покупок].[Количество]) AS [Сумма товаров]
                    FROM 
                        [Товары]
                    INNER JOIN 
                        [Перечни покупок] ON [Перечни покупок].[Код товара] = [Товары].[Код товара]
                    GROUP BY 
                        [Товары].[Код товара]";
                    break;

                case "продажи по каждому типу":
                    query = @"
                    SELECT 
                        [Типы товаров].[Код типа],
                        SUM([Товары].[Цена] * [Перечни покупок].[Количество]) AS [Сумма товаров]
                    FROM 
                        [Товары]
                    INNER JOIN 
                        [Перечни покупок] ON [Перечни покупок].[Код товара] = [Товары].[Код товара]
                    GROUP BY 
                        [Товары].[Код товара]";
                    break;

                case "продажи по каждому производителю":
                    Console.WriteLine("Вы выбрали продажи по каждому производителю");
                    break;

                case "сумма возвратов":
                    query = @"
                    SELECT 
                        SUM([Товары].[Цена] * [Перечни покупок].[Количество]) AS [Сумма возвратов]
                    FROM 
                        [Товары]
                    INNER JOIN 
                        [Перечни покупок] ON [Перечни покупок].[Код товара] = [Товары].[Код товара]";
                    break;

                case "сумма заказов":
                    query = @"
                    SELECT 
                        SUM([Товары].[Цена] * [Перечни заказов].[Количество]) AS [Сумма заказов]
                    FROM 
                        [Товары]
                    INNER JOIN
                        [Перечни заказов] ON [Перечни заказов].[Код товара] = [Товары].[Код товара]";
                    break;

                case "сумма каждого заказа":
                    query = @"
                    SELECT 
                        [Перечни заказов].[Код поставки],
                        SUM([Перечни заказов].[Цена единицы товара] * [Перечни заказов].[Количество]) AS [Сумма товаров]
                    FROM 
                        [Товары]
                    INNER JOIN 
                        [Перечни заказов] ON [Перечни заказов].[Код товара] = [Товары].[Код товара]
                    GROUP BY 
                        [Перечни заказов].[Код поставки]";
                    break;

                case "сумма каждой покупки":
                    query = @"
                    SELECT 
                        [Перечни покупок].[Номер покупки],
                        SUM([Товары].[Цена] * [Перечни покупок].[Количество]) AS [Сумма товаров]
                    FROM 
                        [Товары]
                    INNER JOIN 
                        [Перечни покупок] ON [Перечни покупок].[Код товара] = [Товары].[Код товара]
                    GROUP BY 
                        [Перечни покупок].[Номер покупки]";
                    break;


            }

            using (OleDbConnection connection = new OleDbConnection(main.connectionString))
            {
                try
                {
                    connection.Open();
                    DataSet dataSet = new DataSet();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    adapter.Fill(dataSet, "table");
                    dataGridViewQuery.DataSource = dataSet.Tables["table"].DefaultView;
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

        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteQuery();
        }

        private void dataGridViewQuery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}