using JetBrains.Annotations;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Futurify.Training.Employees.Models;
using Orchard.Environment.Extensions;
using Orchard.ContentManagement;
using System.Linq;
using System;
using System.Collections.Generic;


namespace Futurify.Training.Employees.Handlers
{
    public class EmployeesPartHandler:ContentHandler
    {
        public EmployeesPartHandler(IRepository<EmployeesPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }

    }
}