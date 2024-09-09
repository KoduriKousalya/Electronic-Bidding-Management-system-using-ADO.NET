using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EBMSS
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if necessary
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Form6 form6 = new Form6();
                form6.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form6: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Handle form load event if necessary
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM BUYER1 WHERE BEMAIL = @BEmail AND BPASS = @BPASS", conn);
                    SqlCommand cmdd = new SqlCommand("SELECT * FROM BUYER1 WHERE BEMAIL=@BEmail", conn);
                    cmd.Parameters.AddWithValue("@BEMAIL", textBox1.Text);
                    cmd.Parameters.AddWithValue("@BPASS", maskedTextBox1.Text);
                    cmdd.Parameters.AddWithValue("@BEMAIL", textBox1.Text);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    SqlDataReader reader = cmdd.ExecuteReader();

                    if (count == 1)
                    {
                        reader.Read();
                        UserSession.Bbid = (int)reader["BID"];
                        UserSession.Bname = reader["BNAME"].ToString();
                        UserSession.Bphone = (long)reader["BPHONE"];
                        UserSession.Bemail = reader["BEMAIL"].ToString();
                        UserSession.Badd = reader["BADD"].ToString();
                        reader.Close();
                        MessageBox.Show("Login Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Form7 form7 = new Form7();
                        form7.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed. Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click event if necessary
        }
    }

    public static class UserSession
    {
        public static int Bbid = 0;
        public static string Bname = "";
        public static long Bphone = 0;
        public static string Bemail = "";
        public static string Badd = "";
    }
}
