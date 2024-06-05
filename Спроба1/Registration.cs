using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Спроба1
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegistration_client_Click(object sender, EventArgs e)
        {
            string login_client = txt_login_client.Text;
            string password_client = txt_password_client.Text;
            string name_client = txt_name_client.Text;
            string surname_client = txt_surname_client.Text;
            string phone_number = txt_phone_client.Text;
           // Перевірка заповнення всіх полів
           if (string.IsNullOrWhiteSpace(login_client) ||
                string.IsNullOrWhiteSpace(password_client) ||
                string.IsNullOrWhiteSpace(name_client) ||
                string.IsNullOrWhiteSpace(surname_client) ||
                string.IsNullOrWhiteSpace(phone_number))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля!");
                return;
            }
            // перевірка довжини пароля
            if (password_client.Length < 8)
            {
                MessageBox.Show("Довжина паролю має бути не менше 8 символів!");
                return;
            }
            //перевірка формату номера телефону
            Regex phoneRegex = new Regex(@"^\d{3} \d{3} \d{4}$");
            if (!phoneRegex.IsMatch(phone_number))
            {
                MessageBox.Show("Формат номеру телефону введено неправильно! Спробуйте ще раз!");
                return;
            }
            //Перевірка формату логіна
            Regex loginRegex = new Regex(@"^[a-zA-Z0-9_]+$");
            if (!loginRegex.IsMatch(login_client))
            {
                MessageBox.Show("Логін має містити лише англійські букви та цифри!");
                return;
            }
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                // Перевірка логіна
                string checkLoginQuery = "SELECT COUNT(*) FROM client WHERE login_client = @login_client";
                MySqlCommand cmd = new MySqlCommand(checkLoginQuery, conn);
                cmd.Parameters.AddWithValue("@login_client", login_client);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Не можна зареєструватись, бо такий логін вже існує!");
                    return;
                }
                // Реєстрація
                string insertQuery = "INSERT INTO client (login_client, password_client, name_client, surname_client, phone_number) " +
                                     "VALUES (@login_client, @password_client, @name_client, @surname_client, @phone_number)";
                cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@login_client", login_client);
                cmd.Parameters.AddWithValue("@password_client", password_client);
                cmd.Parameters.AddWithValue("@name_client", name_client);
                cmd.Parameters.AddWithValue("@surname_client", surname_client);
                cmd.Parameters.AddWithValue("@phone_number", phone_number);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Вітаємо! Реєстрація пройшла успішно!");
                // очистка полів 
                txt_login_client.Text = string.Empty;
                txt_password_client.Text = string.Empty;
                txt_name_client.Text = string.Empty;
                txt_surname_client.Text = string.Empty;
                txt_phone_client.Text = string.Empty;
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

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void txt_login_client_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Close();
        }
    }
}
