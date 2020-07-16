using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SOF.Utils
{
    /// <summary>
    /// 字列表
    /// </summary>
    public class WordList : List<UInt16>
    {
        /// <summary>
        /// 标准构造函数
        /// </summary>
        public WordList() : base() { }

        /// <summary>
        /// 使用集合构造
        /// </summary>
        /// <param name="collection">集合</param>
        public WordList(IEnumerable<UInt16> collection) : base(collection) { }

        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="count">初始大小，空数据填充</param>
        public WordList(int count)
        {
            AddRange(new UInt16[count]);
        }

        /// <summary>
        /// 使用数组构造
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public WordList(ushort[] data, int index, int count)
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
        public WordList Clone()
        {
            return new WordList(this);
        }

        /// <summary>
        /// 重载字符串表示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "[" + this.Count + "]";
            foreach (var x in this.ToArray())
            {
                str += string.Format("{0:X4} ", x);
            }
            return str;
        }
    }
}
