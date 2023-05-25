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
using System.Windows.Controls;
using System.Windows.Forms;

namespace EducationSystem.WinFormUI
{
    public partial class SubeEkleGuncelleSilForm : Form
    {
        BranchRepository repoBranch;
        UserRepository repoUser;
        UserRoleRepository repoUserRole;
        Form anaForm;
        Branch selectedBranch;

        public SubeEkleGuncelleSilForm(Form gelenForm)
        {
            InitializeComponent();
            anaForm = gelenForm;
        }

        private void SubeEkleGuncelleSilForm_Load(object sender, EventArgs e)
        {
            repoBranch = new BranchRepository();
            repoUser = new UserRepository();
            repoUserRole = new UserRoleRepository();

            int userRoleId = repoUserRole.GetByRoleName("Koordinatör").UserRoleID;
            FillComboBoxCoordinator(repoUser.GetListByUserRoleId(userRoleId));
            FillListView();
        }

        private void FillComboBoxCoordinator(List<User> liste)
        {
            cmbSubeKoordinatoru.Items.Clear();
            cmbSubeKoordinatoru.DataSource = liste;
            cmbSubeKoordinatoru.DisplayMember = "FullName";
            cmbSubeKoordinatoru.ValueMember = "UserID";
        }

        private void FillListView()
        {
            lstSubeBilgileri.Items.Clear();
            foreach (Branch item in repoBranch.GetList())
            {
                System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem();
                lvi.Text = item.BranchName;
                User koordinator = repoUser.GetById(item.CoordinatorID);
                if (koordinator == null)
                    lvi.SubItems.Add("");
                else
                    lvi.SubItems.Add(koordinator.FullName);
                lvi.SubItems.Add(item.BMail);
                lvi.SubItems.Add(item.BPhone);
                lvi.Tag = item;
                lstSubeBilgileri.Items.Add(lvi);
            }
        }

        private void btnSubeEkle_Click(object sender, EventArgs e)
        {
            if (HelperMethods.IsEmptyControl(grpSubeBilgileri))
            {
                MessageBox.Show("Lütfen gerekli bütün alanları doldurunuz.");
            }
            else
            {
                Branch branch = new Branch()
                {
                    BranchName = txtSubeAdi.Text,
                    BAdress = txtSubeAdresi.Text,
                    BMail = txtSubeMaili.Text,
                    BPhone = txtSubeTelefon.Text,
                    CoordinatorID = ((User)cmbSubeKoordinatoru.SelectedItem).UserID,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                };

                repoBranch.AddBranch(branch);
                FillListView();
                MessageBox.Show("Şube bilgileri kaydedilmiştir.");           
            }
        }

        
        private void lstSubeBilgileri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSubeBilgileri.SelectedItems.Count > 0)
            {
                selectedBranch = (Branch)lstSubeBilgileri.SelectedItems[0].Tag;
                txtSubeAdi.Text = selectedBranch.BranchName;
                txtSubeMaili.Text = selectedBranch.BMail;
                txtSubeTelefon.Text = selectedBranch.BPhone;
                txtSubeAdresi.Text = selectedBranch.BAdress;
                cmbSubeKoordinatoru.SelectedItem = repoUser.GetById(selectedBranch.CoordinatorID);
            }
        }

        private void btnSubeGuncelle_Click(object sender, EventArgs e)
        {
            if (!HelperMethods.IsEmptyControl(grpSubeBilgileri))
            {
                DialogResult dr = MessageBox.Show("Şube bilgilerini güncellemek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Branch updatedBranch = repoBranch.GetById(selectedBranch.BranchID);
                    updatedBranch.BranchName = txtSubeAdi.Text;
                    updatedBranch.BAdress = txtSubeAdresi.Text;
                    updatedBranch.BMail = txtSubeMaili.Text;
                    updatedBranch.BPhone = txtSubeTelefon.Text;
                    updatedBranch.CoordinatorID = ((User)cmbSubeKoordinatoru.SelectedItem).UserID;
                    repoBranch.UpdateBranch(updatedBranch);
                    FillListView();
                    MessageBox.Show("Şube bilgileri güncellenmiştir.");

                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }

        }

        private void btnSubeSil_Click(object sender, EventArgs e)
        {
            if (repoUser.GetListByBranchId(selectedBranch.BranchID).Count > 0)
            {
                MessageBox.Show("Bu şubede kullanıcılar vardır. Kullanıcıları silmeden siliemezsiniz.");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Şubeyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    repoBranch.DeleteBranch(selectedBranch);
                    FillListView();
                    MessageBox.Show("Şube silinmiştir");
                }
            }
          
        }
    }
}
