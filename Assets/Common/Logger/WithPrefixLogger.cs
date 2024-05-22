using UnityEngine;

namespace Common.Logger
{
    public class WithPrefixLogger : LoggerDecorator
    {
        private readonly string m_Prefix;

        public WithPrefixLogger(ILogger logger, string prefix) : base(logger)
        {
            m_Prefix = prefix;
        }

        public override void Log(LogType logType, object message)
        {
            base.Log(logType, message.Prefix(m_Prefix));
        }
        
        public override void Log(object message)
        {
            base.Log(message.Prefix(m_Prefix));
        }
    }
}