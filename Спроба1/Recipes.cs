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
    public partial class Recipes : Form
    {
        public Recipes()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Close();
        }

        private void LoadRecipes()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string query = @"SELECT r.id_recipes, r.name_recipes, c.category_name, r.calories_recipes, r.cooking_instructions, r.image_recipes, 
							GROUP_CONCAT(p.name_products SEPARATOR ', ') AS sklad
							FROM recipes r
							LEFT JOIN products_and_recipes par ON r.id_recipes = par.id_recipes
							LEFT JOIN products p ON par.id_products = p.id_products
                            LEFT JOIN category c ON r.id_category = c.id_category
							GROUP BY r.id_recipes, r.name_recipes, c.category_name, r.calories_recipes, r.cooking_instructions, r.image_recipes;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Panel menuPanel = new Panel();
                menuPanel.AutoScroll = true; 
                menuPanel.Dock = DockStyle.Top; 
                menuPanel.Height = this.ClientSize.Height - 80;
                this.Controls.Add(menuPanel);

                int yPosition = 50;
                Font labelFont = new Font("Palatino Linotype", 12, FontStyle.Bold); 

                while (reader.Read())
                {
                    GroupBox groupBox = new GroupBox();
                    groupBox.Size = new Size(900, 300); 
                    groupBox.Location = new Point(30, yPosition); 
                    menuPanel.Controls.Add(groupBox);

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(270, 270); 
                    pictureBox.Location = new Point(10, 20);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    try
                    {
                        pictureBox.Image = Image.FromFile(reader["image_recipes"].ToString());
                    }
                    catch
                    {
                        pictureBox.Image = null; 
                    }

                    groupBox.Controls.Add(pictureBox);

                    Label nameLabel = new Label();
                    nameLabel.Text = "Назва: " + reader["name_recipes"].ToString();
                    nameLabel.Location = new Point(290, 20);
                    nameLabel.Font = labelFont;
                    nameLabel.AutoSize = true;
                    nameLabel.MaximumSize = new Size(600, 0); 
                    nameLabel.TextAlign = ContentAlignment.MiddleLeft;
                    groupBox.Controls.Add(nameLabel);

                    Label categoryLabel = new Label();
                    categoryLabel.Text = "Категорія: " + reader["category_name"].ToString();
                    categoryLabel.Location = new Point(290, 50);
                    categoryLabel.Font = labelFont;
                    categoryLabel.AutoSize = true;
                    categoryLabel.MaximumSize = new Size(600, 0); 
                    categoryLabel.TextAlign = ContentAlignment.MiddleLeft;
                    groupBox.Controls.Add(categoryLabel);

                    Label caloriesLabel = new Label();
                    caloriesLabel.Text = "Калорії: " + reader["calories_recipes"].ToString();
                    caloriesLabel.Location = new Point(290, 80);
                    caloriesLabel.Font = labelFont;
                    caloriesLabel.AutoSize = true;
                    caloriesLabel.MaximumSize = new Size(600, 0); 
                    caloriesLabel.TextAlign = ContentAlignment.MiddleLeft;
                    groupBox.Controls.Add(caloriesLabel);

                    Label skladLabel = new Label();
                    skladLabel.Text = "Склад: " + reader["sklad"].ToString();
                    skladLabel.Location = new Point(290, 110);
                    skladLabel.Font = labelFont;
                    skladLabel.AutoSize = true;
                    skladLabel.MaximumSize = new Size(600, 0); 
                    skladLabel.TextAlign = ContentAlignment.MiddleLeft;
                    groupBox.Controls.Add(skladLabel);

                    Label instructionLabel = new Label();
                    instructionLabel.Text = "Інструкція з приготування:" + reader["cooking_instructions"].ToString();
                    instructionLabel.Location = new Point(290, 140);
                    instructionLabel.Font = labelFont;
                    instructionLabel.AutoSize = true;
                    instructionLabel.MaximumSize = new Size(600, 0); 
                    instructionLabel.TextAlign = ContentAlignment.MiddleLeft;
                    groupBox.Controls.Add(instructionLabel);

                    yPosition += 310; 
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

        private void Recipes_Load(object sender, EventArgs e)
        {

        }
    }
}
