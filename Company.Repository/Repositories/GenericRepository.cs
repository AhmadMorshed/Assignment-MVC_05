using Company.Data.Context;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CompanyDBContext _context;
        public GenericRepository(CompanyDBContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
           
        }
        public IEnumerable<T> GetAll()
        => _context.Set<T>().AsNoTracking().ToList();

        public T GetById(int id)
        => _context.Set<T>().Find(id);

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
