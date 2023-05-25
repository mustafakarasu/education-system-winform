using EducationSystem.WinFormUI;
using EducationSystem.DAL.Repositories;
using EducationSystem.DATA;
using PdfSharp.Drawing;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace EducationSystem.WinFormUI
{
    public partial class SubeRaporForm : Form
    {
        BranchRepository repoBranch;
        UserRepository repoUser;
        UserRoleRepository repoUserRole;
        StudentRepository repoStudent;
        ClassesRepository repoClasses;
        User _user;

        public SubeRaporForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void SubeRaporForm_Load(object sender, EventArgs e)
        {
            repoBranch = new BranchRepository();
            repoUser = new UserRepository();
            repoUserRole = new UserRoleRepository();
            repoStudent = new StudentRepository();
            repoClasses = new ClassesRepository();

            cmbSube.DataSource = repoBranch.GetList();
            cmbSube.DisplayMember = "BranchName";
            cmbSube.ValueMember = "BranchID";

            if (repoUserRole.GetByRoleName("Yönetici").UserRoleID == _user.UserRoleID)
            {
                cmbSube.Enabled = true;
                
            }
            else if (repoUserRole.GetByRoleName("Koordinatör").UserRoleID == _user.UserRoleID)
            {
                cmbSube.Enabled = false;          
                cmbSube.SelectedValue = _user.BranchID;
                RaporDoldur(_user.BranchID);
            }
        }


        private void RaporDoldur(int branchID)
        {
            int branchId = branchID;
            int studentCount = 0;
            int lessonTime = 0;
            int coordinatorCount = repoUser.GetListByUserRoleId(repoUserRole.GetByRoleName("Koordinatör").UserRoleID).Count();
            int instructorCount = repoUser.GetListByUserRoleId(repoUserRole.GetByRoleName("Eğitmen").UserRoleID).Count();
            
            foreach (Classes item in repoClasses.GetListByBranchId(branchId))
            {
                studentCount += repoStudent.GetListByClassesId(item.ClassesID).Count();
            }
      
            int classesCount = repoClasses.GetListByBranchId(branchId).Count();

            foreach (Classes classes in repoClasses.GetListByBranchId(branchId))
            {
                lessonTime += classes.Course.CourseTime;
            }

            double ortalama = Convert.ToDouble(lessonTime) / instructorCount;

            lblKoordinatorSayisi.Text = coordinatorCount.ToString();
            lblEgitmenSayisi.Text = instructorCount.ToString();
            lblOgrenciSayisi.Text = studentCount.ToString();
            lblSinifSayisi.Text = classesCount.ToString();
            lblVerilenDersSaati.Text = lessonTime.ToString();
            lblDersOrtalamasi.Text = ortalama.ToString();
        }

        private void btnPDFKaydet_Click(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12, XFontStyle.Regular);

            gfx.DrawString("Koordinator Sayısı : ", font, XBrushes.Black, new XPoint(60, 50), XStringFormats.TopLeft);
            gfx.DrawString(lblKoordinatorSayisi.Text, font, XBrushes.Black, new XPoint(160, 50), XStringFormats.TopLeft);
            gfx.DrawString("Eğitmen Sayısı : ", font, XBrushes.Black, new XPoint(60, 70), XStringFormats.TopLeft);
            gfx.DrawString(lblEgitmenSayisi.Text, font, XBrushes.Black, new XPoint(160, 70), XStringFormats.TopLeft);
            gfx.DrawString("Öğrenci Sayısı : ", font, XBrushes.Black, new XPoint(60, 90), XStringFormats.TopLeft);
            gfx.DrawString(lblOgrenciSayisi.Text, font, XBrushes.Black, new XPoint(160, 90), XStringFormats.TopLeft);
            gfx.DrawString("Sınıf Sayısı : ", font, XBrushes.Black, new XPoint(60, 110), XStringFormats.TopLeft);
            gfx.DrawString(lblSinifSayisi.Text, font, XBrushes.Black, new XPoint(160, 110), XStringFormats.TopLeft);
            gfx.DrawString("Verilen Ders Saati : ", font, XBrushes.Black, new XPoint(60, 130), XStringFormats.TopLeft);
            gfx.DrawString(lblVerilenDersSaati.Text, font, XBrushes.Black, new XPoint(160, 130), XStringFormats.TopLeft);
            gfx.DrawString("Verilen Ders / Eğitmen Ortalaması : ", font, XBrushes.Black, new XPoint(60, 150), XStringFormats.TopLeft);
            gfx.DrawString(lblDersOrtalamasi.Text, font, XBrushes.Black, new XPoint(200, 150), XStringFormats.TopLeft);


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

            xlWorksheet.Cells[1, 1] = "Koordinator Sayısı";
            xlWorksheet.Cells[1, 2] = lblKoordinatorSayisi.Text;
            xlWorksheet.Cells[2, 1] = "Eğitmen Sayısı";
            xlWorksheet.Cells[2, 2] = lblEgitmenSayisi.Text;
            xlWorksheet.Cells[3, 1] = "Öğrenci Sayısı";
            xlWorksheet.Cells[3, 2] = lblOgrenciSayisi.Text;
            xlWorksheet.Cells[4, 1] = "Sınıf Sayısı";
            xlWorksheet.Cells[4, 2] = lblSinifSayisi.Text;
            xlWorksheet.Cells[4, 1] = "Verilen Ders Saati";
            xlWorksheet.Cells[4, 2] = lblVerilenDersSaati.Text;
            xlWorksheet.Cells[4, 1] = "Verilen Ders / Eğitmen Ortalaması";
            xlWorksheet.Cells[4, 2] = lblDersOrtalamasi.Text;



            xlApp.ActiveWorkbook.SaveAs(Application.StartupPath + @"\" + _user.FirstName + DateTime.Now.DayOfWeek + ".xlsx", Excel.XlFileFormat.xlWorkbookNormal);


            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorksheet);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkbook);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
