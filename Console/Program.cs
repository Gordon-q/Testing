using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Core;
using Core.CommandActions;

namespace Console
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length >= 2)
			{
				Command command = CommandWrapper.GetCommandByDescription(args[1]);
				if (!command.HasFlag(Command.Invalid))
				{
					string rootFolder = args[0];
					if(Directory.Exists(rootFolder))
					{
						ICommandAction action = CommandActionFactory.CreateCommandAction(command);
						var files = action.GetFilesAsync(rootFolder);
						string reportPath = args.Length == 3 ? args[3] : CommandWrapper.DefaultReportFilePath;
						if (Directory.Exists(Path.GetDirectoryName(rootFolder)))
						{
							CommandWrapper.WriteCommandResultsToReport(files, reportPath);
						}
						else
						{
							System.Console.WriteLine("Report directory not found");
						}
					}
					else
					{
						System.Console.WriteLine("Invalid root path");
					}
				}
				else
				{
					System.Console.WriteLine("Invalid command");
				}
			}
			else
			{
				System.Console.WriteLine("Too few arguments");
			}
		}
	}
}
