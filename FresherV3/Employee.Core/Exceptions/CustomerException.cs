using System;

namespace MISA.Core.Exceptions
{
    /// <summary>
    /// Tạo Custom Exception kế thừa từ Exception
    /// </summary>
    /// CreatedBy: NTTHAO(8/5/2021)
    public class CustomerException : Exception
    {
        /// <summary>
        /// Khởi tạo CustomException
        /// </summary>
        /// <param name="message"></param>
        /// CreatedBy: NTTHAO(8/5/2021)
        public CustomerException(string message) : base(message)
        {
        }
    }
}