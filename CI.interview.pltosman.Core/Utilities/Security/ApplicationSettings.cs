using System;
namespace CI.interview.pltosman.Core.Utilities.Security
{
    public class ApplicationSettings
    {
        public AuthSettings AuthSettings { get; set; }
        public FixerSettings CustomerSettings { get; set; }
        public ExcelSetting ExcelSetting { get; set; }
    }

    public class AuthSettings
    {
        public string Url { get; set; }
        public string Type { get; set; }
        public string ApiName { get; set; }
        public string RequireHttpsMetadata { get; set; }
    }

    public class FixerSettings
    {
        public string ApiBaseUrl { get; set; }
        public string ApiCode { get; set; }
    }
    public class ExcelSetting
    {
        public string FilePath { get; set; }
    }
}
