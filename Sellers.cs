using System;
using System.Data;
using System.Windows.Forms;

namespace CarShowRoom
{
    public partial class Sellers : Form
    {
        functions Con;
        int key = 0;

        public Sellers()
        {
            InitializeComponent();
            Con = new functions();
            ShowSellers();
        }

        private void ShowSellers()
        {
            string query = "SELECT * FROM SellersTbl";
            dataGridView2.DataSource = Con.GetData(query);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Optional: Add search/filter logic here
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Check for missing input
            if (idd.Text == "" || firstname.Text == "" || lastname.Text == "" ||
                Emails.Text == "" || Password.Text == "" || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!");
                return;
            }

            try
            {
                string id = idd.Text;
                string firstName = firstname.Text;
                string lastName = lastname.Text;
                string email = Emails.Text;
                string passwords = Password.Text;
                string gender = comboBox2.SelectedItem.ToString();
                string dob = DOBTb.Value.ToString("yyyy-MM-dd");

                string query = string.Format(
                    "INSERT INTO SellersTbl (Id, FirstName, LastName, Email, Data, Gener, Passwords) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                    id, firstName, lastName, email, dob, gender, passwords
                );

                Con.SetData(query);
                MessageBox.Show("Seller added!");

                ShowSellers();

                // Clear fields
                idd.Text = "";
                firstname.Text = "";
                lastname.Text = "";
                Emails.Text = "";
                Password.Text = "";
                comboBox2.SelectedIndex = -1;
                DOBTb.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Check for missing input
            if (idd.Text == "" || firstname.Text == "" || lastname.Text == "" ||
                Emails.Text == "" || Password.Text == "" || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {

                try
                {
                    string id = idd.Text;
                    string firstName = firstname.Text;
                    string lastName = lastname.Text;
                    string email = Emails.Text;
                    string passwords = Password.Text;
                    string gender = comboBox2.SelectedItem.ToString();
                    string dob = DOBTb.Value.ToString("yyyy-MM-dd");

                    string query = string.Format("UPDATE SellersTbl SET FirstName = '{0}', LastName = '{1}', Email = '{2}', Passwords = '{3}', Gener = '{4}', Data = '{5}' WHERE id = '{6}'",
                                                 firstName, lastName, email, passwords, gender, dob, id, key);

                    Con.SetData(query);
                    MessageBox.Show("Seller updated!");

                    ShowSellers();

                    // Clear fields
                    idd.Text = "";
                    firstname.Text = "";
                    lastname.Text = "";
                    Emails.Text = "";
                    Password.Text = "";
                    comboBox2.SelectedIndex = -1;
                    DOBTb.Value = DateTime.Now;

                    key = 0; // Reset key after update
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idd.Text == "")
            {
                MessageBox.Show("Please enter an ID to delete.");
            }
            else
            {
                try
                {
                    int key = int.Parse(idd.Text); // Assure-toi que c'est un nombre entier
                    string query = string.Format("DELETE FROM SellersTbl WHERE id = {0}", key);
                    Con.SetData(query);
                    MessageBox.Show("Seller deleted!");

                    ShowSellers();

                    // Clear fields
                    idd.Text = "";
                    firstname.Text = "";
                    lastname.Text = "";
                    Emails.Text = "";
                    Password.Text = "";
                    comboBox2.SelectedIndex = -1;
                    DOBTb.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void label20_Click(object sender, EventArgs e)
        {
            // Optional label click action
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                idd.Text = row.Cells[0].Value.ToString();
                firstname.Text = row.Cells[1].Value.ToString();
                lastname.Text = row.Cells[2].Value.ToString();
                Emails.Text = row.Cells[3].Value.ToString();
                DOBTb.Value = Convert.ToDateTime(row.Cells[4].Value); // Date de naissance
                comboBox2.SelectedItem = row.Cells[5].Value.ToString(); // Genre
                Password.Text = row.Cells[6].Value.ToString(); // Mot de passe

                key = Convert.ToInt32(idd.Text); // Stocker l'ID pour modification/suppression
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {
            cars obj = new cars();
            obj.Show();
            this.Hide();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            Selling obj = new Selling();
            obj.Show();
            this.Hide();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            Login obj = new Login ();
            obj.Show();
            this.Hide();
        }

    }
}
