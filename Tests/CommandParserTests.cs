using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace Tests
{
	[TestClass]
	public class CommandParserTests
	{
		[TestMethod]
		public void GetCommandsTest()
		{
			string commandName = "all";
			Assert.IsTrue(CommandWrapper.GetCommandByDescription(commandName) == Command.All);
			commandName = "cpp";
			Assert.IsTrue(CommandWrapper.GetCommandByDescription(commandName) == Command.Cрр);
			commandName = "reversed1";
			Assert.IsTrue(CommandWrapper.GetCommandByDescription(commandName) == Command.Reversed1);
			commandName = "reversed2";
			Assert.IsTrue(CommandWrapper.GetCommandByDescription(commandName) == Command.Reversed2);
		}
	}
}
