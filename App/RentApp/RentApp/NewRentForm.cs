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
    public partial class NewRentForm : Form
    { private RentCarsEntities2 db;
        public NewRentForm()
        {
            InitializeComponent();
            this.db = new RentCarsEntities2();
            FillUsers();
            FillCustomers();
            //FillCar();
            //dtpHandOver.Value = DateTime.Today;
            //dtpTakeOver.Value = DateTime.Today;
        }
        private void Reset()
        {
         
            cbUsers.SelectedItem = "Choose";
           
            cbCustomers.SelectedItem = "Choose";
            
            cbCars.SelectedItem = "Choose";
            //dtpHandOver.Value = DateTime.Today;
            //dtpTakeOver.Value = DateTime.Today;
            numPrice.Value = 0;

        }
        private void FillUsers()
        {
            cbUsers.Items.Clear();
            cbUsers.Items.Add("Choose");
            cbUsers.SelectedItem = "Choose";
            foreach (Users item in db.Users.ToList())
            {
                cbUsers.Items.Add(item.Name+" "+item.Surname);
            }
        }
        private void FillCustomers()
        {
            cbCustomers.Items.Clear();
            cbCustomers.Items.Add("Choose");
            cbCustomers.SelectedItem = "Choose";
            foreach (Customers item in db.Customers.ToList())
            {
                cbCustomers.Items.Add(item.Name + " " + item.Surname);
            }
        }
        private void FillCar()
        {
            cbCars.Items.Clear();

            cbCars.Items.Add("Choose");
            cbCars.SelectedItem = "Choose";
            List<Cars> car = db.Cars.ToList();
            foreach (Cars item in car)
            {
                cbCars.Items.Add(item.Brands.Name + " :    " + item.CarModels.Name + "   " + item.Number + " " + item.Price.ToString());
            }
            foreach (Rents item in db.Rents.Where(r => r.DelayDate == null))
            {
                if ((dtpHandOver.Value.Date >= item.HandOverDate && dtpHandOver.Value.Date <= item.TakeOverDate) ||
                    (dtpTakeOver.Value.Date >= item.HandOverDate && dtpTakeOver.Value.Date <= item.TakeOverDate) ||
                    (dtpHandOver.Value.Date <= item.HandOverDate && dtpTakeOver.Value.Date >= item.TakeOverDate))
                {
                    cbCars.Items.Remove(item.Cars.Brands.Name + " " + item.Cars.CarModels.Name + " " + item.Cars.Number + " " + item.Cars.Price.ToString());
                    MessageBox.Show("this false");
                }
                else
                {
                    MessageBox.Show("fuck off");
                }
             
            }
           

         
        }
        private void btnNewRent_Click(object sender, EventArgs e)
        {
            int userid = db.Users.FirstOrDefault(u => u.Name +" "+ u.Surname==cbUsers.Text).ID;
            int customerid = db.Customers.FirstOrDefault(c => c.Name +" "+ c.Surname== cbCustomers.Text).ID;
            int carid = db.Cars.FirstOrDefault(car => cbCars.Text.Contains(car.Number)).ID;
            int priceid = db.Cars.FirstOrDefault(car => cbCars.Text.Contains(car.Number)).ID;

            Rents rent = new Rents();
            rent.UsersID = userid;
            rent.CustomersID = customerid;
            rent.CarID = carid;
            rent.HandOverDate = dtpHandOver.Value;
            rent.TakeOverDate = dtpTakeOver.Value;
            rent.DailyPrice = priceid;
            rent.Addeddate =DateTime.Now;
            db.Rents.Add(rent);
            db.SaveChanges();
            Reset();
            MessageBox.Show("Operation completed!");
        }

        private void dtpHandOver_ValueChanged(object sender, EventArgs e)
        {
            FillCar();
        }

        private void dtpTakeOver_ValueChanged(object sender, EventArgs e)
        {
            FillCar();
        }
    }
}
