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
    public partial class FrmDoctorDetail : Form
    {
        public FrmDoctorDetail()
        {
            InitializeComponent();
        }


        sqlconn bgl = new sqlconn();
        public string TC;
        private void FrmDoctorDetail_Load(object sender, EventArgs e)
        {
            lblDoctorTc.Text = TC;

            // Doctor Ad Soyad çekme

            SqlCommand komut = new SqlCommand("select DoctorName, DoctorSurname from Tbl_Doctors where DoctorTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblDoctorTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblDoctorNameSurname.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();


            // Randevular

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Appointment where AppointmentDoctor='" + lblDoctorNameSurname.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            FrmDoctorEditInfo frd = new FrmDoctorEditInfo();
            frd.TCNO = lblDoctorTc.Text;
            frd.Show();

        }

        private void btnannounc_Click(object sender, EventArgs e)
        {
            FrmAnnouncments fr = new FrmAnnouncments();
            fr.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
