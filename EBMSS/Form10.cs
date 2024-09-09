using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EBMSS
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT BIDNAME, BIDVAL FROM OBID WHERE @BID = BID", con);
                cmd.Parameters.AddWithValue("@BID", UserSession.Bbid);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "SELECT",
                    Name = "SELECT"
                };
                dataGridView1.Columns.Add(checkBoxColumn);
                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Handle text change if necessary
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text change if necessary
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
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE OBID SET BIDNAME = @TE1, BIDVAL = @TE2 WHERE @BID = BID", con);
                cmd.Parameters.AddWithValue("@TE1", textBox1.Text);
                cmd.Parameters.AddWithValue("@TE2", long.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@BID", UserSession.Bbid);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM OBID WHERE @BIDNAME = BIDNAME", con);
                cmd.Parameters.AddWithValue("@BIDNAME", textBox1.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                SqlCommand cmdd = new SqlCommand("SELECT BIDID FROM OBID WHERE @BIDNAME = BIDNAME", con);
                cmdd.Parameters.AddWithValue("@BIDNAME", textBox1.Text);
                object result = cmdd.ExecuteScalar();
                int count = Convert.ToInt32(result);

                SqlCommand cmdd1 = new SqlCommand("DELETE FROM NEWBID WHERE @BIDID = BIDID", con);
                cmdd1.Parameters.AddWithValue("@BIDID", count);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmdd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);

                MessageBox.Show("Delete successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReloadForm();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click event if necessary
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }

        private void ReloadForm()
        {
            this.Hide();
            Form10 form10 = new Form10();
            form10.ShowDialog();
        }
    }
}
