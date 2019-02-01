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
  using AutoIt;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Support.UI;
  using System;
  using System.Drawing;

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

      utils.RandomPause(1);

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

    public IWebDriver LogInn(IWebDriver webDriver, HelperUtilities utils, UserData usrAccount, int iteration)
    {
      bool testPassed = false;

      string findThis = "tel:+1-855-755-2267";

      string pageText = string.Empty;

      utils.RandomPause(.5);

      webDriver.FindElement(By.Id("Username")).SendKeys(usrAccount.LogInAlias + iteration.ToString());

      utils.RandomPause(.5);

      webDriver.FindElement(By.Id("Password")).SendKeys(usrAccount.Password);

      utils.RandomPause(.5);

      webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();

      var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));

      IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("navbar-header")));

      utils.RandomPause(1);

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

    public IWebDriver OpenCourse(IWebDriver webDriver, HelperUtilities utils, int iteration)
    {
      var openLessonButton = webDriver.FindElements(By.CssSelector("div.cc-course-module li.list-group-item > button"));

      openLessonButton[0].Click();

      var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));

      IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div.col-xs-10.col-xs-offset-1")));

      utils.RandomPause(1);

      return webDriver;
    }

    public IWebDriver UploadFile(IWebDriver webDriver, HelperUtilities utils, string filePath)
    {
      bool retry = false;

      int retryCount = 0;

      var waitUploadBox = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));

      IWebElement elementUpLoadBox = waitUploadBox.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div.col-xs-10.col-xs-offset-1")));

      elementUpLoadBox.Click();

      //webDriver.FindElement(By.CssSelector("div.col-xs-10.col-xs-offset-1")).Click();

      utils.RandomPause(1);

      // NOTE for testing purposes the following block of code will fail if you break point it.  
      AutoItX.WinWaitActive("Open");
      AutoItX.ControlGetFocus("ComboBox1");
      AutoItX.Send(filePath);
      AutoItX.ControlGetFocus("Button1");
      AutoItX.Send("{ENTER}");
      // END of Auto IT code

      utils.RandomPause(1);

      do
      {

        try
        {
          string tempCssSelector = "div.row div.col-xs-10.col-xs-offset-1 div div div.display.inline-block > button";

          var waitUploadDone = new WebDriverWait(webDriver, new TimeSpan(0, 0, 180));  // YES! REALLY 180 seconds to test for a 200 meg upload

          IWebElement elementUploadDone = waitUploadDone.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(tempCssSelector)));

          utils.RandomPause(1);

          IJavaScriptExecutor pageScroll = webDriver as IJavaScriptExecutor;

          pageScroll.ExecuteScript("window.scrollBy(0,150);");

          var submitButton = webDriver.FindElements(By.CssSelector("div.row div.col-xs-10.col-xs-offset-1 div button"));

          submitButton[1].Click();

          utils.RandomPause(2);

          var confirmSubmit = webDriver.FindElements(By.CssSelector("div.modal-footer > button"));

          ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", confirmSubmit[1]);

          confirmSubmit[1].Click();

          retry = true;

        }
        catch (Exception exText)
        {

          Console.WriteLine(exText);

          string redXclass = "fa.fa-times.fa-2x.color.red";
          var redXvisable = webDriver.FindElement(By.ClassName(redXclass));
          var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 180));  // YES! REALLY 180 seconds to test for a 200 meg upload
          IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(redXclass)));
          utils.RandomPause(1);
          var removeButton = webDriver.FindElements(By.CssSelector("div.row div.col-xs-10.col-xs-offset-1 div button"));
          removeButton[1].Click();
          utils.RandomPause(1);

          retryCount++;
          if (retryCount > 2)
          {
            Environment.Exit(1);
          }

        }

      } while (!retry);

      return webDriver;
    }

    public IWebDriver NextLessonPage(IWebDriver webDriver, HelperUtilities utils, int iteration, int lessonCountIs, int lessonsInCourse)
    {
      utils.RandomPause(2);

      string searchForText = "Processing file(s) for download";

      string pageTextContents = webDriver.PageSource;

      utils.PageIsReady(webDriver, pageTextContents, searchForText);

      webDriver.FindElement(By.Id("nextLessonBtn")).Click();

      if (lessonCountIs < lessonsInCourse-1)
      {
          var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 60));
          IWebElement elementNewTopicLesson = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div.col-xs-10.col-xs-offset-1")));
          utils.RandomPause(1);
      }
      else
      {
          utils.RandomPause(2);
          return webDriver;
      }

      return webDriver;
    }

    public IWebDriver LogOff(IWebDriver webDriver, HelperUtilities utils)
    {
      utils.RandomPause(1);

      webDriver.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right>li:last-child>a")).Click();

      utils.RandomPause(1);

      webDriver.FindElement(By.Id("qa-dropdown-logout")).Click();

      utils.RandomPause(1);

      return webDriver;
    }

  }
}
