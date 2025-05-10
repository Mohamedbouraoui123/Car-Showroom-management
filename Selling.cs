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
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
            con = new functions();
            Showcars();
        }
        functions con;

        private void Showcars()
        {
            string query = "SELECT * FROM CarsTbl";
            carsdgv.DataSource = con.GetData(query);
        }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void carsdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = carsdgv.Rows[e.RowIndex];
                cartb.Text = row.Cells[0].Value.ToString();
                pricetb.Text = row.Cells[4].Value.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            cars obj = new cars();
            obj.Show();
            this.Hide();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            Sellers obj = new Sellers();
            obj.Show();
            this.Hide();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
