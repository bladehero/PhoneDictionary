<template>
  <v-text-field
    label="Search"
    placeholder="Search expression..."
    v-model="search"
    outlined
    dense
    dark
    hide-details
    class="mb-2 mb-md-3"
  ></v-text-field>
</template>

<script>
import { mapActions, mapMutations } from 'vuex'

export default {
  computed: {
    search: {
      get () {
        return this.$store.state.contacts.params.search
      },
      set (value) {
        this.$store.commit('contacts/setSearchParams', { search: value })
      }
    }
  },
  methods: {
    ...mapActions('contacts', ['getContacts', 'resetPage']),
    ...mapMutations('contacts', ['setSearchParams'])
  },
  watch: {
    async search (newValue) {
      this.resetPage()
      this.setSearchParams({ search: newValue })
      await this.getContacts()
    }
  }
}
</script>
