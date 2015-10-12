using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInfo
{
    /// <summary>
    /// Contains Methods for getting information about the current system 
    /// that the program is running on
    /// </summary>
    class clsSystem
    {

        /// <summary>
        /// Prints the name of PC
        /// </summary>
        /// <param name="bolNewLine">
        /// (Optional, Default TRUE) whether to write to a new line after printing
        /// information.
        /// </param>
        public static void GetBasicInfo(bool bolNewLine = true)
        {
            System.Console.Write("PC Name : ");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(System.Environment.MachineName.ToString());
            System.Console.ForegroundColor = ConsoleColor.Gray;

            System.Console.WriteLine(); // Create Blank Space for next Element
        }
    }
}
