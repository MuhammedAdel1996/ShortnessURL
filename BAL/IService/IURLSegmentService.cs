using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.IService
{
	public interface IURLSegmentService
	{
		string AddSegment(string url);
		IEnumerable<URLSegment> GetAll();
		string CheckURLExsitance(string url);
	}
}
