// See https://aka.ms/new-console-template for more information
using NCMDotNetCore.ConsoleAppRestClientExamples;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

RestClientExample restClientExample = new RestClientExample();
await restClientExample.RunAsync();

Console.ReadLine();