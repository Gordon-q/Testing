using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Core.CommandActions
{
	public abstract class ReversedCommandAction:ICommandAction
	{
		public IEnumerable<string> GetFiles(string baseDirectoryPath)
		{
			return Directory.EnumerateFiles(baseDirectoryPath, "*.*", SearchOption.AllDirectories)
				.Select(fileName => InvertFilePath(fileName.GetRelativePath(baseDirectoryPath)));
		}
		public IEnumerable<string> GetFilesAsync(string baseDirectoryPath)
		{
			return Task<IEnumerable<string>>.Run(() => Directory.EnumerateFiles(baseDirectoryPath, "*.*", SearchOption.AllDirectories)).GetAwaiter().GetResult()
				.Select(fileName => InvertFilePath(fileName.GetRelativePath(baseDirectoryPath)));
		}

		internal abstract string InvertFilePath(string filePath);
	}
}
