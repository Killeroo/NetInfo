﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NetInfo
{
    /// <summary>
    /// Contains Methods for controlling core application and console functions
    /// such as ConsoleLoop
    /// </summary>
    class clsConsole
    {

        public static ConsoleColor color;

        /// <summary>
        /// Creates an application loop for refreshing the console
        /// </summary>
        public static void ConsoleLoop()
        {
            // Local Variable Declaration
            //bool consoleRunning = true;
            //const int TICK_INTERVAL = 250; // for creating a slight delay, allowing better render and more CPU frendly
            //int count = 0;
            //while (consoleRunning) // Console Loop
            //{

            //    Thread.Sleep(TICK_INTERVAL); // Creates a delay of 250 ms

            //    System.Console.WriteLine("Tick = " + count);

            //    clsSystem.GetBasicInfo();
            //    clsNetwork.GetAdapters();
            //    clsNetwork.GetIPAddresses_IPv4();
            //    clsNetwork.GetDNSAddresses_IPv4();


            //    System.Console.SetCursorPosition(0, 0); // Set Cursor Position back to start

            //    count++;

            //}

            color = Console.ForegroundColor;

            clsSystem.GetBasicInfo();
            clsNetwork.GetAdapters();
            clsNetwork.GetIPAddresses_IPv4();
            clsNetwork.GetDNSAddresses_IPv4();

            Console.ForegroundColor = color;

            //Console.ReadKey();

        }

        /// <summary>
        /// Sets the Basic console properties
        /// required by this program
        /// </summary>
        public static void SetConsoleProperties()
        {
            System.Console.Clear();
            System.Console.Title = "NetInfo - Version 1";
            //System.Console.SetWindowSize(65, 40);
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.CursorVisible = false;
            //System.Console.BufferHeight = 40;
            //System.Console.BufferWidth = 65;
        }

    }
}
