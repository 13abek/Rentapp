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
using System.Windows;

namespace RentApp
{
    public partial class CarForm : Form
    {
        private RentCarsEntities2 db;
        public CarForm()
        {
            InitializeComponent();
            this.db = new RentCarsEntities2();
            FillDgvCarRuslt();
            FillFuelType();
            FIllTransmission();
            FillBrnads();
        }
        private int SelectedID;
        private void Reset()
        {
            if (txtNewBrands.Visible==true)
            {
                txtNewBrands.Text = "";
            }
            else
            {
                cbExistingBrands.SelectedItem = "Choose";
            }
            txtModels.Text = "";
            txtNumber.Text = "";
            txtYear.Text = "";
            cbFuelType.SelectedItem = "Choose";
            cbTransmission.SelectedItem = "Choose";
            txtHorsePower.Text = "";
            txtPrice.Text = "";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNewBrands.Visible = true;
            cbExistingBrands.Visible = false;
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbExistingBrands.Visible = true;
            txtNewBrands.Visible = false;
            Reset();
        }
        
        private void FillBrnads()
        {
            cbExistingBrands.Items.Clear();
            //cbExistingBrands.Items.Add("Choose");
            //cbExistingBrands.SelectedItem="Choose";
            foreach (Brands item in db.Brands.ToList())
            {
                cbExistingBrands.Items.Add(item.Name);
            }

        }
        private void FillDgvCarRuslt()
        {
            dgvcarResult.Rows.Clear();
            foreach (Cars item in db.Cars.ToList())
            {
                dgvcarResult.Rows.Add(item.ID, item.Brands.Name, item.CarModels.Name, item.Number, item.Year, item.FuelType.Name, item.Transmission1.Name, item.HorsePower, item.Price);
            }

        }

        private void FillFuelType()
        {
            cbFuelType.Items.Add("Choose");
            cbFuelType.SelectedItem= "Choose";
            
            foreach (FuelType item in db.FuelType.ToList())
            {
                cbFuelType.Items.Add(item.Name);
            }
        }

        private void FIllTransmission()
        {
            cbTransmission.Items.Add("Choose");
            cbTransmission.SelectedItem = "Choose";

            foreach (Transmission1 item in db.Transmission1.ToList())
            {
                cbTransmission.Items.Add(item.Name);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbExistingBrands.Visible==true && txtNewBrands.Visible == false && !string.IsNullOrWhiteSpace(cbExistingBrands.Text) && string.IsNullOrWhiteSpace(txtNewBrands.Text) )
            {
                cbExistingBrands.Items.Clear();


                if (!string.IsNullOrWhiteSpace(cbExistingBrands.Text) && !string.IsNullOrWhiteSpace(txtModels.Text)
                    && !string.IsNullOrWhiteSpace(txtNumber.Text) && !string.IsNullOrWhiteSpace(txtYear.Text)
                    && !string.IsNullOrWhiteSpace(cbTransmission.Text) && !string.IsNullOrWhiteSpace(cbFuelType.Text)
                    && !string.IsNullOrWhiteSpace(txtHorsePower.Text) && !string.IsNullOrWhiteSpace(txtPrice.Text))
                {

                    if (db.Brands.FirstOrDefault(b=>b.Name==cbExistingBrands.Text)!=null
                        && db.Cars.FirstOrDefault(c=>c.Number==txtNumber.Text)==null)
                    {
                        int brandid = db.Brands.FirstOrDefault(b => b.Name == cbExistingBrands.Text).ID;
                        CarModels carModels = new CarModels();
                        carModels.Name = txtModels.Text;
                        carModels.BrandsID = brandid;
                        db.CarModels.Add(carModels);
                        db.SaveChanges();
                        int carmodelid = db.CarModels.FirstOrDefault(cm => cm.Name == txtModels.Text).ID;
                        int fueltypeid = db.FuelType.FirstOrDefault(ft => ft.Name == cbFuelType.Text).ID;
                        int transmissionid = db.Transmission1.FirstOrDefault(t => t.Name == cbTransmission.Text).ID;
                        Cars cars = new Cars();
                        cars.BrandsID = brandid;
                        cars.CarModelsID = carmodelid;
                        cars.Number = txtNumber.Text;
                        cars.Year = Convert.ToInt32(txtYear.Text);
                        cars.FuelTypeID = fueltypeid;
                        cars.TransmissionID = transmissionid;
                        cars.HorsePower = Convert.ToInt32(txtHorsePower.Text);
                        cars.Price = Convert.ToInt32(txtPrice.Text);
                        db.Cars.Add(cars);
                        db.SaveChanges();
                        Reset();
                        MessageBox.Show("New Car Add seccessfully");
                        FillDgvCarRuslt();
                        FillBrnads();
                    }
                    else
                    {
                        MessageBox.Show("Not found this Brand or Number cannot be the same.Please check the Information!");
                    }

                }
                else
                {
                    lblError.Visible = true;

                }

            }
            else if (txtNewBrands.Visible==true && cbExistingBrands.Visible == false && string.IsNullOrWhiteSpace(cbExistingBrands.Text))
            {

                if (!string.IsNullOrWhiteSpace(txtNewBrands.Text) && !string.IsNullOrWhiteSpace(txtModels.Text)
                    && !string.IsNullOrWhiteSpace(txtNumber.Text) && !string.IsNullOrWhiteSpace(txtYear.Text)
                    &&!string.IsNullOrWhiteSpace(cbFuelType.Text) && !string.IsNullOrWhiteSpace(cbTransmission.Text)
                    && !string.IsNullOrWhiteSpace(txtHorsePower.Text) && !string.IsNullOrWhiteSpace(txtPrice.Text))

                {
                    if (db.Brands.FirstOrDefault(b=>b.Name==txtNewBrands.Text)==null
                        && db.Cars.FirstOrDefault(c => c.Number == txtNumber.Text) == null)
                    {
                        Brands brands = new Brands();
                        brands.Name = txtNewBrands.Text;
                        db.Brands.Add(brands);
                        db.SaveChanges();
                        CarModels carModels = new CarModels();
                        carModels.Name = txtModels.Text;
                        int brandid = db.Brands.FirstOrDefault(b => b.Name == txtNewBrands.Text).ID;

                        carModels.BrandsID = brandid;

                        db.CarModels.Add(carModels);
                        db.SaveChanges();
                        int carmodelid = 0;
                        if (db.CarModels.FirstOrDefault(cm => cm.Name == txtModels.Text) != null)
                        {
                            carmodelid = db.CarModels.FirstOrDefault(cm => cm.Name == txtModels.Text).ID;
                        }
                        else
                        {
                            MessageBox.Show("is nullable");
                        }
                        int fueltypeid = db.FuelType.FirstOrDefault(ft => ft.Name == cbFuelType.Text).ID;
                        int transmissionid = db.Transmission1.FirstOrDefault(t => t.Name == cbTransmission.Text).ID;


                        Cars cars = new Cars();

                        cars.CarModelsID = carmodelid;
                        cars.BrandsID = brandid;
                        cars.Number = txtNumber.Text;                    
                        cars.Year = Convert.ToInt32(txtYear.Text);
                        cars.FuelTypeID = fueltypeid;
                        cars.TransmissionID = transmissionid;
                        cars.HorsePower = Convert.ToInt32(txtHorsePower.Text);
                        cars.Price = Convert.ToInt32(txtPrice.Text);
                       db.Cars.Add(cars);

                        db.SaveChanges();
                        Reset();
                        MessageBox.Show("New Car Add seccessfully");
                        FillDgvCarRuslt();
                        FillBrnads();
                    }
                    else
                    {
                        MessageBox.Show("This Brand Has been in List. Please Choose in Existing Brands OR  Number cannot be the same.Please Check the Information!");
                        Reset();
                      
                    }
                }
                else
                {
                    lblError.Visible = true;
                }

            }
            else if(cbExistingBrands.Visible == false && txtNewBrands.Visible == false && string.IsNullOrWhiteSpace(cbExistingBrands.Text) && string.IsNullOrWhiteSpace(txtNewBrands.Text))
            {
                MessageBox.Show("Please select and add All information");
            }
            else
            {
                MessageBox.Show("your can only one choice");
            }
        }
        private void txtCarSearch_TextChanged(object sender, EventArgs e)
        {
            dgvcarResult.Rows.Clear();
            List<Cars> cars = db.Cars.ToList();
            var cs = db.Cars.Where(c => c.Brands.Name.Contains(txtCarSearch.Text) | c.CarModels.Name.Contains(txtCarSearch.Text)).ToList();

            foreach (Cars item in cs)
            {
                dgvcarResult.Rows.Add(item.ID, item.Brands.Name, item.CarModels.Name, item.Number, item.Year, item.FuelType.Name, item.Transmission1.Name,item.HorsePower,item.Price);

            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
     
            //if (cars==null)
            //{
            //    MessageBox.Show("This Choose is not true");
            //}
            //else
            //{
                if (txtNewBrands.Visible == true && !string.IsNullOrWhiteSpace(txtNewBrands.Text))
                {
                    Cars cars = db.Cars.Find(SelectedID);
                //Brands brands = db.Brands.Find(this.SelectedID);
                Brands brands = new Brands();
                brands.Name = txtNewBrands.Text;
                //db.Brands.Add(brands);
                db.SaveChanges();
                int brandid = db.Brands.FirstOrDefault(b => b.Name == txtNewBrands.Text).ID;
                //CarModels carModels = db.CarModels.Find(this.SelectedID);
                CarModels carModels = new CarModels();
                carModels.Name = txtModels.Text;
                carModels.BrandsID = brandid;
                db.CarModels.Add(carModels);
                db.SaveChanges();
                int carmodelid = db.CarModels.FirstOrDefault(cm => cm.Name == txtModels.Text).ID;
                int fueltypeid = db.FuelType.FirstOrDefault(ft => ft.Name == cbFuelType.Text).ID;
                int transmissionid = db.Transmission1.FirstOrDefault(t => t.Name == cbTransmission.Text).ID;
                cars.CarModelsID = carmodelid;
                cars.BrandsID = brandid;
                cars.Number = txtNumber.Text;
                    cars.Year = Convert.ToInt32(txtYear.Text);
                    cars.FuelTypeID = fueltypeid;
                    cars.TransmissionID = transmissionid;
                    cars.HorsePower = Convert.ToInt32(txtHorsePower.Text);
                    cars.Price = Convert.ToInt32(txtPrice.Text);
                    db.SaveChanges();
                    Reset();
                    MessageBox.Show(" Car Models Information Updated ");
                    FillDgvCarRuslt();
                    FillBrnads();
                }
                else if(cbExistingBrands.Visible == true && !string.IsNullOrWhiteSpace(cbExistingBrands.Text)) 
                {
                    Cars cars = db.Cars.Find(SelectedID);             
                    //Brands brands = new Brands();
                    //brands.Name = cbExistingBrands.Text;
                    //db.Brands.Add(brands);
                    //db.SaveChanges();
                    int brandid = db.Brands.FirstOrDefault(b => b.Name == cbExistingBrands.Text).ID;
                    CarModels carModels = new CarModels();
                    carModels.Name = txtModels.Text;
                    carModels.BrandsID = brandid;
                    db.CarModels.Add(carModels);
                    db.SaveChanges();
                    int carmodelid = db.CarModels.FirstOrDefault(cm => cm.Name == txtModels.Text).ID;
                    int fueltypeid = db.FuelType.FirstOrDefault(ft => ft.Name == cbFuelType.Text).ID;
                    int transmissionid = db.Transmission1.FirstOrDefault(t => t.Name == cbTransmission.Text).ID;
                    cars.BrandsID = brandid;
                    cars.CarModelsID = carmodelid;
                    cars.Number = txtNumber.Text;
                    cars.Year = Convert.ToInt32(txtYear.Text);
                    cars.FuelTypeID = fueltypeid;
                    cars.TransmissionID = transmissionid;
                    cars.HorsePower = Convert.ToInt32(txtHorsePower.Text);
                    cars.Price = Convert.ToInt32(txtPrice.Text);
                    db.SaveChanges();  
                    Reset();
                    MessageBox.Show("Car Brnads Information Updated ");
                    FillDgvCarRuslt();
                    FillBrnads();                 
                }
 
            //}
           
        }

        private void dgvcarResult_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
              if (txtNewBrands.Visible == false && cbExistingBrands.Visible == false)
            {
                MessageBox.Show("Please Choose to Change Brand or Model Information!");
                Reset();
            }
            else
            {
                SelectedID = Convert.ToInt32(dgvcarResult.Rows[e.RowIndex].Cells[0].Value);
                if (txtNewBrands.Visible == true)
                {
                    txtNewBrands.Text = dgvcarResult.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtModels.Text = dgvcarResult.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtNumber.Text = dgvcarResult.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtYear.Text = dgvcarResult.Rows[e.RowIndex].Cells[4].Value.ToString();
                    cbFuelType.Text = string.Empty;
                    cbFuelType.SelectedText = dgvcarResult.Rows[e.RowIndex].Cells[5].Value.ToString();
                    cbTransmission.Text = string.Empty;
                    cbTransmission.SelectedText = dgvcarResult.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtHorsePower.Text = dgvcarResult.Rows[e.RowIndex].Cells[7].Value.ToString();
                    txtPrice.Text = dgvcarResult.Rows[e.RowIndex].Cells[8].Value.ToString();
                }
                else
                {
                    cbExistingBrands.Text = string.Empty;
                    cbExistingBrands.SelectedText = dgvcarResult.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtModels.Text = dgvcarResult.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtNumber.Text = dgvcarResult.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtYear.Text = dgvcarResult.Rows[e.RowIndex].Cells[4].Value.ToString();
                    cbFuelType.Text = string.Empty;
                    cbFuelType.SelectedText = dgvcarResult.Rows[e.RowIndex].Cells[5].Value.ToString();
                    cbTransmission.Text = string.Empty;
                    cbTransmission.SelectedText = dgvcarResult.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtHorsePower.Text = dgvcarResult.Rows[e.RowIndex].Cells[7].Value.ToString();
                    txtPrice.Text = dgvcarResult.Rows[e.RowIndex].Cells[8].Value.ToString();
                }
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Cars cars = db.Cars.Find(this.SelectedID);
            Brands brands = db.Brands.Find(this.SelectedID);
            db.Cars.Remove(cars);
            db.Brands.Remove(brands);
            db.SaveChanges();
            Reset();
            MessageBox.Show("Car Information hea been Deleted");
            FillDgvCarRuslt();
        }
    }
}
