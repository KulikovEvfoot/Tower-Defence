using UnityEngine;

namespace Common.Logger
{
    public static class LoggerExtensions
    {
        public static ILogger WithPrefix(this ILogger logger, string prefix)
        {
            return new WithPrefixLogger(logger, prefix);
        }

        internal static string Prefix(this object message, string prefix)
        {
            return $"{prefix}{message}";
        }
    }
}