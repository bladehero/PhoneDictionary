<template>
  <v-combobox
    id="city-list"
    class="text-white"
    color="white"
    v-model="selected"
    :items="cities"
    label="All citites"
    multiple
    outlined
    dark
    auto-select-first
    dense
    hide-details
  />
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  computed: {
    selected: {
      get () {
        return this.$store.state.contacts.params.cities
      },
      set (value) {
        const cities = value.map(x => (typeof x === 'string' ? x : x.value))
        this.$store.commit('contacts/setSearchParams', { cities })
      }
    },
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
