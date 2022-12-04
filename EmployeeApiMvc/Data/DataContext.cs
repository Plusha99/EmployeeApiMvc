using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApiMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApiMvc.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}