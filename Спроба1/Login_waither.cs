using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Спроба1.Log_in;

namespace Спроба1
{
    public partial class Login_waither : Form
    {
        private int waitherId;

        public Login_waither()
        {
            InitializeComponent();
            waitherId = Log_in.GlobalVariables.WaitherId;
            LoadOrdersInAnticipationData();
        }
        // виведення інформації про невиконані замовлення клієнтів в таблиці 
        private void LoadOrdersInAnticipationData()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = @"SELECT o.id_orders_in_anticipation AS `ID Замовлення`, o.menu_id_menu AS `ID Меню`, 
                                m.name_menu AS `Назва`, c.category_name AS `Категорія`, m.price_menu AS `Ціна`, 
                                o.client_id_client AS `ID Клієнта`, cl.name_client AS `Ім'я`, cl.surname_client AS `Прізвище`, 
                                cl.login_client AS `Логін`, cl.phone_number AS `Телефон`, 
                                o.date_orders_in_anticipation AS `Дата замовлення`
                                FROM orders_in_anticipation o
                                INNER JOIN client cl ON o.client_id_client = cl.id_client
                                INNER JOIN menu m ON o.menu_id_menu = m.id_menu
                                INNER JOIN category c ON m.id_category = c.id_category";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_waither.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Close();
        }
        //виконуємо замовлення
        private void btn_complete_Click(object sender, EventArgs e)
        {
            if (dataGridView_waither.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dataGridView_waither.SelectedRows[0].Cells["ID Замовлення"].Value);
                var result = MessageBox.Show($"Чи дійсно ви хочете відмітити замовлення з ID = {orderId} як виконане?", "Підтвердження", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    CompleteOrder(orderId);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть замовлення для виконання.");
            }
        }
        // Для виконання замовлення (переміщення інфи з таблиці замовлень в очікуванні до виконаних замовлень)
        private void CompleteOrder(int orderId)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlTransaction transaction = null;

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = transaction;

                // Вставка рядка у таблицю orders_completed
                cmd.CommandText = @"INSERT INTO orders_completed (id_orders_in_anticipation, menu_id_menu, client_id_client, id_employees, date_orders_in_anticipation, date_order_complited)
                            SELECT o.id_orders_in_anticipation, o.menu_id_menu, o.client_id_client, @waitherId, o.date_orders_in_anticipation, @completeDate
                            FROM orders_in_anticipation o
                            WHERE o.id_orders_in_anticipation = @orderId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.Parameters.AddWithValue("@waitherId", waitherId);
                cmd.Parameters.AddWithValue("@completeDate", DateTime.Now);
                cmd.ExecuteNonQuery();

                // Видалення рядка з таблиці orders_in_anticipation
                cmd.CommandText = @"DELETE FROM orders_in_anticipation WHERE id_orders_in_anticipation = @orderId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show("Замовлення успішно виконано.");
                LoadOrdersInAnticipationData();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("Сталася помилка при виконанні замовлення: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView_waither_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}