using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace LeanPlanner.Data
{
    public class Db4ORepository : IRepository, IDisposable
    {
        private IObjectContainer _database;

        public Db4ORepository(IObjectServer server)
        {
            _database = server.OpenClient();
        }

        public void Dispose()
        {
            Commit();
            _database.Close();
            _database.Dispose();
        }

        public void Commit()
        {
            _database.Commit();
        }

        public void Rollback()
        {
            _database.Rollback();
        }

        public void Save<T>(T item)
        {
            _database.Store(item);
        }

        public IQueryable<T> All<T>()
        {
            return (from T item in _database select item).AsQueryable();
        }

        public void Delete<T>(T item)
        {
            _database.Delete(item);
        }

        public void Delete<T>(Expression<Func<T, bool>> expression)
        {
            All<T>().Where(expression).ToList().ForEach(t => _database.Delete(t));
        }
    }
}
