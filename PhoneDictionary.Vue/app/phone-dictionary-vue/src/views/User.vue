<template>
  <v-card class="mx-auto" outlined>
    <v-list-item>
      <v-list-item-content>
        <v-btn small text class="pl-0 ml-0 mb-4" @click="goBack">
          <v-icon>
            mdi-chevron-left
          </v-icon>
          Назад
        </v-btn>
        <v-list-item-title class="headline mb-5">
          {{ userName }}
        </v-list-item-title>
        <v-list-item-title class="overline mb-1">
          Контакти:
        </v-list-item-title>
        <p class="font-weight-light mt-1">
          {{ allContacts }}
        </p>
      </v-list-item-content>
    </v-list-item>

    <v-divider class="mt-1"></v-divider>
    <v-list-item class="mb-0">
      <span class="title">Теги:</span>
    </v-list-item>
    <v-card-actions class="mt-0 pt-0">
      <v-chip-group active-class="accent--text" column>
        <v-chip
          class="my-1 mx-1"
          v-for="tag in tags"
          :key="tag.tagId"
          dark
          :color="tag.color"
        >
          {{ tag.tag }}
        </v-chip>
        <v-chip class="my-1 mx-1" light>
          <v-icon>
            mdi-plus
          </v-icon>
        </v-chip>
      </v-chip-group>
    </v-card-actions>
  </v-card>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  computed: {
    ...mapGetters('users', ['userName', 'tags', 'contacts']),
    allContacts () {
      return this.contacts.map(x => x.contact).join(', ')
    }
  },
  methods: {
    ...mapActions('users', ['getUserById']),
    goBack () {
      this.$router.go(-1)
    }
  },
  created () {
    this.getUserById(this.$route.params.userId)
  }
}
</script>

<style></style>
