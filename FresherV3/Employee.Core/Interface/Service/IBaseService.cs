using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Interface.Service
{
    /// <summary>
    /// Interface xử lý nghiệp vụ
    /// Tạo ra khung chuẩn để các Interface Service khác kế thừa
    /// </summary>
    /// CreatedBy: NTTHAO(8/5/2021)
    public interface IBaseService<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Xử lý nghiệp vụ khi lấy toàn bộ nhân viên về
        /// </summary>
        /// <returns><MISAEntity></returns>
        /// CreatedBy: NTTHAO(7/5/2021)
        public IEnumerable<MISAEntity> getAll();

        /// <summary>
        /// Xử lý nghiệp vụ khi thêm mới một nhân viên
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        /// CreatedBy: NTTHAO(7/5/2021)
        public int Post(MISAEntity Entity);

        /// <summary>
        /// Xử lý nghiệp vụ khi sửa dữ liệu của một nhân viên
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        /// CreatedBy: NTTHAO(7/5/2021)
        public int Put(MISAEntity Entity);

        /// <summary>
        /// Xử lý nghiệp vụ khi xóa dữ liệu của một bản ghi nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// CreatedBy: NTTHAO(7/5/2021)
        public int Delete(Guid employeeId);

        /// <summary>
        /// Xử lý nghiệp vụ khi Lọc nhân viên theo:
        /// - CustomerId : Mã nhân viên
        /// - FullName : Tên nhân viên
        /// - PhoneNumber : Số điện thoại
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="fullName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        /// CreatedBy: NTTHAO(7/5/2021)
    }
}