// See https://aka.ms/new-console-template for more information

using System.Configuration;
using superheros.console;

new Bootstrapper().Bootstrap();

Console.WriteLine($"Please write your input: ");

var paramline = Console.ReadLine();

Console.WriteLine($"input : {paramline}");