using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly DBContext DBContext;
		public Repository(DBContext _DBContext)
		{
			DBContext = _DBContext;
		}

		public IEnumerable<T> GetAll()
		{
			return DBContext.Set<T>().ToList();
		}

		public void Insert(T entity)
		{
			DBContext.Set<T>().Add(entity);
			DBContext.SaveChanges();
		}
	}
}
