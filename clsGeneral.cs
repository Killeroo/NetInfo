using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInfo
{
    class clsGeneral
    {
        /// <summary>
        /// Creates a buffer by changing the console cursor position. Used for keeping elements on 
        /// console user interfaces (TUIs) alligned.
        /// </summary>
        /// <param name="iBufferSize">Intended Size of buffer</param>
        /// <param name="iContentSize">Size of content already on line (in characters)</param>
        /// <param name="iConsoleCursorTop">Current cursor Y Axis/Top</param>
        // TODO: Move to clsConsole class
        public static void CreateConsoleBuffer(int iBufferSize, int iContentSize, int iConsoleCursorTop)
        {
            int iBuffer = 0;

            if (iBufferSize > iContentSize)
            {
                iBuffer = iBufferSize - iContentSize;
            }

            System.Console.SetCursorPosition(iContentSize + iBuffer, iConsoleCursorTop);

        }
    }
}
