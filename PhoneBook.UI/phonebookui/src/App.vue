<template>
  <div id="app">
    <img height="150px" width="150px" alt="Absa logo" src="./assets/logo.jpg">
    <h2>Simple Phone Book App!</h2>
    <PhoneBook msg="This is a simple phone book"/>
  </div>
</template>

<script>
import PhoneBook from './components/PhoneBook.vue'

export default {
  name: 'App',
  components: {
    PhoneBook
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

#app.logo
{
  width: 10%;
}
</style>
