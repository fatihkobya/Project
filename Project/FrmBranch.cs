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
    public partial class FrmBranch : Form
    {
        public FrmBranch()
        {
            InitializeComponent();
        }

        sqlconn bgl = new sqlconn();
        private void FrmBranch_Load(object sender, EventArgs e)
        {
            DataTable dr = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branchs", bgl.baglanti());
            da.Fill(dr);
            dataGridView1.DataSource = dr; 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Branchs (BranchName) values (@b1) ", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", textBoxBranchName.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branch is added");
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            TxtBranchId.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textBoxBranchName.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Tbl_Branchs where BranchId=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBranchId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Registration is deleted.");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Branchs set BranchName=@p1 where BranchId=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBoxBranchName.Text);
            komut.Parameters.AddWithValue("@p2", TxtBranchId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Registration is updated.");
        }
    }
}
