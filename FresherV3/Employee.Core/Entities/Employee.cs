using MISA.Core.AttributeCustom;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Entities
{
    /// <summary>
    /// Thực thể nhân viên (Employee)
    /// </summary>
    /// CreatedBy: NTTHAO(8/5/2021)
    public class Employee
    {
        /// <summary>
        /// Mã định danh
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [MISARequired("Mã khách hàng không được phép để trống")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [MISARequired("Tên khách hàng không được phép để trống")]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính (ID)
        /// </summary>
        public int GenderId { get; set; }

        /// <summary>
        /// Đơn vị làm việc
        /// </summary>
        [MISARequired("Đơn vị làm việc không được phép để trống")]
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Số chứng minh thư nhân dân
        /// </summary>
        public int IdentityId { get; set; }

        /// <summary>
        /// Ngày cấp : Chứng minh thư nhân dân
        /// </summary>
        public DateTime IdentityDate { get; set; }

        /// <summary>
        /// Chức danh
        /// </summary>
        public string PositionId { get; set; }

        /// <summary>
        /// Nơi cấp : Chứng minh thư nhân dân
        /// </summary>
        public string IdentityPosition { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public string LandlinePhone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string BankBranch { get; set; }
    }
}