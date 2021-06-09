<template>
  <v-app>
    <v-main>
      <v-container>
        <v-row justify="center">
          <v-col class="mt-5 mb-3" cols="3">
            <router-link to="/">
              <v-img
                lazy-src="@/assets/logo-header.png"
                src="@/assets/logo-header.png"
                alt="logo"
              />
            </router-link>
          </v-col>
          <v-col cols="12">
            <router-view />
          </v-col>
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
  font-size: 1.5rem;
  --scrollbarBG: transparent;
  --thumbBG: #00d8a2;
}

::-webkit-scrollbar {
  width: 7px;
}

::-webkit-scrollbar-track {
  background: var(--scrollbarBG);
}

::-webkit-scrollbar-thumb {
  background-color: var(--thumbBG) ;
  border-radius: 6px;
  border: 3px solid var(--scrollbarBG);
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
