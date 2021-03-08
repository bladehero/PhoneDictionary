<template>
  <v-container>
    <v-row justify="center">
      <v-col class="mt-5 mb-3" cols="3">
        <v-img src="../assets/logo-header.png" alt="logo" />
      </v-col>
      <v-col cols="12">
        <v-row justify="center">
          <v-col cols="8" sm="6" md="4" lg="3">
            <ContactTypesHeader />
          </v-col>
          <v-col cols="8" sm="6" md="4" lg="3">
            <CityHeader />
          </v-col>
          <v-col cols="8" sm="12" md="4" lg="3">
            <SearchHeader />
          </v-col>
        </v-row>
      </v-col>
      <v-col cols="10">
        <div style="position: relative;">
          <v-btn id="search-button" elevation="5" fab dark color="yellow">
            <v-icon>
              mdi-magnify
            </v-icon>
          </v-btn>
        </div>
        <ContactsList />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import CityHeader from '../components/CityHeader'
import ContactTypesHeader from '../components/ContactTypesHeader'
import SearchHeader from '../components/SearchHeader'
import ContactsList from '../components/ContactsList'

export default {
  components: {
    CityHeader,
    ContactTypesHeader,
    SearchHeader,
    ContactsList
  },
  name: 'Home'
}
</script>

<style scoped>
#search-button {
  position: absolute;
  top: -30px;
  right: 30px;
  z-index: 9;
}
</style>
