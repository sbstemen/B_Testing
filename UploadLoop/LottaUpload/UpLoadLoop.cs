// *************************************************************
// Coder Camps
// 8444 N. 90th Street St. 110
// Scottsdale, AZ
// -- SBS ~ 20180830
// Copyright (c) 2016-18
// Project: Runs through the repetitive upload test course
// *************************************************************

namespace LottaUpload
{
  using System;
  using System.IO;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using OpenQA.Selenium.Interactions;
  using SeleniumExtras;
  using SeleniumExtras.PageObjects;
  using SeleniumExtras.WaitHelpers;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Microsoft.VisualStudio.TestTools;
  
  [TestClass]
  public class UpLoadLoop
  {
    private static string chromePath = Directory.GetCurrentDirectory() + "\\assets\\";
    private static string uploadFile = Directory.GetCurrentDirectory() + "\\assets\\TestUpload.zip";
    private UserData studentData = new UserData();
    private UserData administratorData = new UserData();
    private HelperUtilities Utils = new HelperUtilities();
    private UploadProcess Process = new UploadProcess();

    [TestInitialize]
    public void TestSetUp()
    {
      studentData.Password = Properties.Settings.Default.Password;
      studentData.LogInAlias = Properties.Settings.Default.BaseUserNames;
      studentData.ClientUrl = Properties.Settings.Default.ClientUrl;
    }

    [TestMethod]
    public void UploadLoopingTest()
    {
      int stop = 1;
      do
      {
        using (IWebDriver webDriver = new ChromeDriver(chromePath))
        {
          Process.BrowserReady(webDriver, Utils, studentData);
          Process.LogInn(webDriver, Utils, studentData);
        }

      } while (stop < 2);

    }
  }
}
