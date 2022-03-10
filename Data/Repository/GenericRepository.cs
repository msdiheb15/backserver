
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        // here goes the application logic
        private DataContext _context = null;
        private DbSet<TEntity> table = null;

        public GenericRepository(DataContext context)
        {
            _context = context;
            table = _context.Set<TEntity>(); // return set of the given entity 
        }
        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> condition,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            try
            {
                IQueryable<TEntity> query = table;

                if (includes != null)
                {
                    query = includes(query); // ????
                }
                if (condition != null)
                {
                    return query.Where(condition).ToList();
                }
                else
                    return query.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            try
            {
                IQueryable<TEntity> query = table;

                if (includes != null)
                {
                    query = includes(query);
                }
                if (condition != null)
                {
                    return query.Where(condition).FirstOrDefault(); // same as  list 
                }

                else
                    return query.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                table.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;

            }
            return entity;

        }

        //public TEntity Delete(Guid id)
        //{
        //    TEntity existing = table.Find(id);
        //    table.Remove(existing);
        //    _context.SaveChanges();
        //    return existing;

        //}

        public String Delete(Guid id)
        {
            if (id == null)
            {
                return "Id null";
            }

            try
            {
                TEntity existing = table.Find(id);
                table.Remove(existing);
                _context.SaveChanges();

                JsonConvert.SerializeObject(existing, Formatting.Indented,
                   new JsonSerializerSettings
                   {
                       ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        //ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                return "Done";
            }
            catch (Exception ex)
            {
                return ex.ToString();
                // return "could not be updated: {ex.Message}";
            }
        }

        public String DeleteCustomer(String id)
        {
            if (id == null)
            {
                return "Id null";
            }

            try
            {
                TEntity existing = table.Find(id);
                table.Remove(existing);
                _context.SaveChanges();

                JsonConvert.SerializeObject(existing, Formatting.Indented,
                   new JsonSerializerSettings
                   {
                       ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                       //ContractResolver = new CamelCasePropertyNamesContractResolver()
                   });
                return "Done";
            }
            catch (Exception ex)
            {
                return "Delete error";
                // return "could not be updated: {ex.Message}";
            }
        }


        public String Put(TEntity Entity)
        {
            if (Entity == null)
            {
                //throw new ArgumentNullException($"{nameof(Put)} entity must not be null");
                return "entity must not be null";
            }



            try
            {
                table.Attach(Entity);
                _context.Entry(Entity).State = EntityState.Modified;
                _context.SaveChanges();
                return JsonConvert.SerializeObject(Entity, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
            }
            catch (Exception ex)
            {
                //throw new Exception($"{nameof(Entity)} could not be updated: {ex.Message}");
                return "could not be updated";
            }
        }

        /*public TEntity Put(TEntity Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException($"{nameof(Put)} entity must not be null");
            }

            try
            {
                table.Attach(Entity);
                _context.Entry(Entity).State = EntityState.Modified;
                _context.SaveChanges();
                return Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(Entity)} could not be updated: {ex.Message}");
               // return "could not be updated: {ex.Message}";
            }
        }*/


        /*table.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Entity;*/

    }
}
