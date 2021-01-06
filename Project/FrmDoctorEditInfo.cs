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
    public partial class FrmDoctorEditInfo : Form
    {
        public FrmDoctorEditInfo()
        {
            InitializeComponent();
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }

        sqlconn bgl = new sqlconn();
        public string TCNO;
        private void FrmDoctorEditInfo_Load(object sender, EventArgs e)
        {
            mskTc.Text = TCNO;
            SqlCommand komut = new SqlCommand("select * from Tbl_Doctors where DoctorTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtName.Text = dr[1].ToString();
                txtSurname.Text = dr[2].ToString();
                cmbBranch.Text = dr[3].ToString();
                textBoxPassword.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnEditInf_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Doctors set DoctorName=@p1, DoctorSurname=@p2, DoctorBranch=@p3, DoctorPassword=@p4 where DoctorTc=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtName.Text);
            komut.Parameters.AddWithValue("@p2", txtSurname.Text);
            komut.Parameters.AddWithValue("@p3", cmbBranch.Text);
            komut.Parameters.AddWithValue("@p4", textBoxPassword.Text);
            komut.Parameters.AddWithValue("@p5", mskTc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Updated");
        }
    }
}
