<template>
  <div id="employee">
    <!-- Tên Bảng và chức năng thêm nhân nhân viên -->
    <div class="content-add-employee">
      <!-- Tên bảng  -->
      <div class="content-table-name">
        Nhân viên
      </div>
      <!-- Nút thêm nhân viên -->
      <button class="content-button-add button-common" @click="addEmployee()">
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
            @keydown.enter="keyEnterSearch()"
          />
          <!-- Biểu tượng tìm kiếm -->
          <div class="content-tool-icon" @click="filterEmployee()"></div>
        </div>
        <!-- Xuất file Excel -->
        <div class="content-tool-excel" @click="exportFileExcel()"></div>
        <!-- Reload trang -->
        <div class="content-tool-reload" @click="reloadData()"></div>
      </div>
      <!-- Bảng hiện thị dữ liệu -->
      <table class="content-table">
        <thead>
          <tr>
            <th class="content-table-columnsticky-left">Mã nhân viên</th>
            <th>Tên nhân viên</th>
            <th>Giới tính</th>
            <th>Ngày sinh</th>
            <th>Số CMND</th>
            <th>Chức danh</th>
            <th>Tên đơn vị</th>
            <th>Số tài khoản</th>
            <th>Tên ngân hàng</th>
            <th>Chi nhánh ngân hàng</th>
            <th class="content-table-columnsticky-right">Chức năng</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="employee in employeeGetAll" :key="employee.employeeId">
            <td class="content-table-columnsticky-left">
              {{ employee.employeeCode }}
            </td>
            <td>{{ employee.fullName }}</td>
            <td>{{ formatGenderId(employee.genderId) }}</td>
            <td>{{ formatDateOfBirth(employee.dateOfBirth) }}</td>
            <td>{{ employee.identityId }}</td>
            <td>{{ employee.positionId }}</td>
            <td>{{ formatDepartment(employee.departmentId) }}</td>
            <td>{{ employee.bankId }}</td>
            <td>{{ employee.bankName }}</td>
            <td>{{ employee.bankBranch }}</td>
            <!-- employee.bankBranch -->
            <td class="content-table-columnsticky-right">
              <!-- <button
                name=""
                class="toolId"
                value=""
                @click="editEmployee(employee.employeeId)"
              >
                Sửa
              </button>
              <button
                name=""
                class="toolId"
                value=""
                @click="
                  deleteEmployee(employee.employeeId, employee.employeeCode)
                "
              >
                Xóa
              </button> -->
              <select name="" class="editData" v-bind:id="employee.employeeId" @change="changeData(employee.employeeId,employee.employeeCode)">
                <option value="">...</option>
                <option value="edit">Sửa</option>
                <option value="delete">Xóa</option>
              </select>
            </td>
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
      <div class="content-paging-number">
        <!-- Chọn số bản ghi trên một trang -->
        <div class="paging-number-employee">
          <div class="page-select-default">
            <div class="page-select-text" value="10">
              10 bản ghi hiển thị
            </div>
            <div class="page-select-icon"></div>
          </div>
          <div class="paging-selected-employee">
            <div
              class="paging-selected-10 page-selected"
              value="10"
              id="selected-10"
              @click="paging(10)"
            >
              10 bản ghi hiển thị
            </div>
            <div
              class="paging-selected-20 page-selected"
              id="selected-20"
              value="20"
              @click="paging(20)"
            >
              20 bản ghi hiển thị
            </div>
            <div
              class="paging-selected-30 page-selected"
              id="selected-30"
              value="30"
              @click="paging(30)"
            >
              30 bản ghi hiển thị
            </div>
            <div
              class="paging-selected-40 page-selected"
              id="selected-40"
              value="40"
              @click="paging(40)"
            >
              40 bản ghi hiển thị
            </div>
          </div>
        </div>

        <!-- Chọn trang muốn hiển thị -->
        <div class="paging-number-display">
          <!-- PrePage -->
          <div class="paging-display-pre">Trước</div>
          <!-- Chọn trang số mấy -->
          <div class="paging-display-number">1 2</div>
          <!-- Chọn trang sau -->
          <div class="paging-dipslay-next">Sau</div>
        </div>
      </div>
    </div>
    <Dialog
      :ishow="isShowDialog"
      @closeDialog="closeDialog()"
      :employeeSelected="employeeSelected"
      :statusSendData="statusSendData"
      :employeeCodeMax="employeeCodeMax"
      :inputFocus="inputFocus"
    />
  </div>
</template>

<script>
import axios from "axios";
import Dialog from "../layout/dialog.vue";
import $ from "jquery";

export default {
  // Sử dụng các Component từ bên ngoài
  components: {
    Dialog,
  },
  // Toàn bộ các biến được lưu trữ ở đây
  data() {
    return {
      employeeGetAll: {}, // Object lưu toàn bộ dữ liệu nhân viên được lấy về
      employeeGetAllCount: 0, // Đếm tổng số nhân viên trong Database
      pageSizeEmployee: 0, // Số phần tử trên một trang
      isShowDialog: false, // cho phép Dialog hiển thị hoặc không
      stringFilterEmployee: "", // biến để lọc dữ liệu theo: mã nhân viên, tên, sđt
      employeeIdSelected: "", // employeeId của khách hàng được ấn vào chỉnh sửa
      employeeSelected: {}, // Đây là biến khách hàng được chọn, cùng chính là biến khách hàng được thêm
      statusSendData: "add", // Trạng thái thêm mới nhân viên(add) hoặc chỉnh sửa nhân viên(edit)
      employeeCodeMax: "", // Trả về mã nhân viên lớn nhất hiện tại
      inputFocus: false, // Kiểm tra sự Focus

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

    // Lấy về mã nhân viên lớn nhất
    axios
      .get("https://localhost:44308/v1/api/WebApi/EmployeeCodeMax")
      .then((res) => {
        this.employeeCodeMax = res.data;
      })
      .catch(() => {});
  },
  methods: {
    addEmployee() {
      this.isShowDialog = true;
      this.employeeSelected = {};
      this.statusSendData = "add";
      this.employeeSelected.employeeCode =
        "ms" + String(this.employeeCodeMax + 1);
      this.inputFocus = true;
    },
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
    paging(x) {
      this.pageSizeEmployee = x;
      axios
        .get(
          "https://localhost:44308/v1/api/WebApi/Paging?pageIndex=1&pageSize=" +
            this.pageSizeEmployee
        )
        .then((res) => {
          this.employeeGetAll = res.data;
        })
        .catch((res) => {
          console.log(res);
        });
    },
    closeDialog() {
      this.isShowDialog = false;
      this.employeeSelected = {};
      this.reloadData();
      this.getEmployeeCodeMax();
      this.inputFocus = false;
    },

    // Lọc dữ liệu dựa trên Mã nhân viên, tên hoặc số điện thoại
    filterEmployee() {
      // Biến lưu dữ liệu từ thao tác nhập vào ô Input của người dùng
      var filterData = $(".content-tool-inputsearch").val();
      this.stringFilterEmployee = filterData;
      // Thực hiện lọc dữ liệu từ API với các biến đã được chọn
      axios
        .get(
          "https://localhost:44308/v1/api/WebApi/Filter?employeeCode=" +
            filterData +
            "&employeeFullName=" +
            filterData +
            "&employeePhoneNumber=" +
            filterData
        )
        .then((res) => {
          console.log(res.data);
          // Toàn bộ dữ liệu lấy về - lưu vào biến employeeGetAll
          this.employeeGetAll = res.data;
        })
        .catch((res) => {
          console.log(res);
        });
    },

    // Lấy employeeId của bản ghi khi Click vào
    editEmployee(employeeId) {
      this.employeeIdSelected = employeeId;
      this.isShowDialog = true;
      this.statusSendData = "edit";
      this.inputFocus = true;

      // Lấy dữ liệu theo employeeId
      axios
        .get("https://localhost:44308/v1/api/WebApi/" + this.employeeIdSelected)
        .then((res) => {
          // Dữ liệu nhân viên lấy về theo employeeId
          this.employeeSelected = res.data;
          console.log(this.employeeSelected);
        })
        .catch((res) => {
          console.log(res);
        });
    },

    // Reload lại dữ liệu
    reloadData() {
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
    // Format Department
    formatDepartment(department) {
      if (department == "2796d66f-b008-11eb-8a1f-00163e047e87") {
        return "Phú Thọ";
      }
      if (department == "2796d66f-b008-11eb-8a1f-00163e047e88") {
        return "TP HCM";
      }
      if (department == "2796d66f-b008-11eb-8a1f-00163e047e89") {
        return "Hà Nội";
      }
    },
    // Xóa dữ liệu
    deleteEmployee(employeeId, employeeCode) {
      if (
        confirm(
          "Bạn có chắc chắn muốn xóa nhân viên " + employeeCode + " không?"
        )
      ) {
        axios
          .delete(
            "https://localhost:44308/v1/api/WebApi?EmployeeId=" + employeeId
          )
          .then(() => {
            alert("Xóa dữ liệu thành công");
            this.reloadData();
            this.getEmployeeCodeMax();
          })
          .catch(() => {
            alert("Không xóa được dữ liệu");
          });
      }
    },
    keyEnterSearch() {
      this.filterEmployee();
    },
    // Lấy employeeCodeMax
    getEmployeeCodeMax() {
      axios
        .get("https://localhost:44308/v1/api/WebApi/EmployeeCodeMax")
        .then((res) => {
          this.employeeCodeMax = res.data;
        })
        .catch(() => {});
    },
    // Xuất file Excel
    exportFileExcel() {
      window.open("https://localhost:44308/v1/api/WebApi/DataExcel");
    },
    // Format giới tính
    formatGenderId(genderId) {
      if (genderId == 1) {
        return "Nam";
      }
      if (genderId == 0) {
        return "Nữ";
      }
      if (genderId == 2) {
        return "Giới tính khác";
      }
    },
    // Khi thay đổi dữ liệu
    editDeleteData() {},
    // Khi ấn Edit hoặc Delete
    changeData(employeeId,employeeCode){
      this.employeeIdSelected = employeeId; 
      var valueEdit = $("#"+this.employeeIdSelected).val();
      if(valueEdit == "edit"){
        this.editEmployee(employeeId);
      }
      if(valueEdit == "delete"){
        this.deleteEmployee(employeeId,employeeCode);
      }
      // alert(this.employeeIdSelected);
    }
  },
  mounted() {},
};
// Xử lý Jquery
$(document).ready(function() {
  $(".page-select-icon").on("click", function() {
    $(".paging-selected-employee").toggle();

    $(".page-select-default").css("border", "1px solid green");

    var index_select = $(".paging-selected-employee div");
    // Lấy giá trị của giá trị được chọn
    var value_select_text = $(".page-select-text").text();

    console.log(index_select);
    var setValue = 0;
    // Đặt css cho nó
    for (var count = 0; count < index_select.length; count++) {
      index_select[count].style.backgroundColor = "#ffffff";
      index_select[count].style.color = "#000000";
      setValue = setValue + 10;
      index_select[count].value = setValue;
    }

    // Set CSS cho giá trị được ch
    for (
      var count_select = 0;
      count_select < index_select.length;
      count_select++
    ) {
      var value_select = $(index_select[count_select]).text();
      if (value_select_text == value_select) {
        index_select[count_select].style.backgroundColor = "#2ca01c";
        index_select[count_select].style.color = "#ffffff";
      }
    }
  });

  // Xử lý khi chọn thì binding dữ liệu lên vị trí được chọn
  $(".page-selected").on("click", function() {
    $(".page-select-text").text($(this).text());
    $(".paging-selected-employee").css("display", "none");
    $(".page-select-default").css("border", "1px solid #cccccc");
  });
});
</script>
<style></style>
