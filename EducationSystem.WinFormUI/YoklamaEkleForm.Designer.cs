namespace EducationSystem.WinFormUI
{
    partial class YoklamaEkleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblSubeAdi = new System.Windows.Forms.Label();
            this.cmbSiniflar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpYoklamaTarihi = new System.Windows.Forms.DateTimePicker();
            this.btnYoklamaBul = new System.Windows.Forms.Button();
            this.grpYoklamaBul = new System.Windows.Forms.GroupBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnYoklamaGir = new System.Windows.Forms.Button();
            this.btnHicbiriniSecme = new System.Windows.Forms.Button();
            this.btnTumunuSec = new System.Windows.Forms.Button();
            this.flpYoklamaListesi = new System.Windows.Forms.FlowLayoutPanel();
            this.grpYoklamaBul.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Şube:";
            // 
            // lblSubeAdi
            // 
            this.lblSubeAdi.AutoSize = true;
            this.lblSubeAdi.Location = new System.Drawing.Point(18, 73);
            this.lblSubeAdi.Name = "lblSubeAdi";
            this.lblSubeAdi.Size = new System.Drawing.Size(38, 18);
            this.lblSubeAdi.TabIndex = 2;
            this.lblSubeAdi.Text = "?????";
            // 
            // cmbSiniflar
            // 
            this.cmbSiniflar.FormattingEnabled = true;
            this.cmbSiniflar.Location = new System.Drawing.Point(166, 67);
            this.cmbSiniflar.Name = "cmbSiniflar";
            this.cmbSiniflar.Size = new System.Drawing.Size(180, 26);
            this.cmbSiniflar.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sınıf:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tarih:";
            // 
            // dtpYoklamaTarihi
            // 
            this.dtpYoklamaTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpYoklamaTarihi.Location = new System.Drawing.Point(375, 68);
            this.dtpYoklamaTarihi.Name = "dtpYoklamaTarihi";
            this.dtpYoklamaTarihi.Size = new System.Drawing.Size(114, 25);
            this.dtpYoklamaTarihi.TabIndex = 6;
            // 
            // btnYoklamaBul
            // 
            this.btnYoklamaBul.Location = new System.Drawing.Point(514, 39);
            this.btnYoklamaBul.Name = "btnYoklamaBul";
            this.btnYoklamaBul.Size = new System.Drawing.Size(165, 54);
            this.btnYoklamaBul.TabIndex = 7;
            this.btnYoklamaBul.Text = "Yoklama Bul";
            this.btnYoklamaBul.UseVisualStyleBackColor = true;
            this.btnYoklamaBul.Click += new System.EventHandler(this.btnYoklamaBul_Click);
            // 
            // grpYoklamaBul
            // 
            this.grpYoklamaBul.Controls.Add(this.label1);
            this.grpYoklamaBul.Controls.Add(this.btnYoklamaBul);
            this.grpYoklamaBul.Controls.Add(this.lblSubeAdi);
            this.grpYoklamaBul.Controls.Add(this.dtpYoklamaTarihi);
            this.grpYoklamaBul.Controls.Add(this.cmbSiniflar);
            this.grpYoklamaBul.Controls.Add(this.label3);
            this.grpYoklamaBul.Controls.Add(this.label2);
            this.grpYoklamaBul.Location = new System.Drawing.Point(17, 17);
            this.grpYoklamaBul.Margin = new System.Windows.Forms.Padding(4);
            this.grpYoklamaBul.Name = "grpYoklamaBul";
            this.grpYoklamaBul.Padding = new System.Windows.Forms.Padding(4);
            this.grpYoklamaBul.Size = new System.Drawing.Size(726, 109);
            this.grpYoklamaBul.TabIndex = 1;
            this.grpYoklamaBul.TabStop = false;
            this.grpYoklamaBul.Text = "Yoklama Bul";
            // 
            // btnYoklamaGir
            // 
            this.btnYoklamaGir.Location = new System.Drawing.Point(487, 582);
            this.btnYoklamaGir.Name = "btnYoklamaGir";
            this.btnYoklamaGir.Size = new System.Drawing.Size(256, 59);
            this.btnYoklamaGir.TabIndex = 3;
            this.btnYoklamaGir.Text = "YOKLAMA GİR";
            this.btnYoklamaGir.UseVisualStyleBackColor = true;
            this.btnYoklamaGir.Click += new System.EventHandler(this.btnYoklamaGir_Click);
            // 
            // btnHicbiriniSecme
            // 
            this.btnHicbiriniSecme.Location = new System.Drawing.Point(203, 582);
            this.btnHicbiriniSecme.Name = "btnHicbiriniSecme";
            this.btnHicbiriniSecme.Size = new System.Drawing.Size(180, 59);
            this.btnHicbiriniSecme.TabIndex = 4;
            this.btnHicbiriniSecme.Text = "HİÇBİRİNİ SEÇME";
            this.btnHicbiriniSecme.UseVisualStyleBackColor = true;
            this.btnHicbiriniSecme.Click += new System.EventHandler(this.btnHicbiriniSecme_Click);
            // 
            // btnTumunuSec
            // 
            this.btnTumunuSec.Location = new System.Drawing.Point(17, 582);
            this.btnTumunuSec.Name = "btnTumunuSec";
            this.btnTumunuSec.Size = new System.Drawing.Size(180, 59);
            this.btnTumunuSec.TabIndex = 5;
            this.btnTumunuSec.Text = "TÜM ÖĞRENCİLERİ SEÇ";
            this.btnTumunuSec.UseVisualStyleBackColor = true;
            this.btnTumunuSec.Click += new System.EventHandler(this.btnTumunuSec_Click);
            // 
            // flpYoklamaListesi
            // 
            this.flpYoklamaListesi.Location = new System.Drawing.Point(17, 146);
            this.flpYoklamaListesi.Name = "flpYoklamaListesi";
            this.flpYoklamaListesi.Size = new System.Drawing.Size(726, 414);
            this.flpYoklamaListesi.TabIndex = 6;
            // 
            // YoklamaEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 660);
            this.Controls.Add(this.flpYoklamaListesi);
            this.Controls.Add(this.btnTumunuSec);
            this.Controls.Add(this.btnHicbiriniSecme);
            this.Controls.Add(this.btnYoklamaGir);
            this.Controls.Add(this.grpYoklamaBul);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "YoklamaEkleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YoklamaEkleForm";
            this.Load += new System.EventHandler(this.YoklamaEkleForm_Load);
            this.grpYoklamaBul.ResumeLayout(false);
            this.grpYoklamaBul.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSubeAdi;
        private System.Windows.Forms.ComboBox cmbSiniflar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpYoklamaTarihi;
        private System.Windows.Forms.Button btnYoklamaBul;
        private System.Windows.Forms.GroupBox grpYoklamaBul;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnYoklamaGir;
        private System.Windows.Forms.Button btnHicbiriniSecme;
        private System.Windows.Forms.Button btnTumunuSec;
        private System.Windows.Forms.FlowLayoutPanel flpYoklamaListesi;
    }
}