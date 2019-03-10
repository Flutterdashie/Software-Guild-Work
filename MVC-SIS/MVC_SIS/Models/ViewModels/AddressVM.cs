using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.ViewModels
{
    public class AddressVM
    {
        public Address Address { get; set; }
        public int StudentId { get; set; }
    }
}