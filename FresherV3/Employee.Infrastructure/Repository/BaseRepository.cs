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
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Khai báo các đối tượng dùng chung
        /// - connect
        /// - dbConnection
        /// - tableName
        /// </summary>
        /// CreatedBy: NTTHAO(8/5/2021)
        protected string connectString = "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MF817-Import-NTTHAO;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "AllowZeroDateTime=True"
                ;

        protected IDbConnection dbConnection;
        private string tableName = typeof(MISAEntity).Name;

        /// <summary>
        /// Xóa một bản ghi theo khóa chính ( EmployeeId)
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Số bản ghi bị xóa</returns>
        /// CreatedBy: NTTHAO(8/5/2021)
        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@m_{tableName}Id", entityId);
                var deleteEmployee = dbConnection.Execute($"proc_Delete{tableName}", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return deleteEmployee;
            }
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu của nhân viên
        /// </summary>
        /// <returns><MISAEntity></returns>
        /// CreatedBy: NTTHAO(8/5/2021)
        public IEnumerable<MISAEntity> getAll()
        {
            // Kết nối với DataBase

            using (dbConnection = new MySqlConnection(connectString))
            {
                var employees = dbConnection.Query<MISAEntity>($"proc_GetAll{tableName}", commandType: CommandType.StoredProcedure);

                // Trả về danh sách người dùng
                return employees;
            }
        }

        /// <summary>
        /// Thêm mới một bản ghi nhân viên
        /// </summary>
        /// <param name="Entity">Số bản ghi được thêm mới</param>
        /// <returns></returns>
        /// CreatedBy: NTTHAO(8/5/2021)
        public int Post(MISAEntity Entity)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                var postData = dbConnection.Execute($"proc_Insert{tableName}", param: Entity,
                    commandType: CommandType.StoredProcedure);
                return postData;
            }
        }

        /// <summary>
        /// Sửa một bản ghi nhân viên
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns>Số bản ghi được sửa</returns>
        /// CreatedBy: NTTHAO(8/5/2021)
        public int Put(MISAEntity Entity)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                var putData = dbConnection.Execute($"proc_Update{tableName}", param: Entity,
                    commandType: CommandType.StoredProcedure);
                return putData;
            }
        }
    }
}