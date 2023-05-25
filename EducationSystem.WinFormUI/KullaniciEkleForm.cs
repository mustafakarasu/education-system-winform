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
    public partial class KullaniciEkleForm : Form
    {
        Form anaForm;
        public KullaniciEkleForm(Form gelenForm)
        {
            InitializeComponent();
            anaForm = gelenForm;
            repo = new UserRepository();
            repoRole = new UserRoleRepository();
            repoBranch = new BranchRepository();
        }

        UserRepository repo;
        UserRoleRepository repoRole;
        BranchRepository repoBranch;
        string imagePath;

        private void KullaniciEkleForm_Load(object sender, EventArgs e)
        {
            FormLoadComponents();
        }

        private void FormLoadComponents()
        {
            cmbKullaniciGorevi.DataSource = repoRole.GetList();
            cmbKullaniciGorevi.DisplayMember = "UserRoleName";
            cmbKullaniciSubesi.DataSource = repoBranch.GetList();
            cmbKullaniciSubesi.DisplayMember = "BranchName";

            if (anaForm.Text == "KoordinatorForm")
            {
                cmbKullaniciGorevi.SelectedItem = repoRole.GetByRoleName("Eğitmen");
                cmbKullaniciGorevi.Enabled = false;
            }
            else
            {
                cmbKullaniciGorevi.Enabled = true;
            }
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (HelperMethods.IsEmptyControl(grpKullaniciBilgileri) || HelperMethods.IsEmptyControl(grpUyelikBilgileri))
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz.");
            }
            else if (!HelperMethods.IsCheckEmailAddress(txtKullaniciMailAdresi.Text))
            {
                MessageBox.Show("Email adresi doğru formatta değil.");
            }
            else if (!HelperMethods.IsCheckPasswordLength(txtKullaniciParola.Text, out string message))
            {
                MessageBox.Show(message + "\n");
            }
            else if (HelperMethods.IsCheckBirthDate(dtKullaniciDTarihi.Value))
            {
                MessageBox.Show("Kayıt için en az 7 yaşında olmalısınız.\n");
            }
            else
            {
                User user = new User()
                {
                    FirstName = txtKullaniciAdi.Text,
                    LastName = txtKullaniciSoyadi.Text,
                    BirthDate = dtKullaniciDTarihi.Value,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Email = txtKullaniciMailAdresi.Text,
                    Phone = HelperMethods.MaskTextBoxClear(txtKullaniciCepTelefonu.Text),
                    UserRoleID = ((UserRole)cmbKullaniciGorevi.SelectedItem).UserRoleID,
                    Password = txtKullaniciParola.Text,
                    BranchID = ((Branch)cmbKullaniciSubesi.SelectedItem).BranchID,
                    ImagePath = imagePath
                };

                repo.AddUser(user);
                MessageBox.Show("Kullanıcı başarıyla eklenmiştir");
                HelperMethods.ControlsClear(grpKullaniciBilgileri);
                HelperMethods.ControlsClear(grpUyelikBilgileri);

            }
        }

        private void chkKullaniciOtoParola_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKullaniciOtoParola.Checked)
            {
                txtKullaniciParola.Text = Guid.NewGuid().ToString().Substring(1, 10).Replace("-", string.Empty);
            }
        }

        private void btnKullaniciResimSec_Click(object sender, EventArgs e)
        {
            imagePath = HelperMethods.SaveImage(pbxKullaniciResmi, txtKullaniciAdi.Text);
        }
    }
}
