using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class FirstPage : Form
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPatientLogin_Click(object sender, EventArgs e)
        {
            FrmPatientLogin fr = new FrmPatientLogin();
            fr.Show();
            this.Hide();
        }

        private void btnDoctorLogin_Click(object sender, EventArgs e)
        {
            FrmDoctorLogin fr = new FrmDoctorLogin();
            fr.Show();
            this.Hide();
        }

        private void btnSecLogin_Click(object sender, EventArgs e)
        {
            FrmSecretaryLogin fr = new FrmSecretaryLogin();
            fr.Show();
            this.Hide();
        }
    }
}
