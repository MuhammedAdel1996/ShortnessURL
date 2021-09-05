using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IRepository
{
	public interface IRepository<T>
	{
		void Insert(T entity);
		IEnumerable<T> GetAll();
	}
}
