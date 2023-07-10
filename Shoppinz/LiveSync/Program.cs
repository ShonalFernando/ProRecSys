// See https://aka.ms/new-console-template for more information
using LiveSync.Services;
using System.Net.Sockets;
using LiveSync.Application.Standards;

Console.WriteLine("=============================================================================================================");
Console.WriteLine("Welcome to Shoppinz|Mindme23 Ecommerce Platform");
Console.WriteLine("=============================================================================================================");
Console.WriteLine("");

PortChecker.CheckPort(ServicingPorts.WebApplication);
PortChecker.CheckPort(ServicingPorts.AuthAPI);
PortChecker.CheckPort(ServicingPorts.MongoDB);
PortChecker.CheckPort(ServicingPorts.MariaDB);
PortChecker.CheckPort(ServicingPorts.RecommendationServices);


Console.ReadLine();
