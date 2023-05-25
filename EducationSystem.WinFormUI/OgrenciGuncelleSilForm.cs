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
    public partial class OgrenciGuncelleSilForm : Form
    {
        ClassesRepository repoClasses;
        StudentRepository repoStudent;
        Student selectedStudent;
        User _gelenUser;
        string imagePath;

        public OgrenciGuncelleSilForm(User gelen)
        {
            InitializeComponent();
            _gelenUser = gelen;
           
        }

        private void OgrenciGuncelleSilForm_Load(object sender, EventArgs e)
        {
            repoClasses = new ClassesRepository();
            repoStudent = new StudentRepository();
            FillComboboxClassess();
            FillListView(repoStudent.GetList());
            cmbSinifaGoreAra.DataSource = repoClasses.GetList();
            cmbSinifaGoreAra.DisplayMember = "ClassesCode";
            cmbSinifaGoreAra.ValueMember = "ClassesID";
        }

        private void FillListView(List<Student> liste)
        {
            lstOgrenciler.Items.Clear();
            foreach (Student item in liste)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.FirstName;
                lvi.SubItems.Add(item.LastName);
                lvi.SubItems.Add(item.Phone);
                lvi.SubItems.Add(item.EMail);
                lvi.SubItems.Add(item.Classes.ClassesCode);
                lvi.SubItems.Add(item.Classes.Branch.BranchName);
                lvi.Tag = item;
                lstOgrenciler.Items.Add(lvi);
            }
        }

        private void FillComboboxClassess()
        {
            cmbOgrenciSinifi.Items.Clear();
            if (repoClasses.GetList().Count < 15)
            {
                cmbOgrenciSinifi.DataSource = repoClasses.GetList();
            }     
            cmbOgrenciSinifi.DisplayMember = "ClassesCode";
            cmbOgrenciSinifi.ValueMember = "ClassesID";
        }

        private void btnOgrenciGuncelle_Click(object sender, EventArgs e)
        {
            if (HelperMethods.IsEmptyControl(grpOgrenciBilgileri))
            {
                MessageBox.Show("Lütfen tüm gerekli alanları doldurunuz.");
            }
            else
            {
               DialogResult dr = MessageBox.Show("Öğrenci bilgilerini güncellemek istediğinize emin misiniz?","Uyarı",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    selectedStudent.FirstName = txtOgrenciAdi.Text;
                    selectedStudent.LastName = txtOgrenciSoyadi.Text;
                    selectedStudent.BirthDate = dtOgrenciDTarihi.Value;
                    selectedStudent.EMail = txtOgrenciMailAdresi.Text;
                    selectedStudent.Phone = txtOgrenciCepTelefonu.Text;
                    selectedStudent.ClassesID = (int)cmbOgrenciSinifi.SelectedValue;
                    selectedStudent.ImagePath = imagePath;

                    repoStudent.UpdateStudent(selectedStudent);
                    FillListView(repoStudent.GetList());
                    MessageBox.Show("Öğrenci bilgileri güncellenmiştir.");
                    HelperMethods.ControlsClear(grpOgrenciBilgileri);
                    HelperMethods.ControlsClear(grpOgrenciSinifBilgileri);
                }
            }

        }

        private void lstOgrenciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOgrenciler.SelectedItems.Count > 0)
            {
                selectedStudent = lstOgrenciler.SelectedItems[0].Tag as Student;
                txtOgrenciAdi.Text = selectedStudent.FirstName;
                txtOgrenciSoyadi.Text = selectedStudent.LastName;
                txtOgrenciMailAdresi.Text = selectedStudent.EMail;
                txtOgrenciCepTelefonu.Text = selectedStudent.Phone;
                dtOgrenciDTarihi.Value = selectedStudent.BirthDate;
                cmbOgrenciSinifi.SelectedItem = selectedStudent.Classes;
                lblOgrenciSubeAdi.Text = selectedStudent.Classes.Branch.BranchName;
                HelperMethods.LoadImage(pbxOgrenciResmi,selectedStudent.ImagePath);
            }
        }

        private void btnOgrenciSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Öğrenciyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                repoStudent.DeleteStudent(selectedStudent);
                FillListView(repoStudent.GetList());
                MessageBox.Show("Eğitim silinmiştir.");
                HelperMethods.ControlsClear(grpOgrenciBilgileri);
                HelperMethods.ControlsClear(grpOgrenciSinifBilgileri);
            }
        }

        private void btnOgrenciResimSec_Click(object sender, EventArgs e)
        {
            imagePath = HelperMethods.SaveImage(pbxOgrenciResmi,txtOgrenciAdi.Text);
        }

        private void btnOgrenciAramaYap_Click(object sender, EventArgs e)
        {
            if (HelperMethods.IsEmptyControl(grpAramaYap))
            {
                MessageBox.Show("Arama kriterlerini seçin");
            }
            else
            {
                int classesId = (int)cmbSinifaGoreAra.SelectedValue;
                FillListView(repoStudent.GetListBySearh(txtAdaGoreAra.Text, classesId));
            }
            
        }
    }
}
