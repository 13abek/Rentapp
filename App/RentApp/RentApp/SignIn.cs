using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentApp.Models;

namespace RentApp
{
    public partial class SignIn : Form
    {
        private RentCarsEntities2 db;
        public SignIn()
        {
            InitializeComponent();
            this.db = new RentCarsEntities2();
           
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
      
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (db.Users.FirstOrDefault(u=>u.Username==txtUsername.Text && u.Password==txtPassword.Text)!=null)
                {
                    DashboardForm dashboard = new DashboardForm();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is mistake,please try again!");
                }
            }
            else
            {
                label3.Text = "Please fill all information !";
            }
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            label3.Text = "";
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            label3.Text = "";
        }
    }
}
