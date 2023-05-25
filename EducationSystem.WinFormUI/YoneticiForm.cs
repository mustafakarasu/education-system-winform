using EducationSystem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EducationSystem.WinFormUI;
using EducationSystem.DAL.Repositories;
using EducationSystem.DATA;

namespace EducationSystem.WinFormUI
{
    public partial class YoneticiForm : Form
    {
        UserRepository repoUser;
        UserRoleRepository repoUserRole;
        List<User> users;
        User gelenKullanici;

        public YoneticiForm(User gelen)
        {
            InitializeComponent();
            gelenKullanici = gelen;
        }

        private void YoneticiForm_Load(object sender, EventArgs e)
        {
            repoUser = new UserRepository();
            repoUserRole = new UserRoleRepository();
            GenelRaporFormu();
            users = new List<User>();
        }

        public void GenelRaporFormu()
        {
            HelperMethods.ChildForm(new GenelRaporForm(gelenKullanici), this);
        }

        private void tsmGenelRapor_Click(object sender, EventArgs e)
        {
            GenelRaporFormu();
        }

        private void tsmKullaniciEkle_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new KullaniciEkleForm(this), this);
        }

        private void tsmKullaniciGuncelleSil_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new KullaniciGuncelleSilForm(this), this);
        }

        private void tsmSubeEkleGuncelleSil_Click(object sender, EventArgs e)
        {
            if (repoUserRole.GetByRoleName("Koordinatör") != null)
            {
                int userRoleIdKoordinator = repoUserRole.GetByRoleName("Koordinatör").UserRoleID;
                users = repoUser.GetListByUserRoleId(userRoleIdKoordinator);
            }

            if (users.Count > 0)
            {
                HelperMethods.ChildForm(new SubeEkleGuncelleSilForm(this), this);
            }
            else
            {
                MessageBox.Show("Şube ekleyebilmek için ilk önce Koordinatör eklemelisniz.");
            }     
        }

        private void tsmSubeRaporu_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new SubeRaporForm(gelenKullanici), this);
        }

        private void tsmSinifRaporu_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new SinifRaporForm(gelenKullanici), this);
        }

        private void tsmEgitimEkleGuncellSil_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new EgitimEkleGuncelleSilForm(), this);
        }
    }
}
