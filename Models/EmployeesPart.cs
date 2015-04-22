using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futurify.Training.Employees.Models
{
    public class EmployeesPart:ContentPart<EmployeesPartRecord>
    {
        public string Name
        {
            get { return Record.Name; }
            set { Record.Name = value; }
        }
        public String Adress
        {
            get { return Record.Address; }
            set { Record.Address = value; }
        }
        public int Age
        {
            get { return Record.Age; }
            set { Record.Age = value; }
        }
    }
}