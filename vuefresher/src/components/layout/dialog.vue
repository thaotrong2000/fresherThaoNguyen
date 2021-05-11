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
              <input type="text" class="dialog-input-code dialog-input" />
            </div>
            <div class="dialog-topleft-two dialog-topleft">
              <div class="dialog-name">Tên <span>*</span></div>
              <input type="text" class="dialog-input-name dialog-input" />
            </div>
            <div class="dialog-topleft-three dialog-topleft">
              <div class="dialog-departmentId">Đơn vị <span>*</span></div>
              <select
                name=""
                id=""
                class="dialog-input dialog-input-departmentId"
              >
                <option value="">Hành chính</option>
                <option value="">Nhân sự</option>
              </select>
            </div>
            <div class="dialog-topleft-four dialog-topleft">
              <div class="dialog-position">Chức danh</div>
              <input type="text" class="dialog-input-position dialog-input" />
            </div>
          </div>
          <!-- Trên bên phải -->
          <div class="dialog-content-topright">
            <div class="dialog-topright-one dialog-topright">
              <div class="dialog-date">Ngày sinh</div>
              <input type="date" class="dialog-input-date dialog-input" />
            </div>
            <div class="dialog-topright-two dialog-topright">
              <div class="dialog-gender">Giới tính</div>
              <!-- <input type="radio" class="dialog-input-gender dialog-input" />
              <input type="radio" class="dialog-input-gender dialog-input" />
              <input type="radio" class="dialog-input-gender dialog-input" /> -->
              <form action="">
                <input type="radio" name="gender" value="male" /> Nam<br />
                <input type="radio" name="gender" value="female" /> Nữ<br />
                <input type="radio" name="gender" value="other" /> Khác
              </form>
            </div>
            <div class="dialog-topright-three dialog-topright">
              <div class="dialog-identityId">Số CMND</div>
              <input type="text" class="dialog-input-identityId dialog-input" />
            </div>
            <div class="dialog-topright-four dialog-topleft">
              <div class="dialog-identityDate">Ngày cấp</div>
              <input
                type="date"
                class="dialog-input-identityDate dialog-input"
              />
            </div>
            <div class="dialog-topright-five dialog-topleft">
              <div class="dialog-identityPosition">Nơi cấp</div>
              <input
                type="text"
                class="dialog-input-identityPosition dialog-input"
              />
            </div>
          </div>
        </div>
        <!-- Phần thông tin thứ hai -->
        <div class="dialog-content-bottom">
          <!-- phần 1  -->
          <div class="dialog-bottom-one">
            <div class="dialog-address">Địa chỉ</div>
            <input type="text" class="dialog-input-address dialog-input" />
          </div>
          <!-- phần 2 -->
          <div class="dialog-bottom-two">
            <div class="dialog-bottom-phoneNumber">
              <div class="dialog-phoneNumber">ĐT di động</div>
              <input
                type="text"
                class="dialog-input-phoneNumber dialog-input"
              />
            </div>
            <div class="dialog-bottom-landLine">
              <div class="dialog-landLine">ĐT cố định</div>
              <input type="text" class="dialog-input-landLine dialog-input" />
            </div>
            <div class="dialog-bottom-email">
              <div class="dialog-email">Email</div>
              <input type="text" class="dialog-input-email dialog-input" />
            </div>
          </div>
          <!-- phần 3 -->
          <div class="dialog-bottom-three">
            <div class="dialog-bottom-phoneNumber dialog-bottom-bankId">
              <div class="dialog-phoneNumber dialog-bankId">Tài khoản ngân hàng</div>
              <input
                type="text"
                class="dialog-input-phoneNumber dialog-input dialog-input-bankId "
              />
            </div>
            <div class="dialog-bottom-landLine dialog-bottom-bankName">
              <div class="dialog-landLine">Tên ngân hàng</div>
              <input type="text" class="dialog-input-landLine dialog-input dialog-input-bankName" />
            </div>
            <div class="dialog-bottom-email dialog-bottom-branch">
              <div class="dialog-email dialog-branch">Chi nhánh</div>
              <input type="text" class="dialog-input-email dialog-input dialog-input-branch" />
            </div>
          </div>
        </div>
      </div>
      <!-- Phần nút chức năng của Dialog -->
      <div class="dialog-footer">
        <div class="dialog-footer-cancel button-common dialog-footer-button">Hủy</div>
        <div class="dialog-footer-save button-common dialog-footer-button">Cất</div>
        <div class="dialog-footer-post button-common dialog-footer-button">Cất và thêm</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    ishow: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      showDialog: true,
    };
  },
  methods: {
    closeDialog() {
      this.$emit("closeDialog");
    },
  },
};
</script>

<style>
@import "../../style/layout/css-dialog.css";
</style>
