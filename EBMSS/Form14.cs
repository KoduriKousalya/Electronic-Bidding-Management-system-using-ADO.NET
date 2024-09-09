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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EBMSS
{
    public partial class Form14 : Form
    {
        int count;
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select BIDNAME,BIDVAL from OBID where @BID=BID and @BIDID NOT IN (select bidid FROM CLOSEB)", con);
            cmd.Parameters.AddWithValue("@BID", UserSession.Bbid);
            cmd.Parameters.AddWithValue("@BIDID", count);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmdd = new SqlCommand("select BIDID from OBID where @BIDNAME=BIDNAME", con);
            cmdd.Parameters.AddWithValue("@BIDNAME", textBox1.Text);
            object result = cmdd.ExecuteScalar();
            count = Convert.ToInt32(result);

            SqlCommand cmd = new SqlCommand("select MIN(NVAL) from NEWBID where @BIDID=BIDID", con);
            cmd.Parameters.AddWithValue("@BIDID", count);
            object result1 = cmd.ExecuteScalar();
            int min = Convert.ToInt32(result1);

            SqlCommand cmd2 = new SqlCommand("SELECT SID FROM NEWBID WHERE NVAL = (SELECT MIN(NVAL) FROM NEWBID)", con);
            cmd2.Parameters.AddWithValue("@BIDID", count);
            object result2 = cmd2.ExecuteScalar();
            int seller = Convert.ToInt32(result2);

            SqlCommand cmd3 = new SqlCommand("INSERT INTO CLOSEB (BIDID, SID) VALUES (@BIDID, @SID)", con);
            cmd3.Parameters.AddWithValue("@BIDID", count);
            cmd3.Parameters.AddWithValue("@SID", seller);

            SqlDataAdapter sda = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            

            
            DataTable dtQ = new DataTable();
            sda.Fill(dtQ);

            //SqlCommand cmdd1 = new SqlCommand("DELETE FROM NEWBID WHERE @BIDID=BIDID", con);
            //cmdd1.Parameters.AddWithValue("@BIDID", count);
            //SqlDataAdapter sda1 = new SqlDataAdapter(cmdd1);
            //DataTable dt1 = new DataTable();
            //sda1.Fill(dt1);

            MessageBox.Show("BID CLOSED SUCESSFULLY");
            this.Hide();
            Form15 form15 = new Form15();
                form15.ShowDialog();
       
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }
    }
}
