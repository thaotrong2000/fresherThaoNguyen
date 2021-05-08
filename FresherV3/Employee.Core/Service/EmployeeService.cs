using MISA.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;
using WebApi.Core.Interface.Repository;
using WebApi.Core.Interface.Service;

namespace WebApi.Core.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Validate dữ liệu Employee Post
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
            }
        }

        /// <summary>
        /// Validate dữ liệu Employee Put
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