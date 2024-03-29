﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        // get data
        ICollection<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(int id);
        //create
        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        //update
        void Update(TEntity entity);
        //delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        //save
        Task<bool> SaveAsync();
    }
}
