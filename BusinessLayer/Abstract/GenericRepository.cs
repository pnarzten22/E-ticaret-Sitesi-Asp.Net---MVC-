using DataAccessLayer.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   
        public class GenericRepository<T> where T : class, new()
        {
            Context1 db = new Context1();

            public void Add(T data)
            {
                db.Set<T>().Add(data);
                db.SaveChanges();

            }

            public void Delete(T data)
            {
                db.Set<T>().Remove(data);
                db.SaveChanges();

            }
            public List<T> GetList()
            {
                return db.Set<T>().ToList();

            }

            public T GetById(int id)
            {
                return db.Set<T>().Find(id);

            }

            public void Update(T data)
            {

                db.Entry<T>(data).State = EntityState.Modified;
                db.SaveChanges();
            }


        }
    
}
