using System;

namespace BatimetryApp.Services.Interfaces
{
	public interface IAwsResourceLocator
	{
		string CreateResourcePath(DateTime date);
	}
}
