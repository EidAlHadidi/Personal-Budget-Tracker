using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.Win32.SafeHandles;
using UI;
using BL;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string value = Console.ReadLine();
            Console.WriteLine(clsGlobal.ComputeHash(value));
            Console.ReadKey();
        }
    }
}
