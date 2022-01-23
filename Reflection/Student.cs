using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Student
    {
        [Required]
        public string? StudentNo { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public double? SalaryCalculate(int hour, double charge) => hour * charge;
    }
}
