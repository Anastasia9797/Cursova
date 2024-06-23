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

namespace Спроба1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            LoadMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Close();

        }
        private void LoadMenu()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = @"SELECT m.id_menu, m.name_menu, c.category_name, m.price_menu, m.calories_menu, m.image_menu, 
                                 GROUP_CONCAT(p.name_products SEPARATOR ', ') AS sklad
                                 FROM menu m
                                 LEFT JOIN menu_and_products mp ON m.id_menu = mp.id_menu
                                 LEFT JOIN products p ON mp.id_products = p.id_products
                                 LEFT JOIN category c ON m.id_category = c.id_category
                                 GROUP BY m.id_menu, m.name_menu, c.category_name, m.price_menu, m.calories_menu, m.image_menu";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Panel menuPanel = new Panel();
                menuPanel.AutoScroll = true; // Дозволити прокрутку
                menuPanel.Dock = DockStyle.Top; // Закріпити зверху
                menuPanel.Height = this.ClientSize.Height - 80; // Висота панелі, щоб залишити місце для кнопки виходу з форми
                this.Controls.Add(menuPanel);

                int yPosition = 50; // початкова позиція по вертикалі для кожного елемента
                Font labelFont = new Font("Palatino Linotype", 12, FontStyle.Bold); // шрифт

                while (reader.Read())
                {
                    GroupBox groupBox = new GroupBox();
                    groupBox.Size = new Size(600, 260);
                    groupBox.Location = new Point(30, yPosition);
                    menuPanel.Controls.Add(groupBox);

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(230, 230); // розмір картинки
                    pictureBox.Location = new Point(10, 20);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    try
                    {
                        pictureBox.Image = Image.FromFile(reader["image_menu"].ToString());
                    }
                    catch
                    {
                        pictureBox.Image = null; // зображення за замовчуванням, якщо файл не знайдено
                    }

                    groupBox.Controls.Add(pictureBox);

                    Label nameLabel = new Label();
                    nameLabel.Text = "Назва: " + reader["name_menu"].ToString();
                    nameLabel.Location = new Point(240, 20);
                    nameLabel.Font = labelFont;
                    nameLabel.AutoSize = true;
                    nameLabel.MaximumSize = new Size(350, 0);
                    nameLabel.TextAlign = ContentAlignment.MiddleLeft;
                    groupBox.Controls.Add(nameLabel);

                    Label categoryLabel = new Label();
                    categoryLabel.Text = "Категорія: " + reader["category_name"].ToString();
                    categoryLabel.Location = new Point(240, 50);
                    categoryLabel.Font = labelFont;
                    categoryLabel.AutoSize = true;
                    categoryLabel.MaximumSize = new Size(350, 0);
                    categoryLabel.TextAlign = ContentAlignment.MiddleLeft;
                    groupBox.Controls.Add(categoryLabel);

                    Label caloriesLabel = new Label();
                    caloriesLabel.Text = "Калорії: " + reader["calories_menu"].ToString();
                    caloriesLabel.Location = new Point(240, 110);
                    caloriesLabel.Font = labelFont;
                    caloriesLabel.AutoSize = true;
                    caloriesLabel.MaximumSize = new Size(350, 0);
                    caloriesLabel.TextAlign = ContentAlignment.MiddleLeft;
                    groupBox.Controls.Add(caloriesLabel);

                    Label skladLabel = new Label();
                    skladLabel.Text = "Склад: " + reader["sklad"].ToString();
                    skladLabel.Location = new Point(240, 140);
                    skladLabel.Font = labelFont;
                    skladLabel.AutoSize = true;
                    skladLabel.MaximumSize = new Size(350, 0);
                    skladLabel.TextAlign = ContentAlignment.MiddleLeft;
                    groupBox.Controls.Add(skladLabel);

                    Label priceLabel = new Label();
                    priceLabel.Text = "Ціна: " + reader["price_menu"] + " грн".ToString();
                    priceLabel.Location = new Point(240, 80);
                    priceLabel.Font = labelFont;
                    priceLabel.AutoSize = true;
                    priceLabel.MaximumSize = new Size(350, 0);
                    priceLabel.TextAlign = ContentAlignment.MiddleLeft;
                    groupBox.Controls.Add(priceLabel);

                    yPosition += 270; // Збільшити позицію по вертикалі для наступного елемента
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

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
