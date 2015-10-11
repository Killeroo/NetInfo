using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

// Usefuly links:
// BackgroundColors : http://www.dotnetperls.com/console-color
// Cursor Position : http://stackoverflow.com/questions/10804233/how-to-modify-the-previous-line-of-console-text
// DNS Information : https://msdn.microsoft.com/en-us/library/system.net.networkinformation.ipinterfaceproperties.dnsaddresses.aspx
// IP Addresses : http://stackoverflow.com/questions/9855230/how-to-get-the-network-interface-and-its-right-ipv4-address

namespace NetInfo
{
    class Program
    {
        static void Main(string[] args) // Seperate into Methods, Add Basic Pc Info EG Name updating time, ping
        {
            // Local Variable Declarations
            NetworkInterface[] localNetAdapters = NetworkInterface.GetAllNetworkInterfaces(); // Get Network Adapters
            
            // Setup Console Properties
            System.Console.Title = "NetInfo - Version 1";
            //System.Console.SetWindowSize(Console.WindowWidth, 100);

            // Get Current Adapters
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

            // Get IP Addresses 
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


            // Get DNS Server Information
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("DNS Servers.....................");
            System.Console.ForegroundColor = ConsoleColor.Gray;

            foreach (NetworkInterface adapter in localNetAdapters)
            {
            
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties(); // Get adapter IP properties
                IPAddressCollection adapterDNSServers = adapterProperties.DnsAddresses; // Get DNS IP Information

                if (adapterDNSServers.Count > 0)
                {
                    
                    System.Console.Write(adapter.Name);
                    System.Console.ForegroundColor = ConsoleColor.DarkGray;

                    foreach (IPAddress adapterDNS in adapterDNSServers)
                    {
                        System.Console.Write(" - " + adapterDNS.ToString());
                    }

                    System.Console.ForegroundColor = ConsoleColor.Gray;
                    System.Console.WriteLine();

                }

            }


            System.Console.Read();
            
        }

    }
}
