<template>
  <v-combobox
    id="contact-type-list"
    class="text-white"
    color="white"
    :items="contactTypes"
    label="Всі типи"
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
