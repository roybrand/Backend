﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<IReadOnlyList<T>> GetAsync();

       // Task<T> GetByIdAsync(int id);   

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity); 

        Task DeleteAsync(int id);   

    }
}
