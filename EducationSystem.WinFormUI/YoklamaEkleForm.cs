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
    public partial class YoklamaEkleForm : Form
    {
        User _user;
        Classes classes;
        ClassesRepository repoClasses;
        BranchRepository repoBranch;     
        StudentPollRepository repoPoll;

        public YoklamaEkleForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void YoklamaEkleForm_Load(object sender, EventArgs e)
        {
            repoClasses = new ClassesRepository();
            repoBranch = new BranchRepository();
            repoPoll = new StudentPollRepository();
            cmbSiniflar.DataSource = repoClasses.GetListByInstructorId(_user.UserID);
            cmbSiniflar.DisplayMember = "ClassesCode";
            cmbSiniflar.ValueMember = "ClassesID";
            lblSubeAdi.Text = repoBranch.GetById(_user.BranchID).BranchName;
        }

        private void btnYoklamaBul_Click(object sender, EventArgs e)
        {
            flpYoklamaListesi.Controls.Clear();
            int classesId = (int)cmbSiniflar.SelectedValue;
            classes = repoClasses.GetById(classesId);
            bool girildiMi = repoPoll.GetByClassesIdAndPollDate(classes.ClassesID, dtpYoklamaTarihi.Value.Date).Count > 0;

            if (classes != null && !girildiMi)
            {
                FillTitles();
                FillChechkbox(false);
            }
            else
            {
                MessageBox.Show("Bu sınıfın yoklamaları girilmiştir.");
            }
        }

        private void FillTitles()
        {
            flpYoklamaListesi.Controls.Clear();
            flpYoklamaListesi.Width = 726;
            Label label = new Label();
            label.Text = "ÖĞRENCİ ADI SOYADI";
            label.AutoSize = false;
            label.Width = 200;
            flpYoklamaListesi.Controls.Add(label);
            int nameWidth = 400 / classes.LessonDailyTime;

            for (int i = 0; i < classes.LessonDailyTime; i++)
            {
                Label lbl = new Label();
                lbl.Text = "DERS " + (i + 1).ToString();
                lbl.Width = nameWidth;

                flpYoklamaListesi.Controls.Add(lbl);
            }
        }

        private void FillChechkbox(bool check)
        {        
            int checkWidth = 400 / classes.LessonDailyTime;

            foreach (Student item in classes.Students)
            {
                Label lbl = new Label();
                lbl.Text = item.FullName;
                lbl.AutoSize = false;
                lbl.Width = 220;
                flpYoklamaListesi.Controls.Add(lbl);
                for (int i = 0; i < classes.LessonDailyTime; i++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Name = item.FullName + (i + 1).ToString();
                    checkBox.Width = checkWidth;
                    checkBox.AutoSize = false;
                    checkBox.Checked = check;
                    flpYoklamaListesi.Controls.Add(checkBox);
                }
            }
        }

        private void btnTumunuSec_Click(object sender, EventArgs e)
        {
            FillTitles();
            FillChechkbox(true);
        }

        private void btnHicbiriniSecme_Click(object sender, EventArgs e)
        {
            FillTitles();
            FillChechkbox(false);
        }

        private void btnYoklamaGir_Click(object sender, EventArgs e)
        {
            foreach (Student item in classes.Students)
            {
                int geldigiSaatSayisi = 0;
                bool isHere = false;

                for (int i = 0; i < flpYoklamaListesi.Controls.Count; i++)
                {
                    if(flpYoklamaListesi.Controls[i] is CheckBox)
                    {
                        if (((CheckBox)flpYoklamaListesi.Controls[i]).Name.StartsWith(item.FullName))
                        {
                            geldigiSaatSayisi++;
                        }
                    }    
                }

                int gecmeSayisi = classes.LessonDailyTime % 2 == 0 ? classes.LessonDailyTime / 2 : (classes.LessonDailyTime / 2) + 1;

                if (geldigiSaatSayisi >= gecmeSayisi)
                {
                    isHere = true;
                }

                StudentPoll poll = new StudentPoll()
                {
                    PollDate = dtpYoklamaTarihi.Value.Date,
                    CreatedDate = DateTime.Now,
                    IsHere = isHere,
                    IsActive = true,
                    StudentID = item.StudentID,
                    ClassID = item.ClassesID               
                };
                
                repoPoll.AddStudentPoll(poll);

                if (!poll.IsHere)
                {
                    string icerik = item.FullName + " adlı öğrencimiz bugün dersse gelmemiştir";
                    HelperMethods.SendMail(item.EMail, "Yoklama Bilgisi", icerik);
                }
                
            }
            MessageBox.Show("Yoklama bilgileri girilmiştir.");
            flpYoklamaListesi.Controls.Clear();
        }
    }
}
