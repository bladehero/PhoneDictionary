<template>
  <div>
    <v-row class="mb-4" justify="center">
      <v-col cols="6" md="4" lg="3">
        <ContactTypesHeader />
      </v-col>
      <v-col cols="6" md="4" lg="3">
        <CityHeader />
      </v-col>
      <v-col cols="12" md="4" lg="3">
        <SearchHeader />
      </v-col>
    </v-row>
    <div class="tool-wrapper">
      <div class="tool-layer">
        <v-btn
          class="mr-2"
          id="search-button"
          elevation="5"
          fab
          dark
          color="yellow"
          @click="search"
        >
          <v-icon>
            mdi-magnify
          </v-icon>
        </v-btn>
        <v-btn
          id="clear-button"
          elevation="5"
          fab
          dark
          color="red darken-1"
          @click="clear"
        >
          <v-icon>
            mdi-cancel
          </v-icon>
        </v-btn>
      </div>
    </div>
    <ContactsList />
  </div>
</template>

<script>
import CityHeader from '../components/CityHeader'
import ContactTypesHeader from '../components/ContactTypesHeader'
import SearchHeader from '../components/SearchHeader'
import ContactsList from '../components/ContactsList'
import { mapActions, mapMutations } from 'vuex'

export default {
  components: {
    CityHeader,
    ContactTypesHeader,
    SearchHeader,
    ContactsList
  },
  name: 'Home',
  methods: {
    ...mapActions('contacts', ['getContacts']),
    ...mapMutations('contacts', ['clearSearchParams']),
    async search () {
      await this.getContacts()
    },
    clear () {
      this.clearSearchParams()
    }
  },
  async created () {
    await this.search()
  }
}
</script>

<style scoped>
.tool-wrapper {
  position: relative;
}
.tool-layer {
  position: absolute;
  top: -30px;
  right: 30px;
  z-index: 1;
}
</style>
