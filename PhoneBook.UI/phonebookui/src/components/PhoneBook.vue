<template>
    <b-container fluid class="container">
      <b-row>
        <b-col sm="4">
          Please Select a Phone Book: <b-form-select v-if="!loading" v-model="phonebook" class="mb-3" :options="phonebooks" value-field="name" text-field="name" @change="onSelect()">
          </b-form-select>
        </b-col>
        <b-col sm="8">
          <b-table v-if="!loading" class="ml-5" striped hover :items="items">
          </b-table>
        </b-col>
      </b-row>
    </b-container>

</template>

<script>
import axios from 'axios';

export default {
  name: 'PhoneBook',
  props: {
    msg: String
  },
  data(){
    return {
      phonebooks: [],
      phonebook: null,
      loading: true,
      fields: ['Name', 'Number'],
      items: []
    }
  },
  methods: {
    onSelect(){
      this.items = this.phonebook.entries;
      console.log(this.items);
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
