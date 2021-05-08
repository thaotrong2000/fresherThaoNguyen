using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;

namespace WebApi.Core.Interface.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public IEnumerable<Employee> FilterByIdNamePhone(string employeeCode, string employeeFullName, int employeePhoneNumber);

        public IEnumerable<Employee> GetEmployeePaging(int m_pageIndex, int m_pageSize);

        public bool CheckEmployeeCodeExist(string employeeCode);
    }
}