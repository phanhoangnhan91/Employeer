using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futurify.Training.Employees.Models
{
    public class EmployeesPartRecord : ContentPartRecord
    {
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual Int32  Age { get; set; }
    }
}