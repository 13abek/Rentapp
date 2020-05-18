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
    public partial class endRental2 : Form
    {
        private RentCarsEntities2 db;

        private int endrental2;
        public endRental2(int endrentsid)
        {
            InitializeComponent();
            this.db = new RentCarsEntities2();
            this.endrental2 = endrentsid;
            FillEndRental();
        }
        int priceAsw;
        int dateAsw;
        int delaydate;

        private void FillEndRental()
        {
            Rents rents = db.Rents.Find(endrental2);
            txtUsers.Text = rents.Users.Name+" "+rents.Users.Surname;
            txtCustomer.Text = rents.Customers.Name + " " + rents.Customers.Surname;
            txtCar.Text = rents.Cars.Brands.Name + "   " + rents.Cars.CarModels.Name + "   " + rents.Cars.Number;
            txtHandOver.Text = rents.HandOverDate.Value.ToShortDateString();
            txtTakeOver.Text = rents.TakeOverDate.Value.ToShortDateString();
             dateAsw = Convert.ToInt32((rents.TakeOverDate.Value - rents.HandOverDate.Value).TotalDays);
             priceAsw = Convert.ToInt32(rents.DailyPrice * dateAsw);

       
            txtDailyPrice.Text = priceAsw.ToString();

        }
        private void FillDelaydate()
        {

            Rents rents = db.Rents.Find(endrental2);

            if (dtpDelay.Value>rents.TakeOverDate.Value)
            {
                 delaydate = Convert.ToInt32(((dtpDelay.Value - rents.TakeOverDate.Value).TotalDays) * 1.2);
                txtDelayFine.Text= delaydate.ToString() ;
                
            }
            else
            {
                rents.DelayedFine = 0;
            }
        }

       
        private void btnEndRental_Click(object sender, EventArgs e)
        {
            Rents rents = db.Rents.Find(endrental2);

            rents.TotalPrice = (delaydate + priceAsw);
            rents.DelayDate = dtpDelay.Value;
            rents.DelayedFine = Convert.ToInt32(txtDelayFine.Text);
            db.Rents.Add(rents);
            db.SaveChanges();

            MessageBox.Show("Completed");

        }

        private void dtpDelay_ValueChanged(object sender, EventArgs e)
        {
            FillDelaydate();


        }
    }
}
