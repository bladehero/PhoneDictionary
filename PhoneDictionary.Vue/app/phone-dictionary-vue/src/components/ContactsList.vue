<template>
  <v-card class="pb-2" elevation="2">
    <v-card-title class="headline">Контакти</v-card-title>
    <v-card-text class="table-list-container" :style="{ maxHeight }">
      <v-simple-table v-if="hasContact" dense>
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
                    @click="openUserInfo(contact.userId)"
                  >
                    mdi-account
                  </v-icon>
                  <v-icon
                    color="teal"
                    @click="openContactInfo(contact.contactId)"
                  >
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
                      <v-list-item link @click="openUserInfo(contact.userId)">
                        <v-list-item-title>О користувачі</v-list-item-title>
                      </v-list-item>
                      <v-list-item
                        link
                        @click="openContactInfo(contact.contactId)"
                      >
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

      <v-overlay :value="isContactInfoShown" opacity="1" color="white">
        <v-container class="contact-info-grid">
          <v-row>
            <div class="d-inline-flex">
              <v-icon left>mdi-account</v-icon>
              <span class="header">Ім'я</span>
            </div>
            <span class="value">{{ infoUserName }}</span>
          </v-row>
          <v-row>
            <div class="d-inline-flex">
              <v-icon left>mdi-earth</v-icon>
              <span class="header">Країна</span>
            </div>
            <span class="value">{{ infoCountry }}</span>
          </v-row>
          <v-row>
            <div class="d-inline-flex">
              <v-icon left>mdi-map-marker-radius</v-icon>
              <span class="header">Місто</span>
            </div>
            <span class="value">{{ infoCity }}</span>
          </v-row>
          <v-row>
            <div class="d-inline-flex">
              <v-icon left>mdi-face-agent</v-icon>
              <span class="header">Провайдер</span>
            </div>
            <span class="value">{{ infoProvider }}</span>
          </v-row>
          <v-row class="mb-2">
            <div class="d-inline-flex">
              <v-icon left>mdi-account-box-outline</v-icon>
              <span class="header">Контакт</span>
            </div>
            <span class="value">{{ infoContact }}</span>
          </v-row>
          <v-row class="float-right">
            <v-btn small color="success" @click="closeContactInfo">
              Закрити
            </v-btn>
          </v-row>
        </v-container>
      </v-overlay>
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
import { mapActions, mapGetters, mapMutations } from 'vuex'

export default {
  data () {
    return {
      windowHeight: window.innerHeight,
      smallHeight: false,
      isContactInfoShown: false,
      maxHeight: 'none'
    }
  },
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
    ...mapGetters('contacts', ['contacts', 'pages']),
    ...mapGetters('contactInfos', [
      'infoUserName',
      'infoCountry',
      'infoCity',
      'infoProvider',
      'infoContact'
    ])
  },
  mounted () {
    setTimeout(this.onResize, 200)
    this.$nextTick(() => {
      window.addEventListener('resize', this.onResize)
    })
  },
  methods: {
    ...mapActions('contacts', ['getContacts']),
    ...mapActions('contactInfos', ['getContactInfo']),
    ...mapMutations('contactInfos', ['clearContactInfo']),
    ...mapMutations('contacts', ['setSize']),
    openUserInfo (userId) {
      this.$router.push({ name: 'User', params: { userId } })
    },
    async openContactInfo (id) {
      await this.getContactInfo(id)
      this.isContactInfoShown = true
    },
    closeContactInfo () {
      this.clearContactInfo()
      this.isContactInfoShown = false
    },
    onResize () {
      this.smallHeight = window.innerHeight < 610
      this.maxHeight =
        window.innerHeight -
        document.querySelector('.table-list-container').getBoundingClientRect()
          .y -
        70 +
        'px'
    }
  },
  watch: {
    async page () {
      await this.getContacts()
    },
    async smallHeight (newValue) {
      if (newValue) {
        await this.setSize(10)
      } else {
        await this.setSize(20)
      }
    }
  }
}
</script>

<style scoped>
.v-card__title {
  color: white;
  background: linear-gradient(45deg, #b02799, #00ffbf);
}

.contact-info-grid i {
  color: black;
}
.contact-info-grid span {
  color: black;
  font-size: 1.2rem;
}
.contact-info-grid span.header::after {
  content: ':';
  margin-right: 10px;
}
.contact-info-grid span.value {
  font-weight: bold;
}
.table-list-container {
  overflow-y: auto;
}
</style>
