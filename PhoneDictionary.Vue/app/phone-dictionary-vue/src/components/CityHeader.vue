<template>
  <v-container fluid>
    <v-row>
      <v-col cols="12">
        <v-combobox
          v-model="select"
          :items="cities"
          label="Города"
          multiple
          outlined
          dense
        ></v-combobox>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  computed: {
    ...mapGetters('cities', ['cities'])
  },
  methods: {
    ...mapActions('cities', ['getAllCities'])
  },

  created: function () {
    this.getAllCities()
  }
}
</script>

<style></style>
