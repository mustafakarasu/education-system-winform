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
    public partial class EgitimEkleGuncelleSilForm : Form
    {
        CourseRepository repoCourse;
        Course selectedCourse;
        public EgitimEkleGuncelleSilForm()
        {
            InitializeComponent();
            
        }

        private void EgitimEkleGuncelleSilForm_Load(object sender, EventArgs e)
        {
            repoCourse = new CourseRepository();
            FillListView();
        }

        private void btnEgitimEkle_Click(object sender, EventArgs e)
        {
            if (HelperMethods.IsEmptyControl(grpEgitimBilgileri))
            {
                MessageBox.Show("Gerekli bütün alanları doldurunuz.");
            }
            else
            {
                Course course = new Course()
                {
                    CourseName = txtEgitimAdi.Text,
                    CourseTime = (int)nmrDersSuresi.Value,
                    Description = txtEgitimAciklama.Text,
                    CreatedDate = DateTime.Now,
                    IsActive = true             
                };

                repoCourse.AddCourse(course);
                FillListView();
                MessageBox.Show("Eğitim bilgileri eklenmiştir.");
            }
        }

        private void FillListView()
        {
            lstEgitimListesi.Items.Clear();
            foreach (Course item in repoCourse.GetList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.CourseName;
                lvi.SubItems.Add(item.CourseTime.ToString());
                lvi.SubItems.Add(item.Description);
                lvi.Tag = item;
                lstEgitimListesi.Items.Add(lvi);
            }
        }

        private void lstEgitimListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEgitimListesi.SelectedItems.Count > 0)
            {
                selectedCourse = lstEgitimListesi.SelectedItems[0].Tag as Course;
                txtEgitimAdi.Text = selectedCourse.CourseName;
                txtEgitimAciklama.Text = selectedCourse.Description;
                nmrDersSuresi.Value = (int)selectedCourse.CourseTime;
            }
        }

        private void btnEgitimGuncelle_Click(object sender, EventArgs e)
        {
            if (HelperMethods.IsEmptyControl(grpEgitimBilgileri))
            {
                MessageBox.Show("Gerekli bütün alanları doldurunuz.");
            }
            else
            {
                selectedCourse.CourseName = txtEgitimAdi.Text;
                selectedCourse.Description = txtEgitimAciklama.Text;
                selectedCourse.CourseTime = (int)nmrDersSuresi.Value;
                repoCourse.UpdateCourse(selectedCourse);
                FillListView();
                MessageBox.Show("Eğitim bilgileri güncellenmiştir.");
            }
        }

        private void btnEgitimSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Eğitimi silmek istediğinize emin misiniz?","Uyarı",MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                repoCourse.DeleteCourse(selectedCourse);
                FillListView();
                MessageBox.Show("Eğitim silinmiştir.");
            }
        }

       
    }
}
