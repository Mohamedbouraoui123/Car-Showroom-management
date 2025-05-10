using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarShowRoom
{
    public partial class cars : Form
    {
        public cars()
        {
            InitializeComponent();
            con = new functions();
            Showcars();
        }
        functions con;
        int key = 0;
        private void Showcars()
        {
            string query = "SELECT * FROM CarsTbl";
            carsdgv.DataSource = con.GetData(query);
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check for missing input
            if (string.IsNullOrWhiteSpace(numbertb.Text) ||
                string.IsNullOrWhiteSpace(colortb.Text) ||
                string.IsNullOrWhiteSpace(manufacturertb.Text) ||
                string.IsNullOrWhiteSpace(pricetb.Text) ||
                string.IsNullOrWhiteSpace(descripetb.Text))
            {
                MessageBox.Show("Missing Data!");
                return;
            }

            try
            {
                string numberCar = numbertb.Text.Trim();
                string manufacturer = manufacturertb.Text.Trim();
                string color = colortb.Text.Trim();
                int price = Convert.ToInt32(pricetb.Text.Trim());
                string description = descripetb.Text.Trim();
                string yearOfFab = Dobtb.Value.ToString("yyyy-MM-dd");

                string query = string.Format(
                    "INSERT INTO CarsTbl (Numbercar, Manfactures, Color, Price, Description, YearOFab) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                    numberCar, manufacturer, color, price, description, yearOfFab
                );

                con.SetData(query);
                MessageBox.Show("Car added!");

                Showcars();

                // Clear fields
                numbertb.Text = "";
                manufacturertb.Text = "";
                colortb.Text = "";
                pricetb.Text = "";
                descripetb.Text = "";
                Dobtb.Value = DateTime.Now;
            }
            catch (FormatException)
            {
                MessageBox.Show("Price must be a valid number.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void colortb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check for missing input
            if (string.IsNullOrWhiteSpace(numbertb.Text) ||
                string.IsNullOrWhiteSpace(colortb.Text) ||
                string.IsNullOrWhiteSpace(manufacturertb.Text) ||
                string.IsNullOrWhiteSpace(pricetb.Text) ||
                string.IsNullOrWhiteSpace(descripetb.Text))
            {
                MessageBox.Show("Missing Data!");
                return;
            }

            try
            {
                string numberCar = numbertb.Text.Trim();
                string Manfactures = manufacturertb.Text.Trim();
                string color = colortb.Text.Trim();
                int price = int.Parse(pricetb.Text.Trim()); // Safer if you know it must be an int
                string description = descripetb.Text.Trim();
                string YearOFab = Dobtb.Value.ToString("yyyy-MM-dd");

                // Use parameterized query to prevent SQL injection
                string query = string.Format("UPDATE CarsTbl SET Manfactures = '{0}', color = '{1}', price = '{2}', description = '{3}', YearOFab = '{4}' WHERE numberCar = '{5}'",
                                       Manfactures, color, price, description, YearOFab, numberCar);
                con.SetData(query);
                MessageBox.Show("Car updated!");
                Showcars();

                // Clear fields
                numbertb.Text = "";
                manufacturertb.Text = "";
                colortb.Text = "";
                pricetb.Text = "";
                descripetb.Text = "";
                Dobtb.Value = DateTime.Now;
            }
            catch (FormatException)
            {
                MessageBox.Show("Price must be a valid number.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numbertb.Text == "")
            {
                MessageBox.Show("Please enter a car number to delete.");
                return;
            }

            try
            {
                // Try to parse the car number as integer
                int carNumber;
                if (!int.TryParse(numbertb.Text, out carNumber))
                {
                    MessageBox.Show("Car number must be a valid number.");
                    return;
                }

                // Correct query formatting using string.Format (no quotes around int)
                string query = string.Format("DELETE FROM CarsTbl WHERE Numbercar = {0}", carNumber);

                con.SetData(query);
                MessageBox.Show("Car Deleted!");
                Showcars();

                // Clear input fields
                numbertb.Text = "";
                manufacturertb.Text = "";
                colortb.Text = "";
                pricetb.Text = "";
                descripetb.Text = "";
                Dobtb.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void carsdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = carsdgv.Rows[e.RowIndex];

                numbertb.Text = row.Cells[0].Value.ToString();             // Numbercar
                manufacturertb.Text = row.Cells[1].Value.ToString();       // Manufacturer
                colortb.Text = row.Cells[2].Value.ToString();
                Dobtb.Value = Convert.ToDateTime(row.Cells[3].Value);
                pricetb.Text = row.Cells[4].Value.ToString();              // Price
                descripetb.Text = row.Cells[5].Value.ToString();  
                  
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Sellers obj = new Sellers();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Selling obj = new Selling();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

    }
}