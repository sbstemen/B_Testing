// *************************************************************
// Coder Camps
// 8444 N. 90th Street St. 110
// Scottsdale, AZ
// -- SBS ~ 20180830
// Copyright (c) 2016-18
// Project: Runs through the repetitive upload test course
// *************************************************************

namespace UploadRepetitive
{
  using System;
  using System.IO;
  using System.Diagnostics;
  using System.Text;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;

  public class UsefulTools
  {

    private string logFile = string.Empty;

    public UsefulTools()
    {
    }

    public UsefulTools(string logPath)
    {
      Directory.CreateDirectory(logPath);
      this.LogFile = logPath + "\\QA~Log.Txt";
    }

    public string LogFile
    {
      get
      {
        return this.logFile;
      }

      set
      {
        if (!File.Exists(value))
        {
          File.Create(value).Close();
        }

        this.logFile = value;
      }
    }

    public void MakeLogEntry(string logMessage)
    {
      using (TextWriter txtWriter = new StreamWriter(this.LogFile, true))
      {
        txtWriter.WriteLine(logMessage);
        txtWriter.WriteLine(DateTime.Now.ToString("MMM:dd_HH:mm:ss"));
        txtWriter.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        txtWriter.Close();
      }
    }

    public bool TestForInt(string itemToTest)
    {
      int cycles = 0;
      bool retVal = false;
      retVal = int.TryParse(itemToTest, out cycles);
      return retVal;
    }

    public void RandomPause()
    {
      Thread.Sleep(1024);
      double sleepyTime;
      sleepyTime = 5120;
      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; ; i++)
      {
        if (i % 100000 == 0)
        {
          sw.Stop();
          if (sw.ElapsedMilliseconds > sleepyTime)
          {
            break;
          }
          else
          {
            sw.Start();
          }
        }
      }
    }

    public void RandomPause(double seconds)
    {
      Thread.Sleep(1024);
      double sleepyTime;
      sleepyTime = seconds * 1024;
      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; ; i++)
      {
        if (i % 100000 == 0)
        {
          sw.Stop();
          if (sw.ElapsedMilliseconds > sleepyTime)
          {
            break;
          }
          else
          {
            sw.Start();
          }
        }
      }
    }

    public bool LogOnTask(IWebDriver webDriver, MicroUser microUser, PassFailCount pfCounter)
    {
      this.RandomPause(2);
      var newLine = Environment.NewLine;
      string pgText = webDriver.PageSource.ToString();
      string lookForThis = "X";

      /* Search for the client Icon */
      try
      {
        if(pgText.Contains(lookForThis))
        {
          this.MakeLogEntry("Pass, text found" + newLine + pgText);
          pgText = string.Empty;
        }
      }
      catch (Exception expText)
      {
        this.MakeLogEntry("FAILED" + newLine + expText);
        this.MakeLogEntry("Searched text failed" + newLine + pgText);
        pgText = string.Empty;
        Assert.Fail();
      }

      this.RandomPause(1);
      webDriver.FindElement(By.Id("Username")).SendKeys(userAlias);
      webDriver.FindElement(By.Id("Password")).SendKeys(pwd);
      this.RandomPause(2);
      webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();
      this.RandomPause(5);
      pgText = webDriver.PageSource;
      pgText = "Copyright © 2018 Exeter Education, LLC.";

      /* Search for the logged in user alias */
      try
      {
        Assert.IsTrue(pgText.Contains(lookForThis));
        {
          this.MakeLogEntry("Log On succeeded for ==> " + userAlias);
          this.RandomPause(2);
          pgText = string.Empty;
        }
      }
      catch (Exception expText)
      {
        this.MakeLogEntry("Log On Failed for client " + newLine + userAlias);
        this.MakeLogEntry("Exception Code" + newLine + expText);
        Assert.Fail();
      }
      pfCounter.GoodToGo = false;
      return pfCounter.GoodToGo;
    }

  }//EOC
}// EONS
