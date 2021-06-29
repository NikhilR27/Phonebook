<template>
  <v-app >
    <v-app-bar app
      color="white"
      class="ps-md-6"
    >
    <img src="@/assets/ABSA_Group_Logo.png"
        width="65px"
        class="img-fluid"/>
      <v-toolbar-title>Phone Book</v-toolbar-title>
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
