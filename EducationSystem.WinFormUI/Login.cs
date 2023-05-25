using EducationSystem.WinFormUI;
using EducationSystem.DAL;
using EducationSystem.DAL.Migrations;
using EducationSystem.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationSystem.WinFormUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        EducationContext db;
        User user;
        private void Form1_Load(object sender, EventArgs e)
        {
            db = new EducationContext();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
        
            bool isValidEmail = HelperMethods.IsCheckEmailAddress(txtGirisMailAdresi.Text);

            if (!isValidEmail)
            {
                MessageBox.Show("Mail adresini doğru formatta giriniz.\n");
                return;
            }

            bool isValidPassword = HelperMethods.IsCheckPasswordLength(txtGirisParola.Text, out string message);

            if (!isValidPassword)
            {
                MessageBox.Show($"{message}\n");
                return;
            }

            user = db.Users.FirstOrDefault(x => x.Email == txtGirisMailAdresi.Text && x.Password == txtGirisParola.Text && x.IsActive == true);
            if (user == null)
            {
                MessageBox.Show("Mail adresi veya şifreniz yanlıştır.\nLütfen tekrar deneyiniz.");
            }
            else
            {
                UserRole userRole = user.UserRole;
                switch (userRole.UserRoleName)
                {
                    case "Yönetici":
                        YoneticiForm yoneticiForm = new YoneticiForm(user);
                        this.Hide();
                        yoneticiForm.Show();
                        break;
                    case "Koordinatör":
                        KoordinatorForm koordinatorForm = new KoordinatorForm(user);
                        this.Hide();
                        koordinatorForm.Show();
                        break;
                    case "Eğitmen":
                        EgitmenForm egitmenForm = new EgitmenForm(user);
                        this.Hide();
                        egitmenForm.Show();
                        break;
                }
            }
        }

        private void chkParolaGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (chkParolaGoster.Checked)
            {
                txtGirisParola.PasswordChar = '\0';
            }
            else
            {
                txtGirisParola.PasswordChar = '*';
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
