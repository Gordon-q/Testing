using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CommandActions
{
	public class Reversed2CommandAction : ReversedCommandAction
	{
		internal override string InvertFilePath(string filePath)
		{
			var reverted = filePath.ToCharArray();
			Array.Reverse(reverted);
			return new string(reverted);
		}
	}
}
