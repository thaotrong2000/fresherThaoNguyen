<template>
  <div id="app">
    <Navbar/>
    <Header/>
    <Content/>
  </div>
</template>

<script>
import Navbar from './components/layout/navbar';
import Header from './components/layout/header';
import Content from './components/layout/content';

export default {
  name: 'App',
  components: {
    Navbar, 
    Header, 
    Content
    
  }
}
</script>

<style>
@import "./style/common/css-common.css";

</style>
