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
    public partial class UsersForm : Form
    {
        private RentCarsEntities2 db;
        private int SelectedID;
        public UsersForm()
        {
            InitializeComponent();
            this.db = new RentCarsEntities2();
            FillDegResult();
        }

        public void FillDegResult()
        {
            dgvUsersRslt.Rows.Clear();
            foreach (Users item in db.Users.ToList())
            {
                dgvUsersRslt.Rows.Add(item.ID, item.Name, item.Surname, item.Age, item.Phone, item.Username, item.Password);
            }
        }
        private void Reset()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtAge.Text = "";
            txtPhone.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text)&&!string.IsNullOrWhiteSpace(txtSurname.Text)&&!string.IsNullOrWhiteSpace(txtAge.Text)
                &&!string.IsNullOrWhiteSpace(txtPhone.Text)&&!string.IsNullOrWhiteSpace(txtUsername.Text)&&!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (db.Users.FirstOrDefault(u=>u.Username==txtUsername.Text)==null)
                {
                    Users user = new Users();
                    user.Name = txtName.Text;
                    user.Surname = txtSurname.Text;
                    user.Age = Convert.ToInt32(txtAge.Text);
                    user.Phone = txtPhone.Text;
                    user.Username = txtUsername.Text;
                    user.Password = txtPassword.Text;
                    db.Users.Add(user);
                    db.SaveChanges();

                    label2.Text = "";
                    Reset();
                    
                    MessageBox.Show("User Added Successfully!");
                    FillDegResult();
                }
                else
                {
                    MessageBox.Show("This username is used ");
                }
            }
            else
            {
                label2.Text = "Please add All personal information!";
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Users user = db.Users.Find(this.SelectedID);
            if (user==null)
            {
                MessageBox.Show("this Choose is not true!");

            }
            else
            {
                user.Name = txtName.Text;
                user.Surname = txtSurname.Text;
                user.Age = Convert.ToInt32(txtAge.Text);
                user.Phone = txtPhone.Text;
                user.Username = txtUsername.Text;
                user.Password = txtPassword.Text;

                db.SaveChanges();
                FillDegResult();
                Reset();
                MessageBox.Show("User Informatin has been Updated!");
            }

        }

        private void dgvUsersRslt_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SelectedID =Convert.ToInt32(dgvUsersRslt.Rows[e.RowIndex].Cells[0].Value);
            txtName.Text = dgvUsersRslt.Rows[e.RowIndex].Cells["column2"].Value.ToString();
            txtSurname.Text= dgvUsersRslt.Rows[e.RowIndex].Cells["column3"].Value.ToString();
            txtAge.Text= dgvUsersRslt.Rows[e.RowIndex].Cells["column4"].Value.ToString();
            txtPhone.Text= dgvUsersRslt.Rows[e.RowIndex].Cells["column5"].Value.ToString();
            txtUsername.Text= dgvUsersRslt.Rows[e.RowIndex].Cells["column6"].Value.ToString();
            txtPassword.Text= dgvUsersRslt.Rows[e.RowIndex].Cells["column7"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Users users = db.Users.Find(this.SelectedID);

            db.Users.Remove(users);
            db.SaveChanges();
            FillDegResult();
            Reset();
            MessageBox.Show("User Information has been Deleted!");
        }

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    dgvUsersRslt.Rows.Clear();
        //    List<Users> users = db.Users.Where(u => !string.IsNullOrEmpty(txtUserSearchName.Text) ? u.Name.Contains(txtUserSearchName.Text) : true
        //      || !string.IsNullOrEmpty(txtUserSearchSurname.Text) ? u.Surname.Contains(txtUserSearchSurname.Text) : true).ToList();
        //    foreach (Users item in users)
        //    {
        //        dgvUsersRslt.Rows.Add(item.ID,item.Name, item.Surname, item.Age, item.Phone, item.Username, item.Password);
        //    }
        //    txtUserSearchName.Text = "";
        //    txtUserSearchSurname.Text = "";
           
        //}



        private void txtUserSearchName_TextChanged_1(object sender, EventArgs e)
        {
            dgvUsersRslt.Rows.Clear();
            List<Users> users = db.Users.ToList();
            var us = db.Users.Where(u => u.Name.Contains(txtUserSearchName.Text) | u.Surname.Contains(txtUserSearchName.Text)).ToList();

            foreach (Users item in us)
            {
                dgvUsersRslt.Rows.Add(item.ID, item.Name, item.Surname, item.Age, item.Phone, item.Username, item.Password);

            }
        }
    }
}
