using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CommandActions;

namespace Core
{
	public static class CommandActionFactory
	{
		private static ICommandAction Action { get; set; }

		public static ICommandAction CreateCommandAction(Command command)
		{
			switch (command)
			{
				case Command.All:
					Action = new AllCommandAction();
					break;
				case Command.Cрр:
					Action = new CppCommandAction();
					break;
				case Command.Reversed1:
					Action = new Reversed1CommandAction();
					break;
				case Command.Reversed2:
					Action = new Reversed2CommandAction();
					break;
				default:
					throw new Exception();
			}
			return Action;
		}

	}
}
