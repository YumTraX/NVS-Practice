using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NVS_PRA2_B.Models
{
    public class Person
    {
        [Required]
        public int id { get; set; }
        public int age { get; set; }
    }
}