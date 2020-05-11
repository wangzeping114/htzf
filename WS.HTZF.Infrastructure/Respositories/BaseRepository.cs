using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WS.HTZF.Core.Exceptions;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Infrastructure.Respositories
{
    public abstract class BaseRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected HTZFDbContext DbContext { get; }
 
        protected DbSet<TEntity> Table => DbContext.Set<TEntity>();

        protected BaseRepository(HTZFDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ParameterNullException(nameof(dbContext));
        }

        public IQueryable<TEntity> Entities => Table.AsQueryable();

        public IUnitOfWork UnitOfWork => DbContext;


        /// <summary>
        /// 让EF跟踪实体状态
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = DbContext
                .ChangeTracker
                .Entries()
                .FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }
            Table.Attach(entity);
        }
        /// <summary>
        /// 获取数据总量
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> CountAsync()
        {
            return await Table.CountAsync();
        }
        /// <summary>
        /// 根据条件获取数据总量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.CountAsync(predicate);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual  async  Task DeleteAsync(TPrimaryKey id)
        {
            var entity = GetFromChangeTrackerOrNull(id) ?? await GetAsync(id);
            if (entity == null)
                return;

            await DeleteAsync(entity);
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await DbContext.Database.ExecuteSqlCommandAsync(sql, parameters);
        }
        /// <summary>
        /// 根据条件获取首条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await GetAllIncludingAsync();
        }
        /// <summary>
        /// 获取所有数据并可包含导航属性
        /// </summary>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = Table.AsQueryable();
            if (propertySelectors == null || !propertySelectors.Any())
                return  await Task.FromResult(query);

            query = propertySelectors.Aggregate(query,
                (current, propertySelector) => current.Include(propertySelector));

            return await Task.FromResult(query);
        }
        /// <summary>
        /// 获取所有数据列表(不跟踪数据)
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllListAsNoTrackingAsync()
        {
            return await Entities
                .AsNoTracking()
                .ToListAsync();
        }
        /// <summary>
        /// 获取所有数据列表(不跟踪数据)
        /// </summary>
        /// <returns></returns>
        public virtual  async Task<List<TEntity>> GetAllListAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities
                .AsNoTracking()
                .ToListAsync();
        }
        /// <summary>
        /// 获取所有数据列表
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> GetAllListAsync()
        {
            return await Entities.ToListAsync();
        }
        /// <summary>
        /// 根据查询条件获取数据列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities
                .Where(predicate)
                .ToListAsync();
        }
        /// <summary>
        /// 根据主键获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }
        /// <summary>
        /// 插入新数据并返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async  Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            entity = await InsertAsync(entity);
            if (entity.IsTransient())
                await DbContext.SaveChangesAsync();

            return entity.Id;
        }
        /// <summary>
        /// 插入新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (!entity.IsTransient())
                return entity;

            var newEntity = await Task.FromResult(Table.Add(entity));

            await UnitOfWork.SaveChangesAsync();

            return newEntity;
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task InsertEntitiesAsync(IEnumerable<TEntity> entities)
        {
            await Task.FromResult(Table.AddRange(entities));
        }
        /// <summary>
        /// 插入或更新数据并返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<TPrimaryKey> InsertOrUpdateAndGetId(TEntity entity)
        {
            return (await InsertOrUpdateAsync(entity)).Id;
        }

        /// <summary>
        /// 插入或更新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return entity.IsTransient()
                ? await InsertAsync(entity)
                : await UpdateAsync(entity);
        }
        /// <summary>
        /// 获取数据总量
        /// </summary>
        /// <returns></returns>
        public virtual async Task<long> LongCountAsync()
        {
            return await Table.LongCountAsync();
        }
        /// <summary>
        /// 根据条件获取数据总量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.LongCountAsync(predicate);
        }
        /// <summary>
        /// 根据条件获取唯一数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return entity.IsTransient()
                ? await InsertAsync(entity)
                : await UpdateAsync(entity);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            AttachIfNot(entity);
            var entry = DbContext.Entry(entity);
            foreach (var selector in properties)
            {
                entry.Property(selector).IsModified = true;
            }
            return await Task.FromResult(entity);
        }
        /// <summary>
        /// 根据主键更新数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateFunc"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateFunc)
        {
            var entity = await GetAsync(id);
            await updateFunc(entity);
            return entity;
        }

        /// <summary>
        /// 批量更新 暂时未实现
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task UpdateEntitiesAsync(IEnumerable<TEntity> entities)
        {
            await Task.CompletedTask;
        }

        private TEntity GetFromChangeTrackerOrNull(TPrimaryKey id)
        {
            var entry = DbContext.ChangeTracker.Entries()
                .FirstOrDefault(
                    ent =>
                        ent.Entity is TEntity entity &&
                        EqualityComparer<TPrimaryKey>.Default.Equals(id, entity.Id)
                );

            return entry?.Entity as TEntity;
        }
    }
}