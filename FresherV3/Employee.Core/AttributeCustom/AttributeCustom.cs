using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.AttributeCustom
{
    /// <summary>
    /// Attribute bắt buộc nhập
    /// </summary>
    /// CreatedBy: NTTHAO(8/5/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        public string MsgError = string.Empty;

        public MISARequired(string msgError = "")
        {
            MsgError = msgError;
        }
    }

    /// <summary>
    /// Độ dài Attribute giới hạn
    /// </summary>
    /// CreatedBy: NTTHAO(8/5/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength : Attribute
    {
        public int MaxLength = 0;
        public string MsgError = string.Empty;

        public MISAMaxLength(int maxLength = 0, string msg = "")
        {
            MaxLength = maxLength;
            MsgError = msg;
        }
    }
}