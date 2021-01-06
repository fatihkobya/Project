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
    public partial class FrmSecretaryDetail : Form
    {
        public FrmSecretaryDetail()
        {
            InitializeComponent();
        }

        public string TcNumber;
        sqlconn bgl = new sqlconn();
        private void FrmSecretaryDetail_Load(object sender, EventArgs e)
        {
            lbltc.Text = TcNumber;

            // Ad Soyad

            SqlCommand komut1 = new SqlCommand("Select SecretaryNameSurname from Tbl_Secretaries where SecretaryTc=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read())
            {
                lblNameSurname.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();



            // Branşları data gride aktarma

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branchs", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;


            // Doktorları datagride aktarma

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select DoctorName,DoctorSurname from Tbl_Doctors", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            // Bransşı comboboxa aktarma

            SqlCommand komut3 = new SqlCommand("select BranchName from Tbl_Branchs", bgl.baglanti());
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranch.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand komutsave = new SqlCommand("Insert into Tbl_Appointment(AppointmentDate, AppointmentTime, AppointmentBranch, AppointmentDoctor) values(@p1, @p2, @p3, @p4)", bgl.baglanti());
            komutsave.Parameters.AddWithValue("@p1", mskDate.Text);
            komutsave.Parameters.AddWithValue("@p2", mskTime.Text);
            komutsave.Parameters.AddWithValue("@p3", cmbBranch.Text);
            komutsave.Parameters.AddWithValue("@p4", cmbDoctor.Text);
            komutsave.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Your appointment is created");

        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Items.Clear();

            SqlCommand komutt = new SqlCommand("select DoctorName, DoctorSurname from Tbl_Doctors where DoctorBranch=@p1", bgl.baglanti());
            komutt.Parameters.AddWithValue("@p1", cmbBranch.Text);
            SqlDataReader dr = komutt.ExecuteReader();
            while (dr.Read())
            {
                cmbDoctor.Items.Add(dr[0] + " " + dr[1]);

            }
            bgl.baglanti().Close();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand komuttt = new SqlCommand("insert into Tbl_Announcements (Announcment) values (@p1)", bgl.baglanti());
            komuttt.Parameters.AddWithValue("@p1", richAnnounc.Text);
            komuttt.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Announcements is created.");
        }

        private void btnDoctorPanel_Click(object sender, EventArgs e)
        {
            FrmDoctorPanel drp = new FrmDoctorPanel();
            drp.Show();

        }

        private void btnBranchPanel_Click(object sender, EventArgs e)
        {
            FrmBranch fbr = new FrmBranch();
            fbr.Show();
        }

        private void btnAppointmentList_Click(object sender, EventArgs e)
        {
            FrmAppointmentList fra = new FrmAppointmentList();
            fra.Show();
        }

    

    }
}
