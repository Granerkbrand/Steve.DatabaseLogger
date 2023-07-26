using Steve.Core;
using Steve.DatabaseLogger;
using Steve.Logger;
using Steve.Logger.Misc;

ILogging<Program> logger = new Logging<Program>(LoggingLevel.Debug, new List<ILogger>()
{
    new ConsoleLogger(),
    new DatabaseLogger(new DatabaseOptions()
    {
        Server = "",
        Database = "",
        User = "",
        Password = ""
    })
});

APIResponse response = new()
{
    Status = 200,
    Message = "Mock message",
    ErrorCode = -1
};


for (int i = 0; i < 10; i++)
{


    var timelog = logger.Log("First timelog")
        .WithLogLevel(LogLevel.Debug)
        .WithMessage("the Sandbox")
        .WithCallerInfo()
        .StartTimer();

    logger.Log("First log")
        .WithMessage("First message")
        .Submit();

    logger.Log("First error log")
        .WithMessage("Error while updating")
        .WithException(new Exception("Update failed"))
        .Submit();

    logger.Log("API")
        .WithMessage("API Response")
        .WithCallerInfo()
        .WithObject(response)
        .Submit();

    logger.Log("log")
        .WithMessage("Update {newVersion} succesfull")
        .WithParameters(("newVersion", "1.0.0"))
        .WithLogLevel(LogLevel.Success)
        .WithCallerInfo()
        .Submit();

    timelog.Submit();

}

class APIResponse
{
    public int Status { get; set; }

    public string? Message { get; set; }

    public int ErrorCode { get; set; }

}