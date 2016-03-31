using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;

namespace NetInfo
{
    /// <summary>
    /// Contains methods associated with Network infromation and functions
    /// </summary>
    class clsNetwork
    {
		// Poop
        /// <summary>
        /// Prints a list of all adapters currently installed on PC
        /// and their status.
        /// </summary>
        /// <param name="bolNewLine">
        /// (Optional, Default TRUE) whether to write to a new line after printing
        /// information.
        /// </param>
        public static void GetAdapters(bool bolNewLine = true)
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

                //clsGeneral.CreateConsoleBuffer(55, adapter.Name.ToString().Length, Console.CursorTop); // Set Buffer 

                switch (adapter.OperationalStatus) // Get Appropriate Colour for status
                {
                    case OperationalStatus.Down:
                        System.Console.ForegroundColor = ConsoleColor.DarkRed;

                        clsGeneral.CreateConsoleBuffer(49, adapter.Name.ToString().Length, Console.CursorTop); // Set Buffer 

                        break;

                    case OperationalStatus.Up:
                        System.Console.ForegroundColor = ConsoleColor.DarkGreen;

                        clsGeneral.CreateConsoleBuffer(50, adapter.Name.ToString().Length, Console.CursorTop); // Set Buffer 

                        break;
                        
                    case OperationalStatus.Unknown:
                        System.Console.ForegroundColor = ConsoleColor.DarkCyan;

                        clsGeneral.CreateConsoleBuffer(50, adapter.Name.ToString().Length, Console.CursorTop); // Set Buffer 

                        break;

                    case default(OperationalStatus):
                        System.Console.ForegroundColor = ConsoleColor.Gray;

                        clsGeneral.CreateConsoleBuffer(48, adapter.Name.ToString().Length, Console.CursorTop); // Set Buffer 

                        break;
                }

                System.Console.WriteLine(" [" + adapter.OperationalStatus + "]"); // Get Adapter Status

                System.Console.ForegroundColor = ConsoleColor.Gray; // Reset Colour

            }

            clsNetwork.InsertNewLine(bolNewLine);

        }


        /// <summary>
        /// Gets IPv4 Addresses Currently Associated with this computer
        /// and its corresponding adapter
        /// </summary>
        /// <param name="bolNewLine">
        /// (Optional, Default TRUE) whether to write to a new line after printing
        /// information.
        /// </param>
        public static void GetIPAddresses_IPv4(bool bolNewLine = true)
        {

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("IP Addresses....................");
            System.Console.ForegroundColor = ConsoleColor.Gray;

            foreach (NetworkInterface networkAdapter in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (networkAdapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet || networkAdapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) // If Adapter is ethernet or wireless
                {

                    System.Console.Write(networkAdapter.Name);

                    clsGeneral.CreateConsoleBuffer(45, networkAdapter.Name.ToString().Length, Console.CursorTop); // Set Buffer 

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

            clsNetwork.InsertNewLine(bolNewLine);
            
        }

        /// <summary>
        /// Prints a list of adapters and their DNS Server IP Addresses (for IPv4 addresses)
        /// </summary>
        /// <param name="bolNewLine">
        /// (Optional, Default TRUE) whether to write to a new line after printing
        /// information.
        /// </param>
        public static void GetDNSAddresses_IPv4(bool bolNewLine = true)
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

                            clsGeneral.CreateConsoleBuffer(28, adapter.Name.ToString().Length, Console.CursorTop); // Set Buffer 

                            System.Console.WriteLine(" - " + adapterDNS.ToString());

                        }

                        System.Console.ForegroundColor = ConsoleColor.Gray;

                    }

                }

            }

            clsNetwork.InsertNewLine(bolNewLine);

        }


        /// <summary>
        /// Used to create new line based on boolean
        /// </summary>
        /// <param name="bolNewLine"></param>
        private static void InsertNewLine(bool bolNewLine)
        {
            if (bolNewLine == true)
            {
                System.Console.WriteLine();
            }
        }
    }
}
