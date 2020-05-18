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
    public partial class DashboardForm : Form
    {
        private RentCarsEntities2 db;
        public DashboardForm()
        {
            InitializeComponent();
            this.db = new RentCarsEntities2();
            FillDgvDAshboard();
        }

        private void FillDgvDAshboard()
        {
            List<Rents> rents = new List<Rents>();
            foreach (Rents item in db.Rents.Where(r=>r.DelayDate==null))
            {
                rents.Add(item);
            }
            int a = 0;
            dgvDashboard.Rows.Clear();
            foreach (Rents item in db.Rents.AsEnumerable().Reverse())
            {
                dgvDashboard.Rows.Add(item.ID, item.Users.Name + " " + item.Users.Surname, item.Customers.Name + " " + item.Customers.Surname, item.Cars.Brands.Name, item.Cars.CarModels, item.Cars.Number, item.HandOverDate, item.TakeOverDate, item.DelayDate, item.DelayedFine, item.DailyPrice, item.TotalPrice, item.Addeddate);
                
                if (a==10)
                {
                    a++;
                    return;

                }
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.Show();
        }

        private void custamerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersForm customersForm = new CustomersForm();
            customersForm.Show();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarForm carForm = new CarForm();
            carForm.Show();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailsForm detailsForm = new DetailsForm();
            detailsForm.Show();
        }

        private void btnRentACar_Click(object sender, EventArgs e)
        {
            NewRentForm newRentForm = new NewRentForm();
            newRentForm.Show();
        }

        private void btnEndedRental_Click(object sender, EventArgs e)
        {
            EndRent endRent = new EndRent();
            endRent.Show();
        }
    }
}
