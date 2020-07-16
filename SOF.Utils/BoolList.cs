using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOF.Utils
{
    /// <summary>
    /// Bool列表
    /// </summary>
    public class BoolList : List<Boolean>
    {
        /// <summary>
        /// 标准构造函数
        /// </summary>
        public BoolList() : base() { }

        /// <summary>
        /// 使用集合构造
        /// </summary>
        /// <param name="collection">集合</param>
        public BoolList(IEnumerable<Boolean> collection) : base(collection) { }

        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="count">初始大小，空数据填充</param>
        public BoolList(int count)
        {
            AddRange(new Boolean[count]);
        }

        /// <summary>
        /// 复制MSG
        /// </summary>
        /// <returns></returns>
        public BoolList Clone()
        {
            return new BoolList(this);
        }

        /// <summary>
        /// 重载字符串表示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "[" + this.Count + "]";
            foreach (Boolean x in this.ToArray())
            {
                str += string.Format("{0:X2} ", x);
            }
            return str;
        }
    }
}
