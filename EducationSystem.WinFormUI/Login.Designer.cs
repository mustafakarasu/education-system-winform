namespace EducationSystem.WinFormUI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.grpGirisPaneli = new System.Windows.Forms.GroupBox();
            this.chkParolaGoster = new System.Windows.Forms.CheckBox();
            this.txtGirisParola = new System.Windows.Forms.TextBox();
            this.txtGirisMailAdresi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpGirisPaneli.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGirisPaneli
            // 
            this.grpGirisPaneli.Controls.Add(this.chkParolaGoster);
            this.grpGirisPaneli.Controls.Add(this.txtGirisParola);
            this.grpGirisPaneli.Controls.Add(this.txtGirisMailAdresi);
            this.grpGirisPaneli.Controls.Add(this.label2);
            this.grpGirisPaneli.Controls.Add(this.label1);
            this.grpGirisPaneli.Controls.Add(this.btnGirisYap);
            this.grpGirisPaneli.Location = new System.Drawing.Point(12, 102);
            this.grpGirisPaneli.Name = "grpGirisPaneli";
            this.grpGirisPaneli.Size = new System.Drawing.Size(413, 162);
            this.grpGirisPaneli.TabIndex = 0;
            this.grpGirisPaneli.TabStop = false;
            this.grpGirisPaneli.Text = "GİRİŞ PANELİ";
            // 
            // chkParolaGoster
            // 
            this.chkParolaGoster.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkParolaGoster.Location = new System.Drawing.Point(126, 94);
            this.chkParolaGoster.Name = "chkParolaGoster";
            this.chkParolaGoster.Size = new System.Drawing.Size(280, 22);
            this.chkParolaGoster.TabIndex = 2;
            this.chkParolaGoster.Text = "Parolayı Göster";
            this.chkParolaGoster.UseVisualStyleBackColor = true;
            this.chkParolaGoster.CheckedChanged += new System.EventHandler(this.chkParolaGoster_CheckedChanged);
            // 
            // txtGirisParola
            // 
            this.txtGirisParola.Location = new System.Drawing.Point(126, 62);
            this.txtGirisParola.Margin = new System.Windows.Forms.Padding(4);
            this.txtGirisParola.Name = "txtGirisParola";
            this.txtGirisParola.PasswordChar = '*';
            this.txtGirisParola.Size = new System.Drawing.Size(280, 25);
            this.txtGirisParola.TabIndex = 1;
            // 
            // txtGirisMailAdresi
            // 
            this.txtGirisMailAdresi.Location = new System.Drawing.Point(126, 25);
            this.txtGirisMailAdresi.Margin = new System.Windows.Forms.Padding(4);
            this.txtGirisMailAdresi.Name = "txtGirisMailAdresi";
            this.txtGirisMailAdresi.Size = new System.Drawing.Size(280, 25);
            this.txtGirisMailAdresi.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Parola:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mail Adresi:";
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Location = new System.Drawing.Point(126, 123);
            this.btnGirisYap.Margin = new System.Windows.Forms.Padding(4);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(280, 32);
            this.btnGirisYap.TabIndex = 3;
            this.btnGirisYap.Text = "GİRİŞ YAP";
            this.btnGirisYap.UseVisualStyleBackColor = true;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 84);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Admin Giriş Bilgileri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Parola: 123456";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Email: admin@admin.com";
            // 
            // Login
            // 
            this.AcceptButton = this.btnGirisYap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(442, 274);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpGirisPaneli);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Ekranı";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpGirisPaneli.ResumeLayout(false);
            this.grpGirisPaneli.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGirisPaneli;
        private System.Windows.Forms.CheckBox chkParolaGoster;
        private System.Windows.Forms.TextBox txtGirisParola;
        private System.Windows.Forms.TextBox txtGirisMailAdresi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

