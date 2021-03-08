<template>
  <v-card class="pb-2" elevation="2">
    <v-card-title class="headline">Контакти</v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th class="text-left">
                Name
              </th>
              <th class="text-left">
                Calories
              </th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in desserts" :key="item.name">
              <td>{{ item.name }}</td>
              <td>{{ item.calories }}</td>
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
export default {
  data () {
    return {
      page: 1,
      desserts: [
        {
          name: 'Frozen Yogurt',
          calories: 159
        },
        {
          name: 'Ice cream sandwich',
          calories: 237
        }
      ]
    }
  }
}
</script>

<style scoped>
.v-card__title{
  color: white;
  background: linear-gradient(45deg, #b02799, #00ffbf);
}
</style>
