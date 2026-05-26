namespace Users.Api.Logging;

public interface ILoggerAdapter<TType>
{
    //loglar internal olduğundan dolayı bu yönteme başvurduk
    void LogInformation(string? message, params object?[] args);
    void LogError(Exception? exception,string? message,params object?[] args);
}
