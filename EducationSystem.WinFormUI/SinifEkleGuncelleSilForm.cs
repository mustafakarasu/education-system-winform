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
    public partial class SinifEkleGuncelleSilForm : Form
    {
        ClassesRepository repoClasses;
        UserRepository repoUser;
        UserRoleRepository repoUserRole;
        CourseRepository repoCourse;
        Classes selectedClasses;
        User _gelen;

        public SinifEkleGuncelleSilForm(User gelen)
        {
            InitializeComponent();
            _gelen = gelen;
        }

        private void SinifEkleGuncelleSilForm_Load(object sender, EventArgs e)
        {
            repoClasses = new ClassesRepository();
            repoUser = new UserRepository();
            repoUserRole = new UserRoleRepository();
            repoCourse = new CourseRepository();

            FillComboBoxInstructor();
            FillListView();
            FillComboBoxCourse();

            dtSinifBitisTarihi.Enabled = false;
            lblSubeAdi.Text = _gelen.Branch.BranchName;
        }

        private void FillComboBoxInstructor()
        {
            cmbSinifEgitmen.Items.Clear();
            int userRoleID = repoUserRole.GetByRoleName("Eğitmen").UserRoleID;
            cmbSinifEgitmen.DataSource = repoUser.GetListByUserRoleId(userRoleID);
            cmbSinifEgitmen.DisplayMember = "FullName";
            cmbSinifEgitmen.ValueMember = "UserID";
        }

        private void FillComboBoxCourse()
        {
            cmbSinifEgitim.Items.Clear();
            cmbSinifEgitim.DataSource = repoCourse.GetList();
            cmbSinifEgitim.DisplayMember = "FullCourseName";
            cmbSinifEgitim.ValueMember = "CourseID";
        }

        private void FillListView()
        {
            lstSubeSiniflar.Items.Clear();
            foreach (Classes item in repoClasses.GetList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.ClassesCode;
                Course course = repoCourse.GetById(item.CourseID);
                lvi.SubItems.Add(course.CourseName);
                lvi.SubItems.Add(item.StartCourseDate.ToShortDateString());
                lvi.SubItems.Add(item.EndCourseData.ToShortDateString());
                User egitmen = repoUser.GetById(item.InstructorID);
                lvi.SubItems.Add(egitmen.FullName);
                lvi.Tag = item;
                lstSubeSiniflar.Items.Add(lvi);
            }
        }

        private void btnSinifEkle_Click(object sender, EventArgs e)
        {
            if (HelperMethods.IsEmptyControl(grpSinifBilgileri) || HelperMethods.IsEmptyControl(grpEgitimBilgileri))
            {
                MessageBox.Show("Lütfen tüm gerekli alanları doldurunuz.");
            }
            else
            {
                Classes classes = new Classes()
                {
                    ClassesCode = txtSinifKodu.Text,
                    StartCourseDate = dtSinifBaslangicTarihi.Value,
                    EndCourseData = dtSinifBitisTarihi.Value,
                    CourseID = (cmbSinifEgitim.SelectedItem as Course).CourseID,
                    InstructorID = (cmbSinifEgitmen.SelectedItem as User).UserID,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    LessonDailyTime = (int)nmrEgitimSuresi.Value,
                    WeekDays = chkLbxEgitimGunleri.CheckedItems.Count,
                    BranchID = _gelen.BranchID,
                    
                };

                repoClasses.AddClasses(classes);
                FillListView();
                MessageBox.Show("Sınıf Bilgileri Kaydedilmiştir.");
                HelperMethods.ControlsClear(grpSinifBilgileri);
                HelperMethods.ControlsClear(grpEgitimBilgileri);
            }
        }

        private DateTime EndCourseDateCompute(int dayCount, int dayTime, int courseTime, DateTime startDate)
        {
            decimal weekCount = Math.Ceiling(Convert.ToDecimal(courseTime) / (dayCount * dayTime));
            double sumDays = (double)weekCount * 7;
            DateTime endDateStarting = startDate.AddDays(sumDays);

            return endDateStarting;

        }

        private void chkLbxEgitimGunleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillEndDateTimePicker();
        }

        private void FillEndDateTimePicker()
        {
            if (chkLbxEgitimGunleri.Items.Count > 0 && cmbSinifEgitim.SelectedIndex != -1)
            {
                int selectedDayCount = chkLbxEgitimGunleri.CheckedItems.Count;
                int selectedCourseTime = (cmbSinifEgitim.SelectedItem as Course).CourseTime;
                DateTime slectedStartDate = dtSinifBaslangicTarihi.Value;
                int selectedDayTime = (int)nmrEgitimSuresi.Value;
                if (!(selectedDayTime == 0 || selectedDayCount == 0))
                {
                    dtSinifBitisTarihi.MinDate = EndCourseDateCompute(selectedDayCount, selectedDayTime, selectedCourseTime, slectedStartDate).Date;

                }
            }
        }

        private void nmrEgitimSuresi_ValueChanged(object sender, EventArgs e)
        {
            FillEndDateTimePicker();
        }

        private void btnSinifGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Sınıf bilgilerini güncellemek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                selectedClasses.ClassesCode = txtSinifKodu.Text;
                selectedClasses.StartCourseDate = dtSinifBaslangicTarihi.Value;
                selectedClasses.EndCourseData = dtSinifBitisTarihi.Value;
                selectedClasses.CourseID = ((Course)cmbSinifEgitim.SelectedItem).CourseID;
                selectedClasses.InstructorID = (int)cmbSinifEgitmen.SelectedValue;
                selectedClasses.LessonDailyTime = (int)nmrEgitimSuresi.Value;
                selectedClasses.WeekDays = chkLbxEgitimGunleri.SelectedItems.Count;

                repoClasses.UpdateClasses(selectedClasses);
                FillListView();
                MessageBox.Show("Sınıf bilgileri güncellenmiştir.");
                HelperMethods.ControlsClear(grpSinifBilgileri);
                HelperMethods.ControlsClear(grpEgitimBilgileri);
            }
        }

        private void lstSubeSiniflar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSubeSiniflar.SelectedItems.Count > 0)
            {
                selectedClasses = (Classes)lstSubeSiniflar.SelectedItems[0].Tag;
                txtSinifKodu.Text = selectedClasses.ClassesCode;
                dtSinifBaslangicTarihi.Value = selectedClasses.StartCourseDate;
                dtSinifBitisTarihi.Value = selectedClasses.EndCourseData;
                Course course = repoCourse.GetById(selectedClasses.CourseID);
                cmbSinifEgitim.SelectedItem = course;
                User instructor = repoUser.GetById(selectedClasses.InstructorID);
                cmbSinifEgitmen.SelectedItem = instructor.FullName;
                nmrEgitimSuresi.Value = (int)selectedClasses.LessonDailyTime;
            }
        }

        private void btnSinifSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Sınıf bilgilerini silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                repoClasses.DeleteClasses(selectedClasses);
                FillListView();
                MessageBox.Show("Sınıf silinmiştir.");
                HelperMethods.ControlsClear(grpSinifBilgileri);
                HelperMethods.ControlsClear(grpEgitimBilgileri);
            }
        }

        private void txtSinifBaslangicSaati_TextChanged(object sender, EventArgs e)
        {
            if (txtSinifBaslangicSaati.Text.Length == 5)
            {
                int baslangicSaati = int.Parse(txtSinifBaslangicSaati.Text.Replace(":", string.Empty));
                int bitisSaati = baslangicSaati + (int)nmrEgitimSuresi.Value;
                txtSinifBitisSaati.Text = bitisSaati.ToString();
            }
            
        }
    }
}
