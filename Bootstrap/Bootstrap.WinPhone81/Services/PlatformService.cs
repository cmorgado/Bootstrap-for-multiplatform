
using Bootstrap.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.PlatformSpecific.Services
{
    public class PlatformService : IPlatform
    {
        public string AppName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string AppVersion
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string DeviceId
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string DeviceName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string OsName
        {
            get
            {
                return "WPA";
            }
        }

        public string OsVersion
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string xAuthKey
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string xAuthUser
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
