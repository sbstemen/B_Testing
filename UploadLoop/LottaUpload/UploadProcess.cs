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
  using System.Drawing;
  using System.IO;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Interactions;
  using OpenQA.Selenium.Support.UI;
  using SeleniumExtras.WaitHelpers;
  using SeleniumExtras;
  using SeleniumExtras.PageObjects;

  internal class UploadProcess
  {

    public IWebDriver BrowserReady(IWebDriver webDriver, HelperUtilities utils, UserData usrData)
    {
      bool testPassed = false;

      string findThis = "Sign in with Microsoft";

      string pageText = string.Empty;

      Size viewPortSize = new Size(1650, 1000);

      string startPage = @"https://www.google.com/";

      utils.RandomPause(1);

      webDriver.Navigate().GoToUrl(startPage);

      utils.RandomPause(1);

      webDriver.Manage().Window.Size = viewPortSize;

      utils.RandomPause(1);

      webDriver.Navigate().GoToUrl(usrData.ClientUrl);

      var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));

      var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("RememberLogin")));

      utils.RandomPause(3);

      pageText = webDriver.PageSource;

      testPassed = utils.PageIsReady(webDriver, pageText, findThis);

      if (testPassed)
      {
        // resultWas.PassCount++;
      }
      else
      {
        // resultWas.FailCount++;
      }

      return webDriver;
    }


    public IWebDriver LogInn(IWebDriver webDriver, HelperUtilities utils, UserData usrAccount)
    {
      bool testPassed = false;
      string findThis = "tel:+1-855-755-2267";
      string pageText = string.Empty;
      utils.RandomPause(1);
      webDriver.FindElement(By.Id("Username")).SendKeys(usrAccount.LogInAlias);
      utils.RandomPause(1);
      webDriver.FindElement(By.Id("Password")).SendKeys(usrAccount.Password);
      utils.RandomPause(1);
      webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();
      utils.RandomPause(5);
      pageText = webDriver.PageSource;
      testPassed = utils.PageIsReady(webDriver, pageText, findThis);
      if (testPassed)
      {
        // resultWas.PassCount++;
      }
      else
      {
        // resultWas.FailCount++;
      }

      return webDriver;
    }
  }
}
