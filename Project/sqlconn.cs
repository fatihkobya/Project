using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project
{
    class sqlconn
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-F3DSPQC\\SQL2021;Initial Catalog=HospitalProje;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
