<template>
  <v-container fluid>
    <v-row justify="center">
      <v-col class="mt-5 mb-3" cols="3">
        <v-img src="../assets/logo-header.png" alt="logo" />
      </v-col>
      <v-col cols="12">
        <v-row justify="center">
          <v-col cols="6">
            <CityHeader />
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import CityHeader from '../components/CityHeader'

export default {
  components: {
    CityHeader
  },
  name: 'Home'
}
</script>
