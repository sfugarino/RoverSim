using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RoverSim
{
    public class CommandParser
    {
        public static RoverCommand[] ParseCommands(string commandList)
        {
            if (commandList == null || commandList.Trim().Length == 0)
                throw new ArgumentException("Command list can not be null or empty");

            if (!IsValidCommandString(commandList))
                throw new ArgumentException("Command string contains invalid arguments");


           return commandList.ToUpper().ToArray().Select(c => (RoverCommand)c).ToArray();
        }


        static bool IsValidCommandString(string commandList)
        {
            return commandList.ToUpper().All(c => "LRM".Contains(c));
        }
    }
}
