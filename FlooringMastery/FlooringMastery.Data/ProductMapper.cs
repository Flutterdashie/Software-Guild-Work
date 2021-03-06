﻿using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public static class ProductMapper
    {
        public static List<Product> GetAllProducts()
        {
            List<Product> result = new List<Product>();
            List<string> lines = File.ReadAllLines(GetPath()).ToList();
            if (lines.First() == "ProductType,CostPerSquareFoot,LaborCostPerSquareFoot")
            {
                lines.RemoveAt(0);
            }
            else
            {
                throw new FormatException("Header line of product file is missing or invalid. Your file may have been compromised.");
            }


            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                result.Add(new Product(values[0], decimal.Parse(values[1]), decimal.Parse(values[2])));
            }
            return result;
        }

        private static string GetPath()
        {
            return ConfigurationManager.AppSettings.Get("FileTestMode") == "true"
                ? @"C:\Users\Jacob\Documents\bitbucket\jacob-harris-individual-work\FlooringMastery\FlooringMastery\bin\Debug\Products.txt"
                : @".\Products.txt";
        }
    }

}
