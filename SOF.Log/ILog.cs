using System;

namespace SOF.Log
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILog
    {
        void Trace(string msg, params object[] args);
        void Debug(string msg, params object[] args);
        void Info(string msg, params object[] args);
        void Warn(string msg, params object[] args);
        void Warn(Exception ex, string msg, params object[] args);
        void Error(string msg, params object[] args);
        void Error(Exception ex, string msg, params object[] args);
        void Fatal(string msg, params object[] args);
        void Fatal(Exception ex, string msg, params object[] args);
    }
}
