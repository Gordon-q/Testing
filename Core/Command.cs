using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace Core
{
    public enum Command
    {
		[Description("")]
		Invalid = 5,
		[Description("all")]
		All = 1,
		[Description("cpp")]
		Cрр = 2,
		[Description("reversed1")]
		Reversed1 = 3,
		[Description("reversed2")]
		Reversed2 = 4
	}

	public static class CommandWrapper
	{
		public static readonly string DefaultReportFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "results.txt");
		public static Command GetCommandByDescription(string description)
		{
			Command command = Command.Invalid;
			if (!string.IsNullOrWhiteSpace(description))
			{
				foreach (Command commandItem in Enum.GetValues(typeof(Command)))
				{
					if (commandItem != Command.Invalid && GetCommandDescription(commandItem) == description.ToLower())
					{
						command = commandItem;
						break;
					}
				}
			}
			return command;
		}
		private static string GetCommandDescription(Command command)
		{
			var type = typeof(Command);
			var memInfo = type.GetMember(command.ToString());
			var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
			return ((DescriptionAttribute)attributes[0]).Description;
		}

		public static void WriteCommandResultsToReport(IEnumerable<string> actionResult, string filePath)
		{
			File.AppendAllLines(filePath, actionResult);
		}
		public static string GetRelativePath(this string fullPath, string basePath)
		{
			return new Uri(basePath).MakeRelativeUri(new Uri(fullPath)).ToString();
		}
	}
}
