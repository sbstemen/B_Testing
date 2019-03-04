// *************************************************************
// Coder Camps
// 8444 N. 90th Street St. 110
// Scottsdale, AZ
// -- SBS ~ 20190214
// Copyright (c) 2016-18
// Project: Loops through user groups to log in many users
// *************************************************************

namespace LogInLottaUsers
{
  using System;
  public class UserData
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ClientUrl { get; set; }
    public string LogInAlias { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public string LoginVerifyTxt { get; set; }
    public string FirstLoginVerify { get; set; }
    public string FirstLogLink { get; set; }
  }
}
