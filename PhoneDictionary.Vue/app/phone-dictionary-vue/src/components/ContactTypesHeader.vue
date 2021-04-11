<template>
  <v-combobox
    id="contact-type-list"
    class="text-white"
    color="white"
    v-model="selected"
    :items="contactTypes"
    label="All types"
    outlined
    multiple
    dark
    dense
    hide-details
  ></v-combobox>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  computed: {
    selected: {
      get () {
        return this.$store.state.contacts.params.contactTypes
      },
      set (value) {
        const contactTypes = value.map(x => typeof x === 'string' ? x : x.value)
        this.$store.commit('contacts/setSearchParams', { contactTypes })
      }
    },
    ...mapGetters('contactTypes', ['contactTypes'])
  },
  methods: {
    ...mapActions('contactTypes', ['getAllContactTypes'])
  },

  created: function () {
    this.getAllContactTypes()
  }
}
</script>
