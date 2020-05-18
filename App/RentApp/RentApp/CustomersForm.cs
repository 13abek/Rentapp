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
    public partial class CustomersForm : Form
    {
        private RentCarsEntities2 db;
        public CustomersForm()
        {
            InitializeComponent();
            this.db = new RentCarsEntities2();
            FillDgvResult();
        }
        private int SelectedID;
        private void Reset(){
            txtName.Text = "";
            txtSurname.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtDrivingLicense.Text = "";

        }

        private void FillDgvResult()
        {
            dgvCustomerRslt.Rows.Clear();
            foreach (Customers item in db.Customers.ToList())
            {
                dgvCustomerRslt.Rows.Add(item.ID, item.Name,item.Surname, item.Phone, item.Address, item.DrivingLicense);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtSurname.Text) && !string.IsNullOrWhiteSpace(txtPhone.Text)
                 && !string.IsNullOrWhiteSpace(txtAddress.Text) && !string.IsNullOrWhiteSpace(txtDrivingLicense.Text))
            {
                Customers customers = new Customers();
                customers.Name = txtName.Text;
                customers.Surname = txtSurname.Text;
                customers.Phone = txtPhone.Text;
                customers.Address = txtAddress.Text;
                customers.DrivingLicense = txtDrivingLicense.Text;
                db.Customers.Add(customers);
                db.SaveChanges();
                Reset();
                lblAddedError.Visible = false;           
                MessageBox.Show(" Customer Added Successfully!");
                FillDgvResult();

            }
            else
            {
                lblAddedError.Visible = true;
            }

           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Customers customers = db.Customers.Find(SelectedID);
            db.Customers.Remove(customers);
            db.SaveChanges();
            Reset();
            FillDgvResult();
            MessageBox.Show("Customer information has been Deleted!");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Customers customers = db.Customers.Find(SelectedID);
            if (customers == null)
            {
                MessageBox.Show("this Choose is not true!");

            }
            else
            {
                customers.Name = txtName.Text;
                customers.Surname = txtSurname.Text;
                customers.Phone = txtPhone.Text;
                customers.Address = txtAddress.Text;
                customers.DrivingLicense = txtDrivingLicense.Text;
                db.SaveChanges();
                Reset();
                FillDgvResult();
                MessageBox.Show("Customer Informatin has been Updated!");
            }
            
         
        }
        private void dgvCustomerRslt_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectedID = Convert.ToInt32(dgvCustomerRslt.Rows[e.RowIndex].Cells[0].Value);
            txtName.Text = dgvCustomerRslt.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSurname.Text = dgvCustomerRslt.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhone.Text = dgvCustomerRslt.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAddress.Text = dgvCustomerRslt.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDrivingLicense.Text = dgvCustomerRslt.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            dgvCustomerRslt.Rows.Clear();
            List<Customers> customers = db.Customers.ToList();
            var cus = db.Customers.Where(c => c.Name.Contains(txtSearchName.Text) | c.Surname.Contains(txtSearchName.Text)).ToList();

            foreach (Customers item in cus)
            {
                dgvCustomerRslt.Rows.Add(item.ID,item.Name,item.Surname,item.Phone,item.Address,item.DrivingLicense);

            }
        }
    }
}
