using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {

        }
        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options)
        {

        }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Supervisor> Supervisor { get; set; }

    }
}
