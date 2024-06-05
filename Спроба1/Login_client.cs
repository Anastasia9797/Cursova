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
    public partial class Login_client : Form
    {
        public Login_client()
        {
            InitializeComponent();
            LoadMenu();
            LoadClientOrders();
            int clientId = Log_in.GlobalVariables.ClientId;
            LoadClientOrdersData();
        }
        //Завантаження списку назв страв
        private void LoadMenu()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT name_menu FROM menu";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                comboBox_client.Items.Clear();
                while (reader.Read())
                {
                    comboBox_client.Items.Add(reader["name_menu"].ToString());
                }
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
        //Вихід
        private void button1_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Close();
        }
        
        private void Login_client_Load(object sender, EventArgs e)
        {

        }
        //Виведення інформації про страву після обрання її назви
        private void comboBox_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_client.SelectedIndex != -1)
            {
                string selectedMenuName = comboBox_client.SelectedItem.ToString();

                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    string query = @"SELECT m.category_menu, m.price_menu, m.calories_menu, GROUP_CONCAT(p.name_products SEPARATOR ', ') as ingredients 
                                    FROM menu m 
                                    INNER JOIN menu_and_products mp ON m.id_menu = mp.id_menu
                                    INNER JOIN products p ON mp.id_products = p.id_products
                                    WHERE m.name_menu = @menuName
                                    GROUP BY m.category_menu, m.price_menu, m.calories_menu";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@menuName", selectedMenuName);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox_category.Text = reader["category_menu"].ToString();
                        textBox_price.Text = reader["price_menu"].ToString();
                        textBox_calories.Text = reader["calories_menu"].ToString();
                        textBox_ingridients.Text = reader["ingredients"].ToString();
                    }
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
        }
        //Замовлення страви
        private void button_order_Click(object sender, EventArgs e)
        {
            if(comboBox_client.SelectedIndex != -1)
            {
                // отримуємо назву обраної страви з comboBox
                string selectedMenuName = comboBox_client.SelectedItem.ToString();
                int clientId = GlobalVariables.ClientId;

                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    //запит для отримання id_menu за назвою страви та вставки замовлення
                    string query = @"INSERT INTO orders_in_anticipation (menu_id_menu, client_id_client, date_orders_in_anticipation) 
                                     SELECT id_menu, @clientId, @date 
                                     FROM menu 
                                     WHERE name_menu = @menuName";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@menuName", selectedMenuName);
                    cmd.Parameters.AddWithValue("@clientId", clientId);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Замовлення успішно додано!");
                        comboBox_client.SelectedIndex = -1;
                        textBox_category.Text = string.Empty;
                        textBox_price.Text = string.Empty;
                        textBox_calories.Text = string.Empty;
                        textBox_ingridients.Text = string.Empty;
                        LoadClientOrders();
                        LoadClientOrdersData();
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося знайти страву у меню.");
                    }
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
            else
            {
                MessageBox.Show("Будь ласка, оберіть страву!");
            }
        }
        // виводимо інформацію про id та назву позиції меню в комбобокс
        private void LoadClientOrders()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT o.id_orders_in_anticipation, m.name_menu " +
                               "FROM orders_in_anticipation o " +
                               "INNER JOIN menu m ON o.menu_id_menu = m.id_menu " +
                               "WHERE o.client_id_client = @clientId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@clientId", GlobalVariables.ClientId);
                MySqlDataReader reader = cmd.ExecuteReader();

                comboBox_order_delete.Items.Clear();
                while (reader.Read())
                {
                    int orderId = reader.GetInt32("id_orders_in_anticipation");
                    string menuName = reader.GetString("name_menu");
                    comboBox_order_delete.Items.Add(new { Id = orderId, Назва = menuName });
                }
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
        // скасування замовлення
        private void button_order_delete_Click(object sender, EventArgs e)
        {
            if (comboBox_order_delete.SelectedIndex != -1)
            {
                dynamic selectedItem = comboBox_order_delete.SelectedItem;
                int orderId = selectedItem.Id;
                DialogResult result = MessageBox.Show("Ви впевнені, що хочете скасувати замовлення?", "Підтвердження скасування", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM orders_in_anticipation WHERE id_orders_in_anticipation = @orderId";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@orderId", orderId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Замовлення успішно видалено!");
                        comboBox_order_delete.SelectedIndex = -1;
                        // оновлюємо список замовлень
                        LoadClientOrders();
                        LoadClientOrdersData();
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
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть замовлення для видалення!");
            }
        }
        // заповнення таблиці замовлень
        private void LoadClientOrdersData()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = @"SELECT o.id_orders_in_anticipation AS `№ замовлення`,
                                m.name_menu AS `Назва`,
                                m.category_menu AS `Категорія`,
                                m.price_menu AS `Ціна`,
                                GROUP_CONCAT(DISTINCT p.name_products SEPARATOR ', ') AS `Склад`,
                                o.date_orders_in_anticipation AS `Дата та час замовлення`
                                FROM orders_in_anticipation o
                                INNER JOIN menu m ON o.menu_id_menu = m.id_menu
                                LEFT JOIN menu_and_products mp ON m.id_menu = mp.id_menu
                                LEFT JOIN products p ON mp.id_products = p.id_products
                                WHERE o.client_id_client = @clientId
                                GROUP BY o.id_orders_in_anticipation, m.name_menu, m.category_menu, 
                                m.price_menu, o.date_orders_in_anticipation";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@clientId", GlobalVariables.ClientId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_clients_orders.DataSource = table;
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

        private void dataGridView_clients_orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
