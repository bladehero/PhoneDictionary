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
              <th class="text-left d-none d-md-table-cell">
                Тип
              </th>
              <th class="text-left">
                Контакт
              </th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="contact in contacts" :key="contact.contactId">
              <td>{{ contact.userName }}</td>
              <td class="d-none d-md-table-cell">{{ contact.contactType }}</td>
              <td>{{ contact.contact }}</td>
              <td>
                <div class="float-right d-none d-sm-table-cell">
                  <v-icon
                    class="mr-2"
                    color="blue darken-2"
                    @click="openUserInfo"
                  >
                    mdi-account
                  </v-icon>
                  <v-icon color="teal" @click="openContactInfo">
                    mdi-alpha-i-circle
                  </v-icon>
                </div>
                <div class="float-right d-sm-none d-table-cell">
                  <v-menu bottom left>
                    <template v-slot:activator="{ on, attrs }">
                      <v-btn icon v-bind="attrs" v-on="on">
                        <v-icon>mdi-dots-vertical</v-icon>
                      </v-btn>
                    </template>

                    <v-list>
                      <v-list-item link @click="openUserInfo">
                        <v-list-item-title>О користувачі</v-list-item-title>
                      </v-list-item>
                      <v-list-item link @click="openContactInfo">
                        <v-list-item-title>Інформація</v-list-item-title>
                      </v-list-item>
                    </v-list>
                  </v-menu>
                </div>
              </td>
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
        :total-visible="7"
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
    ...mapActions('contacts', ['getContacts']),
    openUserInfo () {},
    openContactInfo () {}
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
