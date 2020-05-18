using System;
using System.Collections.Generic;

namespace EFCoreDBFirstRestful.Models
{
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public int? SkillId { get; set; }
        public int? YearsExperience { get; set; }
    }
}
