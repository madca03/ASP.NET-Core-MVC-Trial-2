using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreDBFirstRestful.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Skill { get; set; }
        public int YearsExperience { get; set; }
    }
}
