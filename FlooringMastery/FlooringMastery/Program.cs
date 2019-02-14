﻿using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserIO userIO = new ConsoleIO();
            IOrderRepo repo = new FileOrderRepo();
            userIO.WriteLine(repo.GetSpecificOrder(1, new DateTime(2013, 6, 1)).GetFullOrderString());
            Console.ReadLine();
        }
    }
}
