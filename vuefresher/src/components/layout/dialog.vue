<template>
  <div id="dialog" v-show="ishow">
    <!-- Làm mờ phần màn hình chính -->
    <div class="dialog-opacity"></div>
    <!-- Nội dung chính của Dialog -->
    <div class="dialog-content">
      <!-- Tạo header -->
      <div class="dialog-header">
        <div class="dialog-header-infor">Thông tin nhân viên</div>
        <input class="dialog-header-checkbox" type="checkbox" />
        <div class="dialog-header-customer dialog-header-select">
          Là khách hàng
        </div>
        <input class="dialog-header-checkbox" type="checkbox" />
        <div class="dialog-header-employee dialog-header-select">
          Là nhà cung cấp
        </div>
        <div class="dialog-header-help"></div>
        <div class="dialog-header-close" @click="closeDialog()"></div>
      </div>
      <!-- Phần nội dung -->
      <div class="dialog-content-middle">
        <!-- Phần thông tin thứ nhất -->
        <div class="dialog-content-top">
          <!-- Trên bên trái -->
          <div class="dialog-content-topleft">
            <div class="dialog-topleft-one dialog-topleft">
              <div class="dialog-code">Mã <span>*</span></div>
              <input
                type="text"
                class="dialog-input-code dialog-input"
                v-model="employeeSelected.employeeCode"
                ref="employeeCode"
                @blur="employeeCode()"
                :style="
                  checkEmployeeCode
                    ? 'border: 0.1px solid #ccc;'
                    : 'border: 0.1px solid red;'
                "
              />
            </div>
            <div class="dialog-topleft-two dialog-topleft">
              <div class="dialog-name">Tên <span>*</span></div>
              <input
                type="text"
                class="dialog-input-name dialog-input"
                v-model="employeeSelected.fullName"
                ref="employeeFullName"
                @blur="employeeFullName()"
                :style="
                  checkEmployeeFullName
                    ? 'border: 0.1px solid #ccc;'
                    : 'border: 0.1px solid red;'
                "
              />
            </div>
            <div class="dialog-topleft-three dialog-topleft">
              <div class="dialog-departmentId">Đơn vị <span>*</span></div>
              <select
                name=""
                id=""
                class="dialog-input dialog-input-departmentId"
                v-model="employeeSelected.departmentId"
                ref="employeeDepartmentId"
                @blur="employeeDepartmentId()"
                :style="
                  checkEmployeeDepartmentId
                    ? 'border: 0.1px solid #ccc;'
                    : 'border: 0.1px solid red;'
                "
              >
                <option
                  :selected="
                    employeeSelected.departmentId ==
                      '2796d66f-b008-11eb-8a1f-00163e047e89'
                  "
                  value="2796d66f-b008-11eb-8a1f-00163e047e89"
                  >Hà Nội</option
                >
                <option
                  :selected="
                    employeeSelected.departmentId ==
                      '2796d66f-b008-11eb-8a1f-00163e047e88'
                  "
                  value="2796d66f-b008-11eb-8a1f-00163e047e88"
                  >TP HCM</option
                >
                <option
                  :selected="
                    employeeSelected.departmentId ==
                      '2796d66f-b008-11eb-8a1f-00163e047e87'
                  "
                  value="2796d66f-b008-11eb-8a1f-00163e047e87"
                  >Phú Thọ</option
                >
              </select>
            </div>
            <div class="dialog-topleft-four dialog-topleft">
              <div class="dialog-position">Chức danh</div>
              <input
                type="text"
                class="dialog-input-position dialog-input"
                v-model="employeeSelected.positionId"
              />
            </div>
          </div>
          <!-- Trên bên phải -->
          <div class="dialog-content-topright">
            <div class="dialog-topright-one dialog-topright">
              <div class="dialog-date">Ngày sinh</div>
              <input
                type="date"
                class="dialog-input-date dialog-input"
                v-bind:value="dateChange(employeeSelected.dateOfBirth)"
                v-on:change="updateDate($event.target.value)"
              />
            </div>
            <div class="dialog-topright-two dialog-topright">
              <div class="dialog-gender">Giới tính</div>
              <!-- <input type="radio" class="dialog-input-gender dialog-input" />
              <input type="radio" class="dialog-input-gender dialog-input" />
              <input type="radio" class="dialog-input-gender dialog-input" /> -->
              <form action="">
                <input
                  type="radio"
                  name="gender"
                  value="1"
                  :checked="employeeSelected.genderId == 1"
                />
                Nam<br />
                <input
                  type="radio"
                  name="gender"
                  value="0"
                  :checked="employeeSelected.genderId == 0"
                />
                Nữ<br />
                <input
                  type="radio"
                  name="gender"
                  value="2"
                  :checked="employeeSelected.genderId == 2"
                />
                Khác
              </form>
            </div>
            <div class="dialog-topright-three dialog-topright">
              <div class="dialog-identityId">Số CMND</div>
              <input
                type="text"
                class="dialog-input-identityId dialog-input"
                v-model="employeeSelected.identityId"
              />
            </div>
            <div class="dialog-topright-four dialog-topleft">
              <div class="dialog-identityDate">Ngày cấp</div>
              <input
                type="date"
                class="dialog-input-identityDate dialog-input"
                v-bind:value="dateChange(employeeSelected.identityDate)"
              />
            </div>
            <div class="dialog-topright-five dialog-topleft">
              <div class="dialog-identityPosition">Nơi cấp</div>
              <input
                type="text"
                class="dialog-input-identityPosition dialog-input"
                v-model="employeeSelected.identityPosition"
              />
            </div>
          </div>
        </div>
        <!-- Phần thông tin thứ hai -->
        <div class="dialog-content-bottom">
          <!-- phần 1  -->
          <div class="dialog-bottom-one">
            <div class="dialog-address">Địa chỉ</div>
            <input
              type="text"
              class="dialog-input-address dialog-input"
              v-model="employeeSelected.address"
            />
          </div>
          <!-- phần 2 -->
          <div class="dialog-bottom-two">
            <div class="dialog-bottom-phoneNumber">
              <div class="dialog-phoneNumber">ĐT di động</div>
              <input
                type="text"
                class="dialog-input-phoneNumber dialog-input"
                v-model="employeeSelected.phoneNumber"
              />
            </div>
            <div class="dialog-bottom-landLine">
              <div class="dialog-landLine">ĐT cố định</div>
              <input
                type="text"
                class="dialog-input-landLine dialog-input"
                v-model="employeeSelected.landlinePhone"
              />
            </div>
            <div class="dialog-bottom-email">
              <div class="dialog-email">Email</div>
              <input
                type="text"
                class="dialog-input-email dialog-input"
                v-model="employeeSelected.email"
              />
            </div>
          </div>
          <!-- phần 3 -->
          <div class="dialog-bottom-three">
            <div class="dialog-bottom-phoneNumber dialog-bottom-bankId">
              <div class="dialog-phoneNumber dialog-bankId">
                Tài khoản ngân hàng
              </div>
              <input
                type="text"
                class="dialog-input-phoneNumber dialog-input dialog-input-bankId "
                v-model="employeeSelected.bankId"
              />
            </div>
            <div class="dialog-bottom-landLine dialog-bottom-bankName">
              <div class="dialog-landLine">Tên ngân hàng</div>
              <input
                type="text"
                class="dialog-input-landLine dialog-input dialog-input-bankName"
                v-model="employeeSelected.bankName"
              />
            </div>
            <div class="dialog-bottom-email dialog-bottom-branch">
              <div class="dialog-email dialog-branch">Chi nhánh</div>
              <input
                type="text"
                class="dialog-input-email dialog-input dialog-input-branch"
                v-model="employeeSelected.bankBranch"
              />
            </div>
          </div>
        </div>
      </div>
      <!-- Phần nút chức năng của Dialog -->
      <div class="dialog-footer">
        <div
          class="dialog-footer-cancel button-common dialog-footer-button"
          @click="closeDialog()"
        >
          Hủy
        </div>
        <div class="dialog-footer-save button-common dialog-footer-button">
          Cất
        </div>
        <div
          class="dialog-footer-post button-common dialog-footer-button"
          @click="postData()"
        >
          Cất và thêm
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import $ from "jquery";


export default {
  props: {
    ishow: {
      type: Boolean,
      default: false,
    },
    statusSendData: {
      type: String,
      default: "add",
    },
    employeeSelected: {
      type: Object,
    },
    
  },
  data() {
    return {
      showDialog: true,
      checkEmployeeFullName: true,
      checkEmployeeDepartmentId: true,
      checkEmployeeCode: true,
      checkPostPutData: false
    };
  },
  methods: {
    closeDialog() {
      this.$emit("closeDialog");
      console.log(this.employeeSelected);
      this.checkEmployeeFullName = true; 
      this.checkEmployeeDepartmentId = true;
      this.checkEmployeeCode = true;
    },
    dateChange(date) {
      var d = new Date(date),
        month = "" + (d.getMonth() + 1),
        day = "" + d.getDate(),
        year = d.getFullYear();

      if (month.length < 2) month = "0" + month;
      if (day.length < 2) day = "0" + day;

      return [year, month, day].join("-");
    },

    // Thêm dữ liệu
    postData() {
      if(this.statusSendData=="edit"){
        this.checkPostPutData = true;
      }
      if(this.$refs.employeeFullName.value == ""){
        this.checkEmployeeFullName = false;
         $(".dialog-input-name").prop("title", "Bạn không được để trống Tên!");
      }
      if(this.$refs.employeeCode.value == ""){
        this.checkEmployeeCode = false;
        $(".dialog-input-code").prop("title", "Bạn không được để trống Mã khách hàng!");
      }
      if(this.$refs.employeeDepartmentId.value == ""){
        this.checkEmployeeDepartmentId = false;
        $(".dialog-input-departmentId").prop("title", "Bạn không được để trống Đơn vị!");
      }
      if(this.checkEmployeeFullName == true && this.checkEmployeeDepartmentId == true 
      && this.checkEmployeeCode == true && this.checkPostPutData == true){
        if (this.statusSendData == "add") {
        // this.employeeSelected.genderId = 1;
        // Test dữ liệu cứng
        console.log(this.employeeSelected);
        axios
          .post("https://localhost:44308/v1/api/WebApi", this.employeeSelected)
          .then(() => {
            alert("Thêm dữ liệu thành công");
            this.closeDialog();
            
          })
          .catch((err) => {
            console.log(err.response.data);
            var error = err.response.data.devMsg;
            alert(error);
          });
      } else {
        axios
          .put("https://localhost:44308/v1/api/WebApi", this.employeeSelected)
          .then(() => {
            alert("Sửa dữ liệu thành công");
            this.closeDialog();
          })
          .catch((err) => {
            console.log("Sửa không được");
            console.log(err.response.data);
            var error = err.response.data.devMsg;
            alert(error);
          });
      }
      }
    },
    // Cập nhật ngày khi thay đổi
    updateDate(date){
      this.employeeSelected.dateOfBirth = date;
    },
    // Check thông tin bắt buộc nhập: employeeCode
    employeeFullName(){
      var check = this.$refs.employeeFullName.value;
      if (check == "") {
        this.checkEmployeeFullName = false;
        $(".dialog-input-name").prop("title", "Bạn không được để trống Tên!");
        
      } else {
        this.checkEmployeeFullName = true;
      }
      
    },
    // Check thông tin bắt buộc nhập: departmentId
    employeeDepartmentId(){
      var check = this.$refs.employeeDepartmentId.value;
      this.checkPostPutData = true;
      if (check == "") {
        this.checkEmployeeDepartmentId = false;
        $(".dialog-input-departmentId").prop("title", "Bạn không được để trống Đơn vị!");
      } else {
        this.checkEmployeeDepartmentId = true;
      }
    },
    // Check thông tin bắt buộc nhập: employeeCode
    employeeCode() {
      var check = this.$refs.employeeCode.value;
      
      if (check == "") {
        this.checkEmployeeCode = false;
        $(".dialog-input-code").prop("title", "Bạn không được để trống Mã khách hàng!");
      } else {
        this.checkEmployeeCode = true;
      }

    },
  },
};
</script>

<style>
@import "../../style/layout/css-dialog.css";
</style>
