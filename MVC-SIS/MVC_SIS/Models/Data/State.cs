using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State
    {
        [Required(ErrorMessage = "State Abbreviation is required")]
        public string StateAbbreviation { get; set; }
        [Required(ErrorMessage = "State Name is required")]
        public string StateName { get; set; }
    }
}