namespace EFCoreInWebAPI.Options;

public class DatabaseOptions
{
    public String ConnectionString { get; set; }=String.Empty;

    public int MaxRetryCount { get; set; }

    public int CommandTimeOut { get; set; }

    public bool EnableDetailError { get; set; }

    public bool EnableSensitiveDataLogging { get; set; }

}