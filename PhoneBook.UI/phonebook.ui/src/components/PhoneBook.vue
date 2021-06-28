<template>
  <div class="hello">
    <select v-model="selectedCity" name="city" id="city" class="form-control" tabindex="12">

   <option v-for="(city,cityIndex) in cities" :key="city.id" :value="city.id">{{ city.name }}</option>

</select>
  </div>
</template>

<script>
//import PhoneBookApi from "@/services/api/phonebook.js";
import axios from 'axios';

export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  data(){
    return {
      phonebooks: [],
      phonebook: null,
      loading: true
    }
  },
  beforeMount(){
    axios.get('/phonebook/phonebook')
    .then(resp => {
        this.phonebooks = (resp.data);
    })
    .catch(err => {
        // Handle Error Here
        console.error(err);
    })
    .finally(() => {
        this.loading = false;
    });
    // this.phonebooks = PhoneBookApi.getPhoneBooks()
    //   .then(response =>   {
    //     return response;
    //   })
    //   .catch(err => console.log(err))
    //   .finally(() => {
    //     this.loading = false;
    //     console.log(this.phonebooks);
    //   });
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
