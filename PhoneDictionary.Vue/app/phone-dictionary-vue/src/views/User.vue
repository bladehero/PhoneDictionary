<template>
  <v-card class="mx-auto" outlined>
    <v-list-item>
      <v-list-item-content>
        <v-btn small text class="pl-0 ml-0 mb-4" @click="goBack">
          <v-icon>
            mdi-chevron-left
          </v-icon>
          Back
        </v-btn>
        <v-list-item-title class="headline mb-5">
          {{ userName }}
        </v-list-item-title>
        <v-list-item-title class="overline mb-1">
          Contacts:
        </v-list-item-title>
        <p class="font-weight-light mt-1">
          {{ allContacts }}
        </p>
      </v-list-item-content>
    </v-list-item>

    <v-divider class="mt-1"></v-divider>
    <v-list-item class="mb-0">
      <span class="title">Tags:</span>
    </v-list-item>
    <v-card-actions class="mt-0 pt-0">
      <v-chip-group active-class="accent--text" column>
        <v-dialog v-model="dialog" persistent max-width="300">
          <template v-slot:activator="{ on, attrs }">
            <v-chip class="my-1 mx-1" light v-bind="attrs" v-on="on" last>
              <v-icon>
                mdi-plus
              </v-icon>
            </v-chip>
          </template>
          <v-card>
            <v-card-title class="headline">
              Type new tag...
            </v-card-title>
            <v-card-text>
              <v-text-field
                color="purple"
                label="Tag Name"
                v-model="tag"
              ></v-text-field>
              <v-color-picker
                class="no-alpha"
                dot-size="25"
                swatches-max-height="200"
                hide-inputs
                v-model="color"
              ></v-color-picker>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="error darken-1" text @click="closeModal">
                Cancel
              </v-btn>
              <v-btn color="purple darken-3" text @click="addTag">
                OK
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-chip
          class="my-1 mx-1"
          v-for="tag in tags"
          :key="tag.tagId"
          dark
          :color="tag.color"
        >
          {{ tag.tag }}
        </v-chip>
      </v-chip-group>
    </v-card-actions>
  </v-card>
</template>

<script>
import { mapActions, mapGetters, mapMutations } from 'vuex'

export default {
  data () {
    return {
      dialog: false,
      tag: '',
      color: ''
    }
  },
  computed: {
    ...mapGetters('users', ['userName', 'tags', 'contacts']),
    allContacts () {
      return this.contacts.map(x => x.contact).join(', ')
    }
  },
  methods: {
    ...mapActions('users', ['getUserById', 'createTag']),
    ...mapMutations('users', ['clearUser']),
    goBack () {
      this.$router.go(-1)
    },
    closeModal () {
      this.tag = ''
      this.dialog = false
    },
    addTag () {
      const userId = this.$route.params.userId
      const tag = this.tag
      const color = this.color.slice(0, 7)
      this.closeModal()
      this.createTag({ userId, tag, color })
    }
  },
  created () {
    this.getUserById(this.$route.params.userId)
  }
}
</script>

<style lang="scss">
.no-alpha {
  .v-color-picker__controls {
    .v-color-picker__preview {
      .v-color-picker__sliders {
        .v-color-picker__alpha {
          display: none;
        }
      }
    }
    .v-color-picker__edit {
      .v-color-picker__input:last-child {
        display: none;
      }
    }
  }
}
</style>
