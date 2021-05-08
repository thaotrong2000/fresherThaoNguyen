using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Interface.Repository
{
    /// <summary>
    /// InterFace xử lý với DataBase
    /// Tạo ra khung để các Interface Repository khác kế thừa
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: NTTHAO(8/5/2021)
    public interface IBaseRepository<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu nhân viên
        /// </summary>
        /// <returns>
        /// - 200 : Lấy dữ liệu thành công
        /// - 204 : Không có dữ liệu trả về
        /// </returns>
        /// CreatedBy: NTTHAO(7/5/2021)
        public IEnumerable<MISAEntity> getAll();

        /// <summary>
        /// Thêm mới một nhân viên
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns>
        /// - 201: Đã tạo thành công một nhân viên
        /// - 400: Không thêm được dữ liệu
        /// </returns>
        /// CreatedBy: NTTHAO(7/5/2021)
        public int Post(MISAEntity Entity);

        /// <summary>
        /// Sửa dữ liệu của một nhân viên
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns>
        /// - 204 : Dữ liệu nhân viên đã được cập nhật thành công
        /// - 400 : Không thêm được dữ liệu
        /// </returns>
        /// CreatedBy: NTTHAO(7/5/2021)
        public int Put(MISAEntity Entity);

        /// <summary>
        /// Xóa dữ liệu của một bản ghi nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>
        /// - 204 : Xóa dữ liệu của nhân viên thành công
        /// - 400 : Không thể xóa dữ liệu bản ghi của nhân viên này
        /// </returns>
        /// CreatedBy: NTTHAO(7/5/2021)
        public int Delete(Guid employeeId);

        /// <summary>
        /// Lọc nhân viên theo:
        /// - CustomerId : Mã nhân viên
        /// - FullName : Tên nhân viên
        /// - PhoneNumber : Số điện thoại
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="fullName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns>
        /// - 200 : Lọc được dữ liệu thành công
        /// - 204 : Không có dữ liệu phù hợp
        /// </returns>
        /// CreatedBy: NTTHAO(7/5/2021)
    }
}