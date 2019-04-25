using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace ApiUriAwake
{
  public class ApiUriProcess
  {
    public bool WakeUpUrl(HelpCode help, string urlToWakeUp)
    {
      bool good = false;
      string htmlText = string.Empty;
      string returnedCodeAsString = string.Empty;
      int returnedCodeValueAsInteger = -1;

      try
      {
        HttpWebRequest webRequested = (HttpWebRequest)WebRequest.Create(urlToWakeUp);
        webRequested.AutomaticDecompression = DecompressionMethods.GZip;
        using (HttpWebResponse webResponseIs = (HttpWebResponse)webRequested.GetResponse())
        using (Stream bitStream = webResponseIs.GetResponseStream())
        using (StreamReader sReader = new StreamReader(bitStream))
        {
          htmlText = sReader.ReadToEnd(); // just the text incase it goes to shit!
          returnedCodeAsString = Convert.ToString(webResponseIs.StatusCode); // description as well 
          returnedCodeValueAsInteger = (int)webResponseIs.StatusCode;
          if (returnedCodeValueAsInteger > 0)
          {
            good = true;
          }
        }
      }
      catch (System.Net.WebException exceptionTextIs)
      {
        string exText = exceptionTextIs.ToString();
        string expectedFlawedUrl = "https://users.qa.exeterlms.com/fail/";

        if ((exText.Contains("(404) Not Found.")) && (expectedFlawedUrl == urlToWakeUp))
        {
          help.MakeLogEntry("Expected failure because input was an invalid URL");
          help.MakeLogEntry("Flawed URL was ==> " + urlToWakeUp);
          good = true;
        }
        else
        {
          help.MakeLogEntry("FAILED" + Environment.NewLine + exceptionTextIs);
        }

      }
      return good;
    }

    public List<string> MakeWorkingList (string filePathIs)
    {
      string lineBeingRead = string.Empty;
      List<string> UrlListIs = new List<string>();

      using (StreamReader sReader = new StreamReader(filePathIs))
      {
        while ((lineBeingRead = sReader.ReadLine()) != null)
        {
          UrlListIs.Add(lineBeingRead);
        }
      }

      return UrlListIs;
    }

  }//EOC
}//EONS
