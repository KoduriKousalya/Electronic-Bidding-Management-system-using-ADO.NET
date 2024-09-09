using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EBMSS
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO OBID values (@BIDNAME,@BIDVAL,@BID)", conn);
                    cmd.Parameters.AddWithValue("@BIDNAME", textBox1.Text);
                    cmd.Parameters.AddWithValue("@BIDVAL", int.Parse(textBox2.Text));
                    cmd.Parameters.AddWithValue("@BID", UserSession.Bbid);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    MessageBox.Show("Bid successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Form8 form = new Form8();
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the bid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // Handle form load event if necessary
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Handle label click event if necessary
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if necessary
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click event if necessary
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Form7 form = new Form7();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form7: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
