using MISA.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;
using WebApi.Core.Interface.Repository;
using WebApi.Core.Interface.Service;

namespace WebApi.Core.Service
{
    /// <summary>
    /// Xử lý nghiệp vụ riêng cho Employee
    /// </summary>
    /// CreatedBy: NTTHAO(8/5/2021)
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        /// <summary>
        /// Biến để xử lý với Database
        /// </summary>
        /// CreatedBy: NTTHAO(8/5/2021)
        private IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Khởi tạo biến cho Class
        /// </summary>
        /// <param name="employeeRepository"></param>
        /// CreatedBy: NTTHAO(8/5/2021)
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Validate dữ liệu Employee thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// CreatedBy: NTTHAO(8/5/2021)
        protected override void CustomValidate(Employee entity)
        {
            // Kiểm tra dữ liệu đã tồn tại hay chưa?
            if (entity != null)
            {
                // Check trùng mã
                var isExist = _employeeRepository.CheckEmployeeCodeExist(entity.EmployeeCode);
                if (isExist == true)
                {
                    throw new CustomerException(Properties.Resources.Error_EmployeeCodeExist);
                }

                // Check xem mã Đơn vị công tác thêm vào có hợp lệ không?
                var checkDepartmentId = _employeeRepository.CheckDepartmentIdExist(entity.DepartmentId);
                // Check Guid
                string correctString = entity.DepartmentId.ToString();
                Guid guid;
                bool guidResTrue = Guid.TryParse(correctString, out guid);

                // Kiểm tra xem DepartmentId có phải là Guid
                if (guidResTrue == false)
                {
                    throw new CustomerException("Không phải Guid");
                }

                // Kiểm tra xem DepartmentId đã tồn tại hay chưa
                if (checkDepartmentId == false)
                {
                    throw new CustomerException(Properties.Resources.Error_DepartmentId);
                }
            }
        }

        /// <summary>
        /// Validate dữ liệu Employee sửa dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// CreatedBy: NTTHAO(8/5/2021)
        protected override void CustomValidatePut(Employee entity)
        {
            // Kiểm tra dữ liệu đã tồn tại hay chưa?
            if (entity != null)
            {
                // Check trùng mã
                var isExist = _employeeRepository.CheckEmployeeCodeExist(entity.EmployeeCode);
                if (isExist == false)
                {
                    throw new CustomerException(Properties.Resources.Error_EmployeeCodeNoExist);
                }
            }
        }
    }
}