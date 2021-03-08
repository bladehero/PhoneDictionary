<template>
  <v-combobox
    id="contact-type-list"
    class="text-white"
    color="white"
    v-model="selected"
    :items="contactTypes"
    label="Всі типи"
    outlined
    multiple
    dark
    dense
    hide-details
    @change="contactTypesChanged"
  ></v-combobox>
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
    ...mapGetters('contactTypes', ['contactTypes'])
  },
  methods: {
    ...mapActions('contactTypes', ['getAllContactTypes']),
    ...mapMutations('contacts', ['setSearchParams']),
    contactTypesChanged () {
      const contactTypes = this.selected.map(x => x.value)
      this.setSearchParams({ contactTypes })
    }
  },

  created: function () {
    this.getAllContactTypes()
  }
}
</script>
