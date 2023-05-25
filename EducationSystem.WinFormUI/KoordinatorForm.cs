using EducationSystem.WinFormUI;
using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationSystem.WinFormUI
{
    public partial class KoordinatorForm : Form
    {
        User gelenKullanici;
        public KoordinatorForm(User gelen)
        {
            InitializeComponent();
            gelenKullanici = gelen;
        }

        private void tsmEgitmenEkle_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new KullaniciEkleForm(this), this);
        }

        private void tsmEgitmenGuncelleSil_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new KullaniciGuncelleSilForm(this), this);
        }

        private void tsmSinifEkle_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new SinifEkleGuncelleSilForm(gelenKullanici), this);
        }

        private void tsmSinifGuncellemeSil_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new SinifEkleGuncelleSilForm(gelenKullanici), this);
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new OgrenciEkleForm(gelenKullanici), this);
        }

        private void güncelleSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new OgrenciGuncelleSilForm(gelenKullanici), this);
        }

        private void tsmSubeRaporu_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new SubeRaporForm(gelenKullanici), this);
        }

        private void tsmSinifRaporu_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new SinifRaporForm(gelenKullanici), this);
        }
    }
}
