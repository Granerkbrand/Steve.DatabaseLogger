using Steve.Core;

namespace Steve.DatabaseLogger
{
    public class DatabaseLogger : ILogger
    {
        private readonly DatabaseOptions _options;

        public DatabaseLogger(DatabaseOptions options)
        {
            _options = options;

            LogContext.ApplyMigrations(options);
        }

        public void Flush()
        {
            
        }

        public void Submit(LogMessage logMessage)
        {
            using var context = new LogContext(_options);

            context.Messages.Add(new LogMessageModel()
            {
                Name = logMessage.Name,
                Message = logMessage.Message,
                Parameters = logMessage.Parameters,
                Level = logMessage.Level,
                LoggedAt = logMessage.DateTime,
                LoggedFrom = logMessage.LoggedFrom,
                Exception = logMessage.Exception,
                CallerInfo_Origin = logMessage?.CallerInfo?.Origin,
                CallerInfo_FilePath = logMessage?.CallerInfo?.FilePath,
                CallerInfo_LineNumber = logMessage?.CallerInfo?.LineNumber,
                Duration = logMessage?.Duration,
                Object = logMessage?.Object,
            });

            context.SaveChanges();
        }
    }
}
