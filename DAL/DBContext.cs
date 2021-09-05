using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions options) : base(options)
		{
		}
		public DBContext() : base()
		{ }
		public virtual DbSet<URLSegment> URLSegment { get; set; }
	}
}
