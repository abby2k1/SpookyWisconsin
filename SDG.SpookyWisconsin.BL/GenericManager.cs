using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.PL;
using SGD.SpookyWisconsin.Entities;

namespace SGD.SpookyWisconsin.BL
{
    public abstract class GenericManager<T> where T : class, IEntity
    {
        protected DbContextOptions<SpookyWisconsinEntities> options;

        public GenericManager(DbContextOptions<SpookyWisconsinEntities> options)
        {
            this.options = options;
        }

        public GenericManager() { }

        public List<T> Load()
        {
            try
            {
                //var rows = new SpookyWisconsinEntities(options).Set<T>().ToList();
                //return rows;
                return new SpookyWisconsinEntities(options)
                    .Set<T>()
                    .ToList()
                    .OrderBy(x => x.SortField)
                    .ToList<T>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T LoadById(Guid id)
        {
            try
            {
                var row = new SpookyWisconsinEntities(options).Set<T>().Where(t => t.Id == id).FirstOrDefault();
                return row;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    entity.Id = Guid.NewGuid();

                    dc.Set<T>().Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    //Need to write the code to say the it was updated because it's generic
                    dc.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    T row = dc.Set<T>().FirstOrDefault(t => t.Id == id);

                    if (row != null)
                    {
                        dc.Set<T>().Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) dbTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
