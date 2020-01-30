using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverSim;
using System.Drawing;

namespace RoverTest
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void MoveNorthTest()
        {
            Rover rover = new Rover(new Point(1,1), new Rectangle(0, 0, 5, 5));

            rover.Move();

            Assert.AreEqual(rover.Position.X, 1);
            Assert.AreEqual(rover.Position.Y, 2);
        }

        [TestMethod]
        public void MoveEastTest()
        {
            Rover rover = new Rover(new Point(1, 1), new Rectangle(0, 0, 5, 5), Direction.East);

            rover.Move();

            Assert.AreEqual(rover.Position.X, 2);
            Assert.AreEqual(rover.Position.Y, 1);
        }

        [TestMethod]
        public void MoveSouthTest()
        {
            Rover rover = new Rover(new Point(1, 1), new Rectangle(0, 0, 5, 5), Direction.South);

            rover.Move();

            Assert.AreEqual(rover.Position.X, 1);
            Assert.AreEqual(rover.Position.Y, 0);
        }

        [TestMethod]
        public void MoveWestTest()
        {
            Rover rover = new Rover(new Point(1, 1), new Rectangle(0, 0, 5, 5), Direction.West);

            rover.Move();

            Assert.AreEqual(rover.Position.X, 0);
            Assert.AreEqual(rover.Position.Y, 1);
        }
    }
}