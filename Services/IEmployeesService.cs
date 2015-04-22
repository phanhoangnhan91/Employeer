using Orchard;
using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Futurify.Training.Employees.Services
{
    public interface IEmployeesService : IDependency
    {
       ContentItem GetById(int id);
    }
}
