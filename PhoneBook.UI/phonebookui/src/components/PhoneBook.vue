<template>
  <v-container fluid>
      <v-row align="center">
        <v-col
          class="d-flex"
          cols="12"
          sm="6"
        >
          <v-select
            :items="phonebooks"
            v-model="phonebook"
            item-text="name"
            item-value="id"
            bottom
            autocomplete
            label="Please select a Phonebook"
            v-on:change="onSelect"
          ></v-select>
        </v-col>
        <v-col
          cols="12"
          sm="6"
          md="3"
        >
          <v-text-field
            label="Search"
            placeholder=""
          ></v-text-field>
        </v-col>
      </v-row>
      <div class="centre">
        <v-data-table
        v-if="phonebook != null"
        :headers="headers"
        :items="items"
        item-key="name"
        class="elevation-1"
       ></v-data-table>
      </div>
  </v-container>
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
      items: []
    }
  },
  computed: {
    headers () {
      return [
        {
          text: 'Name',
          align: 'start',
          sortable: true,
          value: 'name',
        },
        {
          text: 'Number',
          value: 'number'
        }
      ]
    }
  },
  methods: {
    onSelect(value){
      this.items = this.phonebooks.find(x => x.id == value).entries;
    }
  },
  beforeMount(){
    axios.get('/phonebook')
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

.centre {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 10%;
}
</style>
