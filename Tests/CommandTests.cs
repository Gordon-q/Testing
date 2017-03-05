using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System.IO;

namespace Tests
{
	[TestClass]
	public class CommandTests
	{
		public static readonly string MainFolder = @"C:\PlaytikaTest";
		public static readonly string All = @"C:\PlaytikaTest\All";
		public static readonly string Cpps = @"C:\PlaytikaTest\Cpps";
		public static readonly string Reversed1 = @"C:\PlaytikaTest\Reversed1";
		public static readonly string Reversed2 = @"C:\PlaytikaTest\Reversed2";

		[TestInitialize]
		public void Init()
		{
			Cleanup();
			Directory.CreateDirectory(MainFolder);
			Directory.CreateDirectory(All);
			File.Create(Path.Combine(All, "qwe.txt")).Close();
			File.Create(Path.Combine(All, "qwe1.cpp")).Close();
			File.Create(Path.Combine(All, "qwe2.pdf")).Close();
			File.Create(Path.Combine(All, "qwe3.jpg")).Close();
			File.Create(Path.Combine(All, "qwe4.doc")).Close();
			Directory.CreateDirectory(Cpps);
			File.Create(Path.Combine(Cpps, "qwe.txt")).Close();
			File.Create(Path.Combine(Cpps, "qwe1.cpp")).Close();
			File.Create(Path.Combine(Cpps, "qwe2.pdf")).Close();
			File.Create(Path.Combine(Cpps, "qwe3.jpg")).Close();
			File.Create(Path.Combine(Cpps, "qwe4.doc")).Close();
			Directory.CreateDirectory(Reversed1);
			File.Create(Path.Combine(Reversed1, "qwe.txt")).Close();
			File.Create(Path.Combine(Reversed1, "qwe1.cpp")).Close();
			File.Create(Path.Combine(Reversed1, "qwe2.pdf")).Close();
			File.Create(Path.Combine(Reversed1, "qwe3.jpg")).Close();
			File.Create(Path.Combine(Reversed1, "qwe4.doc")).Close();
			Directory.CreateDirectory(Reversed2);
			File.Create(Path.Combine(Reversed2, "qwe.txt")).Close();
			File.Create(Path.Combine(Reversed2, "qwe1.cpp")).Close();
			File.Create(Path.Combine(Reversed2, "qwe2.pdf")).Close();
			File.Create(Path.Combine(Reversed2, "qwe3.jpg")).Close();
			File.Create(Path.Combine(Reversed2, "qwe4.doc")).Close();
		}

		[TestCleanup]
		public void Cleanup()
		{
			if(Directory.Exists(MainFolder))
			{
				Directory.Delete(@"C:\PlaytikaTest", true);
			}
		}

		[TestMethod]
		public void AllCommandTest()
		{
			Assert.IsTrue(CommandActionFactory.CreateCommandAction(Command.All).GetFiles(All).Count() == 5);
		}

		[TestMethod]
		public void CppCommandTest()
		{
			Assert.IsTrue(CommandActionFactory.CreateCommandAction(Command.Cрр).GetFiles(Cpps).Count() == 1);
		}

		[TestMethod]
		public void Reversed1CommandTest()
		{
			var a = CommandActionFactory.CreateCommandAction(Command.Reversed1).GetFiles(Reversed1).OrderBy(fileName => fileName).First();
			Assert.IsTrue(a == @"qwe.txt/Reversed1");
		}

		[TestMethod]
		public void Reversed2CommandTest()
		{
			var a = CommandActionFactory.CreateCommandAction(Command.Reversed2).GetFiles(Reversed2).OrderBy(fileName => fileName)
				.First();
			Assert.IsTrue(a == @"Reversed2\qwe.txt".Reverse().ToString());
		}
	}
}
