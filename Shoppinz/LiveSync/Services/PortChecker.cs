using LiveSync.Application.Standards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LiveSync.Services
{
    internal static class PortChecker
    {

        public static void CheckPort(ServicingPorts PortValue)
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                Console.WriteLine($"Checking Port for {PortValue} Services :");
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    int enumInt = (int)PortValue;
                    tcpClient.Connect("127.0.0.1", enumInt);
                    Console.WriteLine("\t Service Running");
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t Service closed");
                    Console.ResetColor();
                }
            }
        }
    }
}
