using Microsoft.EntityFrameworkCore;
using System;

namespace Khan.EntityFrameworkCore.Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Khontext>();
            var khontext = new Khontext(optionsBuilder.UseSqlServer(DBGlobals.DbConnection).Options);

            Console.WriteLine("Hello World!");
        }
    }
}
