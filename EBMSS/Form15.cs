using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace EBMSS
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            

            SqlCommand cmd = new SqlCommand("SELECT OBID.BIDNAME,    OBID.BIDID,  NEWBID.NVAL,  SELLER1.SNAME AS SELLERNAME  FROM   CLOSEB INNER JOIN     OBID ON CLOSEB.BIDID = OBID.BIDID INNER JOIN   NEWBID ON CLOSEB.BIDID = NEWBID.BIDID INNER JOIN    SELLER1 ON CLOSEB.SID = SELLER1.SID  WHERE OBID.BID=@BID", con);
            cmd.Parameters.AddWithValue("@BID", UserSession.Bbid);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14);

        }
    }
}
