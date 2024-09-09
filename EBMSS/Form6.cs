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

namespace EBMSS
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
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
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO BUYER1 values (@BNAME,@BPHONE,@BEMAIL,@BADDR,@BPASS)", conn))
                    {
                        cmd.Parameters.AddWithValue("@BNAME", textBox1.Text);
                        cmd.Parameters.AddWithValue("@BPHONE", int.Parse(textBox2.Text));
                        cmd.Parameters.AddWithValue("@BEMAIL", textBox3.Text);
                        cmd.Parameters.AddWithValue("@BADDR", textBox4.Text);
                        cmd.Parameters.AddWithValue("@BPASS", maskedTextBox1.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration successful! \nYou can log in now.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form5 form5 = new Form5();
                form5.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
                form5.ShowDialog();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
