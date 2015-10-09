using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.Core.Interfaces
{
  public  interface IPlatform
    {

        string AppName { get; }
        string appVersion { get; set; }

        string deviceID { get; set; }
        string deviceName { get; set; }
        string OSName { get; }
        string OSVersion { get; }
    }
}
