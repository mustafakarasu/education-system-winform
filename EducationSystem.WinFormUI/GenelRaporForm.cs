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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace EducationSystem.WinFormUI
{
    public partial class GenelRaporForm : Form
    {
        BranchRepository repoBranch;
        UserRepository repoUser;
        UserRoleRepository repoUserRole;
        StudentRepository repoStudent;
        ClassesRepository repoClasses;
        CourseRepository repoCourse;
        User _user;

        public GenelRaporForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void GenelRaporForm_Load(object sender, EventArgs e)
        {
            repoBranch = new BranchRepository();
            repoUser = new UserRepository();
            repoUserRole = new UserRoleRepository();
            repoStudent = new StudentRepository();
            repoClasses = new ClassesRepository();
            repoCourse = new CourseRepository();

            int yoneticiSayisi = repoUser.GetListByUserRoleId(repoUserRole.GetByRoleName("Yönetici").UserRoleID).Count;
            int subeSayisi = repoBranch.GetList().Count;
            int koordinatorSayisi = repoUser.GetListByUserRoleId(repoUserRole.GetByRoleName("Koordinatör").UserRoleID).Count;
            int egitmenSayisi = repoUser.GetListByUserRoleId(repoUserRole.GetByRoleName("Eğitmen").UserRoleID).Count;
            int ogrenciSayisi = repoStudent.GetList().Count;
            int egitimSayisi = repoCourse.GetList().Count;

            double verilenDersSaati = 0;
            foreach (Classes classes in repoClasses.GetList())
            {
                verilenDersSaati += classes.Course.CourseTime;
            }

            double subeOrtalamasi = verilenDersSaati / subeSayisi;
            double egitmenOrtalamasi = verilenDersSaati / egitimSayisi;

            string textSubeOrtalamasi = double.IsNaN(subeOrtalamasi) ? "0" : subeOrtalamasi.ToString();
            string textEgitmenOrtalamasi = double.IsNaN(egitmenOrtalamasi) ? "0" : egitmenOrtalamasi.ToString();

            lblYoneticiSayisi.Text = yoneticiSayisi.ToString();
            lblSubeSayisi.Text = subeSayisi.ToString();
            lblKoordinatorSayisi.Text = koordinatorSayisi.ToString();
            lblEgitmenSayisi.Text = egitmenSayisi.ToString();
            lblOgrenciSayisi.Text = ogrenciSayisi.ToString();
            lblEgitimSayisi.Text = egitimSayisi.ToString();
            lblVerilenDersSaati.Text = verilenDersSaati.ToString();
            lblSubeOrtalamasi.Text = textSubeOrtalamasi;
            lblEgitmenOrtalamasi.Text = textEgitmenOrtalamasi;

        }

        private void btnPDFKaydet_Click(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12, XFontStyle.Regular);

            gfx.DrawString("Yönetici Sayısı : ", font, XBrushes.Black, new XPoint(20, 50), XStringFormats.TopLeft);
            gfx.DrawString(lblYoneticiSayisi.Text, font, XBrushes.Black, new XPoint(120, 50), XStringFormats.TopLeft);
            gfx.DrawString("Eğitim Sayısı : ", font, XBrushes.Black, new XPoint(160, 50), XStringFormats.TopLeft);
            gfx.DrawString(lblEgitimSayisi.Text, font, XBrushes.Black, new XPoint(260, 50), XStringFormats.TopLeft);
            gfx.DrawString("Şube Sayısı : ", font, XBrushes.Black, new XPoint(20, 70), XStringFormats.TopLeft);
            gfx.DrawString(lblOgrenciSayisi.Text, font, XBrushes.Black, new XPoint(120, 70), XStringFormats.TopLeft);
            gfx.DrawString("Verilen Ders Saati : ", font, XBrushes.Black, new XPoint(160, 70), XStringFormats.TopLeft);
            gfx.DrawString(lblVerilenDersSaati.Text, font, XBrushes.Black, new XPoint(260, 70), XStringFormats.TopLeft);
            gfx.DrawString("Koordinatör Sayısı : ", font, XBrushes.Black, new XPoint(20, 90), XStringFormats.TopLeft);
            gfx.DrawString(lblKoordinatorSayisi.Text, font, XBrushes.Black, new XPoint(120, 90), XStringFormats.TopLeft);
            gfx.DrawString("Verilen Ders / Şube Ortalaması : ", font, XBrushes.Black, new XPoint(160, 90), XStringFormats.TopLeft);
            gfx.DrawString(lblSubeOrtalamasi.Text, font, XBrushes.Black, new XPoint(320, 90), XStringFormats.TopLeft);
            gfx.DrawString("Eğitmen Sayısı : ", font, XBrushes.Black, new XPoint(20, 110), XStringFormats.TopLeft);
            gfx.DrawString(lblEgitmenSayisi.Text, font, XBrushes.Black, new XPoint(120, 110), XStringFormats.TopLeft);
            gfx.DrawString("Öğrenci Sayısı : ", font, XBrushes.Black, new XPoint(160, 110), XStringFormats.TopLeft);
            gfx.DrawString(lblOgrenciSayisi.Text, font, XBrushes.Black, new XPoint(260, 110), XStringFormats.TopLeft);
            gfx.DrawString("Verilen Ders / Eğitmen Ortalaması : ", font, XBrushes.Black, new XPoint(20, 130), XStringFormats.TopLeft);
            gfx.DrawString(lblEgitmenOrtalamasi.Text, font, XBrushes.Black, new XPoint(220, 130), XStringFormats.TopLeft);


            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderDialog.ShowNewFolderButton = true;
            
            string seciliKlasorYolu = "";
            string fileName = "";

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                seciliKlasorYolu = folderDialog.SelectedPath;
                fileName = seciliKlasorYolu + DateTime.Now.ToLongDateString();        
                document.Save(fileName);
                Process.Start(fileName);
            }
            else
            {
                MessageBox.Show("Hiçbir Klasör Seçilmedi");
            }        
        }

        private void button1_Click(object sender, EventArgs e)
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

            xlWorksheet.Cells[1, 1] = "Yönetici Sayısı";
            xlWorksheet.Cells[1, 2] = lblYoneticiSayisi.Text;
            xlWorksheet.Cells[2, 1] = "Eğitim Sayısı";
            xlWorksheet.Cells[2, 2] = lblEgitimSayisi.Text;
            xlWorksheet.Cells[3, 1] = "Şube Sayısı";
            xlWorksheet.Cells[3, 2] = lblSubeSayisi.Text;
            xlWorksheet.Cells[4, 1] = "Verilen Ders Saati";
            xlWorksheet.Cells[4, 2] = lblVerilenDersSaati.Text;
            xlWorksheet.Cells[5, 1] = "Koordinatör Sayısı";
            xlWorksheet.Cells[5, 2] = lblKoordinatorSayisi.Text;
            xlWorksheet.Cells[6, 1] = "Verilen Ders / Şube Ortalaması";
            xlWorksheet.Cells[6, 2] = lblSubeOrtalamasi.Text;
            xlWorksheet.Cells[7, 1] = "Eğitmen Sayısı";
            xlWorksheet.Cells[7, 2] = lblEgitimSayisi.Text;
            xlWorksheet.Cells[8, 1] = "Öğrenci Sayısı";
            xlWorksheet.Cells[8, 2] = lblOgrenciSayisi.Text;
            xlWorksheet.Cells[9, 1] = "Verilen Ders / Eğitmen Ortalaması";
            xlWorksheet.Cells[9, 2] = lblEgitmenOrtalamasi.Text;

            xlApp.ActiveWorkbook.SaveAs(Application.StartupPath + @"\"+ _user.FirstName + DateTime.Now.DayOfWeek +".xlsx", Excel.XlFileFormat.xlWorkbookNormal);

            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorksheet);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkbook);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
    }
}
