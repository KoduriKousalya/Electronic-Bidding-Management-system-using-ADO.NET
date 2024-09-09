using System;
using System.Collections;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Handle label click event if necessary
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91917\\OneDrive\\Documents\\EBMS.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO SELLER1 values (@SNAME,@SPHONE,@SEMAIL,@SADDR,@SPASS)", conn);
                    cmd.Parameters.AddWithValue("@SNAME", textBox1.Text);
                    cmd.Parameters.AddWithValue("@SPHONE", int.Parse(textBox2.Text));
                    cmd.Parameters.AddWithValue("@SEMAIL", textBox3.Text);
                    cmd.Parameters.AddWithValue("@SADDR", textBox4.Text);
                    cmd.Parameters.AddWithValue("@SPASS", maskedTextBox1.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registration successful! \nYou can log in now.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form3 form3 = new Form3();
                    form3.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form3: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Handle form load event if necessary
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click event if necessary
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Handle text box text changed event if necessary
        }
    }
}
