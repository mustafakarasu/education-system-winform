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
    public partial class OgrenciEkleForm : Form
    {
        ClassesRepository repoClasses;
        StudentRepository repoStudent;
        string imagePath;
        User gelenKullanici;
        public OgrenciEkleForm(User gelen)
        {
            InitializeComponent();
            gelenKullanici = gelen;
        }

        private void OgrenciEkleForm_Load(object sender, EventArgs e)
        {
            repoClasses = new ClassesRepository();
            repoStudent = new StudentRepository();
            FillComboboxClassess();
            lblOgrenciSubeAdi.Text = gelenKullanici.Branch.BranchName;
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

        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            if (HelperMethods.IsEmptyControl(grpOgrenciBilgileri))
            {
                MessageBox.Show("Lütfen tüm gerekli alanları doldurunuz.");
            }
            else
            {
                Student student = new Student()
                {
                    FirstName = txtOgrenciAdi.Text,
                    LastName = txtOgrenciSoyadi.Text,
                    BirthDate = dtOgrenciDTarihi.Value,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Phone = txtOgrenciCepTelefonu.Text,
                    EMail = txtOgrenciMailAdresi.Text,
                    ImagePath = imagePath,
                    ClassesID = (int)cmbOgrenciSinifi.SelectedValue             
            };

                repoStudent.AddStudent(student);
                MessageBox.Show("Öğrenci kaydedilmiştir.");
                HelperMethods.ControlsClear(grpOgrenciBilgileri);
                HelperMethods.ControlsClear(grpOgrenciSinifBilgileri);
            }
        }

        private void btnOgrenciResimSec_Click(object sender, EventArgs e)
        {
            imagePath = HelperMethods.SaveImage(pbxOgrenciResmi, txtOgrenciAdi.Text);
        }
    }
}
