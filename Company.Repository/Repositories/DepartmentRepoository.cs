using Company.Data.Context;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class DepartmentRepoository : GenericRepository<Department>,IDepartmentRepository
    {
        private readonly CompanyDBContext _context;

        public DepartmentRepoository(CompanyDBContext context):base(context) 
        {
            _context = context;   
        }
        
    }
}
