using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CommandActions
{
	public interface ICommandAction
	{
		IEnumerable<string> GetFiles(string baseDirectoryPath);
		IEnumerable<string> GetFilesAsync(string baseDirectoryPath);
	}
}
