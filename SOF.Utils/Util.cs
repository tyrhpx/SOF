using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace SOF.Utils
{
    /// <summary>
    /// 辅助类
    /// </summary>
    public class Util
    {
        /// <summary>
        /// 取汉字拼音的首字母
        /// </summary>
        /// <param name="UnName">汉字</param>
        /// <returns>首字母</returns>
        public static string GetCodstring(string UnName)
        {
            int i = 0;
            ushort key = 0;
            string strResult = string.Empty;

            Encoding unicode = Encoding.Unicode;
            Encoding gbk = Encoding.GetEncoding(936);
            byte[] unicodeBytes = unicode.GetBytes(UnName);
            byte[] gbkBytes = Encoding.Convert(unicode, gbk, unicodeBytes);
            while (i < gbkBytes.Length)
            {
                if (gbkBytes[i] <= 127)
                {
                    strResult = strResult + (char)gbkBytes[i];
                    i++;
                }
                #region 生成汉字拼音简码,取拼音首字母
                else
                {
                    key = (ushort)(gbkBytes[i] * 256 + gbkBytes[i + 1]);
                    if (key >= '\uB0A1' && key <= '\uB0C4')
                    {
                        strResult = strResult + "A";
                    }
                    else if (key >= '\uB0C5' && key <= '\uB2C0')
                    {
                        strResult = strResult + "B";
                    }
                    else if (key >= '\uB2C1' && key <= '\uB4ED')
                    {
                        strResult = strResult + "C";
                    }
                    else if (key >= '\uB4EE' && key <= '\uB6E9')
                    {
                        strResult = strResult + "D";
                    }
                    else if (key >= '\uB6EA' && key <= '\uB7A1')
                    {
                        strResult = strResult + "E";
                    }
                    else if (key >= '\uB7A2' && key <= '\uB8C0')
                    {
                        strResult = strResult + "F";
                    }
                    else if (key >= '\uB8C1' && key <= '\uB9FD')
                    {
                        strResult = strResult + "G";
                    }
                    else if (key >= '\uB9FE' && key <= '\uBBF6')
                    {
                        strResult = strResult + "H";
                    }
                    else if (key >= '\uBBF7' && key <= '\uBFA5')
                    {
                        strResult = strResult + "J";
                    }
                    else if (key >= '\uBFA6' && key <= '\uC0AB')
                    {
                        strResult = strResult + "K";
                    }
                    else if (key >= '\uC0AC' && key <= '\uC2E7')
                    {
                        strResult = strResult + "L";
                    }
                    else if (key >= '\uC2E8' && key <= '\uC4C2')
                    {
                        strResult = strResult + "M";
                    }
                    else if (key >= '\uC4C3' && key <= '\uC5B5')
                    {
                        strResult = strResult + "N";
                    }
                    else if (key >= '\uC5B6' && key <= '\uC5BD')
                    {
                        strResult = strResult + "O";
                    }
                    else if (key >= '\uC5BE' && key <= '\uC6D9')
                    {
                        strResult = strResult + "P";
                    }
                    else if (key >= '\uC6DA' && key <= '\uC8BA')
                    {
                        strResult = strResult + "Q";
                    }
                    else if (key >= '\uC8BB' && key <= '\uC8F5')
                    {
                        strResult = strResult + "R";
                    }
                    else if (key >= '\uC8F6' && key <= '\uCBF9')
                    {
                        strResult = strResult + "S";
                    }
                    else if (key >= '\uCBFA' && key <= '\uCDD9')
                    {
                        strResult = strResult + "T";
                    }
                    else if (key >= '\uCDDA' && key <= '\uCEF3')
                    {
                        strResult = strResult + "W";
                    }
                    else if (key >= '\uCEF4' && key <= '\uD188')
                    {
                        strResult = strResult + "X";
                    }
                    else if (key >= '\uD1B9' && key <= '\uD4D0')
                    {
                        strResult = strResult + "Y";
                    }
                    else if (key >= '\uD4D1' && key <= '\uD7F9')
                    {
                        strResult = strResult + "Z";
                    }
                    else
                    {
                        strResult = strResult + "?";
                    }
                    i = i + 2;
                }
                #endregion
            }
            return strResult;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="del">分割符</param>
        /// <returns></returns>
        public static string[] SplitString(string s, string del)
        {
            return s.Split(del.ToCharArray());
        }

        /// <summary>
        /// 将字符串转化为坐标点
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Point Str2Point(string s)
        {
            string[] sa = s.Split(',');
            if (sa.Length == 2)
            {
                return new Point(Convert.ToInt16(sa[0]), Convert.ToInt16(sa[1]));
            }
            return Point.Empty;
        }

        /// <summary>
        /// 将字符串转化为点数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Point[] Str2PointArr(string s)
        {
            List<Point> results = new List<Point>();
            if (!string.IsNullOrEmpty(s))
            {
                string[] sa = s.Split('-');
                foreach (string x in sa)
                {
                    results.Add(Str2Point(x));
                }
            }
            return results.ToArray();
        }

        /// <summary>
        /// 将坐标点转化为字符串
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static string Point2Str(Point point)
        {
            return string.Format("{0},{1}", point.X, point.Y);
        }

        /// <summary>
        /// 将点数组转化为字符串，分隔符为‘-’
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static string PointArr2Str(Point[] points)
        {
            string result = "";
            foreach (Point x in points)
            {
                result += Point2Str(x) + "-";
            }
            result.TrimEnd('-');
            return result;
        }

        /// <summary>
        /// 将字符串转为逻辑类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Str2Bool(string s)
        {
            if (s.ToUpper() == "TRUE"
                || s == "1")
            {
                return true;
            }
            if (s.ToUpper() == "FALSE"
                || s == "0")
            {
                return false;
            }
            return false; //其它均为无效值，默认为false.
        }

        /// <summary>
        /// 将RGB的数值转化为颜色
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public static Color ColorFromRGB(int rgb)
        {
            //透明色为255
            return Color.FromArgb((255 << 24) + rgb);
        }
    }
}
