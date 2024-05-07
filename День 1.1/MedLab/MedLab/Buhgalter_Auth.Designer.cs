namespace MedLab
{
    partial class Buhgalter_Auth
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
            this.password_label = new System.Windows.Forms.Label();
            this.login_label = new System.Windows.Forms.Label();
            this.par = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.TextBox();
            this.Enter_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_label.Location = new System.Drawing.Point(40, 155);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(81, 26);
            this.password_label.TabIndex = 18;
            this.password_label.Text = "Пароль";
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_label.Location = new System.Drawing.Point(40, 90);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(69, 26);
            this.login_label.TabIndex = 17;
            this.login_label.Text = "Логин";
            // 
            // par
            // 
            this.par.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.par.Location = new System.Drawing.Point(182, 152);
            this.par.Name = "par";
            this.par.Size = new System.Drawing.Size(217, 34);
            this.par.TabIndex = 16;
            this.par.UseSystemPasswordChar = true;
            // 
            // log
            // 
            this.log.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log.Location = new System.Drawing.Point(182, 87);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(217, 34);
            this.log.TabIndex = 15;
            // 
            // Enter_button
            // 
            this.Enter_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(140)))), ((int)(((byte)(81)))));
            this.Enter_button.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Enter_button.Location = new System.Drawing.Point(141, 243);
            this.Enter_button.Name = "Enter_button";
            this.Enter_button.Size = new System.Drawing.Size(163, 48);
            this.Enter_button.TabIndex = 14;
            this.Enter_button.Text = "Войти";
            this.Enter_button.UseVisualStyleBackColor = false;
            this.Enter_button.Click += new System.EventHandler(this.Enter_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(227)))), ((int)(((byte)(131)))));
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(119, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 47);
            this.label1.TabIndex = 20;
            this.label1.Text = "Авторизация";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(227)))), ((int)(((byte)(131)))));
            this.pictureBox1.Location = new System.Drawing.Point(-21, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(576, 49);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // pass
            // 
            this.pass.BackColor = System.Drawing.Color.Green;
            this.pass.Location = new System.Drawing.Point(405, 158);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(20, 24);
            this.pass.TabIndex = 21;
            this.pass.Text = "!";
            this.pass.UseVisualStyleBackColor = false;
            this.pass.Click += new System.EventHandler(this.pass_Click);
            // 
            // Buhgalter_Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 303);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_label);
            this.Controls.Add(this.par);
            this.Controls.Add(this.log);
            this.Controls.Add(this.Enter_button);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(482, 342);
            this.MinimumSize = new System.Drawing.Size(482, 342);
            this.Name = "Buhgalter_Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.TextBox par;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Button Enter_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button pass;
    }
}