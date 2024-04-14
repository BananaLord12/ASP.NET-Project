﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(BoardGameWDbContext _context)
        {
            context= _context;
        }

        private DbSet<T> DbSet<T> () where T : class
        {
            return this.context.Set<T>();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        public async Task<int> SaveChangedAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<T> GetByIdsAsync<T>(object[] id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task DeleteAsync<T>(object id) where T : class
        {
            T? entity = await GetByIdAsync<T>(id);

            if(entity != null)
            {
                DbSet<T>().Remove(entity);
            }
        }

        public void Detach<T>(T entity) where T : class
        {
            EntityEntry entry = this.context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public async Task DeleteRangeAsync<T>(object[] id) where T : class
        {
            T? entities = await GetByIdsAsync<T>(id);

            if(entities != null)
            {
                DbSet<T>().RemoveRange(entities);
            }
        }

        public async Task DeleteEntity<T>(object[] id) where T : class
        {
            T? entity = await DbSet<T>().FindAsync(id);
            if(entity != null)
            {
                DbSet<T>().Remove(entity);
            }

        }
    }
}
