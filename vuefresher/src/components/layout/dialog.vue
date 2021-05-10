<template>
  <div id="dialog" v-show="ishow">
    <!-- Làm mờ phần màn hình chính -->
    <div class="dialog-opacity">
        
    </div>
    <!-- Nội dung chính của Dialog -->
    <div class="dialog-content" @click="closeDialog()">
        nguyen trong thao
    </div>
  </div>
</template>

<script>
export default {
  props: {
    ishow: {
      type: Boolean,
      default: false
    },
  },
  data() {
    return {
      showDialog: true,
    };
  },
  methods:{
      closeDialog(){
          this.$emit("closeDialog");
      }
  }
};
</script>

<style>
@import "../../style/layout/css-dialog.css";
</style>
