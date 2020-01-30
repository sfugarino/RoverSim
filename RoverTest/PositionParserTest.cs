using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverSim;

namespace RoverTest
{

    [TestClass]
    public class PositionParserTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullInputTest()
        {
            Direction direction;
            PositionParser.ParsePosition(null, out direction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyInputTest()
        {
            Direction direction;
            PositionParser.ParsePosition("  ", out direction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyInvalidTextTest()
        {
            Direction direction;
            PositionParser.ParsePosition("AB C", out direction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InVailidXTest()
        {
            Direction direction;
            PositionParser.ParsePosition("A 7 N", out direction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InVailidYTest()
        {
            Direction direction;
            PositionParser.ParsePosition("7 Y N", out direction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InVailidDirectionTest()
        {
            Direction direction;
            PositionParser.ParsePosition("7 7 @", out direction);
        }

        [TestMethod]
        public void ValidInputTest()
        {
            Direction direction;
            var point = PositionParser.ParsePosition("7 8 S", out direction);
            Assert.AreEqual(point.X, 7);
            Assert.AreEqual(point.Y, 8);
            Assert.AreEqual(direction, Direction.South);
        }
    }
}
