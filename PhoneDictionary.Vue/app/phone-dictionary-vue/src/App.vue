<template>
  <v-app>
    <v-main>
      <v-container>
        <v-row justify="center">
            <v-col class="mt-5 mb-3" cols="3">
              <v-img src="@/assets/logo-header.png" alt="logo" />
            </v-col>
            <router-view />
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: 'App',

  data: () => ({
    //
  })
}
</script>

<style>
html {
  overflow-x: hidden !important;
  overflow-y: hidden !important;
}
#app {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: linear-gradient(45deg, #00ffbf, #b02799);
}
</style>
