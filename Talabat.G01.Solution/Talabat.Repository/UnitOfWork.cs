﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.IRepositories;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreContext context) 
        {
            _context = context;
        }
        public async Task<int> Complete()
         => await _context.SaveChangesAsync();

        public void Dispose()
        {
           _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity 
        {
            if(_repositories ==null)
                _repositories = new Hashtable();
            var type = typeof(TEntity).Name; // TEntity =>(Product,Order,.........)

            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(_context);
                _repositories.Add(type, repository);
            }

            return (IGenericRepository<TEntity>)_repositories[type];// return object from repository<TEntity> 
        }
    }
}
