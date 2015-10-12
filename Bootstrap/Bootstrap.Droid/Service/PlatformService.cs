
using Bootstrap.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.PlatformSpecific.Services
{
    public class PlatformService : Bootstrap.Core.Interfaces.IPlatform
    {
        public string AppName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string appVersion
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

        public string deviceID
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

        public string deviceName
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

        public string OSName
        {
            get
            {
                return "Droid";
            }
        }

        public string OSVersion
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
