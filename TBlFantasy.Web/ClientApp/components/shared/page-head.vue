<template>
  <h4 class="font-weight-bold py-3 mb-4">
    <icon v-if="icon" :icon="icon" />
    <span class="text-muted font-weight-light">{{prefix}}/  </span>{{title}}
  </h4>
</template>

<script>
export default {
  props: {
    title: {
      default: "",
      type: String
    },
    prefix: {
      default: "TBLFANTASY",
      type: String
    },
     icon: {
      default: "TBLFANTASY",
      type: String
    }
  }
};
</script>
