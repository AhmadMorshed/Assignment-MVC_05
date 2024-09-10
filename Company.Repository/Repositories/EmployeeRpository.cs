using Company.Data.Context;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class EmployeeRpository : GenericRepository<Employee> ,IEmployeeRepository
    {
        private readonly CompanyDBContext _context;

        public EmployeeRpository( CompanyDBContext context) : base(context) 
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< Employee> GetEmployeeByName(string name)
        => _context.Employees.Where(x => x.Name.Trim().ToLower().Contains(name.Trim().ToLower())).ToList();
    }
}
