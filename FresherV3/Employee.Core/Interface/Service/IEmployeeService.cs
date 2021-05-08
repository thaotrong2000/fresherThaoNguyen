using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;

namespace WebApi.Core.Interface.Service
{
    /// <summary>
    /// InterfaceRepository của Employee
    /// Kế thừa từ IBaseRepository
    /// </summary>
    /// CreatedBy: NTTHAO(8/5/2021)
    public interface IEmployeeService : IBaseService<Employee>
    {
    }
}