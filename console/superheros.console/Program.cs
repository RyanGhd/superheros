// See https://aka.ms/new-console-template for more information

using System.Configuration;using superheors.console.Services;

 new Bootstrapper().Bootstrap();
 var paramline = Console.ReadLine();

Console.WriteLine($"input : {paramline}");