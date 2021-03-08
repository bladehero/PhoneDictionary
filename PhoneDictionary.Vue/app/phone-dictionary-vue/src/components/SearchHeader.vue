<template>
  <v-text-field
    label="Пошук"
    placeholder="Пошуковий запит..."
    v-model="search"
    outlined
    dense
    dark
    hide-details
    class="mb-3"
  ></v-text-field>
</template>

<script>
import { mapActions, mapMutations } from 'vuex'

export default {
  data () {
    return {
      search: ''
    }
  },
  methods: {
    ...mapActions('contacts', ['getContacts']),
    ...mapMutations('contacts', ['setSearchParams'])
  },
  watch: {
    async search (newValue) {
      this.setSearchParams({ search: newValue })
      await this.getContacts()
    }
  }
}
</script>
