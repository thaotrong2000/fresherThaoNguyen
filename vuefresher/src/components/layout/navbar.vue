<template>
  <div id="navbar">
    <!-- Phần biểu tượng logo biểu tượng và logo chữ của Navbar -->
    <div class="navbar-logo">
      <!-- Biểu tượng toggle -->
      <div class="navbar-logo-toggle">
        <!-- Chứa biểu tượng Toggle -->
        <div class="navbar-toggle-icon"></div>
      </div>

      <!-- Biểu tượng sản phẩm và text -->
      <div class="navbar-logo-text"></div>
    </div>

    <!-- Phần thanh điều hướng của Navbar -->
    <div class="navbar-router">
      <!-- Tổng quan  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-dashboard"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Tổng quan</span>
        </div>
      </router-link>
      <!-- Tiền mặt  -->
      <router-link class="navbar-router-select" to="/employee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-money"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Tiền mặt</span>
        </div>
      </router-link>
      <!-- Tiền gửi  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-moneysend"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Tiền gửi</span>
        </div>
      </router-link>
      <!-- Mua hàng  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-buy"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Mua hàng</span>
        </div>
      </router-link>
      <!-- Bán hàng  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-sell"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Bán hàng</span>
        </div>
      </router-link>
      <!-- Quản lý hóa đơn  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-bill"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Quản lý hóa đơn</span>
        </div>
      </router-link>
      <!-- Kho  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-repository"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Kho </span>
        </div>
      </router-link>
      <!-- Tool  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-tool"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Công cụ dụng cụ</span>
        </div>
      </router-link>
      <!-- Tài sản cố định  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-asset"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Tài sản cố định</span>
        </div>
      </router-link>
      <!-- Thuế  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-tax"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Thuế</span>
        </div>
      </router-link>
      <!-- Giá thành  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-price"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Giá thành</span>
        </div>
      </router-link>
      <!-- Tổng hợp  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-summary"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Tổng hợp</span>
        </div>
      </router-link>
      <!-- Ngân sách  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-budget"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Ngân sách</span>
        </div>
      </router-link>
      <!-- Báo cáo  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-report"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Báo cáo</span>
        </div>
      </router-link>
      <!-- Phân tích tài chính  -->
      <router-link class="navbar-router-select" to="/notemployee">
        <div class="navbar-router-icon">
          <div class="navbar-icon-img navbar-select-analyst"></div>
        </div>
        <div class="navbar-router-text">
          <span class="navbar-router-content">Phân tích tài chính</span>
        </div>
      </router-link>
    </div>
  </div>
</template>

// Phần Xử lý liên quan đến JS
<script>
export default {};
</script>

// Phần xử lý về CSS
<style>
@import "../../style/common/css-font.css";
@import "../../style/layout/css-navbar.css";
</style>
