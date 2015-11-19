using System;

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
                return "IOS";
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
