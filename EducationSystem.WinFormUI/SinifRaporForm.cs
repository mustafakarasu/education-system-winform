using EducationSystem.WinFormUI;
using EducationSystem.DAL.Repositories;
using EducationSystem.DATA;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
using Excel = Microsoft.Office.Interop.Excel;

namespace EducationSystem.WinFormUI
{
    public partial class SinifRaporForm : Form
    {
        BranchRepository repoBranch;
        UserRepository repoUser;
        UserRoleRepository repoUserRole;
        StudentRepository repoStudent;
        ClassesRepository repoClasses;
        CourseRepository repoCourse;
        StudentPollRepository repoPoll;
        User _user;

        public SinifRaporForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void SinifRaporForm_Load(object sender, EventArgs e)
        {
            repoBranch = new BranchRepository();
            repoUser = new UserRepository();
            repoUserRole = new UserRoleRepository();
            repoStudent = new StudentRepository();
            repoClasses = new ClassesRepository();
            repoCourse = new CourseRepository();
            repoPoll = new StudentPollRepository();

            cmbSubeSec.DisplayMember = "BranchName";
            cmbSubeSec.ValueMember = "BranchID";

            cmbSinifSec.DisplayMember = "ClassesCode";
            cmbSinifSec.ValueMember = "ClassesID";

            if (_user.UserRoleID == repoUserRole.GetByRoleName("Yönetici").UserRoleID)
            {
                cmbSubeSec.DataSource = repoBranch.GetList();
                cmbSubeSec.Enabled = true;
            }
            else
            {
                cmbSubeSec.DataSource = repoBranch.GetListById(_user.BranchID);
                cmbSubeSec.SelectedValue = _user.BranchID;
                cmbSubeSec.Enabled = false;
            }
        }

        private void cmbSubeSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubeSec.SelectedIndex != -1)
            {
                int branchId = (int)cmbSubeSec.SelectedValue;
                cmbSinifSec.DataSource = repoClasses.GetListByBranchId(branchId);
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (cmbSubeSec.SelectedIndex != -1 && cmbSinifSec.SelectedIndex != -1)
            {
                int classessId = (int)cmbSinifSec.SelectedValue;
                lblYapilanDersSaati.Text = CompleteLessonTime(classessId).ToString();
                int instructorId = repoClasses.GetById(classessId).InstructorID;
                lblEgitmen.Text = repoUser.GetById(instructorId).FullName;
                lblKalanDersSaati.Text = RemainderLessonTime(classessId).ToString();
                lblOgrenciSayisi.Text = repoStudent.GetListByClassesId(classessId).Count.ToString();
                FillListView(classessId);
            }
            else
            {
                MessageBox.Show("Lütfen tüm filtereleme alanları seçiniz");
            }
        }

        private double CompleteLessonTime(int classesId)
        {
            DateTime girilenSonTarih = repoPoll.GetListByClassesId(classesId).OrderByDescending(x => x.PollDate).FirstOrDefault().PollDate;
            Classes classes = repoClasses.GetById(classesId);
            double gecenHaftaSayisi = (girilenSonTarih - classes.StartCourseDate).TotalDays / 7.0;
            double yoklamaGunSayisi = Math.Ceiling(gecenHaftaSayisi * classes.WeekDays);
            return yoklamaGunSayisi * (classes.LessonDailyTime);
        }

        private double RemainderLessonTime(int classesId)
        {
            DateTime girilenSonTarih = repoPoll.GetListByClassesId(classesId).OrderByDescending(x => x.PollDate).FirstOrDefault().PollDate;
            Classes classes = repoClasses.GetById(classesId);
            double kalanHaftaSayisi = (classes.EndCourseData - girilenSonTarih).TotalDays / 7.0;
            double kalanGunSayisi = Math.Ceiling(kalanHaftaSayisi * classes.WeekDays);
            return kalanGunSayisi * (classes.LessonDailyTime);
        }

        private void FillListView(int classedId)
        {
            lstYoklamalar.Items.Clear();
            List<Student> students = repoStudent.GetListByClassesId(classedId);
            for (int i = 0; i < students.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = (i + 1).ToString();
                lvi.SubItems.Add(students[i].FullName);
                double bulunduguSaatSayisi = LessonTimeHere(classedId, students[i].StudentID, out double sumDays);
                double katilmaYuzdesi = Math.Round(((bulunduguSaatSayisi / sumDays) * 100.0), 2);
                lvi.SubItems.Add(katilmaYuzdesi.ToString());
                lvi.SubItems.Add(bulunduguSaatSayisi.ToString());
                lvi.Tag = students[i];
                lstYoklamalar.Items.Add(lvi);
            }

        }

        private double LessonTimeHere(int classesId, int studentId, out double sumDays)
        {
            double bulunduguGunSayisi = 0;
            double toplamGunSayisi = 0;
            Classes classes = repoClasses.GetById(classesId);

            foreach (StudentPoll item in repoPoll.GetListByClassesIdAndStudentId(classesId, studentId))
            {
                bulunduguGunSayisi += (item.IsHere ? 1 : 0);
            }

            sumDays = toplamGunSayisi * (classes.LessonDailyTime);

            return bulunduguGunSayisi * (classes.LessonDailyTime);
        }

        private void btnPDFKaydet_Click(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12, XFontStyle.Regular);

            gfx.DrawString("Yapılan Ders Saati : ", font, XBrushes.Black, new XPoint(40, 50), XStringFormats.TopLeft);
            gfx.DrawString(lblYapilanDersSaati.Text, font, XBrushes.Black, new XPoint(160, 50), XStringFormats.TopLeft);
            gfx.DrawString("Öğrenci Sayısı : ", font, XBrushes.Black, new XPoint(220, 50), XStringFormats.TopLeft);
            gfx.DrawString(lblOgrenciSayisi.Text, font, XBrushes.Black, new XPoint(320, 50), XStringFormats.TopLeft);

            gfx.DrawString("Kalan Ders Saati : ", font, XBrushes.Black, new XPoint(40, 70), XStringFormats.TopLeft);
            gfx.DrawString(lblKalanDersSaati.Text, font, XBrushes.Black, new XPoint(160, 70), XStringFormats.TopLeft);
            gfx.DrawString("Eğitmen : ", font, XBrushes.Black, new XPoint(220, 70), XStringFormats.TopLeft);
            gfx.DrawString(lblEgitmen.Text, font, XBrushes.Black, new XPoint(300, 70), XStringFormats.TopLeft);

            string header = $"Sıra No{new string(' ', 3)}Öğrenci Adı Soyadı{new string(' ', 3)}Katıldığı Ders Saati{new string(' ', 3)}Devam Durumu(%)";

            gfx.DrawString(header, font, XBrushes.Black, new XRect(40, 100, page.Width, page.Height), XStringFormats.TopLeft);
            double x_point = 40;
            double y_point = 120;
            foreach (ListViewItem item in lstYoklamalar.Items)
            {
                foreach (ListViewSubItem subItem in item.SubItems)
                {
                    gfx.DrawString(subItem.Text, font, XBrushes.Black, new XPoint(x_point, y_point), XStringFormats.TopLeft);
                    x_point += 80;
                }
                x_point = 40;
                y_point += 20;

            }

            string filename = "deneme.pdf";
            document.Save(filename);
            Process.Start(filename);
        }

        private void btnExcelKaydet_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            object Missing = System.Reflection.Missing.Value;
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Missing);
            Excel._Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
            Excel.Range xlRange = xlWorksheet.UsedRange;
            xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;

            xlApp.Visible = true;
            xlApp.AlertBeforeOverwriting = false;

            xlWorksheet.Cells[1, 1] = "Yapılan Ders Saati";
            xlWorksheet.Cells[1, 2] = lblYapilanDersSaati.Text;
            xlWorksheet.Cells[2, 1] = "Öğrenci Sayısı";
            xlWorksheet.Cells[2, 2] = lblOgrenciSayisi.Text;
            xlWorksheet.Cells[3, 1] = "Kalan Ders Saati";
            xlWorksheet.Cells[3, 2] = lblKalanDersSaati.Text;
            xlWorksheet.Cells[4, 1] = "Eğitmen";
            xlWorksheet.Cells[4, 2] = lblEgitmen.Text;

            xlWorksheet.Cells[7, 1] = "Sıra No";
            xlWorksheet.Cells[7, 2] = "Öğrenci Adı Soyadı";
            xlWorksheet.Cells[7, 3] = "Katıldığı Ders Saati";
            xlWorksheet.Cells[7, 4] = "Devam Durumu (%)";

            int row = 8;
            int col = 1;
            foreach (ListViewItem item in lstYoklamalar.Items)
            {
                foreach (ListViewSubItem subItem in item.SubItems)
                {
                    xlWorksheet.Cells[row, col] = subItem.Text;
                    col += 1;
                }
                col = 1;
                row += 1;
            }

            xlApp.ActiveWorkbook.SaveAs(Application.StartupPath + @"\" + _user.FirstName + DateTime.Now.DayOfWeek + ".xlsx", Excel.XlFileFormat.xlWorkbookNormal);


            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorksheet);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkbook);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
