using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class FrmPatientLogin : Form
    {
        public FrmPatientLogin()
        {
            InitializeComponent();
        }

        private void FrmPatientLogin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPatientSign fr = new FrmPatientSign();
            fr.Show();
        }

        sqlconn bgl = new sqlconn();
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(" Select * from Tbl_Patients where PatientTC=@p1 and PatientPassword=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            komut.Parameters.AddWithValue("@p2", textBoxPassword.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                FrmPatientDetail fr = new FrmPatientDetail();
                fr.tc = mskTc.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(" Incorrect Tc or Password");
            }
            bgl.baglanti().Close();
        }
    }
}
