namespace EducationSystem.WinFormUI
{
    partial class KoordinatorForm
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
            this.msKoordinatorForm = new System.Windows.Forms.MenuStrip();
            this.tsmEgitmenIslemleri = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEgitmenEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEgitmenGuncelleSil = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSinifIslemleri = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSinifEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSinifGuncellemeSil = new System.Windows.Forms.ToolStripMenuItem();
            this.öğrenciİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.güncelleSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRaporIslemleri = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSubeRaporu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSinifRaporu = new System.Windows.Forms.ToolStripMenuItem();
            this.msKoordinatorForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // msKoordinatorForm
            // 
            this.msKoordinatorForm.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.msKoordinatorForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEgitmenIslemleri,
            this.tsmSinifIslemleri,
            this.öğrenciİşlemleriToolStripMenuItem,
            this.tsmRaporIslemleri});
            this.msKoordinatorForm.Location = new System.Drawing.Point(0, 0);
            this.msKoordinatorForm.Name = "msKoordinatorForm";
            this.msKoordinatorForm.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.msKoordinatorForm.Size = new System.Drawing.Size(800, 27);
            this.msKoordinatorForm.TabIndex = 1;
            this.msKoordinatorForm.Text = "menuStrip1";
            // 
            // tsmEgitmenIslemleri
            // 
            this.tsmEgitmenIslemleri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEgitmenEkle,
            this.tsmEgitmenGuncelleSil});
            this.tsmEgitmenIslemleri.Name = "tsmEgitmenIslemleri";
            this.tsmEgitmenIslemleri.Size = new System.Drawing.Size(134, 21);
            this.tsmEgitmenIslemleri.Text = "Eğitmen İşlemleri";
            // 
            // tsmEgitmenEkle
            // 
            this.tsmEgitmenEkle.Name = "tsmEgitmenEkle";
            this.tsmEgitmenEkle.Size = new System.Drawing.Size(162, 22);
            this.tsmEgitmenEkle.Text = "Ekle";
            this.tsmEgitmenEkle.Click += new System.EventHandler(this.tsmEgitmenEkle_Click);
            // 
            // tsmEgitmenGuncelleSil
            // 
            this.tsmEgitmenGuncelleSil.Name = "tsmEgitmenGuncelleSil";
            this.tsmEgitmenGuncelleSil.Size = new System.Drawing.Size(162, 22);
            this.tsmEgitmenGuncelleSil.Text = "Güncelle / Sil";
            this.tsmEgitmenGuncelleSil.Click += new System.EventHandler(this.tsmEgitmenGuncelleSil_Click);
            // 
            // tsmSinifIslemleri
            // 
            this.tsmSinifIslemleri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSinifEkle,
            this.tsmSinifGuncellemeSil});
            this.tsmSinifIslemleri.Name = "tsmSinifIslemleri";
            this.tsmSinifIslemleri.Size = new System.Drawing.Size(110, 21);
            this.tsmSinifIslemleri.Text = "Sınıf İşlemleri";
            // 
            // tsmSinifEkle
            // 
            this.tsmSinifEkle.Name = "tsmSinifEkle";
            this.tsmSinifEkle.Size = new System.Drawing.Size(162, 22);
            this.tsmSinifEkle.Text = "Ekle";
            this.tsmSinifEkle.Click += new System.EventHandler(this.tsmSinifEkle_Click);
            // 
            // tsmSinifGuncellemeSil
            // 
            this.tsmSinifGuncellemeSil.Name = "tsmSinifGuncellemeSil";
            this.tsmSinifGuncellemeSil.Size = new System.Drawing.Size(162, 22);
            this.tsmSinifGuncellemeSil.Text = "Güncelle / Sil";
            this.tsmSinifGuncellemeSil.Click += new System.EventHandler(this.tsmSinifGuncellemeSil_Click);
            // 
            // öğrenciİşlemleriToolStripMenuItem
            // 
            this.öğrenciİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem,
            this.güncelleSilToolStripMenuItem});
            this.öğrenciİşlemleriToolStripMenuItem.Name = "öğrenciİşlemleriToolStripMenuItem";
            this.öğrenciİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(131, 21);
            this.öğrenciİşlemleriToolStripMenuItem.Text = "Öğrenci İşlemleri";
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ekleToolStripMenuItem.Text = "Ekle";
            this.ekleToolStripMenuItem.Click += new System.EventHandler(this.ekleToolStripMenuItem_Click);
            // 
            // güncelleSilToolStripMenuItem
            // 
            this.güncelleSilToolStripMenuItem.Name = "güncelleSilToolStripMenuItem";
            this.güncelleSilToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.güncelleSilToolStripMenuItem.Text = "Güncelle / Sil";
            this.güncelleSilToolStripMenuItem.Click += new System.EventHandler(this.güncelleSilToolStripMenuItem_Click);
            // 
            // tsmRaporIslemleri
            // 
            this.tsmRaporIslemleri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSubeRaporu,
            this.tsmSinifRaporu});
            this.tsmRaporIslemleri.Name = "tsmRaporIslemleri";
            this.tsmRaporIslemleri.Size = new System.Drawing.Size(119, 21);
            this.tsmRaporIslemleri.Text = "Rapor İşlemleri";
            // 
            // tsmSubeRaporu
            // 
            this.tsmSubeRaporu.Name = "tsmSubeRaporu";
            this.tsmSubeRaporu.Size = new System.Drawing.Size(180, 22);
            this.tsmSubeRaporu.Text = "Şube Raporu";
            this.tsmSubeRaporu.Click += new System.EventHandler(this.tsmSubeRaporu_Click);
            // 
            // tsmSinifRaporu
            // 
            this.tsmSinifRaporu.Name = "tsmSinifRaporu";
            this.tsmSinifRaporu.Size = new System.Drawing.Size(180, 22);
            this.tsmSinifRaporu.Text = "Sınıf Raporu";
            this.tsmSinifRaporu.Click += new System.EventHandler(this.tsmSinifRaporu_Click);
            // 
            // KoordinatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.msKoordinatorForm);
            this.IsMdiContainer = true;
            this.Name = "KoordinatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KoordinatorForm";
            this.msKoordinatorForm.ResumeLayout(false);
            this.msKoordinatorForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msKoordinatorForm;
        private System.Windows.Forms.ToolStripMenuItem tsmEgitmenIslemleri;
        private System.Windows.Forms.ToolStripMenuItem tsmEgitmenEkle;
        private System.Windows.Forms.ToolStripMenuItem tsmEgitmenGuncelleSil;
        private System.Windows.Forms.ToolStripMenuItem tsmSinifIslemleri;
        private System.Windows.Forms.ToolStripMenuItem tsmSinifEkle;
        private System.Windows.Forms.ToolStripMenuItem tsmSinifGuncellemeSil;
        private System.Windows.Forms.ToolStripMenuItem tsmRaporIslemleri;
        private System.Windows.Forms.ToolStripMenuItem tsmSubeRaporu;
        private System.Windows.Forms.ToolStripMenuItem tsmSinifRaporu;
        private System.Windows.Forms.ToolStripMenuItem öğrenciİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem güncelleSilToolStripMenuItem;
    }
}