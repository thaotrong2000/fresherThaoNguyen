using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;

namespace WebApi.Core.Interface.Repository
{
    /// <summary>
    /// Interface xử lý Data của nhân viên
    /// Kế thừa các phương thức của IBaseRepositorys
    /// Custom thêm phương thức đặc thù.
    /// </summary>
    /// CreatedBy: NTTHAO(8/5/2021)
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Lọc dữ liệu theo: Mã nhân viên, họ tên, số điện thoại
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="employeeFullName">Họ tên</param>
        /// <param name="employeePhoneNumber">Số điện thoại</param>
        /// <returns><Employee></returns>
        /// CreatedBy: NTTHAO(8/5/2021)
        public IEnumerable<Employee> FilterByIdNamePhone(string employeeCode, string employeeFullName, int employeePhoneNumber);

        /// <summary>
        /// Phân trang dữ liệu
        /// </summary>
        /// <param name="m_pageIndex">Trang muốn hiển thị</param>
        /// <param name="m_pageSize">Số bản ghi trên một trang</param>
        /// <returns></returns>
        /// CreatedBy: NTTHAO(8/5/2021)
        public IEnumerable<Employee> GetEmployeePaging(int m_pageIndex, int m_pageSize);

        /// <summary>
        /// Kiểm tra sự tồn tại của: Mã nhân viên(EmployeeCode)
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        /// CreatedBy: NTTHAO(8/5/2021)
        public bool CheckEmployeeCodeExist(string employeeCode);
    }
}