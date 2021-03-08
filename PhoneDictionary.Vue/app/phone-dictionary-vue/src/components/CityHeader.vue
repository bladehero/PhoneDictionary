<template>
  <v-combobox
    id="city-list"
    class="text-white"
    color="white"
    v-model="select"
    :items="cities"
    label="Города"
    multiple
    outlined
    dense
  ></v-combobox>
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

<style>
#city-list .v-input__control {
  color: white !important;
}

.v-select__selection {
  color: white !important;
}
</style>
