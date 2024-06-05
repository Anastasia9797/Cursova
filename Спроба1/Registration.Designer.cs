namespace Спроба1
{
    partial class Registration
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
            this.label8 = new System.Windows.Forms.Label();
            this.txt_password_client = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_surname_client = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_name_client = new System.Windows.Forms.TextBox();
            this.txt_phone_client = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_login_client = new System.Windows.Forms.TextBox();
            this.btnRegistration_client = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(80, 419);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(373, 27);
            this.label8.TabIndex = 28;
            this.label8.Text = "Номер телефону. Формат: 050 987 6565";
            // 
            // txt_password_client
            // 
            this.txt_password_client.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_password_client.Location = new System.Drawing.Point(58, 171);
            this.txt_password_client.Name = "txt_password_client";
            this.txt_password_client.Size = new System.Drawing.Size(413, 34);
            this.txt_password_client.TabIndex = 27;
            this.txt_password_client.UseSystemPasswordChar = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(217, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 27);
            this.label10.TabIndex = 26;
            this.label10.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(211, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 27);
            this.label1.TabIndex = 24;
            this.label1.Text = "Прізвище";
            // 
            // txt_surname_client
            // 
            this.txt_surname_client.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_surname_client.Location = new System.Drawing.Point(58, 348);
            this.txt_surname_client.Name = "txt_surname_client";
            this.txt_surname_client.Size = new System.Drawing.Size(413, 34);
            this.txt_surname_client.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(235, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 27);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ім\'я";
            // 
            // txt_name_client
            // 
            this.txt_name_client.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_name_client.Location = new System.Drawing.Point(58, 259);
            this.txt_name_client.Name = "txt_name_client";
            this.txt_name_client.Size = new System.Drawing.Size(413, 34);
            this.txt_name_client.TabIndex = 23;
            // 
            // txt_phone_client
            // 
            this.txt_phone_client.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_phone_client.Location = new System.Drawing.Point(58, 449);
            this.txt_phone_client.Name = "txt_phone_client";
            this.txt_phone_client.Size = new System.Drawing.Size(413, 34);
            this.txt_phone_client.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(235, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 27);
            this.label9.TabIndex = 18;
            this.label9.Text = "Логін";
            // 
            // txt_login_client
            // 
            this.txt_login_client.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_login_client.Location = new System.Drawing.Point(58, 72);
            this.txt_login_client.Name = "txt_login_client";
            this.txt_login_client.Size = new System.Drawing.Size(413, 34);
            this.txt_login_client.TabIndex = 19;
            this.txt_login_client.TextChanged += new System.EventHandler(this.txt_login_client_TextChanged);
            // 
            // btnRegistration_client
            // 
            this.btnRegistration_client.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRegistration_client.Location = new System.Drawing.Point(103, 520);
            this.btnRegistration_client.Name = "btnRegistration_client";
            this.btnRegistration_client.Size = new System.Drawing.Size(316, 63);
            this.btnRegistration_client.TabIndex = 0;
            this.btnRegistration_client.Text = "Зареєструватись";
            this.btnRegistration_client.UseVisualStyleBackColor = true;
            this.btnRegistration_client.Click += new System.EventHandler(this.btnRegistration_client_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_exit.Location = new System.Drawing.Point(103, 602);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(316, 63);
            this.btn_exit.TabIndex = 29;
            this.btn_exit.Text = "Повернутись на головну";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 692);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_password_client);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnRegistration_client);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_login_client);
            this.Controls.Add(this.txt_surname_client);
            this.Controls.Add(this.txt_phone_client);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name_client);
            this.Name = "Registration";
            this.Text = "Реєстрація";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRegistration_client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_surname_client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_name_client;
        private System.Windows.Forms.TextBox txt_phone_client;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_login_client;
        private System.Windows.Forms.TextBox txt_password_client;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_exit;
    }
}