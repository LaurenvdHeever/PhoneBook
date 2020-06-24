namespace PhoneBookAPI
{
    public class SQLDatabaseSettings : ISQLDatabaseSettings
    {
        public string DatabaseFileName { get; set; }
        public string ConnectionString { get; set; }
        public int DbQueryTimeoutInSeconds { get; set; }
        public int DbCallRetryCount { get; set; }
    }

    public interface ISQLDatabaseSettings
    {
        string DatabaseFileName { get; set; }
        string ConnectionString { get; set; }
        int DbQueryTimeoutInSeconds { get; set; }
        int DbCallRetryCount { get; set; }
    }
}
