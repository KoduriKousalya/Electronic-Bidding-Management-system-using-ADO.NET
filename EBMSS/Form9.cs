using System;
using System.Windows.Forms;

namespace EBMSS
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // Handle form load event if necessary
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.Hide();
                Form11 form11 = new Form11();
                form11.ShowDialog();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form11: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Form12 form12 = new Form12();
                form12.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form12: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Handle button3 click event if necessary
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click event if necessary
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Logout successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while logging out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
