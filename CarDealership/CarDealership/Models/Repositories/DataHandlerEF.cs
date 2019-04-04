﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using CarDealership.Models.DataModels;
using CarDealership.Models.ServiceModels;

namespace CarDealership.Models.Repositories
{
    public class DataHandlerEF : IDataHandler
    {
        private static CarDealershipEntities _database = new CarDealershipEntities();
        public IEnumerable<Car> SearchCars(bool isAdmin, bool isSales, bool isNew, int minYear, int maxYear, decimal minPrice, decimal maxPrice, string makeModelYear)
        {
            IEnumerable<Car> firstResult = _database.Cars.Where(c => ((isAdmin || isSales) || c.IsNew == isNew)
                                             && c.Purchases.Count == 0
                                             && c.SalePrice <= maxPrice && c.SalePrice >= minPrice
                                             && c.CarYear <= maxYear && c.CarYear >= minYear
                                             && (c.Model.ModelName.Contains(makeModelYear) 
                                                 || c.Make.MakeName.Contains(makeModelYear)
                                                 || c.CarYear.ToString().Contains(makeModelYear)));
            return isAdmin ? firstResult : firstResult.OrderByDescending(c => c.MSRP).Take(20);
        }

        public IEnumerable<Car> GetInventory(bool isPurchased)
        {
            return _database.Cars.Where(c => c.Purchases.Any() == isPurchased);
        }

        public IEnumerable<Car> GetFeatured()
        {
            return _database.Cars.Where(c => c.IsFeatured);
            //    .Select(c => new Car
            //{
            //    CarYear = c.CarYear,
            //    Make = c.Make,
            //    Model = c.Model,
            //    SalePrice = c.SalePrice
            //});
        }

        public Car AddVehicle(Car newVehicle)
        {
            newVehicle = _database.Cars.Add(newVehicle);
            _database.SaveChanges();
            return newVehicle;
        }

        public void EditVehicle(Car editedVehicle)
        {
            if(editedVehicle.Make == null || editedVehicle.Model == null)
            {
                editedVehicle.Model = _database.Models.FirstOrDefault(m => m.ModelID == editedVehicle.ModelID);
                editedVehicle.Make = _database.Makes.FirstOrDefault(m => m.MakeID == editedVehicle.MakeID);
            }

            _database.Cars.AddOrUpdate(editedVehicle);
            _database.SaveChanges();
        }

        public Make AddMake(string makeName, string userName)
        {
            Make newMake = _database.Makes.Create();
            newMake.MakeName = makeName;
            newMake.UserAdded = userName;
            newMake.DateAdded = DateTime.Today;
            Make output = _database.Makes.Add(newMake);
            _database.SaveChanges();
            return output;
        }

        public Model AddModel(string modelName, int makeID, string userName)
        {
            Model newModel = _database.Models.Create();
            newModel.ModelName = modelName;
            newModel.MakeID = makeID;
            newModel.UserAdded = userName;
            newModel.DateAdded = DateTime.Today;
            Model output = _database.Models.Add(newModel);
            _database.SaveChanges();
            return output;
        }

        public Car GetVehicleByID(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=CarDealership;User Id=CarApp;Password=Testing123;";
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetByID"
                };
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                using (SqlDataReader input = cmd.ExecuteReader())
                {
                    while (input.Read())
                    {
                        Car car = new Car
                        {
                            CarID = (int) input["CarID"],
                            VIN = input["VIN"].ToString(),
                            BodyStyle = input["BodyStyle"].ToString(),
                            Transmission = input["Transmission"].ToString(),
                            Interior = input["Interior"].ToString(),
                            MSRP = decimal.Parse(input["MSRP"].ToString()),
                            SalePrice = decimal.Parse(input["SalePrice"].ToString()),
                            Mileage = (int) input["Mileage"],
                            Color = input["Color"].ToString(),
                            CarYear = (int) input["CarYear"],
                            MakeID = (int) input["MakeID"],
                            ModelID = (int) input["ModelID"],
                            CarDescription = input["CarDescription"].ToString(),
                            IsNew = (int) input["Mileage"] < 1000,
                            IsFeatured = (bool) input["IsFeatured"],
                            ImgExtension = input["ImgExtension"].ToString()
                        };
                        try
                        {
                            car.Model = _database.Models.FirstOrDefault(m => m.ModelID == car.ModelID);
                            car.Make = _database.Makes.FirstOrDefault(m => m.MakeID == car.MakeID);
                            // ReSharper disable once PossibleNullReferenceException
                            car.Purchases = _database.Cars.Find(id).Purchases;
                        }
                        catch (InvalidOperationException)
                        {
                            //This is designed to stop unintended EF accesses from other projects where they are not needed. The data is not usually used this way, and can be populated in other ways, so this should be safe to add.
                        }
                        conn.Close();
                        return car;
                    }
                }

                return null;
            }
        }

        public int DeleteVehicle(int id)
        {
            return _database.DeleteByID(id);
        }

        public IEnumerable<Make> GetMakes()
        {
            return _database.Makes;
        }

        public IEnumerable<Model> GetModels()
        {
            return _database.Models;
        }

        public IEnumerable<Special> GetSpecials()
        {
            return _database.Specials;
        }

        public Special AddSpecial(string title, string description)
        {
            Special newSpecial = _database.Specials.Create();
            newSpecial.SpecialDescription = description;
            newSpecial.SpecialName = title;
            Special output = _database.Specials.Add(newSpecial);
            _database.SaveChanges();
            return output;
        }

        public void DeleteSpecial(int id)
        {
            _database.Entry(_database.Specials.Find(id)).State = EntityState.Deleted;
            _database.SaveChanges();
        }

        public Purchase AddPurchase(Purchase newPurchase)
        {
            Purchase output = _database.Purchases.Add(newPurchase);
            _database.SaveChanges();
            return output;
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            return _database.Purchases;
        }

        public Contact AddContact(string contactName, string contactMsg, string email, string phone)
        {
            Contact newContact = _database.Contacts.Create();
            newContact.ContactName = contactName;
            newContact.ContactMessage = contactMsg;
            newContact.Email = email;
            newContact.Phone = phone;
            Contact output = _database.Contacts.Add(newContact);
            _database.SaveChanges();
            return output;
        }
    }
}