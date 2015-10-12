using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

// Usefuly links:
// BackgroundColors : http://www.dotnetperls.com/console-color
// Cursor Position : http://stackoverflow.com/questions/10804233/how-to-modify-the-previous-line-of-console-text
// DNS Information : https://msdn.microsoft.com/en-us/library/system.net.networkinformation.ipinterfaceproperties.dnsaddresses.aspx
// IP Addresses : http://stackoverflow.com/questions/9855230/how-to-get-the-network-interface-and-its-right-ipv4-address
// Amazing : http://broadcast.oreilly.com/2010/08/understanding-c-text-mode-games.html

namespace NetInfo
{
    class Program
    {

        static void Main(string[] args) 
        {

            SetConsoleProperties(); // Setup Console Properties

            

            ConsoleLoop(); // Start Applicaton loop
            

            // Press Space bar to expand
            // More info
            // Press Space bar to retract just IP Name of Pc and IP address and time flashing disconected for ping test
            
        }

        /// <summary>
        /// Creates an application loop for refreshing the console
        /// </summary>
        static void ConsoleLoop()
        {
            // Local Variable Declaration
            bool consoleRunning = true;
            const int TICK_INTERVAL = 250; // for creating a slight delay, allowing better render and more CPU frendly
            int count = 0;
            while (consoleRunning) // Console Loop
            {

                Thread.Sleep(TICK_INTERVAL); // Creates a delay of 250 ms

                System.Console.WriteLine("Tick = " + count);

                GetBasicInfo();
                GetAdapters();
                GetIPAddresses_IPv4();
                GetDNSAddresses_IPv4();

                System.Console.SetCursorPosition(0, 0); // Set Cursor Position back to start

                count++;

            }

        }

        /// <summary>
        /// Sets the Basic console properties
        /// required by this program
        /// </summary>
        static void SetConsoleProperties()
        {
            System.Console.Clear();
            System.Console.Title = "NetInfo - Version 1";
            System.Console.SetWindowSize(65, 40);
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.CursorVisible = false;
            System.Console.BufferHeight = 40;
            System.Console.BufferWidth = 65;
        }

        /// <summary>
        /// Prints the name of PC
        /// </summary>
        static void GetBasicInfo()
        {
            System.Console.Write("PC Name : ");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(System.Environment.MachineName.ToString());
            System.Console.ForegroundColor = ConsoleColor.Gray;

            System.Console.WriteLine(); // Create Blank Space for next Element
        }


        /// <summary>
        /// Prints a list of all adapters currently installed on PC
        /// and their status.
        /// </summary>
        static void GetAdapters()
        {
            NetworkInterface[] localNetAdapters = NetworkInterface.GetAllNetworkInterfaces(); // Get list of local adapters

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("PC Adapters.....................");
            System.Console.ForegroundColor = ConsoleColor.Gray;

            foreach (NetworkInterface adapter in localNetAdapters)
            {

                IPInterfaceProperties adapterProperties = adapter.GetIPProperties(); // Get adapter IP properties
                IPAddressCollection adapterDNSServers = adapterProperties.DnsAddresses; // Get DNS IP Information

                Console.Write(adapter.Name); // Get Adapter Name

                switch (adapter.OperationalStatus) // Get Appropriate Colour for status
                {
                    case OperationalStatus.Down:
                        System.Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;

                    case OperationalStatus.Up:
                        System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;

                    case OperationalStatus.Unknown:
                        System.Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;

                    case default(OperationalStatus):
                        System.Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }


                System.Console.WriteLine(" [" + adapter.OperationalStatus + "]"); // Get Adapter Status

                System.Console.ForegroundColor = ConsoleColor.Gray; // Reset Colour

            }

            System.Console.WriteLine(); 
        }

        /// <summary>
        /// Gets IPv4 Addresses Currently Associated with this computer
        /// and its corresponding adapter
        /// </summary>
        static void GetIPAddresses_IPv4()
        {
            
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("IP Addresses....................");
            System.Console.ForegroundColor = ConsoleColor.Gray;

            foreach (NetworkInterface networkAdapter in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (networkAdapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet || networkAdapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) // If Adapter is ethernet or wireless
                {

                    System.Console.Write(networkAdapter.Name);

                    foreach (UnicastIPAddressInformation adapterIP in networkAdapter.GetIPProperties().UnicastAddresses) // For Each address present on adapter
                    {

                        if (adapterIP.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // Get IPv4 Addresses on adapter
                        {

                            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                            System.Console.WriteLine(" [" + adapterIP.Address.ToString() + "]");
                            System.Console.ForegroundColor = ConsoleColor.Gray;

                        }

                    }
                }

            }

            System.Console.WriteLine();

        }

        /// <summary>
        /// Prints a list of adapters and their DNS Server IP Addresses (for IPv4 addresses)
        /// </summary>
        static void GetDNSAddresses_IPv4()
        {

            NetworkInterface[] localNetAdapters = NetworkInterface.GetAllNetworkInterfaces(); // Get list of local adapters

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("DNS Servers.....................");
            System.Console.ForegroundColor = ConsoleColor.Gray;

            foreach (NetworkInterface adapter in localNetAdapters)
            {

                IPInterfaceProperties adapterProperties = adapter.GetIPProperties(); // Get adapter IP properties
                IPAddressCollection adapterDNSServers = adapterProperties.DnsAddresses; // Get DNS IP Information

                if (adapterDNSServers.Count > 0) // If the adapter has a DNS address
                {
                    
                    foreach (IPAddress adapterDNS in adapterDNSServers)
                    {
                        if (adapterDNS.AddressFamily.ToString().Equals("InterNetwork")) // Catch IPv4 Addresses 
                        {
                            
                            System.Console.Write(adapter.Name);

                            System.Console.ForegroundColor = ConsoleColor.DarkGray;

                            System.Console.WriteLine(" - " + adapterDNS.ToString());
                        
                        }

                        System.Console.ForegroundColor = ConsoleColor.Gray;

                    }

                }

            }

            System.Console.WriteLine();

        }
    }
}
