using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOverLoad
{
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      string one = "Now.Is.The.Time.For.All.Good.Men.To.Come.To.The.Aid.Of.The.Party.";
      string two = string.Empty;
      string tri = string.Empty;
      int firstInt = 6;
      Console.WriteLine("Start");
      Console.WriteLine(one);
      two = p.TruncationTool(one, firstInt);
      Console.WriteLine(two);

      tri = p.TruncationTool(one, firstInt, 3);

      Console.WriteLine(tri);

      Console.ReadLine();
    }// EOM


    public string TruncationTool(string inPutText, int startPoint, int remainingCharacters)
    {
      if (string.IsNullOrEmpty(inPutText))
      {
        return inPutText;
      }
      else
      {
        inPutText = inPutText.Length <= remainingCharacters ? inPutText : inPutText.Substring(startPoint, remainingCharacters);
      }

      return inPutText;
    }


    public string TruncationTool(string inPutText, int remainingCharacters)
    {
      if (string.IsNullOrEmpty(inPutText))
      {
        return inPutText;
      }
      else
      {
        inPutText = inPutText.Length <= remainingCharacters ? inPutText : inPutText.Substring(0, remainingCharacters);
      }

      return inPutText;
    }

  }// EOC
}// EONs
