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
    public partial class DetailsForm : Form
    {
        private RentCarsEntities2 db;
        public DetailsForm()
        {
            InitializeComponent();
            this.db = new RentCarsEntities2();
            FillDgv();
        }
        private void FillDgv()
        {
            dgvDetails.Rows.Clear();
            foreach (Rents item in db.Rents.ToList())
            {
                dgvDetails.Rows.Add(item.ID, item.Users.Name + " " + item.Users.Surname, item.Customers.Name + " " + item.Customers.Surname, item.Cars.Brands.Name, item.Cars.CarModels, item.Cars.Number, item.HandOverDate, item.TakeOverDate, item.DelayDate, item.DelayedFine, item.DailyPrice, item.TotalPrice, item.Addeddate);
            }

        }

    }
}
