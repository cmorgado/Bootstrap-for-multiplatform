namespace Bootstrap.Core.Interfaces
{
  public  interface IPlatform
    {

        string AppName { get; }
        string AppVersion { get; }

        string DeviceId { get;  }
        string DeviceName { get; }
        string OsName { get; }
        string OsVersion { get; }
    }
}
