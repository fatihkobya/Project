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
    public partial class FrmDoctorPanel : Form
    {
        public FrmDoctorPanel()
        {
            InitializeComponent();
        }

        sqlconn bgl = new sqlconn();
        private void FrmDoctorPanel_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Tbl_Doctors", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            // Branşları Comboboxa aktarma
            SqlCommand komut3 = new SqlCommand("select BranchName from Tbl_Branchs", bgl.baglanti());
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranch.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Doctors (DoctorName,DoctorSurname,DoctorBranch,DoctorTc,DoctorPassword) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtName.Text);
            komut.Parameters.AddWithValue("@p2", textBoxSurname.Text);
            komut.Parameters.AddWithValue("@p3", cmbBranch.Text);
            komut.Parameters.AddWithValue("@p4", mskTc.Text);
            komut.Parameters.AddWithValue("@p5", textBoxPassword.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doctor is added");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            TxtName.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
            textBoxSurname.Text = dataGridView1.Rows[x].Cells[2].Value.ToString();
            cmbBranch.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();
            mskTc.Text = dataGridView1.Rows[x].Cells[4].Value.ToString();
            textBoxPassword.Text = dataGridView1.Rows[x].Cells[5].Value.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Tbl_Doctors where DoctorTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Registration is deleted.");
        }
     


       

    private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Update Tbl_Doctors set DoctorName=@p1, DoctorSurname=@p2, DoctorBranch=@p3, DoctorPassword=@p5 where DoctorTc=@p4", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", TxtName.Text);
            komut1.Parameters.AddWithValue("@p2", textBoxSurname.Text);
            komut1.Parameters.AddWithValue("@p3", cmbBranch.Text);
            komut1.Parameters.AddWithValue("@p4", mskTc.Text);
            komut1.Parameters.AddWithValue("@p5", textBoxPassword.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doctor is updated");
        }




    }
}
