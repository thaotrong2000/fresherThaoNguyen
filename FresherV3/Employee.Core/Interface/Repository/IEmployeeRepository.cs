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
        public IEnumerable<Employee> FilterByIdNamePhone(string employeeCode, string employeeFullName, string employeePhoneNumber);

        /// <summary>
        /// Phân trang dữ liệu
        /// </summary>
        /// <param name="m_pageIndex">Trang muốn hiển thị</param>
        /// <param name="m_pageSize">Số bản ghi trên một trang</param>
        /// <returns>Trả về dữ liệu đã lọc</returns>
        /// CreatedBy: NTTHAO(8/5/2021)
        public IEnumerable<Employee> GetEmployeePaging(int m_pageIndex, int m_pageSize);

        /// <summary>
        /// Kiểm tra sự tồn tại của: Mã nhân viên(EmployeeCode)
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>
        /// - true : đã tồn tại
        /// - false : chưa tồn tại
        /// </returns>
        /// CreatedBy: NTTHAO(8/5/2021)
        public bool CheckEmployeeCodeExist(string employeeCode);

        /// <summary>
        /// Kiểm tra xem Mã đơn vị có hợp lệ hay không
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>
        /// - true : tồn tại (hợp lệ)
        /// - false : chưa tồn tại (không hợp lệ)
        /// </returns>
        /// CreatedBy: NTTHAO(9/5/2021)
        public bool CheckDepartmentIdExist(Guid? departmentId);

        /// <summary>
        /// Lấy mã số nhân viên lớn nhất
        /// </summary>
        /// <returns>Trả về mã số nhân viên lớn nhất</returns>
        /// CreatedBy: NTTHAO(11/5/2021)
        public string GetCodeMax();
    }
}