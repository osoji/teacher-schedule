using Microsoft.EntityFrameworkCore;
using RankenSchedule.UI.Models.DomainModels;

namespace RankenSchedule.UI.Models.DataLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ClassScheduleContext context { get; set; }
        private DbSet<T> dbSet {  get; set; }

        public Repository(ClassScheduleContext ctx)
        {
            context = ctx;
            dbSet = context.Set<T>();
        }
        public void Delete(T entity)=>dbSet.Remove(entity);

        public T? Get(int id)=>dbSet.Find(id);

        public T? Get(QueryOption<T> options)
        {
            IQueryable<T> query = dbSet;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);

            return query.FirstOrDefault();
        }

        public void Insert(T entity)=> dbSet.Add(entity);

        public IEnumerable<T> List(QueryOption<T> options)
        {
            IQueryable<T> query = dbSet;
            foreach (string include in options.GetIncludes()) 
            { 
                query = query.Include(include);
            }
            if(options.HasWhere)
                query = query.Where(options.Where);

            if (options.HasOrderBy)
            {
                if (options.HasThenOrderBy)
                {
                    query = query.OrderBy(options.OrderBy).ThenBy(options.ThenOrderBy);
                }
                else
                {
                    query = query.OrderBy(options.OrderBy);
                }
            }

            return query.ToList();
        }

        public void Save()=>context.SaveChanges();

        public void Update(T entity)=>dbSet.Update(entity);
    }
}
