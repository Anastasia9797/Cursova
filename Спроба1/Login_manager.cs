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
    public partial class Login_manager : Form
    {
        public Login_manager()
        {
            InitializeComponent();
            Product_list();
            Employee_list();
            LoadEmployeeData();
            LoadOrdersInAnticipationData();
            LoadOrdersCompletedData();
            LoadProducts();
            LoadRecipes();
            LoadMenu();
            //LoadProductsToListBox5();
            LoadProductsToListBox7();
        }

        // Заповнення списком продуктів
        private void Product_list()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT name_products FROM products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                comboBox_edit_pr.Items.Clear();
                comboBox_del_pr.Items.Clear();
                while (reader.Read())
                {
                    string productName = reader.GetString("name_products");
                    comboBox_edit_pr.Items.Add(productName);
                    comboBox_del_pr.Items.Add(productName);
                }
                reader.Close();
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
        // Заповнення списком працівників
        private void Employee_list()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT login_employees FROM employees";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                comboBox_del_emp.Items.Clear();
                comboBox_edit_emp.Items.Clear();
                while (reader.Read())
                {
                    string employeeLogin = reader.GetString("login_employees");
                    comboBox_del_emp.Items.Add(employeeLogin);
                    comboBox_edit_emp.Items.Add(employeeLogin);
                }
                reader.Close();
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













        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Продукти
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Додавання продукту
        private void add_product_Click(object sender, EventArgs e)
        {
            string productName = txt_product.Text;
            string caliriesText = txt_calirie.Text;
            int caliries;

            // Перевіряємо заповнення всіх полів
            if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(caliriesText))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля!");
                return;
            }
            // Перевірка чи поле калорії має тип int
            if (!int.TryParse(caliriesText, out caliries))
            {
                MessageBox.Show("Для поля калорій треба вводити тільки числа!");
                return;
            }
            // Перевірка чи немає в полі продукт чисел
            if (Regex.IsMatch(productName, @"\d"))
            {
                MessageBox.Show("Назва продукту не має містити в собі числа!");
                return;
            }
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();

                // Перевірка чи існує такий продукт
                string checkProductQuery = "SELECT COUNT(*) FROM products WHERE name_products = @name";
                MySqlCommand checkCmd = new MySqlCommand(checkProductQuery, conn);
                checkCmd.Parameters.AddWithValue("@name", productName);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Продукт з такою назвою вже існує!");
                    return;
                }

                // Додаємо продукт до таблиці products
                string insertQuery = "INSERT INTO products (name_products, calories_products) VALUES (@name, @caliries)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@name", productName);
                cmd.Parameters.AddWithValue("@caliries", caliries);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Продукт було успішно додано!");
                // Очищаємо поля після цього
                txt_product.Clear();
                txt_calirie.Clear();
                Product_list();
                LoadProducts();
                LoadProductsToListBox5();
                LoadProductsToListBox7();
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
        //очистка полів
        private void clear_product_Click(object sender, EventArgs e)
        {
            txt_product.Clear();
            txt_calirie.Clear();
        }
        //перехід на головну з формування меню
        private void button1_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Close();
        }
        // перехід з рецептів
        private void button13_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Close();
        }
        // перехід з продуктів
        private void button3_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Close();
        }
        //перехід з працівників
        private void button25_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Close();
        }
        //перехід з моніторингу
        private void button23_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Close();
        }
        // зпоавнення списку продуктів (видалення)
        private void comboBox_del_pr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_del_pr.SelectedIndex != -1)
            {
                string selectedProduct = comboBox_del_pr.SelectedItem.ToString();
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM products WHERE name_products = @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", selectedProduct);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox6.Text = reader["id_products"].ToString();
                        textBox5.Text = reader["name_products"].ToString();
                        textBox2.Text = reader["calories_products"].ToString();
                    }
                    reader.Close();
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
        //очистити (видалення)
        private void btn_cancel_del_pr_Click(object sender, EventArgs e)
        {
            comboBox_del_pr.SelectedIndex = -1;
            textBox6.Clear();
            textBox5.Clear();
            textBox2.Clear();
        }
        //кнопка видалення продукту
        private void btn_del_pr_Click(object sender, EventArgs e)
        {
            // чи обраний продукт
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Будь ласка, оберіть продукт для видалення!");
                return;
            }

            string selectedProduct = textBox5.Text; // назва обраного продукту

            DialogResult result = MessageBox.Show("Чи дійсно ви хочете видалити цей продукт? Позиції меню та рецепти, до складу яких входить цей продукт, будуть також видалені.", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    // id продукту
                    string getProductIdQuery = "SELECT id_products FROM products WHERE name_products = @name";
                    MySqlCommand cmdGetProductId = new MySqlCommand(getProductIdQuery, conn);
                    cmdGetProductId.Parameters.AddWithValue("@name", selectedProduct);
                    object productIdResult = cmdGetProductId.ExecuteScalar();

                    if (productIdResult == null)
                    {
                        MessageBox.Show("Продукт не знайдено.");
                        return;
                    }

                    int productId = Convert.ToInt32(productIdResult);

                    // знаходимо всі id_menu, що містять цей продукт (для подальшого видалення з таблиці меню)
                    string getMenusQuery = "SELECT id_menu FROM menu_and_products WHERE id_products = @productId";
                    MySqlCommand cmdGetMenus = new MySqlCommand(getMenusQuery, conn);
                    cmdGetMenus.Parameters.AddWithValue("@productId", productId);
                    MySqlDataReader readerMenus = cmdGetMenus.ExecuteReader();
                    List<int> menuDel = new List<int>();
                    while (readerMenus.Read())
                    {
                        menuDel.Add(readerMenus.GetInt32("id_menu"));
                    }
                    readerMenus.Close();

                    // знаходимо всі id_recipes, що містять цей продукт (те саме, але з рецептами)
                    string getRecipesQuery = "SELECT id_recipes FROM products_and_recipes WHERE id_products = @productId";
                    MySqlCommand cmdGetRecipes = new MySqlCommand(getRecipesQuery, conn);
                    cmdGetRecipes.Parameters.AddWithValue("@productId", productId);
                    MySqlDataReader readerRecipes = cmdGetRecipes.ExecuteReader();
                    List<int> recipesDel = new List<int>();
                    while (readerRecipes.Read())
                    {
                        recipesDel.Add(readerRecipes.GetInt32("id_recipes"));
                    }
                    readerRecipes.Close();

                    // видалення id позиції з menu_and_products та products_and_recipes
                    string deleteFromMenuAndProductsQuery = "DELETE FROM menu_and_products WHERE id_products = @productId";
                    MySqlCommand cmdDeleteFromMenuAndProducts = new MySqlCommand(deleteFromMenuAndProductsQuery, conn);
                    cmdDeleteFromMenuAndProducts.Parameters.AddWithValue("@productId", productId);
                    cmdDeleteFromMenuAndProducts.ExecuteNonQuery();

                    string deleteFromProductsAndRecipesQuery = "DELETE FROM products_and_recipes WHERE id_products = @productId";
                    MySqlCommand cmdDeleteFromProductsAndRecipes = new MySqlCommand(deleteFromProductsAndRecipesQuery, conn);
                    cmdDeleteFromProductsAndRecipes.Parameters.AddWithValue("@productId", productId);
                    cmdDeleteFromProductsAndRecipes.ExecuteNonQuery();

                    //видалення відповідних позицій меню
                    foreach (int menuId in menuDel)
                    {
                        string deleteMenuQuery = "DELETE FROM menu WHERE id_menu = @menuId";
                        MySqlCommand cmdDeleteMenu = new MySqlCommand(deleteMenuQuery, conn);
                        cmdDeleteMenu.Parameters.AddWithValue("@menuId", menuId);
                        cmdDeleteMenu.ExecuteNonQuery();
                    }
                    //видалення рецептів
                    foreach (int recipeId in recipesDel)
                    {
                        string deleteRecipeQuery = "DELETE FROM recipes WHERE id_recipes = @recipeId";
                        MySqlCommand cmdDeleteRecipe = new MySqlCommand(deleteRecipeQuery, conn);
                        cmdDeleteRecipe.Parameters.AddWithValue("@recipeId", recipeId);
                        cmdDeleteRecipe.ExecuteNonQuery();
                    }
                    // видалити сам продукт
                    string deleteProductQuery = "DELETE FROM products WHERE id_products = @productId";
                    MySqlCommand cmdDeleteProduct = new MySqlCommand(deleteProductQuery, conn);
                    cmdDeleteProduct.Parameters.AddWithValue("@productId", productId);
                    int rowsAffected = cmdDeleteProduct.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Продукт було успішно видалено!");
                        comboBox_del_pr.SelectedIndex = -1;
                        textBox6.Clear();
                        textBox5.Clear();
                        textBox2.Clear();
                        Product_list();
                        LoadProducts();
                        LoadProductsToListBox5();
                        LoadProductsToListBox7();
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося видалити продукт.");
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
        //заповнення продуктами (редагування)
        private void comboBox_edit_pr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_edit_pr.SelectedIndex != -1)
            {
                string selectedProduct = comboBox_edit_pr.SelectedItem.ToString();
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM products WHERE name_products = @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", selectedProduct);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox8.Text = reader["id_products"].ToString();
                        textBox12.Text = reader["name_products"].ToString();
                        textBox11.Text = reader["calories_products"].ToString();
                    }
                    reader.Close();
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
        //редагувати продукт
        private void btn_edit_pr_Click(object sender, EventArgs e)
        {
            //чи заповнено всі поля
            if (string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(textBox12.Text) || string.IsNullOrWhiteSpace(textBox11.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля!");
                return;
            }
            //чи поле калорії має тип int
            if (!int.TryParse(textBox11.Text, out int caliries))
            {
                MessageBox.Show("Для поля калорій треба вводити тільки числа!");
                return;
            }
            //чи немає в полі назви продукту чисел
            if (Regex.IsMatch(textBox12.Text, @"\d"))
            {
                MessageBox.Show("Назва продукту не повинна містити чисел!");
                return;
            }
            int productId = int.Parse(textBox8.Text);
            string productName = textBox12.Text;

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string updateQuery = "UPDATE products SET name_products = @name, calories_products = @caliries WHERE id_products = @id";
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@name", productName);
                cmd.Parameters.AddWithValue("@caliries", caliries);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Продукт було успішно відредаговано!");
                comboBox_edit_pr.SelectedIndex = -1;
                textBox8.Clear();
                textBox12.Clear();
                textBox11.Clear();
                Product_list();
                LoadProducts();
                LoadProductsToListBox5();
                LoadProductsToListBox7();
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
        //очищаємо поля
        private void btn_cancel_ed_pr_Click(object sender, EventArgs e)
        {
            comboBox_edit_pr.SelectedIndex = -1;
            textBox8.Clear();
            textBox12.Clear();
            textBox11.Clear();
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Працівники
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //реєстрація працівника
        private void btnRegistration_employee_Click(object sender, EventArgs e)
        {
            string login_employee = txt_login_employee.Text;
            string password_employee = txt_password_employee.Text;
            string name_employee = txt_name_employee.Text;
            string surname_employee = txt_surname_employee.Text;
            string phone_number = txt_number_employee.Text;
            string position_type = comboBox1_employee.SelectedItem?.ToString();

            //перевірка заповнення всіх полів
            if (string.IsNullOrWhiteSpace(login_employee) ||
                string.IsNullOrWhiteSpace(password_employee) ||
                string.IsNullOrWhiteSpace(name_employee) ||
                string.IsNullOrWhiteSpace(surname_employee) ||
                string.IsNullOrWhiteSpace(phone_number) ||
                string.IsNullOrWhiteSpace(position_type))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля!");
                return;
            }

            //перевірка довжини пароля
            if (password_employee.Length < 8)
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

            //перевірка формату логіна
            Regex loginRegex = new Regex(@"^[a-zA-Z0-9_]+$");
            if (!loginRegex.IsMatch(login_employee))
            {
                MessageBox.Show("Логін має містити лише англійські букви та цифри!");
                return;
            }

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                //перевірка логіна
                string checkLoginQuery = "SELECT COUNT(*) FROM employees WHERE login_employees = @login_employee";
                MySqlCommand cmd = new MySqlCommand(checkLoginQuery, conn);
                cmd.Parameters.AddWithValue("@login_employee", login_employee);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Не можна зареєструватись, бо такий логін вже існує!");
                    return;
                }

                //отримуємо id позиції з таблиці position
                string getPositionIdQuery = "SELECT id_position FROM position WHERE position_type = @position_type";
                cmd = new MySqlCommand(getPositionIdQuery, conn);
                cmd.Parameters.AddWithValue("@position_type", position_type);
                int position_id = Convert.ToInt32(cmd.ExecuteScalar());

                //реєстрація
                string insertQuery = @"INSERT INTO employees (login_employees, password_employees, name_employees, surname_employees, phone_number, position_id_position) 
                                       VALUES (@login_employee, @password_employee, @name_employee, @surname_employee, @phone_number, @position_id)";
                cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@login_employee", login_employee);
                cmd.Parameters.AddWithValue("@password_employee", password_employee);
                cmd.Parameters.AddWithValue("@name_employee", name_employee);
                cmd.Parameters.AddWithValue("@surname_employee", surname_employee);
                cmd.Parameters.AddWithValue("@phone_number", phone_number);
                cmd.Parameters.AddWithValue("@position_id", position_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Вітаємо! Реєстрація пройшла успішно!");
                // очищення полів
                txt_login_employee.Text = string.Empty;
                txt_password_employee.Text = string.Empty;
                txt_name_employee.Text = string.Empty;
                txt_surname_employee.Text = string.Empty;
                txt_number_employee.Text = string.Empty;
                comboBox1_employee.SelectedIndex = -1;
                Employee_list();
                LoadEmployeeData();
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
        // список працівників (видалення)
        private void comboBox_del_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_del_emp.SelectedIndex != -1)
            {
                string selectedEmployee = comboBox_del_emp.SelectedItem.ToString();
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    string query = @"SELECT e.id_employees, e.login_employees, e.password_employees, e.name_employees, e.surname_employees, e.phone_number, p.position_type 
                                    FROM employees e 
                                    INNER JOIN position p ON e.position_id_position = p.id_position 
                                    WHERE e.login_employees = @login";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@login", selectedEmployee);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        id_del_emp.Text = reader["id_employees"].ToString();
                        log_del_emp.Text = reader["login_employees"].ToString();
                        pswrd_del_emp.Text = reader["password_employees"].ToString();
                        name_del_emp.Text = reader["name_employees"].ToString();
                        surname_del_emp.Text = reader["surname_employees"].ToString();
                        phone_del_emp.Text = reader["phone_number"].ToString();
                        position_del_emp.Text = reader["position_type"].ToString();
                    }
                    reader.Close();
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
        //очищення полів(видалення)
        private void not_del_emp_Click(object sender, EventArgs e)
        {
            comboBox_del_emp.SelectedIndex = -1;
            id_del_emp.Clear();
            log_del_emp.Clear();
            pswrd_del_emp.Clear();
            name_del_emp.Clear();
            surname_del_emp.Clear();
            phone_del_emp.Clear();
            position_del_emp.Clear();
        }
        //Кнопка видалення працівника
        private void del_emp_Click(object sender, EventArgs e)
        {
            // перевірка чи обраний працівник
            if (string.IsNullOrWhiteSpace(id_del_emp.Text))
            {
                MessageBox.Show("Будь ласка, оберіть працівника для видалення!");
                return;
            }
            string selectedEmployee = log_del_emp.Text;

            DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цього працівника?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    string delQuery = "DELETE FROM employees WHERE login_employees = @login";
                    MySqlCommand cmd = new MySqlCommand(delQuery, conn);
                    cmd.Parameters.AddWithValue("@login", selectedEmployee);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Працівника було успішно видалено!");
                        comboBox_del_emp.SelectedIndex = -1;
                        id_del_emp.Clear();
                        log_del_emp.Clear();
                        pswrd_del_emp.Clear();
                        name_del_emp.Clear();
                        surname_del_emp.Clear();
                        phone_del_emp.Clear();
                        position_del_emp.Clear();
                        Employee_list();
                        LoadEmployeeData();
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося видалити працівника.");
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
        //список (редагування)
        private void comboBox_edit_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_edit_emp.SelectedIndex != -1)
            {
                string selectedEmployee = comboBox_edit_emp.SelectedItem.ToString();
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    string query = @"SELECT e.id_employees, e.login_employees, e.password_employees, e.name_employees, e.surname_employees, e.phone_number, p.position_type 
                                    FROM employees e 
                                    INNER JOIN position p ON e.position_id_position = p.id_position 
                                    WHERE e.login_employees = @login";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@login", selectedEmployee);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        id_ed_emp.Text = reader["id_employees"].ToString();
                        login_ed_emp.Text = reader["login_employees"].ToString();
                        pswrd_ed_emp.Text = reader["password_employees"].ToString();
                        name_ed_emp.Text = reader["name_employees"].ToString();
                        surname_ed_emp.Text = reader["surname_employees"].ToString();
                        phone_ed_emp.Text = reader["phone_number"].ToString();
                        comboBox_e_emp.SelectedItem = reader["position_type"].ToString();
                    }
                    reader.Close();
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
        //редагувати 
        private void edit_emp_Click(object sender, EventArgs e)
        {
            // перевірка чи заповнено всі поля
            if (string.IsNullOrWhiteSpace(id_ed_emp.Text) || string.IsNullOrWhiteSpace(login_ed_emp.Text) ||
                string.IsNullOrWhiteSpace(pswrd_ed_emp.Text) || string.IsNullOrWhiteSpace(name_ed_emp.Text) ||
                string.IsNullOrWhiteSpace(surname_ed_emp.Text) || string.IsNullOrWhiteSpace(phone_ed_emp.Text) ||
                comboBox_e_emp.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, заповніть всі поля!");
                return;
            }

            int employeeId = int.Parse(id_ed_emp.Text);
            string employeeLogin = login_ed_emp.Text;
            string employeePassword = pswrd_ed_emp.Text;
            string employeeName = name_ed_emp.Text;
            string employeeSurname = surname_ed_emp.Text;
            string employeePhone = phone_ed_emp.Text;
            string employeePosition = comboBox_e_emp.SelectedItem.ToString();

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();

                // Отримуємо id позиції з таблиці position
                string getPositionIdQuery = "SELECT id_position FROM position WHERE position_type = @position_type";
                MySqlCommand cmd = new MySqlCommand(getPositionIdQuery, conn);
                cmd.Parameters.AddWithValue("@position_type", employeePosition);
                int position_id = Convert.ToInt32(cmd.ExecuteScalar());

                string updateQuery = @"UPDATE employees SET login_employees = @login, password_employees = @password, 
                                       name_employees = @name, surname_employees = @surname, phone_number = @phone, position_id_position = @position_id WHERE id_employees = @id";
                cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@login", employeeLogin);
                cmd.Parameters.AddWithValue("@password", employeePassword);
                cmd.Parameters.AddWithValue("@name", employeeName);
                cmd.Parameters.AddWithValue("@surname", employeeSurname);
                cmd.Parameters.AddWithValue("@phone", employeePhone);
                cmd.Parameters.AddWithValue("@position_id", position_id);
                cmd.Parameters.AddWithValue("@id", employeeId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Інформацію про працівника було успішно відредаговано!");
                comboBox_edit_emp.SelectedIndex = -1;
                id_ed_emp.Clear();
                login_ed_emp.Clear();
                pswrd_ed_emp.Clear();
                name_ed_emp.Clear();
                surname_ed_emp.Clear();
                phone_ed_emp.Clear();
                comboBox_e_emp.SelectedIndex = -1;
                Employee_list();
                LoadEmployeeData();
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
        private void not_edit_emp_Click(object sender, EventArgs e)
        {
            comboBox_edit_emp.SelectedIndex = -1;
            id_ed_emp.Clear();
            login_ed_emp.Clear();
            pswrd_ed_emp.Clear();
            name_ed_emp.Clear();
            surname_ed_emp.Clear();
            phone_ed_emp.Clear();
            comboBox_e_emp.SelectedIndex = -1;
        }
        //вивід даних в таблицю
        private void LoadEmployeeData()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT e.id_employees AS `ID`, e.name_employees AS `Ім'я`, e.surname_employees AS `Прізвище`, " +
                               "e.login_employees AS `Логін`, e.password_employees AS `Пароль`, e.phone_number AS `Номер телефону`, " +
                               "p.position_type AS `Посада` " +
                               "FROM employees e " +
                               "JOIN position p ON e.position_id_position = p.id_position";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_info_emp.DataSource = table;

                dataGridView_info_emp.Columns["ID"].Width = 50;
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



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Моніторинг замовлень
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //вивід замовлень в очікуванні
        private void LoadOrdersInAnticipationData()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = @"SELECT o.id_orders_in_anticipation AS `ID Замовлення`, 
                                o.menu_id_menu AS `ID Меню`, 
                                m.name_menu AS `Назва страви`, 
                                cat.category_name AS `Категорія`, 
                                m.price_menu AS `Ціна`,
                                o.client_id_client AS `ID Клієнта`, 
                                cl.name_client AS `Ім'я`, 
                                cl.surname_client AS `Прізвище`, 
                                cl.login_client AS `Логін`, 
                                cl.phone_number AS `Телефон`, 
                                o.date_orders_in_anticipation AS `Дата замовлення`
                                FROM orders_in_anticipation o
                                INNER JOIN client cl ON o.client_id_client = cl.id_client
                                INNER JOIN menu m ON o.menu_id_menu = m.id_menu
                                LEFT JOIN category cat ON m.id_category = cat.id_category
                                ORDER BY o.id_orders_in_anticipation";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_in_anticipation.DataSource = table;
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
        //вивід замовлень виконаних
        private void LoadOrdersCompletedData()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = @"SELECT oc.id_orders_completed AS `ID Замовлення`, 
                                oc.menu_id_menu AS `ID Меню`, 
                                m.name_menu AS `Назва страви`, 
                                c.category_name AS `Категорія`, 
                                m.price_menu AS `Ціна`, 
                                m.calories_menu AS `Калорійність`,
                                oc.client_id_client AS `ID Клієнта`, 
                                cl.login_client AS `Логін клієнта`, 
                                cl.name_client AS `Ім'я клієнта`, 
                                cl.surname_client AS `Прізвище клієнта`, 
                                cl.phone_number AS `Телефон клієнта`, 
                                oc.id_employees AS `ID Офіціанта`,
                                e.login_employees AS `Логін офіціанта`, 
                                e.name_employees AS `Ім'я офіціанта`, 
                                e.surname_employees AS `Прізвище офіціанта`, 
                                e.phone_number AS `Телефон офіціанта`, 
                                oc.date_orders_in_anticipation AS `Дата замовлення`,
                                oc.date_order_complited AS `Дата виконання`
                                FROM orders_completed oc
                                INNER JOIN client cl ON oc.client_id_client = cl.id_client
                                INNER JOIN menu m ON oc.menu_id_menu = m.id_menu
                                LEFT JOIN category c ON m.id_category = c.id_category
                                INNER JOIN employees e ON oc.id_employees = e.id_employees
                                ORDER BY oc.id_orders_completed";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_completed.DataSource = table;
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

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }




        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Рецепти
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //завантаження продуктів
        private void LoadProducts()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT name_products FROM products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                listBox_1.Items.Clear();
                while (reader.Read())
                {
                    listBox_1.Items.Add(reader["name_products"].ToString());
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
        //розрахунок калорій
        private void CalculateCalories()
        {
            int totalCalories = 0;
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                foreach (var item in listBox_2.Items)
                {
                    string query = "SELECT calories_products FROM products WHERE name_products = @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", item.ToString());
                    totalCalories += Convert.ToInt32(cmd.ExecuteScalar());
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

            textBox_calories_r.Text = totalCalories.ToString();
        }
        //переміщення одного продукту між лістбоксами
        private void MoveSelectedItems(ListBox source, ListBox destination)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(source);
            selectedItems = source.SelectedItems;

            while (selectedItems.Count > 0)
            {
                destination.Items.Add(selectedItems[0]);
                source.Items.Remove(selectedItems[0]);
            }
        }
        //переміщення всіх продуктів
        private void MoveAllItems(ListBox source, ListBox destination)
        {
            destination.Items.AddRange(source.Items);
            source.Items.Clear();
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBox_1, listBox_2);
            CalculateCalories();
        }

        private void button_all_left_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBox_2, listBox_1);
            CalculateCalories();
        }

        private void button_left_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBox_2, listBox_1);
            CalculateCalories();
        }
        //додати рецепт
        private void btn_add_r_Click(object sender, EventArgs e)
        {
            string name = name_recipe.Text;
            string category_recipe = comboBox_category_recipe.SelectedItem?.ToString();
            string instructions = instruction_r.Text;
            string imagePath = text_imagine.Text;
            int calories = int.Parse(textBox_calories_r.Text);

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(category_recipe) ||
                string.IsNullOrWhiteSpace(instructions) ||
                string.IsNullOrWhiteSpace(imagePath) ||
                listBox_2.Items.Count == 0)
            {
                MessageBox.Show("Будь ласка, заповніть всі поля та додайте інгредієнти!");
                return;
            }

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                //беремо id категорії
                string getCategoryIDQuery = "SELECT id_category FROM category WHERE category_name = @category_name";
                MySqlCommand getCategoryIDCmd = new MySqlCommand(getCategoryIDQuery, conn);
                getCategoryIDCmd.Parameters.AddWithValue("@category_name", category_recipe);
                int categoryId = Convert.ToInt32(getCategoryIDCmd.ExecuteScalar());

                //чи існує такий рецепт
                string checkRecipeQuery = "SELECT COUNT(*) FROM recipes WHERE name_recipes = @name";
                MySqlCommand checkCmd = new MySqlCommand(checkRecipeQuery, conn);
                checkCmd.Parameters.AddWithValue("@name", name);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Рецепт з такою назвою вже існує!");
                    return;
                }
                // додавання рецепта
                string insertRecipeQuery = "INSERT INTO recipes (name_recipes, cooking_instructions, calories_recipes, image_recipes, id_category) " +
                                   "VALUES (@name, @instructions, @calories, @image, @categoryId)";
                MySqlCommand cmd = new MySqlCommand(insertRecipeQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@instructions", instructions);
                cmd.Parameters.AddWithValue("@calories", calories);
                cmd.Parameters.AddWithValue("@image", imagePath);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.ExecuteNonQuery();

                int recipeId = (int)cmd.LastInsertedId;
                // додавання складників до таблиці products_and_recipes
                foreach (var item in listBox_2.Items)
                {
                    //отримання id продукту за його назвою
                    string getProductIdQuery = "SELECT id_products FROM products WHERE name_products = @name";
                    MySqlCommand getProductIdCmd = new MySqlCommand(getProductIdQuery, conn);
                    getProductIdCmd.Parameters.AddWithValue("@name", item.ToString());
                    int productId = (int)getProductIdCmd.ExecuteScalar();

                    string insertIngredientQuery = "INSERT INTO products_and_recipes (id_products, id_recipes) VALUES (@productId, @recipeId)";
                    MySqlCommand insertIngredientCmd = new MySqlCommand(insertIngredientQuery, conn);
                    insertIngredientCmd.Parameters.AddWithValue("@productId", productId);
                    insertIngredientCmd.Parameters.AddWithValue("@recipeId", recipeId);
                    insertIngredientCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Рецепт успішно додано!");
                name_recipe.Text = string.Empty;
                comboBox_category_recipe.SelectedIndex = -1;
                instruction_r.Text = string.Empty;
                text_imagine.Text = string.Empty;
                textBox_calories_r.Text = string.Empty;
                listBox_2.Items.Clear();
                LoadProducts();
                LoadRecipes();
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
        //очистити
        private void btn_add_r_clear_Click(object sender, EventArgs e)
        {
            name_recipe.Text = string.Empty;
            comboBox_category_recipe.SelectedIndex = -1;
            instruction_r.Text = string.Empty;
            text_imagine.Text = string.Empty;
            textBox_calories_r.Text = string.Empty;
            listBox_2.Items.Clear();
            LoadProducts();
        }
        //виюрати зображення
        private void btn_imagine_r_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                text_imagine.Text = ofd.FileName;
            }
        }
        //список рецептів (видалення)
        private void comboBox_de_r_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_de_r.SelectedIndex != -1)
            {
                string selectedRecipe = comboBox_de_r.SelectedItem.ToString();
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM recipes WHERE name_recipes = @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", selectedRecipe);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        id_r.Text = reader["id_recipes"].ToString();
                        name_de_r.Text = reader["name_recipes"].ToString();
                        textBox_calories_de_r.Text = reader["calories_recipes"].ToString();
                        instruction_de_r.Text = reader["cooking_instructions"].ToString();
                        imagine_de_r.Text = reader["image_recipes"].ToString();
                        int categoryId = Convert.ToInt32(reader["id_category"]);
                        reader.Close();

                        // отримання назви категорії
                        query = "SELECT category_name FROM category WHERE id_category = @id_category";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_category", categoryId);
                        string categoryName = cmd.ExecuteScalar().ToString();
                        comboBox_cat_de_r.SelectedItem = categoryName;
                    }
                    reader.Close();
                    // вивід продуктів, які входять до складу рецепту
                    listBox4.Items.Clear();
                    string recipeId = id_r.Text;
                    query = "SELECT p.name_products FROM products p " +
                            "JOIN products_and_recipes pr ON p.id_products = pr.id_products " +
                            "WHERE pr.id_recipes = @recipeId";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox4.Items.Add(reader["name_products"].ToString());
                    }
                    reader.Close();
                    LoadProductsToListBox3();
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

        // завантаження всіх продуктів для формування складу
        private void LoadProductsToListBox3()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT name_products FROM products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                listBox3.Items.Clear();
                while (reader.Read())
                {
                    string productName = reader["name_products"].ToString();
                    if (!listBox4.Items.Contains(productName))
                    {
                        listBox3.Items.Add(productName);
                    }
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

        //редагування рецепта
        private void btn_edit_r_Click(object sender, EventArgs e)
        {
            int recipeId = int.Parse(id_r.Text);
            string name = name_de_r.Text;
            string category_recipe = comboBox_cat_de_r.SelectedItem?.ToString();
            string instructions = instruction_de_r.Text;
            string imagePath = imagine_de_r.Text;
            int calories = int.Parse(textBox_calories_de_r.Text);

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(category_recipe) ||
                string.IsNullOrWhiteSpace(instructions) ||
                string.IsNullOrWhiteSpace(imagePath) ||
                listBox4.Items.Count == 0)
            {
                MessageBox.Show("Будь ласка, заповніть всі поля та додайте інгредієнти!");
                return;
            }

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();

                //отримання id категорії
                string getCategoryIDQuery = "SELECT id_category FROM category WHERE category_name = @category_name";
                MySqlCommand getCategoryIDCmd = new MySqlCommand(getCategoryIDQuery, conn);
                getCategoryIDCmd.Parameters.AddWithValue("@category_name", category_recipe);
                int categoryId = Convert.ToInt32(getCategoryIDCmd.ExecuteScalar());

                //оновлення рецепту
                string updateRecipeQuery = "UPDATE recipes SET name_recipes = @name, id_category = @category, " +
                                           "cooking_instructions = @instructions, calories_recipes = @calories, image_recipes = @image " +
                                           "WHERE id_recipes = @recipeId";
                MySqlCommand cmd = new MySqlCommand(updateRecipeQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@category", categoryId);
                cmd.Parameters.AddWithValue("@instructions", instructions);
                cmd.Parameters.AddWithValue("@calories", calories);
                cmd.Parameters.AddWithValue("@image", imagePath);
                cmd.Parameters.AddWithValue("@recipeId", recipeId);
                cmd.ExecuteNonQuery();

                // видалення старих складників рецепту
                string deleteIngredientsQuery = "DELETE FROM products_and_recipes WHERE id_recipes = @recipeId";
                cmd = new MySqlCommand(deleteIngredientsQuery, conn);
                cmd.Parameters.AddWithValue("@recipeId", recipeId);
                cmd.ExecuteNonQuery();

                // додавання нових складників до таблиці products_and_recipes
                foreach (var item in listBox4.Items)
                {
                    string getProductIdQuery = "SELECT id_products FROM products WHERE name_products = @name";
                    MySqlCommand getProductIdCmd = new MySqlCommand(getProductIdQuery, conn);
                    getProductIdCmd.Parameters.AddWithValue("@name", item.ToString());
                    int productId = (int)getProductIdCmd.ExecuteScalar();

                    string insertIngredientQuery = "INSERT INTO products_and_recipes (id_products, id_recipes) VALUES (@productId, @recipeId)";
                    MySqlCommand insertIngredientCmd = new MySqlCommand(insertIngredientQuery, conn);
                    insertIngredientCmd.Parameters.AddWithValue("@productId", productId);
                    insertIngredientCmd.Parameters.AddWithValue("@recipeId", recipeId);
                    insertIngredientCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Зміни успішно збережено!");
                comboBox_de_r.SelectedIndex = -1;
                id_r.Text = string.Empty;
                name_de_r.Text = string.Empty;
                comboBox_cat_de_r.SelectedIndex = -1;
                textBox_calories_de_r.Text = string.Empty;
                instruction_de_r.Text = string.Empty;
                imagine_de_r.Text = string.Empty;
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                LoadRecipes();

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
        //видалення рецепту
        private void btn_del_r_Click(object sender, EventArgs e)
        {
            int recipeId = int.Parse(id_r.Text);

            DialogResult result = MessageBox.Show("Чи дійсно ви хочете видалити цей рецепт?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();

                    //видалення рецептів зі зв'язуючої таблиці
                    string deleteIngredientsQuery = "DELETE FROM products_and_recipes WHERE id_recipes = @recipeId";
                    MySqlCommand cmd = new MySqlCommand(deleteIngredientsQuery, conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    cmd.ExecuteNonQuery();

                    // видалення рецепта
                    string deleteRecipeQuery = "DELETE FROM recipes WHERE id_recipes = @recipeId";
                    cmd = new MySqlCommand(deleteRecipeQuery, conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Рецепт успішно видалено!");
                    comboBox_de_r.SelectedIndex = -1;
                    id_r.Text = string.Empty;
                    name_de_r.Text = string.Empty;
                    comboBox_cat_de_r.SelectedIndex = -1;
                    textBox_calories_de_r.Text = string.Empty;
                    instruction_de_r.Text = string.Empty;
                    imagine_de_r.Text = string.Empty;
                    listBox3.Items.Clear();
                    listBox4.Items.Clear();
                    LoadRecipes();
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
        //очистити
        private void btn_no_de_r_Click(object sender, EventArgs e)
        {
            id_r.Text = string.Empty;
            name_de_r.Text = string.Empty;
            comboBox_cat_de_r.SelectedIndex = -1;
            textBox_calories_de_r.Text = string.Empty;
            instruction_de_r.Text = string.Empty;
            imagine_de_r.Text = string.Empty;
            comboBox_de_r.SelectedIndex= -1;
            listBox4.Items.Clear();
            listBox3.Items.Clear();
        }

        private void button_de_right_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBox3, listBox4);
            CalculateCaloriesForListBox4();
        }

        private void button_de_all_left_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBox4, listBox3);
            CalculateCaloriesForListBox4();
        }

        private void button_de_left_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBox4, listBox3);
            CalculateCaloriesForListBox4();
        }
        //рахуємо калорії для рецептів в полі видалення/редагування
        private void CalculateCaloriesForListBox4()
        {
            int totalCalories = 0;
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                foreach (var item in listBox4.Items)
                {
                    string query = "SELECT calories_products FROM products WHERE name_products = @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", item.ToString());
                    totalCalories += Convert.ToInt32(cmd.ExecuteScalar());
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

            textBox_calories_de_r.Text = totalCalories.ToString();
        }
        //завантження рецептів
        private void LoadRecipes()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT name_recipes FROM recipes";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                comboBox_de_r.Items.Clear();
                while (reader.Read())
                {
                    comboBox_de_r.Items.Add(reader["name_recipes"].ToString());
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











































        










        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Меню
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //рахуємо калорії
        private void CalculateCalories8()
        {
            int totalCalories = 0;
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                foreach (var item in listBox8.Items)
                {
                    string query = "SELECT calories_products FROM products WHERE name_products = @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", item.ToString());
                    totalCalories += Convert.ToInt32(cmd.ExecuteScalar());
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

            calories_menu.Text = totalCalories.ToString();
        }

        private void button_right_menu_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBox7, listBox8);
            CalculateCalories8();
        }

        private void button_all_left_menu_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBox8, listBox7);
            CalculateCalories8();
        }

        private void button_left_menu_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBox8, listBox7);
            CalculateCalories8();
        }

        //кнопка дадати позицію до меню
        private void btn_add_menu_Click(object sender, EventArgs e)
        {
            string name = name_menu.Text;
            string category = comboBox_cat_menu.SelectedItem?.ToString();
            string image = image_menu.Text;
            int calories = int.Parse(calories_menu.Text);
            decimal price = decimal.Parse(price_menu.Text);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(image) || listBox8.Items.Count == 0)
            {
                MessageBox.Show("Будь ласка, заповніть всі поля та додайте інгредієнти!");
                return;
            }

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();

                // перевірка чи існує продукт з такою ж назвою
                string checkProductQuery = "SELECT COUNT(*) FROM menu WHERE name_menu = @name";
                MySqlCommand checkProductCmd = new MySqlCommand(checkProductQuery, conn);
                checkProductCmd.Parameters.AddWithValue("@name", name);
                int count = Convert.ToInt32(checkProductCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Страва/напій з такою назвою вже існує!");
                    return;
                }

                // отримання id категорії
                string getCategoryIdQuery = "SELECT id_category FROM category WHERE category_name = @category_name";
                MySqlCommand getCategoryIdCmd = new MySqlCommand(getCategoryIdQuery, conn);
                getCategoryIdCmd.Parameters.AddWithValue("@category_name", category);
                int categoryId = Convert.ToInt32(getCategoryIdCmd.ExecuteScalar());

                string insertMenuQuery = "INSERT INTO menu (name_menu, price_menu, calories_menu, image_menu, id_category) VALUES (@name, @price, @calories, @image, @categoryId)";
                MySqlCommand cmd = new MySqlCommand(insertMenuQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@calories", calories);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.ExecuteNonQuery();

                int menuId = (int)cmd.LastInsertedId;

                foreach (var item in listBox8.Items)
                {
                    string getProductIdQuery = "SELECT id_products FROM products WHERE name_products = @name";
                    MySqlCommand getProductIdCmd = new MySqlCommand(getProductIdQuery, conn);
                    getProductIdCmd.Parameters.AddWithValue("@name", item.ToString());
                    int productId = (int)getProductIdCmd.ExecuteScalar();

                    string insertMenuAndProductsQuery = "INSERT INTO menu_and_products (id_menu, id_products) VALUES (@menuId, @productId)";
                    MySqlCommand insertMenuAndProductsCmd = new MySqlCommand(insertMenuAndProductsQuery, conn);
                    insertMenuAndProductsCmd.Parameters.AddWithValue("@menuId", menuId);
                    insertMenuAndProductsCmd.Parameters.AddWithValue("@productId", productId);
                    insertMenuAndProductsCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Позицію меню успішно додано!");
                name_menu.Text = string.Empty;
                comboBox_cat_menu.SelectedIndex = -1;
                image_menu.Text = string.Empty;
                calories_menu.Text = string.Empty;
                price_menu.Text = string.Empty;
                listBox8.Items.Clear();
                LoadProductsToListBox7();
                LoadMenu();
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
        //список назв позицій меню в combobox
        private void LoadMenu()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT name_menu FROM menu";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                comboBox_de_menu.Items.Clear();
                while (reader.Read())
                {
                    comboBox_de_menu.Items.Add(reader["name_menu"].ToString());
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
        //очистити
        private void btn_clean_menu_Click(object sender, EventArgs e)
        {
            name_menu.Text = string.Empty;
            comboBox_cat_menu.SelectedIndex = -1;
            image_menu.Text = string.Empty;
            calories_menu.Text = string.Empty;
            price_menu.Text = string.Empty;
            listBox8.Items.Clear();
            LoadProductsToListBox7();
        }
        //обрати зображення
        private void button_image_menu_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image_menu.Text = ofd.FileName;
            }
        }
        //завантаження продуктів
        private void LoadProductsToListBox7()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT name_products FROM products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                listBox7.Items.Clear();
                while (reader.Read())
                {
                    string productName = reader["name_products"].ToString();
                    if (!listBox8.Items.Contains(productName))
                    {
                        listBox7.Items.Add(productName);
                    }
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

        //завантаження меню 
        private void comboBox_de_menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_de_menu.SelectedIndex != -1)
            {
                string selectedMenu = comboBox_de_menu.SelectedItem.ToString();
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    string query = "SELECT m.*, c.category_name FROM menu m " +
                                   "INNER JOIN category c ON m.id_category = c.id_category " +
                                   "WHERE m.name_menu = @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", selectedMenu);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        id_de_menu.Text = reader["id_menu"].ToString();
                        name_de_menu.Text = reader["name_menu"].ToString();
                        comboBox_cat_de_menu.SelectedItem = reader["category_name"].ToString();
                        calories_de_menu.Text = reader["calories_menu"].ToString();
                        price_de_menu.Text = reader["price_menu"].ToString();
                        image_de_menu.Text = reader["image_menu"].ToString();
                    }
                    reader.Close();

                    //завантаження продуктів, які входять до складу меню
                    listBox6.Items.Clear();
                    string menuId = id_de_menu.Text;
                    query = "SELECT p.name_products FROM products p " +
                            "JOIN menu_and_products mp ON p.id_products = mp.id_products " +
                            "WHERE mp.id_menu = @menuId";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@menuId", menuId);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox6.Items.Add(reader["name_products"].ToString());
                    }
                    reader.Close();

                    //завантаження всіх продуктів для формування складу
                    LoadProductsToListBox5();
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
        //редагувати позицію меню
        private void edit_menu_Click(object sender, EventArgs e)
        {
            int menuId = int.Parse(id_de_menu.Text);
            string name = name_de_menu.Text;
            string category = comboBox_cat_de_menu.SelectedItem?.ToString();
            string imagePath = image_de_menu.Text;
            int calories = int.Parse(calories_de_menu.Text);
            decimal price = decimal.Parse(price_de_menu.Text);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(imagePath) || listBox6.Items.Count == 0)
            {
                MessageBox.Show("Будь ласка, заповніть всі поля та додайте інгредієнти!");
                return;
            }

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                // отримання id категорії
                string getCategoryIdQuery = "SELECT id_category FROM category WHERE category_name = @category_name";
                MySqlCommand getCategoryIdCmd = new MySqlCommand(getCategoryIdQuery, conn);
                getCategoryIdCmd.Parameters.AddWithValue("@category_name", category);
                int categoryId = Convert.ToInt32(getCategoryIdCmd.ExecuteScalar());

                // оновлення позиції меню
                string updateMenuQuery = "UPDATE menu SET name_menu = @name, id_category = @categoryId, price_menu = @price, calories_menu = @calories, image_menu = @image " +
                                 "WHERE id_menu = @menuId";
                MySqlCommand cmd = new MySqlCommand(updateMenuQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@calories", calories);
                cmd.Parameters.AddWithValue("@image", imagePath);
                cmd.Parameters.AddWithValue("@menuId", menuId);
                cmd.ExecuteNonQuery();

                // видалення старих продуктів з меню
                string deleteIngredientsQuery = "DELETE FROM menu_and_products WHERE id_menu = @menuId";
                cmd = new MySqlCommand(deleteIngredientsQuery, conn);
                cmd.Parameters.AddWithValue("@menuId", menuId);
                cmd.ExecuteNonQuery();

                // додавання нових продуктів до меню
                foreach (var item in listBox6.Items)
                {
                    string getProductIdQuery = "SELECT id_products FROM products WHERE name_products = @name";
                    MySqlCommand getProductIdCmd = new MySqlCommand(getProductIdQuery, conn);
                    getProductIdCmd.Parameters.AddWithValue("@name", item.ToString());
                    int productId = (int)getProductIdCmd.ExecuteScalar();

                    string insertIngredientQuery = "INSERT INTO menu_and_products (id_menu, id_products) VALUES (@menuId, @productId)";
                    MySqlCommand insertIngredientCmd = new MySqlCommand(insertIngredientQuery, conn);
                    insertIngredientCmd.Parameters.AddWithValue("@menuId", menuId);
                    insertIngredientCmd.Parameters.AddWithValue("@productId", productId);
                    insertIngredientCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Страву/напій було успішно оновлено!");
                comboBox_de_menu.SelectedIndex = -1;
                id_de_menu.Text = string.Empty;
                name_de_menu.Text = string.Empty;
                comboBox_cat_de_menu.SelectedIndex = -1;
                price_de_menu.Text = string.Empty;
                calories_de_menu.Text = string.Empty;
                image_de_menu.Text = string.Empty;
                listBox5.Items.Clear();
                listBox6.Items.Clear();
                LoadMenu();
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
        //видалити позицію
        private void del_menu_Click(object sender, EventArgs e)
        {
            int menuId = int.Parse(id_de_menu.Text);
            DialogResult result = MessageBox.Show("Чи дійсно ви хочете видалити цю позицію з меню?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();

                    // Видалення продуктів, що входять до складу меню
                    string deleteIngredientsQuery = "DELETE FROM menu_and_products WHERE id_menu = @menuId";
                    MySqlCommand cmd = new MySqlCommand(deleteIngredientsQuery, conn);
                    cmd.Parameters.AddWithValue("@menuId", menuId);
                    cmd.ExecuteNonQuery();

                    // Видалення самого меню
                    string deleteMenuQuery = "DELETE FROM menu WHERE id_menu = @menuId";
                    cmd = new MySqlCommand(deleteMenuQuery, conn);
                    cmd.Parameters.AddWithValue("@menuId", menuId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Страву/напій успішно видалено з меню!");
                    comboBox_de_menu.SelectedIndex = -1;
                    id_de_menu.Text = string.Empty;
                    name_de_menu.Text = string.Empty;
                    comboBox_cat_de_menu.SelectedIndex = -1;
                    price_de_menu.Text = string.Empty;
                    calories_de_menu.Text = string.Empty;
                    image_de_menu.Text = string.Empty;
                    listBox5.Items.Clear();
                    listBox6.Items.Clear();
                    LoadMenu();
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
        //очистити
        private void clean_de_menu_Click(object sender, EventArgs e)
        {
            id_de_menu.Text = string.Empty;
            name_de_menu.Text = string.Empty;
            comboBox_cat_de_menu.SelectedIndex = -1;
            image_de_menu.Text = string.Empty;
            calories_de_menu.Text = string.Empty;
            price_de_menu.Text = string.Empty;
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            comboBox_de_menu.SelectedIndex = -1;
            
        }

        private void button_de_right_menu_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBox5, listBox6);
            CalculateCaloriesForListBox6();
        }

        private void button_de_all_left_menu_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBox6, listBox5);
            CalculateCaloriesForListBox6();
        }

        private void button_de_left_menu_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(listBox6, listBox5);
            CalculateCaloriesForListBox6();
        }

        // рахуємо калорії для меню в полі видалення/редагування
        private void CalculateCaloriesForListBox6()
        {
            int totalCalories = 0;
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                foreach (var item in listBox6.Items)
                {
                    string query = "SELECT calories_products FROM products WHERE name_products = @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", item.ToString());
                    totalCalories += Convert.ToInt32(cmd.ExecuteScalar());
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
            calories_de_menu.Text = totalCalories.ToString();
        }
        //вибір зображення
        private void btn_image_de_menu_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image_de_menu.Text = ofd.FileName;
            }
        }

        private void groupBox12_Enter_1(object sender, EventArgs e)
        {

        }
        //вивід продуктів
        private void LoadProductsToListBox5()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = "SELECT name_products FROM products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                listBox5.Items.Clear();
                while (reader.Read())
                {
                    string productName = reader["name_products"].ToString();
                    if (!listBox6.Items.Contains(productName))
                    {
                        listBox5.Items.Add(productName);
                    }
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

        private void dataGridView_in_anticipation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_completed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void calories_de_menu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}