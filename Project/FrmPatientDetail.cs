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
    public partial class FrmPatientDetail : Form
    {
        public FrmPatientDetail()
        {
            InitializeComponent();
        }
        public string tc;
        sqlconn bgl = new sqlconn();
        private void FrmPatientDetail_Load(object sender, EventArgs e)
        {

            lblTc.Text = tc;
            // Ad Soyad çekme
            SqlCommand komut = new SqlCommand("select PatientName,PatientSurname from Tbl_Patients where PatientTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lblNameSurname.Text = dr[0] + "  " + dr[1];
            }
            bgl.baglanti().Close();

            // Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Appointment where PatientTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            // Branşları Çekme
            SqlCommand komut2 = new SqlCommand("Select BranchName from Tbl_Branchs", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                cmbBranch.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

           
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select DoctorName, DoctorSurname from Tbl_Doctors where DoctorBranch=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbBranch.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while(dr3.Read())
            {
                cmbDoctor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Appointment where AppointmentBranch= '"+ cmbBranch.Text + "'" + " and AppointmentDoctor= '" + cmbDoctor.Text + "' and AppointmentStatus=0", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void linkLabelEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmEditInformation fr = new FrmEditInformation();
            fr.TCno = lblTc.Text;
            fr.Show();  
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView2.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView2.Rows[sec].Cells[0].Value.ToString();
        }

        private void btnMakeAppo_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Appointment set AppointmentStatus=1, PatientTc=@p1, PatientComplaint=@p2 where AppointmentId=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTc.Text);
            komut.Parameters.AddWithValue("@p2", richTextComplaint.Text);
            komut.Parameters.AddWithValue("@p3", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Appointment is created");
        }
    }
}
