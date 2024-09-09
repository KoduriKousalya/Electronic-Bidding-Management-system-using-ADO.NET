using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EBMSS
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            try
            {
                
                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT BIDNAME, BIDVAL FROM OBID WHERE BIDID NOT IN (SELECT BIDID FROM NEWBID);", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                textBox2.Text = selectedRow.Cells[1].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();

                    // Check if BIDNAME exists
                    SqlCommand cmdd = new SqlCommand("SELECT BIDID FROM OBID WHERE BIDNAME = @BIDNAME", con);
                    cmdd.Parameters.AddWithValue("@BIDNAME", textBox1.Text);
                    object result = cmdd.ExecuteScalar();

                    if (result != null)
                    {
                        int bidId = Convert.ToInt32(result);

                        // Check if SID exists in SELLER1 table
                        SqlCommand checkSidCmd = new SqlCommand("SELECT COUNT(1) FROM SELLER1 WHERE SID = @SID", con);
                        checkSidCmd.Parameters.AddWithValue("@SID", Form3.UserSession2.Sbid);
                       

                        
                            // SID exists, proceed with the INSERT
                            SqlCommand cmd = new SqlCommand("INSERT INTO NEWBID (BIDID, SID, NVAL) VALUES (@BIDID, @SID, @NVAL)", con);
                            cmd.Parameters.AddWithValue("@BIDID", bidId);
                            cmd.Parameters.AddWithValue("@SID", Form3.UserSession2.Sbid);
                            cmd.Parameters.AddWithValue("@NVAL", textBox3.Text);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Bid added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                       
                    }
                    else
                    {
                        MessageBox.Show("Bid ID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the bid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click event if necessary
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 form9 = new Form9();
            form9.ShowDialog();
        }

        private void ReloadForm()
        {
            this.Hide();
            Form11 form11 = new Form11();
            form11.ShowDialog();
        }
    }

    public static class UserSession1
    {
        public static int Sbid { get; set; } // Assuming this is set somewhere in your application
    }
}
