using System;
using System.Collections.Generic;

namespace EFCoreDBFirstRestful.Models
{
    public partial class Employees
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public int? SkillID { get; set; }
        public int? YearsExperience { get; set; }
    }
}
