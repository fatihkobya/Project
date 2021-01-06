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
    public partial class FrmEditInformation : Form
    {
        public FrmEditInformation()
        {
            InitializeComponent();
        }
        public string TCno;
        sqlconn bgl = new sqlconn();
        private void FrmEditInformation_Load(object sender, EventArgs e)
        {
            mskTc.Text = TCno;

            SqlCommand komut = new SqlCommand("select * from Tbl_Patients where PatientTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                txtName.Text = dr[1].ToString();
                txtSurname.Text = dr[2].ToString();
                mskTel.Text = dr[4].ToString();
                textBoxPassword.Text = dr[5].ToString();
                cmbGender.Text = dr[6].ToString();

            }
            bgl.baglanti().Close();
        }

        private void btnEditInf_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand(" update Tbl_Patients set PatientName=@p1, PatientSurname=@p2, PatientTel=@p3, PatientPassword=@p4,PatientGender=@p5 where PatientTC=@p6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtName.Text);
            komut2.Parameters.AddWithValue("@p2", txtSurname.Text);
            komut2.Parameters.AddWithValue("@p3", mskTel.Text);
            komut2.Parameters.AddWithValue("@p4", textBoxPassword.Text);
            komut2.Parameters.AddWithValue("@p5", cmbGender.Text);
            komut2.Parameters.AddWithValue("@p6", mskTc.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Your information updated.");

        }
    }
}
