using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IRepository
{
	public interface ISegmentRepository  : IRepository<URLSegment>
	{
		string CheckURLExsitance(string url);
		bool CheckSegmentExsitance(string segment);
	}
}
