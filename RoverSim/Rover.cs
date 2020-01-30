using System;
using System.Drawing;
using System.Runtime.CompilerServices;


namespace RoverSim
{
    public class Rover
    {
        public Rover(Point start, Rectangle fence, Direction heading = Direction.North)
        {
            Position = start;
            Heading = heading;
            Fence = fence;
        }

        public Point Position { get; private set; } = new Point();
        public Rectangle Fence { get; private set; } = new Rectangle();
        public Direction Heading { get; private set; } = Direction.North;

        public void ExecuteCommands(RoverCommand[] commands)
        {
            if (commands == null || commands.Length == 0)
                return;

            foreach(var command in commands)
            {
                ExecuteCommand(command);
            }
        }

        public void ExecuteCommand(RoverCommand command)
        {
            switch(command)
            {
                case RoverCommand.Move: Move(); break;
                case RoverCommand.RotateLeft: Rotate(false); break;
                case RoverCommand.RotateRight: Rotate(true); break;
            }
        }


        public void Rotate(bool clockwise)
        {
            switch(Heading)
            {
                case Direction.North: Heading = clockwise ? Direction.East : Direction.West; break;
                case Direction.East: Heading = clockwise ?  Direction.South : Direction.North; break;
                case Direction.South: Heading = clockwise ? Direction.West : Direction.East; break;
                case Direction.West: Heading = clockwise ?  Direction.North :  Direction.South; break;
            }
        }

        public void Move()
        {
            Point newPosition = Position;

            switch (Heading)
            {
                case Direction.North: newPosition += new Size(0, 1); break;
                case Direction.East: newPosition += new Size(1, 0); break;
                case Direction.South: newPosition += new Size(0, -1); break;
                case Direction.West: newPosition += new Size(-1, 0); break;
            }

            // Can't move outside the fence
            if (Fence.Contains(newPosition))
                Position = newPosition;
        }
    }
}
