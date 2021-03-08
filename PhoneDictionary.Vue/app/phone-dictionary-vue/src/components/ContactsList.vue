<template>
  <v-card class="pb-2" elevation="2">
    <v-card-title class="headline">Контакти</v-card-title>
    <v-card-text>
      <v-simple-table>
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
            <tr v-for="contact in contacts" :key="contact.userId">
              <td>{{ contact.userName }}</td>
              <td>{{ contact.contactType }}</td>
              <td>{{ contact.contact }}</td>
            </tr>
          </tbody>
        </template>
      </v-simple-table>
    </v-card-text>
    <div class="text-center">
      <v-pagination
        color="yellow darken-1"
        v-model="page"
        :length="15"
        :total-visible="7"
      ></v-pagination>
    </div>
  </v-card>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data () {
    return {
      page: 1
    }
  },
  computed: {
    ...mapGetters('contacts', ['contacts'])
  }
}
</script>

<style scoped>
.v-card__title{
  color: white;
  background: linear-gradient(45deg, #b02799, #00ffbf);
}
</style>
