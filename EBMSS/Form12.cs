using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EBMSS.Form3;

namespace EBMSS
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT OBID.BIDNAME, NEWBID.NVAL FROM OBID JOIN NEWBID ON OBID.BIDID = NEWBID.BIDID WHERE NEWBID.SID = @SID and OBID.BIDID NOT IN (SELECT BIDID FROM CLOSEB)", con);
            cmd.Parameters.AddWithValue("@SID", UserSession1.Sbid);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Hide(); 

            Form9 form = new Form9();
            form.ShowDialog();
        }
    }
}
