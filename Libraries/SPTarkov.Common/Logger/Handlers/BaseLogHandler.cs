using Spectre.Console;
using SPTarkov.Common.Models.Logging;

namespace SPTarkov.Common.Logger.Handlers;

public abstract class BaseLogHandler : ILogHandler
{
    public abstract LoggerType LoggerType { get; }

    public abstract void Log(SptLogMessage message, BaseSptLoggerReference reference);

    protected string FormatMessage(string processedMessage, SptLogMessage message, BaseSptLoggerReference reference)
    {
        var formattedMessage = reference
            .Format.Replace("%date%", Markup.Escape(message.LogTime.ToString("yyyy-MM-dd")))
            .Replace("%time%", Markup.Escape(message.LogTime.ToString("HH:mm:ss.fff")))
            .Replace("%message%", processedMessage)
            .Replace("%loggerShort%", Markup.Escape(message.Logger.Split('.').Last()))
            .Replace("%logger%", Markup.Escape(message.Logger))
            .Replace("%tid%", Markup.Escape(message.threadId.ToString()))
            .Replace("%tname%", Markup.Escape(message.threadName ?? string.Empty))
            .Replace("%level%", Markup.Escape(Enum.GetName(message.LogLevel) ?? string.Empty));

        if (message.Exception != null)
        {
            formattedMessage +=
                $"\n{Markup.Escape(message.Exception.Message)}\n{Markup.Escape(message.Exception.StackTrace ?? string.Empty)}";
        }

        return formattedMessage;
    }
}
