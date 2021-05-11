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
    /// <summary>
    /// Controller Quản lý nhân viên
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        // Biến xử lý về dữ liệu
        private IEmployeeRepository _employeeRepository;

        // Biến xử lý về nghiệp vụ
        private IEmployeeService _employeeService;

        /// <summary>
        /// Khởi tạo giá trị
        /// </summary>
        /// <param name="employeeRepository"></param>
        /// <param name="employeeService"></param>
        /// CreatedBy: NTTHAO(8/5/2021)
        public WebApiController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Thêm mới một nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>
        /// - 201 : Thêm mới nhân viên thành công.
        /// - 400 : Không thêm mới được.
        /// </returns>
        /// CreatedBy: NTTHAO(8/5/2021)
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

        [HttpGet("{employeeId}")]
        public IActionResult GetById(Guid employeeId)
        {
            var employees = _employeeRepository.GetById(employeeId);
            if (employees != null)
            {
                return Ok(employees);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu nhân viên
        /// </summary>
        /// <returns>
        /// - 200 : Lấy dữ liệu thành công.
        /// - 204 : Không có dữ liệu được trả về.
        /// </returns>
        /// CreatedBy: NTTHAO(8/5/2021)
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

        /// <summary>
        /// Sửa dữ liệu nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>
        /// - 201 : Sửa thành công dữ liệu.
        /// - 400 : Không sửa được thành công dữ liệu.
        /// </returns>
        /// CreatedBy: NTTHAO(8/5/2021)
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

        /// <summary>
        /// Xóa một bản ghi dữ liệu
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns>
        /// - 204 : Xóa dữ liệu thành công.
        /// - 400 : Không xóa thành công.
        /// </returns>
        /// CreatedBy: NTTHAO(8/5/2021)
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

        /// <summary>
        /// Phân trang dữ liệu hiển thị
        /// </summary>
        /// <param name="pageIndex">Trang cần hiển thị</param>
        /// <param name="pageSize">Số bản ghi hiển thị của mỗi trang</param>
        /// <returns>
        /// - 200 : Phân trang dữ liệu thành công.
        /// - 204 : Không có dữ liệu được trả về.
        /// </returns>
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

        /// <summary>
        /// Lọc dữ liệu theo: Mã nhân viên, họ tên, số điện thoại
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="employeeFullName">Họ và tên</param>
        /// <param name="employeePhoneNumber">Số điện thoại</param>
        /// <returns>
        /// - 200 : Trả về dữ liệu thành công.
        /// - 204 : Không có dữ liệu được trả về.
        /// </returns>
        [HttpGet("Filter")]
        public IActionResult Filter(string employeeCode, string employeeFullName, string employeePhoneNumber)
        {
            var filterEmployee = _employeeRepository.FilterByIdNamePhone(employeeCode, employeeFullName, employeePhoneNumber);
            if (filterEmployee.Count() > 0)
            {
                return Ok(filterEmployee);
            }
            else
            {
                return NoContent();
            }
        }
    }
}