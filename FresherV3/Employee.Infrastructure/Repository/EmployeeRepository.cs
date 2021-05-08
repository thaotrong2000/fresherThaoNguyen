using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WebApi.Core.Entities;
using WebApi.Core.Interface.Repository;

namespace WebApi.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Lọc dữ liệu theo các tiêu chí ( Mã nhân viên, họ và tên, số điện thoại)
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entityFullName"></param>
        /// <param name="entityPhoneNumber"></param>
        /// <returns></returns>
        public IEnumerable<Employee> FilterByIdNamePhone(string employeeCode, string employeeFullName, int employeePhoneNumber)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                if (string.IsNullOrEmpty(employeeCode))
                {
                    employeeCode = string.Empty;
                };
                if (string.IsNullOrEmpty(employeeFullName))
                {
                    employeeFullName = string.Empty;
                };

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_employeeCode", employeeCode);
                dynamicParameters.Add("@m_employeeFullName", employeeFullName);
                dynamicParameters.Add("@m_employeePhoneNumber", employeePhoneNumber);

                var filterEmployee = dbConnection.Query<Employee>("proc_FilterEmployee", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return filterEmployee;
            }
        }

        /// <summary>
        /// Phân trang dữ liệu (Chọn trang số mấy và số dữ liệu muốn hiển thị trên một trang)
        /// </summary>
        /// <param name="m_pageIndex">Trang số mấy</param>
        /// <param name="m_pageSize">Số dữ liệu hiển thị trên một trang</param>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployeePaging(int pageIndex, int pageSize)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_pageIndex", pageIndex);
                dynamicParameters.Add("@m_pageSize", pageSize);

                var paging = dbConnection.Query<Employee>("proc_GetEmployeePaging", param: dynamicParameters,
                    commandType: CommandType.StoredProcedure);
                return paging;
            }
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của EmployeeCode
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public bool CheckEmployeeCodeExist(string employeeCode)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_EmployeeCode", employeeCode);
                var putData = dbConnection.QueryFirstOrDefault<bool>("proc_CheckEmployeeCodeExist",
                    param: dynamicParameters,
                    commandType: CommandType.StoredProcedure);
                return putData;
            }
        }
    }
}