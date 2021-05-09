<template>
  <div id="employee">
    <!-- Tên Bảng và chức năng thêm nhân nhân viên -->
    <div class="content-add-employee">
      <!-- Tên bảng  -->
      <div class="content-table-name">
        Nhân viên
      </div>
      <!-- Nút thêm nhân viên -->
      <button class="content-button-add button-common">
        Thêm mới nhân viên
      </button>
    </div>
    <!-- Thao tác với dữ liệu trên Data -->
    <div class="content-data-table">
      <!-- Tìm kiếm theo mã, tên nhân viên + reload dữ liệu -->
      <div class="content-tool">
        <!-- Tìm kiếm dữ liệu -->
        <div class="content-tool-search">
          <!-- Ô nhập tìm kiếm -->
          <input
            type="text"
            class="content-tool-inputsearch"
            placeholder="Tìm theo mã, tên nhân viên"
          />
          <!-- Biểu tượng tìm kiếm -->
          <div class="content-tool-icon"></div>
        </div>
        <!-- Reload trang -->
        <div class="content-tool-reload"></div>
      </div>
      <!-- Bảng hiện thị dữ liệu -->
      <table class="content-table">
        <thead>
          <tr>
            <th>Mã nhân viên</th>
            <th>Tên nhân viên</th>
            <th>Giới tính</th>
            <th>Ngày sinh</th>
            <th>Số CMND</th>
            <th>Chức danh</th>
            <th>Tên đơn vị</th>
            <th>Số tài khoản</th>
            <th>Tên ngân hàng</th>
            <th>Chi nhánh ngân hàng</th>
            <th>Chức năng</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="employee in employeeGetAll" :key="employee.employeeId">
            <td>{{ employee.employeeCode }}</td>
            <td>{{ employee.fullName }}</td>
            <td>{{ employee.genderId }}</td>
            <td>{{ formatDateOfBirth(employee.dateOfBirth) }}</td>
            <td>{{ employee.identityId }}</td>
            <td>{{ employee.positionId }}</td>
            <td>{{ employee.departmentId }}</td>
            <td>{{ employee.bankId }}</td>
            <td>{{ employee.bankName }}</td>
            <td>{{ employee.bankBranch }}</td>
            <td>Updating</td>
          </tr>
        </tbody>
      </table>
      <!-- Phân trang và hiển thị tổng số dữ liệus -->
    </div>
    <!-- Thao tác phân trang -->
    <div class="content-paging">
      <!-- Trả về tổng số bản ghi -->
      <div class="content-all-employee">
        Tổng số: <span class="all-employee">{{ employeeGetAllCount }}</span> bản
        ghi
      </div>
      <!-- Phân trang  -->
      <div class="content-paging-number" @click="paging()">
        <!-- Chọn số bản ghi trên một trang -->
        <div class="paging-number-employee">
          
        </div>

        <!-- Chọn trang muốn hiển thị -->
        <div class="paging-number-display"></div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  // Toàn bộ các biến được lưu trữ ở đây
  data() {
    return {
      employeeGetAll: {},
      employeeGetAllCount: 0,
    };
  },
  // Sau khi tạo xong sẽ chạy Created
  created() {
    // Thực hiện lấy toàn bộ dữ liệu và gán vào biến: employeeGetAll
    axios
      .get("https://localhost:44308/v1/api/WebApi")
      .then((res) => {
        console.log(res.data);
        // Toàn bộ dữ liệu lấy về - lưu vào biến employeeGetAll
        this.employeeGetAll = res.data;
        // Tổng số bản ghi lấy về - lưu vào biến employeeGetAllCount
        this.employeeGetAllCount = res.data.length;
      })
      .catch((res) => {
        console.log(res);
      });
  },
  methods: {
    // Định dạng ngày tháng
    formatDateOfBirth(birth) {
      var d = new Date(birth),
        month = "" + (d.getMonth() + 1),
        day = "" + d.getDate(),
        year = d.getFullYear();

      if (month.length < 2) month = "0" + month;
      if (day.length < 2) day = "0" + day;

      return [day, month, year].join("-");
    },
    // Phân trang dữ liệu Nhân Viên
    paging() {
      axios
        .get("https://localhost:44308/v1/api/WebApi/Paging?pageIndex=1&pageSize=1")
        .then((res)=>{
          this.employeeGetAll = res.data;
        })
        .catch((res)=>{
          console.log(res);
        });
    },
  },
};
</script>
<style></style>
