using Company.Data.Context;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDBContext _context;

        public UnitOfWork(CompanyDBContext context)
        {
            _context = context;
            DepartmentRepository = new DepartmentRepoository(context);
            EmployeeRepository = new EmployeeRpository(context);
        }
        public IDepartmentRepository DepartmentRepository { get; set ; }
        public IEmployeeRepository EmployeeRepository { get ; set; }

        public int Complete()
        
        =>   _context.SaveChanges();
        
    }
}
