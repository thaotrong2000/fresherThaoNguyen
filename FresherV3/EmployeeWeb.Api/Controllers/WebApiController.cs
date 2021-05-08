using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Entities;
using WebApi.Core.Interface.Repository;
using WebApi.Core.Interface.Service;

namespace WebApi.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
        private IEmployeeService _employeeService;

        public WebApiController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult PostData(Employee employee)
        {
            var postData = _employeeService.Post(employee);
            if (postData > 0)
            {
                return StatusCode(201, "Ban da them thanh cong");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            var employees = _employeeRepository.getAll();
            if (employees.Count() > 0)
            {
                return Ok(employees);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult PutData(Employee employee)
        {
            var putData = _employeeService.Put(employee);
            if (putData > 0)
            {
                return StatusCode(201, "Ban da sua thanh cong");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(Guid EmployeeId)
        {
            var deleteEmployee = _employeeRepository.Delete(EmployeeId);
            if (deleteEmployee > 0)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Paging")]
        public IActionResult Paging(int pageIndex, int pageSize)
        {
            var employee = _employeeRepository.GetEmployeePaging(pageIndex, pageSize);
            if (employee.Count() > 0)
            {
                return Ok(employee);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("Filter")]
        public IActionResult Filter(string employeeCode, string employeeFullName, int employeePhoneNumber)
        {
            var filterEmployee = _employeeRepository.FilterByIdNamePhone(employeeCode, employeeFullName, employeePhoneNumber);
            if (filterEmployee.Count() > 0)
            {
                return Ok(filterEmployee);
            }
            else
            {
                throw new Exception("Khong co du lieu duoc tra ve");
            }
        }
    }
}