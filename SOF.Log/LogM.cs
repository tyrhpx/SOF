using System;
using System.Collections.Generic;
using System.Text;

namespace SOF.Log
{
    /// <summary>
    /// 日志管理类
    /// </summary>
    public class LogM
    {
        /// <summary>
        /// 获取默认日志记录器对象
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static ILog GetLogger()
        {
            return GetLogger("");
        }

        /// <summary>
        /// 获取日志记录器对象
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static ILog GetLogger(string msg, params object[] args)
        {
            return new Loggers.LoggerNLog(string.Format(msg, args));
        }
    }
}
