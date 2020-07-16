using System;
using System.Collections.Generic;
using System.Text;

namespace SOF.Log.Loggers
{
    /// <summary>
    /// NLog日志记录器
    /// </summary>
    internal class LoggerNLog : ILog
    {
        private NLog.ILogger Logger = null;

        public LoggerNLog(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Logger = NLog.LogManager.GetCurrentClassLogger();
            }
            else
            {
                Logger = NLog.LogManager.GetLogger(name);
            }
        }

        public void Trace(string msg, params object[] args)
        {
            this.Logger.Trace(msg, args);
        }
        public void Debug(string msg, params object[] args)
        {
            this.Logger.Debug(msg, args);
        }
        public void Info(string msg, params object[] args)
        {
            this.Logger.Info(msg, args);
        }
        public void Warn(string msg, params object[] args)
        {
            this.Logger.Warn(msg, args);
        }
        public void Warn(Exception ex, string msg, params object[] args)
        {
            this.Logger.Warn(ex, msg, args);
        }
        public void Error(string msg, params object[] args)
        {
            this.Logger.Error(msg, args);
        }
        public void Error(Exception ex, string msg, params object[] args)
        {
            this.Logger.Error(ex, msg, args);
        }
        public void Fatal(string msg, params object[] args)
        {
            this.Logger.Fatal(msg, args);
        }
        public void Fatal(Exception ex, string msg, params object[] args)
        {
            this.Logger.Fatal(ex, msg, args);
        }
    }
}
