using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace ApiUriAwake
{
  class AwakeApiUri
  {
    static void Main(string[] args)
    {
      Console.WriteLine("This will wake up many of our API or web URL's in QA and Prod");

      Stopwatch watch = new Stopwatch();

      watch.Start();

      var nxtLine = Environment.NewLine;

      string totalET = string.Empty;

      string localDir = Directory.GetCurrentDirectory();

      string textList = localDir + "\\SiteList.txt";

      List<string> sitesAsList = new List<string>();

      HelpCode help = new HelpCode(localDir);

      ApiUriProcess toDo = new ApiUriProcess();

      help.MakeLogEntry("starting");

      sitesAsList =  toDo.MakeWorkingList(textList);

      foreach(string element in sitesAsList)
      {
        bool passed = false;
        passed = toDo.WakeUpUrl(help, element);

        if (passed)
        {
          help.MakeLogEntry(element + nxtLine + "PASSED");
        }
        else
        {
          help.MakeLogEntry("FAILED FAILED" + nxtLine + element + nxtLine + "FAILED");
        }

      }

      totalET = help.TruncationTool((watch.Elapsed.ToString()), 12);

      help.MakeLogEntry("Elapsed Time ==> " + totalET);

      Console.WriteLine("Total Elapsed Time was == {0}", totalET);

      help.RandomPause(3);
    }//EOM
  }//EOC
}//EONS
