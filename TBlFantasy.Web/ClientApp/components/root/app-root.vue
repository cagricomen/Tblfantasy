
<template>
    <div class="layout-container" id="app">
    <nav-menu params="route: route"></nav-menu>
    <div class="layout-content">
      <notifications/>
      <!-- Page content -->
      <div class="container-fluid flex-grow-1 container-p-y">
        <router-view></router-view>
      </div>
      <!-- / Page content -->
    </div>
  </div>
</template>

<script>
import NavMenu from "./nav-menu";

export default {
  components: {
    "nav-menu": NavMenu
  },


};
</script>

<style>
</style>
