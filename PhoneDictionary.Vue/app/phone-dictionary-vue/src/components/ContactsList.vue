<template>
  <v-card class="pb-2" elevation="2">
    <v-card-title class="headline">Контакти</v-card-title>
    <v-card-text>
      <v-simple-table v-if="hasContact">
        <template v-slot:default>
          <thead>
            <tr>
              <th class="text-left">
                Ім'я
              </th>
              <th class="text-left">
                Тип
              </th>
              <th class="text-left">
                Контакт
              </th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="contact in contacts" :key="contact.contactId">
              <td>{{ contact.userName }}</td>
              <td>{{ contact.contactType }}</td>
              <td>{{ contact.contact }}</td>
            </tr>
          </tbody>
        </template>
      </v-simple-table>
      <p class="text-center mt-7" v-else>Немає даних згідно із запитом...</p>
    </v-card-text>
    <div class="text-center" v-if="hasContact">
      <v-pagination
        color="yellow darken-1"
        v-model="page"
        :length="pages"
        :total-visible="10"
      ></v-pagination>
    </div>
  </v-card>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
  computed: {
    page: {
      get () {
        return this.$store.state.contacts.page
      },
      set (value) {
        this.$store.commit('contacts/setPage', value)
      }
    },
    hasContact () {
      const contacts = this.contacts
      return contacts && contacts.length
    },
    ...mapGetters('contacts', ['contacts', 'pages'])
  },
  methods: {
    ...mapActions('contacts', ['getContacts'])
  },
  watch: {
    async page () {
      await this.getContacts()
    }
  }
}
</script>

<style scoped>
.v-card__title {
  color: white;
  background: linear-gradient(45deg, #b02799, #00ffbf);
}
</style>
