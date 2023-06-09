﻿namespace EducationSystem.WinFormUI
{
    partial class SubeRaporForm
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
            this.grpSubeRaporu = new System.Windows.Forms.GroupBox();
            this.btnExcelKaydet = new System.Windows.Forms.Button();
            this.btnPDFKaydet = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDersOrtalamasi = new System.Windows.Forms.Label();
            this.lblVerilenDersSaati = new System.Windows.Forms.Label();
            this.lblSinifSayisi = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblOgrenciSayisi = new System.Windows.Forms.Label();
            this.lblEgitmenSayisi = new System.Windows.Forms.Label();
            this.lblKoordinatorSayisi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSube = new System.Windows.Forms.ComboBox();
            this.grpSubeRaporu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSubeRaporu
            // 
            this.grpSubeRaporu.Controls.Add(this.btnExcelKaydet);
            this.grpSubeRaporu.Controls.Add(this.btnPDFKaydet);
            this.grpSubeRaporu.Controls.Add(this.label11);
            this.grpSubeRaporu.Controls.Add(this.lblDersOrtalamasi);
            this.grpSubeRaporu.Controls.Add(this.lblVerilenDersSaati);
            this.grpSubeRaporu.Controls.Add(this.lblSinifSayisi);
            this.grpSubeRaporu.Controls.Add(this.label14);
            this.grpSubeRaporu.Controls.Add(this.label15);
            this.grpSubeRaporu.Controls.Add(this.lblOgrenciSayisi);
            this.grpSubeRaporu.Controls.Add(this.lblEgitmenSayisi);
            this.grpSubeRaporu.Controls.Add(this.lblKoordinatorSayisi);
            this.grpSubeRaporu.Controls.Add(this.label5);
            this.grpSubeRaporu.Controls.Add(this.label4);
            this.grpSubeRaporu.Controls.Add(this.label3);
            this.grpSubeRaporu.Location = new System.Drawing.Point(13, 78);
            this.grpSubeRaporu.Margin = new System.Windows.Forms.Padding(4);
            this.grpSubeRaporu.Name = "grpSubeRaporu";
            this.grpSubeRaporu.Padding = new System.Windows.Forms.Padding(4);
            this.grpSubeRaporu.Size = new System.Drawing.Size(260, 387);
            this.grpSubeRaporu.TabIndex = 1;
            this.grpSubeRaporu.TabStop = false;
            this.grpSubeRaporu.Text = "Şube Raporu";
            // 
            // btnExcelKaydet
            // 
            this.btnExcelKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelKaydet.Location = new System.Drawing.Point(10, 324);
            this.btnExcelKaydet.Name = "btnExcelKaydet";
            this.btnExcelKaydet.Size = new System.Drawing.Size(243, 56);
            this.btnExcelKaydet.TabIndex = 22;
            this.btnExcelKaydet.Text = "EXCEL OLARAK KAYDET";
            this.btnExcelKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcelKaydet.UseVisualStyleBackColor = true;
            this.btnExcelKaydet.Click += new System.EventHandler(this.btnExcelKaydet_Click);
            // 
            // btnPDFKaydet
            // 
            this.btnPDFKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDFKaydet.Location = new System.Drawing.Point(7, 252);
            this.btnPDFKaydet.Name = "btnPDFKaydet";
            this.btnPDFKaydet.Size = new System.Drawing.Size(246, 66);
            this.btnPDFKaydet.TabIndex = 21;
            this.btnPDFKaydet.Text = "PDF OLARAK KAYDET";
            this.btnPDFKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPDFKaydet.UseVisualStyleBackColor = true;
            this.btnPDFKaydet.Click += new System.EventHandler(this.btnPDFKaydet_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(14, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 38);
            this.label11.TabIndex = 20;
            this.label11.Text = "Verilen Ders / Eğitmen Ortalaması:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDersOrtalamasi
            // 
            this.lblDersOrtalamasi.AutoSize = true;
            this.lblDersOrtalamasi.Location = new System.Drawing.Point(192, 211);
            this.lblDersOrtalamasi.Name = "lblDersOrtalamasi";
            this.lblDersOrtalamasi.Size = new System.Drawing.Size(38, 18);
            this.lblDersOrtalamasi.TabIndex = 19;
            this.lblDersOrtalamasi.Text = "?????";
            // 
            // lblVerilenDersSaati
            // 
            this.lblVerilenDersSaati.AutoSize = true;
            this.lblVerilenDersSaati.Location = new System.Drawing.Point(192, 169);
            this.lblVerilenDersSaati.Name = "lblVerilenDersSaati";
            this.lblVerilenDersSaati.Size = new System.Drawing.Size(38, 18);
            this.lblVerilenDersSaati.TabIndex = 16;
            this.lblVerilenDersSaati.Text = "?????";
            // 
            // lblSinifSayisi
            // 
            this.lblSinifSayisi.AutoSize = true;
            this.lblSinifSayisi.Location = new System.Drawing.Point(192, 136);
            this.lblSinifSayisi.Name = "lblSinifSayisi";
            this.lblSinifSayisi.Size = new System.Drawing.Size(38, 18);
            this.lblSinifSayisi.TabIndex = 15;
            this.lblSinifSayisi.Text = "?????";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 169);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 18);
            this.label14.TabIndex = 11;
            this.label14.Text = "Verilen Ders Saati:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(92, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 18);
            this.label15.TabIndex = 10;
            this.label15.Text = "Sınıf Sayısı:";
            // 
            // lblOgrenciSayisi
            // 
            this.lblOgrenciSayisi.AutoSize = true;
            this.lblOgrenciSayisi.Location = new System.Drawing.Point(192, 107);
            this.lblOgrenciSayisi.Name = "lblOgrenciSayisi";
            this.lblOgrenciSayisi.Size = new System.Drawing.Size(38, 18);
            this.lblOgrenciSayisi.TabIndex = 9;
            this.lblOgrenciSayisi.Text = "?????";
            // 
            // lblEgitmenSayisi
            // 
            this.lblEgitmenSayisi.AutoSize = true;
            this.lblEgitmenSayisi.Location = new System.Drawing.Point(192, 69);
            this.lblEgitmenSayisi.Name = "lblEgitmenSayisi";
            this.lblEgitmenSayisi.Size = new System.Drawing.Size(38, 18);
            this.lblEgitmenSayisi.TabIndex = 8;
            this.lblEgitmenSayisi.Text = "?????";
            // 
            // lblKoordinatorSayisi
            // 
            this.lblKoordinatorSayisi.AutoSize = true;
            this.lblKoordinatorSayisi.Location = new System.Drawing.Point(192, 36);
            this.lblKoordinatorSayisi.Name = "lblKoordinatorSayisi";
            this.lblKoordinatorSayisi.Size = new System.Drawing.Size(38, 18);
            this.lblKoordinatorSayisi.TabIndex = 7;
            this.lblKoordinatorSayisi.Text = "?????";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Öğrenci Sayısı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Eğitmen Sayısı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Koordinatör Sayısı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Şube Seç:";
            // 
            // cmbSube
            // 
            this.cmbSube.FormattingEnabled = true;
            this.cmbSube.Location = new System.Drawing.Point(23, 35);
            this.cmbSube.Name = "cmbSube";
            this.cmbSube.Size = new System.Drawing.Size(243, 26);
            this.cmbSube.TabIndex = 3;
            // 
            // SubeRaporForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 478);
            this.Controls.Add(this.cmbSube);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpSubeRaporu);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SubeRaporForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubeRaporForm";
            this.Load += new System.EventHandler(this.SubeRaporForm_Load);
            this.grpSubeRaporu.ResumeLayout(false);
            this.grpSubeRaporu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSubeRaporu;
        private System.Windows.Forms.Button btnPDFKaydet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDersOrtalamasi;
        private System.Windows.Forms.Label lblVerilenDersSaati;
        private System.Windows.Forms.Label lblSinifSayisi;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblOgrenciSayisi;
        private System.Windows.Forms.Label lblEgitmenSayisi;
        private System.Windows.Forms.Label lblKoordinatorSayisi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSube;
        private System.Windows.Forms.Button btnExcelKaydet;
    }
}