using EducationSystem.WinFormUI;
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
    public partial class EgitmenForm : Form
    {
        User _user;
        public EgitmenForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void tsmYoklamaGir_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new YoklamaEkleForm(_user), this);
        }

        private void tsmSinifRaporu_Click(object sender, EventArgs e)
        {
            HelperMethods.ChildForm(new SinifRaporForm(_user), this);
        }
    }
}
