using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class Program
  {
    interface IPerl  // Generates cretes the inteface called IPerl 
    {
      void Read();  // just does what ???
    }

    class Test : IPerl  // Create a new class called, Test but it inherits from an interface called IPerl.  
    {
      public void Read()  //Creates a method called READ inhereited from IPerl just addes to the Iperl
      {
        Console.WriteLine("Read");
        string x = "law";
        string y = "friendly";
        string z = x + " " + y;
        Console.WriteLine(z);
      }
    }

    static void Main(string[] args)
    {
      IPerl perl = new Test();
      perl.Read();

      Console.WriteLine("Stop");
      Console.ReadLine();
    }
  }
}
