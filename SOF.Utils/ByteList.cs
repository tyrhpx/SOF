using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SOF.Utils
{
    /// <summary>
    /// 字节列表
    /// </summary>
    public class ByteList : List<Byte>
    {
        /// <summary>
        /// 标准构造函数
        /// </summary>
        public ByteList() : base() { }

        /// <summary>
        /// 使用集合构造
        /// </summary>
        /// <param name="collection">集合</param>
        public ByteList(IEnumerable<Byte> collection) : base(collection) { }

        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="count">初始大小，空数据填充</param>
        public ByteList(int count)
        {
            AddRange(new Byte[count]);
        }

        /// <summary>
        /// 使用数组构造
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public ByteList(byte[] data, int index, int count)
        {
            Debug.Assert(count <= data.Length);
            Debug.Assert(index + count < data.Length);

            for (int i = index; i < index + count; i++)
            {
                Add(data[i]);
            }
        }

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns></returns>
        public ByteList Clone()
        {
            return new ByteList(this);
        }

        /// <summary>
        /// 重载字符串表示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "[" + this.Count + "]";
            foreach (Byte x in this.ToArray())
            {
                str += string.Format("{0:X2} ", x);
            }
            return str;
        }

        /// <summary>
        /// 转换为16进制字符串
        /// </summary>
        /// <returns></returns>
        public string ToHexStr()
        {
            string str = "";
            foreach (var x in this.ToArray())
            {
                str += x.ToString("X2");
            }
            return str;
        }

        /// <summary>
        /// 从十六进制字符串加载字节流
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ByteList FromHexStr(string s)
        {
            var ret = new ByteList();
            var len = s.Length / 2;
            byte v = 0;
            for (int ii = 0; ii < len; ++ii)
            {
                v = Byte.Parse(s.Substring(2 * ii, 2), System.Globalization.NumberStyles.HexNumber);
                ret.Add(v);
            }
            return ret;
        }
    }
}
