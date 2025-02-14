﻿using Manage_School_Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly MVC_Context _context;

        public BaseRepository(MVC_Context context)
        {
            this._context = context;
        }
        public async Task Delete(int id)
        {
            var TModel = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(TModel);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(int? id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(mbox => mbox.ID == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
