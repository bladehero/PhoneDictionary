<template>
  <v-card class="mx-auto" elevation="1">
    <v-card-title>Контакти</v-card-title>
    <div class="text-center">
      <v-pagination
        v-model="page"
        :length="15"
        :total-visible="7"
      ></v-pagination>
    </div>
  </v-card>
</template>

<script>
export default {}
</script>

<style></style>
