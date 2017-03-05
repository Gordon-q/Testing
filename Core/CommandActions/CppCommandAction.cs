using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Core.CommandActions
{
	public class CppCommandAction : ICommandAction
	{
		public IEnumerable<string> GetFiles(string baseDirectoryPath)
		{
			return Directory.EnumerateFiles(baseDirectoryPath, "*.cpp", SearchOption.AllDirectories).Select(fileName => fileName.GetRelativePath(baseDirectoryPath)); ;
		}
		public IEnumerable<string> GetFilesAsync(string baseDirectoryPath)
		{
			return Task<IEnumerable<string>>.Run(() => Directory.EnumerateFiles(baseDirectoryPath, "*.cpp", SearchOption.AllDirectories)).GetAwaiter().GetResult()
				.Select(fileName => fileName.GetRelativePath(baseDirectoryPath) + " /");
		}
	}
}
