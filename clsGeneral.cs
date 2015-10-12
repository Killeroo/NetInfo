﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInfo
{
    class clsGeneral
    {
        /// <summary>
        /// Creates a buffer make of desired character to keep text/character based objects alligned 
        /// in a TUI (Text Based Interface) 
        /// </summary>
        /// <param name="iBufferSize">Size of buffer to create</param>
        /// <param name="iVariableLength">Length of variable so as to adapt buffer size</param>
        /// <param name="strBufferCharacter"> Character to use as buffer character (default " " [Space] )</param>
        /// <returns>Appropriate buffer length (returned as string) at correct size based on size of character</returns>
        public static string CreateTextBuffer(int iBufferSize, int iVariableLength, string strBufferCharacter = " ")
        {
            // Local Varaible Declaration
            string strReturnString = null;

            return strReturnString;
        }

        /// <summary>
        /// Creates a buffer by changing the console cursor position. Used for keeping elements on 
        /// console user interfaces (TUIs) alligned.
        /// </summary>
        /// <param name="iBufferSize">Intended Size of buffer</param>
        /// <param name="iContentSize">Size of content already on line (in characters)</param>
        public static void CreateConsoleBuffer(int iBufferSize, int iContentSize)
        {
            int iBuffer = 0;
            
            if (iBufferSize > iContentSize)
            {
                iBuffer = iBufferSize - iContentSize;
            }

            System.Console.SetCursorPosition(Console.WindowLeft + iBuffer, Console.WindowTop); 

        }
    }
}
