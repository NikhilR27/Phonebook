<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >
      <div class="d-flex align-center">
        <v-img
          alt="Absa Logo"
          class="shrink mr-2"
          contain
          src="./assets/logo.jpg"
          transition="scale-transition"
          width="40"
        />

        <v-img
          alt="Vuetify Name"
          class="shrink mt-1 hidden-sm-and-down"
          contain
          min-width="100"
          src="./assets/logo.jpg"
          width="100"
        />
      </div>

      <v-spacer></v-spacer>
    </v-app-bar>
    <v-main>
      <phone-book/>
    </v-main>
  </v-app>
</template>

<script>
import PhoneBook from './components/PhoneBook.vue';

export default {
  name: 'App',

  components: {
    PhoneBook
  },

  data: () => ({
    //
  }),
};
</script>
