using EducationSystem.WinFormUI;
using EducationSystem.DAL.Repositories;
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
    public partial class KullaniciGuncelleSilForm : Form
    {
        UserRepository repoUser;
        UserRoleRepository repoUserRole;
        BranchRepository repoBranch;

        Form anaForm;

        public KullaniciGuncelleSilForm(Form gelenForm)
        {
            InitializeComponent();
            anaForm = gelenForm;
        }
        private void KullaniciGuncelleSilForm_Load(object sender, EventArgs e)
        {
            repoUser = new UserRepository();
            repoBranch = new BranchRepository();
            repoUserRole = new UserRoleRepository();

            cmbKullaniciGorevi.DataSource = repoUserRole.GetList();
            cmbKullaniciGorevi.DisplayMember = "UserRoleName";
            cmbKullaniciSubesi.DataSource = repoBranch.GetList();
            cmbKullaniciSubesi.DisplayMember = "BranchName";
            cmbKullaniciSubesi.ValueMember = "BranchID";
            cmbGoreveGoreAra.DataSource = repoUserRole.GetList();
            cmbGoreveGoreAra.DisplayMember = "UserRoleName";

            if (anaForm.Text == "KoordinatorForm")
            {
                FillListView(repoUser.GetListByUserRoleId(repoUserRole.GetByRoleName("Eğitmen").UserRoleID));
                cmbKullaniciGorevi.SelectedItem = repoUserRole.GetByRoleName("Eğitmen");
                cmbKullaniciGorevi.Enabled = false;
                cmbGoreveGoreAra.SelectedItem = repoUserRole.GetByRoleName("Eğitmen");
                cmbGoreveGoreAra.Enabled = false;
            }
            else if (anaForm.Text == "YoneticiForm")
            {
                FillListView(repoUser.GetList());
                cmbKullaniciGorevi.Enabled = true;
                cmbGoreveGoreAra.Enabled = true;
            }         
        }

        public void FillListView(List<User> liste)
        {
            lstKullanicilar.Items.Clear();
            foreach (User item in liste)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.FirstName;
                lvi.SubItems.Add(item.LastName);
                lvi.SubItems.Add(item.Phone);
                lvi.SubItems.Add(item.Email);
                lvi.SubItems.Add(item.UserRole.UserRoleName);
                lvi.SubItems.Add(item.Branch.BranchName);
                lvi.Tag = item;
                lstKullanicilar.Items.Add(lvi);
            }
        }

        User selectedUser;
        private void lstKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstKullanicilar.SelectedItems.Count > 0)
            {
                selectedUser = lstKullanicilar.SelectedItems[0].Tag as User;

                txtKullaniciAdi.Text = selectedUser.FirstName;
                txtKullaniciCepTelefonu.Text = selectedUser.Phone;
                txtKullaniciMailAdresi.Text = selectedUser.Email;
                txtKullaniciSoyadi.Text = selectedUser.LastName;
                txtKullaniciParola.Text = selectedUser.Password;
                dtKullaniciDTarihi.Value = selectedUser.BirthDate;
                cmbKullaniciGorevi.SelectedItem = repoUserRole.GetById(selectedUser.UserRoleID);
                cmbKullaniciSubesi.SelectedItem = repoBranch.GetById(selectedUser.BranchID);
                HelperMethods.LoadImage(pbxKullaniciResmi,selectedUser.ImagePath);
            }
        }

        string imagePath;

        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            User user = repoUser.GetById(selectedUser.UserID);
            DialogResult dr = MessageBox.Show("Kullanıcıyı bilgilerini güncellemek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                user.FirstName = txtKullaniciAdi.Text;
                user.LastName = txtKullaniciSoyadi.Text;
                user.Phone = HelperMethods.MaskTextBoxClear(txtKullaniciCepTelefonu.Text);
                user.Email = txtKullaniciMailAdresi.Text;
                user.ModifiedDate = DateTime.Now;
                user.Password = txtKullaniciParola.Text;
                user.BranchID = (cmbKullaniciSubesi.SelectedItem as Branch).BranchID;
                user.UserRoleID = (cmbKullaniciGorevi.SelectedItem as UserRole).UserRoleID;
                user.BirthDate = dtKullaniciDTarihi.Value;
                user.ImagePath = imagePath;

                repoUser.UpdateUser(user);

                if (anaForm.Text == "KoordinatorForm")
                    FillListView(repoUser.GetListByUserRoleId(repoUserRole.GetByRoleName("Eğitmen").UserRoleID));
                else
                    FillListView(repoUser.GetList());

                MessageBox.Show("Kullanıcı bilgileri güncellenmiştir.");
                HelperMethods.ControlsClear(grpKullaniciBilgileri);
                HelperMethods.ControlsClear(grpUyelikBilgileri);
            }
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            User deletedUser = repoUser.GetById(selectedUser.UserID);
            DialogResult dr = MessageBox.Show("Kullanıcıyı Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                repoUser.DeleteUser(deletedUser);

                if (anaForm.Text == "KoordinatorForm")
                    FillListView(repoUser.GetListByUserRoleId(repoUserRole.GetByRoleName("Eğitmen").UserRoleID));
                else
                    FillListView(repoUser.GetList());

                MessageBox.Show("Kullanıcı silinmiştir.");
                HelperMethods.ControlsClear(grpKullaniciBilgileri);
                HelperMethods.ControlsClear(grpUyelikBilgileri);
            }
        }

        private void btnKullaniciAramaYap_Click(object sender, EventArgs e)
        {
            int searchRoleId = (cmbGoreveGoreAra.SelectedItem as UserRole).UserRoleID;
            FillListView(repoUser.GetListBySearh(txtAdaGoreAra.Text, searchRoleId));  
        }

        private void chkKullaniciOtoParola_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKullaniciOtoParola.Checked)
            {
                txtKullaniciParola.Text = Guid.NewGuid().ToString().Substring(1, 10).Replace('-', '\0');
            }
        }

        private void btnKullaniciResimSec_Click(object sender, EventArgs e)
        {
            imagePath = HelperMethods.SaveImage(pbxKullaniciResmi, txtKullaniciAdi.Text);
        }
    }
}
