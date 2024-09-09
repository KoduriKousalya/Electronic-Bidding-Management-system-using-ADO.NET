using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBMSS
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            label1.Text = $"Welcome, {UserSession.Bname}";
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // Handle form load event if necessary
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Form8 form8 = new Form8();
                form8.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form8: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Handle label click event if necessary
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Logout successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form5 form5 = new Form5();
                form5.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while logging out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Form10 form10 = new Form10();
                form10.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form10: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Form14 form14 = new Form14();
                form14.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening Form14: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle picture box click event if necessary
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Handle button3 click event if necessary
        }
    }
}
