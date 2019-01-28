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
  using System.Drawing;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  class Program
  {
    static void Main(string[] args)
    {
      string runDate = DateTime.Now.ToString("-dd-HHmm");
      string assetPath = Directory.GetCurrentDirectory() + "\\assets\\";
      string testName = Properties.Settings.Default.TestName + runDate;
      string logPath = Properties.Settings.Default.LogPath + testName;
      string gooPage = @"https://www.google.com/";
      string chromePath = Directory.GetCurrentDirectory() + "\\assets\\";
      Size portSize = new Size(1600, 1000);
      UsefulTools ut = new UsefulTools(logPath);
      MicroUser mu = new MicroUser();
      PassFailCount pfc = new PassFailCount();  // Pass Fail && STOP
      Console.WriteLine("Start");
      ut.MakeLogEntry("Starting");
      mu.ClientUrl = Properties.Settings.Default.ClientWOZ;
      mu.LogInAlias = Properties.Settings.Default.UserName;
      mu.Password = Properties.Settings.Default.UserPassWord;

      using (IWebDriver webDriver = new ChromeDriver(chromePath))
      {
        webDriver.Navigate().GoToUrl(gooPage);
        ut.RandomPause(1);
        webDriver.Manage().Window.Size = portSize;
        ut.RandomPause(1);
        webDriver.Navigate().GoToUrl(mu.ClientUrl);
        ut.RandomPause(2);
      }

        // Stopper Console.ReadLine();
    }// EOC


  }//EOC
}// EONS
