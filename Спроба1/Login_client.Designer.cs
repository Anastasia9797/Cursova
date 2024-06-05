namespace Спроба1
{
    partial class Login_client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_order = new System.Windows.Forms.Button();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_calories = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ingridients = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_category = new System.Windows.Forms.TextBox();
            this.comboBox_client = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_clients_orders = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_order_delete = new System.Windows.Forms.Button();
            this.comboBox_order_delete = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_clients_orders)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_order);
            this.groupBox1.Controls.Add(this.textBox_price);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_calories);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_ingridients);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_category);
            this.groupBox1.Controls.Add(this.comboBox_client);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(399, 395);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Замовити страву/напій";
            // 
            // button_order
            // 
            this.button_order.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_order.Location = new System.Drawing.Point(6, 329);
            this.button_order.Name = "button_order";
            this.button_order.Size = new System.Drawing.Size(387, 53);
            this.button_order.TabIndex = 8;
            this.button_order.Text = "Замовити";
            this.button_order.UseVisualStyleBackColor = true;
            this.button_order.Click += new System.EventHandler(this.button_order_Click);
            // 
            // textBox_price
            // 
            this.textBox_price.Location = new System.Drawing.Point(79, 176);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.ReadOnly = true;
            this.textBox_price.Size = new System.Drawing.Size(314, 34);
            this.textBox_price.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ціна:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_calories
            // 
            this.textBox_calories.Location = new System.Drawing.Point(106, 230);
            this.textBox_calories.Name = "textBox_calories";
            this.textBox_calories.ReadOnly = true;
            this.textBox_calories.Size = new System.Drawing.Size(287, 34);
            this.textBox_calories.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Калорії:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ingridients
            // 
            this.textBox_ingridients.Location = new System.Drawing.Point(91, 280);
            this.textBox_ingridients.Multiline = true;
            this.textBox_ingridients.Name = "textBox_ingridients";
            this.textBox_ingridients.ReadOnly = true;
            this.textBox_ingridients.Size = new System.Drawing.Size(302, 30);
            this.textBox_ingridients.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Склад:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_category
            // 
            this.textBox_category.Location = new System.Drawing.Point(143, 120);
            this.textBox_category.Name = "textBox_category";
            this.textBox_category.ReadOnly = true;
            this.textBox_category.Size = new System.Drawing.Size(250, 34);
            this.textBox_category.TabIndex = 4;
            // 
            // comboBox_client
            // 
            this.comboBox_client.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_client.FormattingEnabled = true;
            this.comboBox_client.Location = new System.Drawing.Point(33, 68);
            this.comboBox_client.Name = "comboBox_client";
            this.comboBox_client.Size = new System.Drawing.Size(334, 35);
            this.comboBox_client.TabIndex = 3;
            this.comboBox_client.SelectedIndexChanged += new System.EventHandler(this.comboBox_client_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Оберіть назву страви";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Категорія:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.dataGridView_clients_orders);
            this.groupBox2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(437, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 395);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ваші замовлення:";
            // 
            // dataGridView_clients_orders
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_clients_orders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_clients_orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_clients_orders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_clients_orders.Location = new System.Drawing.Point(6, 33);
            this.dataGridView_clients_orders.Name = "dataGridView_clients_orders";
            this.dataGridView_clients_orders.ReadOnly = true;
            this.dataGridView_clients_orders.RowHeadersWidth = 51;
            this.dataGridView_clients_orders.RowTemplate.Height = 24;
            this.dataGridView_clients_orders.Size = new System.Drawing.Size(647, 349);
            this.dataGridView_clients_orders.TabIndex = 0;
            this.dataGridView_clients_orders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_clients_orders_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_order_delete);
            this.groupBox3.Controls.Add(this.comboBox_order_delete);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(17, 413);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(399, 218);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Скасувати замовлення";
            // 
            // button_order_delete
            // 
            this.button_order_delete.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_order_delete.Location = new System.Drawing.Point(6, 137);
            this.button_order_delete.Name = "button_order_delete";
            this.button_order_delete.Size = new System.Drawing.Size(387, 71);
            this.button_order_delete.TabIndex = 11;
            this.button_order_delete.Text = "Скасувати замовлення";
            this.button_order_delete.UseVisualStyleBackColor = true;
            this.button_order_delete.Click += new System.EventHandler(this.button_order_delete_Click);
            // 
            // comboBox_order_delete
            // 
            this.comboBox_order_delete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_order_delete.FormattingEnabled = true;
            this.comboBox_order_delete.Location = new System.Drawing.Point(33, 85);
            this.comboBox_order_delete.Name = "comboBox_order_delete";
            this.comboBox_order_delete.Size = new System.Drawing.Size(334, 35);
            this.comboBox_order_delete.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(387, 27);
            this.label6.TabIndex = 11;
            this.label6.Text = "Оберіть назву замовленої страви";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(630, 550);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(352, 71);
            this.button1.TabIndex = 7;
            this.button1.Text = "Назад на головну сторінку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 642);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Login_client";
            this.Text = "Сторінка клієнта";
            this.Load += new System.EventHandler(this.Login_client_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_clients_orders)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_calories;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ingridients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_category;
        private System.Windows.Forms.ComboBox comboBox_client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_order;
        private System.Windows.Forms.Button button_order_delete;
        private System.Windows.Forms.ComboBox comboBox_order_delete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView_clients_orders;
    }
}