using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CommandActions
{
	public class Reversed1CommandAction: ReversedCommandAction
	{
		internal override string InvertFilePath(string filePath)
		{
			return string.Join("/", filePath.Split("/".ToCharArray()).Reverse());
		}
	}
}
