using BAL.IService;
using DAL.IRepository;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Service
{
	public class URLSegmentService : IURLSegmentService
	{
		private readonly ISegmentRepository SegmentRepo;
		public URLSegmentService(ISegmentRepository _SegmentRepo)
		{
			SegmentRepo = _SegmentRepo;
		}

		public string AddSegment(string url)
		{
			string segmentstring = GenerateSegment();
			SegmentRepo.Insert(new URLSegment() {Segment=segmentstring,URL=url });
			return segmentstring;
			 
		}

		public IEnumerable<URLSegment> GetAll()
		{
			return SegmentRepo.GetAll();
		}
		public string CheckURLExsitance(string url)
		{
			return SegmentRepo.CheckURLExsitance(url);
		}
		private string GenerateSegment()
		{
			var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var Charsarr = new char[8];
			var random = new Random();

			for (int i = 0; i < Charsarr.Length; i++)
			{
				Charsarr[i] = characters[random.Next(characters.Length)];
			}

			var segmentstring = new String(Charsarr);
			if (SegmentRepo.CheckSegmentExsitance(segmentstring))
				return GenerateSegment();
			else
				return segmentstring;
		}
	}
}
