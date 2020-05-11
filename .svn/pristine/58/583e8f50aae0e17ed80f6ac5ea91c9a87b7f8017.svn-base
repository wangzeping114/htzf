using log4net;

namespace WS.HTZF.Core.LogHelper
{
    public class Log4Net
    {
        private readonly  ILog monitoringLogger;
        private readonly  ILog debugLogger;
        public Log4Net()
        {
            monitoringLogger = LogManager.GetLogger("MonitoringLogger");
            debugLogger = LogManager.GetLogger("DebugLogger");
        }
        /// <summary>
        /// 用于在显式调试日志记录器中记录调试消息
        /// </summary>
        /// <param name="message">要记录的对象消息</param>
        public void Debug(string message) 
        {
            debugLogger.Debug(message);
        }
        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public void Debug(string message, System.Exception exception)
        {
            debugLogger.Debug(message, exception);
        }
        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public void Info(string message)
        {
            monitoringLogger.Info(message);
        }
        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public  void Info(string message, System.Exception exception)
        {
            monitoringLogger.Info(message, exception);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public  void Warn(string message)
        {
            monitoringLogger.Warn(message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public void Warn(string message, System.Exception exception)
        {
            monitoringLogger.Warn(message, exception);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public void Error(string message)
        {
            monitoringLogger.Error(message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public  void Error(string message, System.Exception exception)
        {
            monitoringLogger.Error(message, exception);
        }


        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public  void Fatal(string message)
        {
            monitoringLogger.Fatal(message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public  void Fatal(string message, System.Exception exception)
        {
            monitoringLogger.Fatal(message, exception);
        }
    }
}
