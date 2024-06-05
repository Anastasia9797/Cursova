using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Спроба1
{
    public partial class Log_in : Form
    {
        public Log_in()
        {
            InitializeComponent();
        }

        public static class GlobalVariables
        {
            public static int ClientId { get; set; }
            public static int WaitherId { get; set; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            // перевіряємо заповнення полів
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Не всі поля заповнені! Будь ласка, введіть логін та пароль.");
                return;
            }

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();

                // Перевірка логіну і паролю
                string checkCredentialsQuery = "SELECT id_client FROM client WHERE login_client = @login AND password_client = @password";
                MySqlCommand cmd = new MySqlCommand(checkCredentialsQuery, conn);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Неправильний логін або пароль. Повторіть спробу!");
                    return;
                }

                GlobalVariables.ClientId = Convert.ToInt32(result);
                MessageBox.Show("Вітаємо! Вхід пройшов успішно!");

                // Переходимо до форми створення замовлення, передаючи ClientId
                Login_client loginClientForm = new Login_client();
                loginClientForm.Show();
                this.Close();
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox4.Text;
            string password = textBox3.Text;
            string position = comboBox1.SelectedItem?.ToString();

            // Перевіряємо заповнення полів
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Не всі поля заповнені! Будь ласка, введіть логін, пароль та оберіть свою посаду.");
                return;
            }

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                // Перевірка логіну та пароля в таблиці employees
                string checkUserQuery = "SELECT id_employees, position_id_position FROM employees WHERE login_employees = @login AND password_employees = @password";
                MySqlCommand cmd = new MySqlCommand(checkUserQuery, conn);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("Неправильний логін або пароль. Повторіть спробу!");
                    return;
                }

                int employeeId = 0;
                int employeePositionId = 0;

                while (reader.Read())
                {
                    employeeId = reader.GetInt32("id_employees");
                    employeePositionId = reader.GetInt32("position_id_position");
                }
                reader.Close();

                // Отримуємо id позиції з таблиці position
                string getPositionIdQuery = "SELECT id_position FROM position WHERE position_type = @position";
                cmd = new MySqlCommand(getPositionIdQuery, conn);
                cmd.Parameters.AddWithValue("@position", position);
                int positionId = Convert.ToInt32(cmd.ExecuteScalar());

                // Перевірка правильності посади
                if (employeePositionId != positionId)
                {
                    MessageBox.Show("Вибрано не ту посаду!");
                    return;
                }
                GlobalVariables.WaitherId = Convert.ToInt32(employeeId);
                MessageBox.Show("Вітаємо! Вхід пройшов успішно!");

                if (position == "Менеджер")
                {
                    Login_manager loginManagerForm = new Login_manager();
                    loginManagerForm.Show();
                }
                else if (position == "Офіціант")
                {
                    Login_waither loginWaitherForm = new Login_waither();
                    loginWaitherForm.Show();
                }
                this.Close();
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
}
