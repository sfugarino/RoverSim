using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverSim;

namespace RoverTest
{

    [TestClass]
    public class CommandParserTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullCommandLineTest()
        {
            CommandParser.ParseCommands(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptylCommandLineTest()
        {
            CommandParser.ParseCommands("  ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InVailidCommandLineTest()
        {
            CommandParser.ParseCommands("AMLRB");
        }

        [TestMethod]
        public void ValidCommandLineTest()
        {
            var commands = CommandParser.ParseCommands("LRMRLM");
            Assert.IsTrue(commands.Length == 6);
            Assert.AreEqual(commands[0], RoverCommand.RotateLeft);
            Assert.AreEqual(commands[1], RoverCommand.RotateRight);
            Assert.AreEqual(commands[2], RoverCommand.Move);
            Assert.AreEqual(commands[3], RoverCommand.RotateRight);
            Assert.AreEqual(commands[4], RoverCommand.RotateLeft);
            Assert.AreEqual(commands[5], RoverCommand.Move);
        }

    }
}