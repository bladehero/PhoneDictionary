<template>
  <v-combobox
    id="city-list"
    class="text-white"
    color="white"
    v-model="selected"
    :items="cities"
    label="Всі міста"
    multiple
    outlined
    dark
    auto-select-first
    dense
    hide-details
    @change="citiesChanged"
  />
</template>

<script>
import { mapGetters, mapActions, mapMutations } from 'vuex'

export default {
  data () {
    return {
      selected: []
    }
  },
  computed: {
    ...mapGetters('cities', ['cities'])
  },
  methods: {
    ...mapActions('cities', ['getAllCities']),
    ...mapMutations('contacts', ['setSearchParams']),
    citiesChanged () {
      const cities = this.selected.map(x => x.text)
      this.setSearchParams({ cities })
    }
  },

  created: function () {
    this.getAllCities()
  }
}
</script>
