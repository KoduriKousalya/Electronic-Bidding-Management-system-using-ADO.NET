using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EBMSS
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                using (Form4 form4 = new Form4())
                {
                    form4.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form4: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                using (Form2 form2 = new Form2())
                {
                    form2.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                   
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM SELLER1 WHERE SEMAIL = @SEMAIL AND SPASS = @SPASS", conn);
                        SqlCommand cmdd = new SqlCommand("SELECT * FROM SELLER1 WHERE SEMAIL=@SEMAIL", conn);
                        cmd.Parameters.AddWithValue("@SEMAIL", textBox1.Text);
                        cmd.Parameters.AddWithValue("@SPASS", maskedTextBox1.Text);
                        cmdd.Parameters.AddWithValue("@SEMAIL", textBox1.Text);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        SqlDataReader reader = cmdd.ExecuteReader();

                        if (count == 1)
                        {
                            reader.Read();
                            UserSession2.Sbid = (int)reader["SID"];
                            // Assign values to UserSession1 properties

                            UserSession2.Sname = reader["SNAME"].ToString();
                            UserSession2.Sphone = (long)reader["SPHONE"];
                            UserSession2.Semail = reader["SEMAIL"].ToString();
                            UserSession2.Sadd = reader["SADDR"].ToString();

                            MessageBox.Show("Login Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Form9 form9 = new Form9();
                            form9.ShowDialog();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if necessary
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Handle form load event if necessary
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Handle label click event if necessary
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click event if necessary
        }

        public static class UserSession2
        {
            public static int Sbid;
            public static string Sname = "";
            public static long Sphone = 0;
            public static string Semail = "";
            public static string Sadd = "";
        }
    }
}
