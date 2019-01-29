using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottaUpload
{
  public class UserData
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ClientUrl { get; set; }
    public string LogInAlias { get; set; }
    public string Password { get; set; }
    public string EpochTicks { get; set; }
    public DateTime CreatedAt { get; set; }
    public string SISidValue { get; set; }
    public string CRMidValue { get; set; }
    public string LoginVerifyTxt { get; set; }
    public string FirstLoginVerify { get; set; }
    public string FirstLogLink { get; set; }
  }// EOC
}
