using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationSystem.WinFormUI
{
    public static class HelperMethods
    {
        public static void ChildForm(Form childForm, Form parentForm)
        {
            parentForm.Width = childForm.Width + 100;
            parentForm.Height = childForm.Height + 125;

            bool durum = false;

            foreach (Form form in parentForm.MdiChildren)
            {
                if (form.Text != childForm.Text)
                {
                    form.Close();
                }
                else
                {
                    durum = true;
                    form.Activate();
                }
            }

            if (durum == false)
            {
                childForm.MdiParent = parentForm;
                childForm.Show();
            }
        }

        public static bool IsEmptyControl(GroupBox grp)
        {
            foreach (Control item in grp.Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text == "")
                        return true;
                }
                else if (item is ComboBox)
                {
                    if (((ComboBox)item).SelectedIndex == -1)
                        return true;
                }
                //else if (item is DateTimePicker)
                //{
                //    if (((DateTimePicker)item).Value.Date == DateTime.Now.Date)
                //        return true;
                //}
                else if (item is NumericUpDown)
                {
                    if (((NumericUpDown)item).Value == 0)
                        return true;
                }
                else if (item is CheckedListBox)
                {
                    if (((CheckedListBox)item).CheckedItems.Count == 0)
                        return true;
                }

            }

            return false;
        }

        public static string MaskTextBoxClear(string text)
        {
            return text.Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty);
        }

        public static string SaveImage(PictureBox pictureBox, string firstName)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(Application.StartupPath + "\\images"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\images");
                }
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = new Bitmap(open.FileName);

                string fileName = firstName + Guid.NewGuid().ToString().Substring(1, 6).Replace("-", string.Empty);
                string imagePath = Application.StartupPath + "\\images\\" + fileName + ".jpeg";
                pictureBox.Image.Save(imagePath, ImageFormat.Jpeg);
                return imagePath;
            }
            return "";
        }

        public static void LoadImage(PictureBox pictureBox, string imagePath)
        {
            if (imagePath != null)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = Image.FromFile(imagePath);
            }
            else
            {
                pictureBox.Image = null;
            }

        }

        public static void ControlsClear(GroupBox grp)
        {
            foreach (Control item in grp.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = -1;
                }
                else if (item is DateTimePicker)
                {
                    ((DateTimePicker)item).Value = DateTime.Now.Date;
                }
                else if (item is NumericUpDown)
                {
                    ((NumericUpDown)item).Value = 0;
                }
                else if (item is PictureBox pbox)
                {
                    pbox.Image = null;
                }
            }
        }


        public static bool IsCheckPasswordLength(string password, out string message)
        {
            message = string.Empty;
            if (password.Length < 6)
            {
                message = "Şifre en az 6 karakterden oluşmalıdır.";
                return false;
            }
            else if (password.Length > 20)
            {
                message = "Şifre en fazla 20 karakter olmalıdır.";
                return false;
            }
            return true;
        }

        public static bool IsCheckEmailAddress(string email)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            return validateEmailRegex.IsMatch(email);
        }

        public static bool IsCheckBirthDate(DateTime birthDate)
        {
            var controlDate = DateTime.Now.Date.AddYears(-7);
            if (controlDate > birthDate)
            {
                return false;
            }

            return true;
        }

        public static bool SendMail(string MailAdresi, string MailKonu, string MailIcerik,string Pop3Host = "smtp.gmail.com", int Pop3Port=587, string MailHesabi = "ooverload.team@gmail.com", string MailHesapSifresi = "Olt124578.")
        {
            try
            {
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential(MailHesabi, MailHesapSifresi);
                

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(); 
                mail.From = new System.Net.Mail.MailAddress(MailHesabi); 
                mail.To.Add(MailAdresi); 
                mail.Subject = MailKonu;
                mail.IsBodyHtml = true; 
                mail.Body = MailIcerik; 
                mail.Attachments.Clear();
                

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(Pop3Host, Pop3Port); 
                smtp.UseDefaultCredentials = false; 
                smtp.EnableSsl = true; 
                smtp.Credentials = cred; 
                smtp.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
