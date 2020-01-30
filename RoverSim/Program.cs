using System;

namespace RoverSim
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter Graph Upper Right Coordinate: ");
            string input = Console.ReadLine();
           
            System.Drawing.Point upper = PositionParser.ParseUperBound(input);

            Console.Write("Rover 1 Starting Position: ");
            input = Console.ReadLine();

            Direction heading;
            System.Drawing.Point start = PositionParser.ParsePosition(input, out heading);

            Rover rover = new Rover(start, new System.Drawing.Rectangle(0, 0, upper.X, upper.Y), heading);

            Console.Write("Rover 1 Movement Plan: ");
            input = Console.ReadLine();

            RoverCommand[] commands = CommandParser.ParseCommands(input);

            rover.ExecuteCommands(commands);

            Console.WriteLine("Rover 1 Output: {0} {1} {2}", rover.Position.X, rover.Position.Y, (char)rover.Heading);

            Console.Write("Rover 2 Starting Position: ");
            input = Console.ReadLine();

            start = PositionParser.ParsePosition(input, out heading);

            rover = new Rover(start, new System.Drawing.Rectangle(0, 0, upper.X, upper.Y), heading);

            Console.Write("Rover 2 Movement Plan: ");
            input = Console.ReadLine();

            commands = CommandParser.ParseCommands(input);

            rover.ExecuteCommands(commands);

            Console.WriteLine("Rover 2 Output: {0} {1} {2}", rover.Position.X, rover.Position.Y, (char)rover.Heading);

            Console.Write("Press any key to exit");
            Console.ReadKey();
        }
    }
}
