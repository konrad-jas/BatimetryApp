using System;
using BatimetryApp.Services.Interfaces;

namespace BatimetryApp.Services
{
	public class AwsResourceLocator : IAwsResourceLocator
	{
		//the scheme is tiles/UTM code/latitude band/square/year/month/day/sequence/DATA
		private const string AwsResourcePathTemplate = "tiles/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}";

		public string CreateResourcePath(DateTime date)
		{
			return string.Empty;
		}
	}
}