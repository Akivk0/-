﻿using System;
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
    public partial class SupplierNameAddForm : Form
    {
        public string name;

        public SupplierNameAddForm()
        {
            InitializeComponent();
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

                name = textBoxNameFabricator.Text.ToString();

                string query = $"INSERT INTO [{main.activeTable}] VALUES (" + "{" + Guid.NewGuid() + "}" + ",'" + name + "')";
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
