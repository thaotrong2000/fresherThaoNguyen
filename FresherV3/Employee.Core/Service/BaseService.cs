using WebApi.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Interface.Repository;
using MISA.Core.Exceptions;
using MISA.Core.AttributeCustom;

namespace WebApi.Core.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Khai báo InterFace của Repository để có thể thao tác với DataBase
        /// </summary>
        private IBaseRepository<MISAEntity> _baseRepository;

        /// <summary>
        /// Hàm khởi tạo Class
        /// </summary>
        /// <param name="employeeRepository"></param>
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Xử lý nghiệp vụ Xóa dữ liệu nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public int Delete(Guid employeeId)
        {
            // Xử lý database ( bên Repository của Infrastructure)
            var deleteEmployee = _baseRepository.Delete(employeeId);

            // Đây là nơi xử lý nghiệp vụ

            // Trả về thông tin về việc xóa khách hàng
            return deleteEmployee;
        }

        /// <summary>
        /// Xử lý nghiệp vụ Lọc dữ liệu nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="fullName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>

        /// <summary>
        /// Xử lý nghiệp vụ Lấy toàn bộ dữ liệu nhân viên
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MISAEntity> getAll()
        {
            // Xử lý database ( bên Repository của Infrastructure)
            var getAllData = _baseRepository.getAll();

            // Đây là nơi xử lý nghiệp vụ

            // Trả về thông tin về việc Lọc nhân viên
            return getAllData;
        }

        /// <summary>
        /// Xử lý nghiệp vụ Thêm một nhân viên mới
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public int Post(MISAEntity Entity)
        {
            // Xử lý database ( bên Repository của Infrastructure)
            Validate(Entity);
            var postData = _baseRepository.Post(Entity);

            // Đây là nơi xử lý nghiệp vụ

            // Trả về thông tin về việc Lọc nhân viên
            return postData;
        }

        /// <summary>
        /// Xử lý nghiệp vụ chỉnh sửa dữ liệu nhân viên
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public int Put(MISAEntity Entity)
        {
            CustomValidatePut(Entity);
            // Xử lý database ( bên Repository của Infrastructure)
            var putData = _baseRepository.Put(Entity);

            // Đây là nơi xử lý nghiệp vụ

            // Trả về thông tin về việc Lọc nhân viên
            return putData;
        }

        protected virtual void CustomValidatePut(MISAEntity entity)
        {
        }

        /// <summary>
        /// Validate Dữ liệu chung
        /// </summary>
        /// <param name="entity"></param>
        private void Validate(MISAEntity entity)
        {
            // 1)Lấy ra tất cả Property của Class
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var property in properties)
            {
                var requiredProperties = property.GetCustomAttributes(typeof(MISARequired), true);
                if (requiredProperties.Length > 0)
                {
                    // Lấy giá trị:
                    var valueProperty = property.GetValue(entity);

                    // Kiểm tra giá trị:
                    if (string.IsNullOrEmpty(valueProperty.ToString()))
                    {
                        var msgError = (requiredProperties[0] as MISARequired).MsgError;
                        if (string.IsNullOrEmpty(msgError))
                        {
                            msgError = $"Không được để trống {property.Name}";
                        }
                        throw new CustomerException(msgError);
                    }
                }
            }
            CustomValidate(entity);
        }

        protected virtual void CustomValidate(MISAEntity entity)
        {
        }
    }
}