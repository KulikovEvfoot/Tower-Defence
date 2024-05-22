using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common.Logger
{
    public class LoggerDecorator : ILogger
    {
        public LoggerDecorator(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }
        public void LogFormat(LogType logType, Object context, string format, params object[] args)
        {
            Logger.LogFormat(logType, context, format, args);
        }

        public void LogException(Exception exception, Object context)
        {
            Logger.LogException(exception, context);
        }

        public bool IsLogTypeAllowed(LogType logType)
        {
            return Logger.IsLogTypeAllowed(logType);
        }

        public virtual void Log(LogType logType, object message)
        {
            Logger.Log(logType, message);
        }

        public void Log(LogType logType, object message, Object context)
        {
            Logger.Log(logType, message, context);
        }

        public void Log(LogType logType, string tag, object message)
        {
            Logger.Log(logType, tag, message);
        }

        public void Log(LogType logType, string tag, object message, Object context)
        {
            Logger.Log(logType, tag, message, context);
        }

        public virtual void Log(object message)
        {
            Logger.Log(LogType.Log, message);
        }

        public void Log(string tag, object message)
        {
            Logger.Log(tag, message);
        }

        public void Log(string tag, object message, Object context)
        {
            Logger.Log(tag, message, context);
        }

        public void LogWarning(string tag, object message)
        {
            Logger.LogWarning(tag, message);
        }

        public void LogWarning(string tag, object message, Object context)
        {
            Logger.LogWarning(tag, message, context);
        }

        public void LogError(string tag, object message)
        {
            Logger.LogError(tag, message);
        }

        public void LogError(string tag, object message, Object context)
        {
            Logger.LogError(tag, message, context);
        }

        public void LogFormat(LogType logType, string format, params object[] args)
        {
            Logger.LogFormat(logType, format, args);
        }

        public void LogException(Exception exception)
        {
            Logger.LogException(exception);
        }

        public ILogHandler logHandler
        {
            get => Logger.logHandler;
            set => Logger.logHandler = value;
        }

        public bool logEnabled
        {
            get => Logger.logEnabled;
            set => Logger.logEnabled = value;
        }

        public LogType filterLogType
        {
            get => Logger.filterLogType;
            set => Logger.filterLogType = value;
        }
    }
}