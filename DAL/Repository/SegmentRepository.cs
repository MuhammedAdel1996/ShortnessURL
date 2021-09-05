using DAL.IRepository;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
	public class SegmentRepository:Repository<URLSegment>,ISegmentRepository
	{
		private readonly DBContext DbContext;

		public SegmentRepository(DBContext dbContext) : base(dbContext)
		{
			DbContext = dbContext;
		}
		public string CheckURLExsitance(string url)
		{
			var result = DbContext.URLSegment.Where(s => s.URL == url).FirstOrDefault();
			if (result == null)
				return "";
			else
				return result.Segment;
		}
		public bool CheckSegmentExsitance(string segment)
		{
			var result = DbContext.URLSegment.Where(s => s.Segment == segment).FirstOrDefault();
			if (result == null)
				return false;
			else
				return true;
		}
	}
}
