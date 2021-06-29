<template>
  <v-container fluid>
    <v-row>
      <v-col class="centre">
        <v-form v-model="valid" ref="addform">
          <div class="text-lg-h6 centre" >
            Add New Entry
          </div>
        <v-container>
          <v-row>
            <v-col
              cols="12"
              md="6"
            >
              <v-text-field
                v-model="newname"
                :counter="50"
                label="Name"
                required
              ></v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col
              md="6">
              <v-text-field
                v-model="newnumber"
                :counter="12"
                label="Number"
                required
              ></v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col
          class="d-flex"
          cols="12"
          sm="6"
        >
          <v-select
            :items="phonebooks"
            v-model="newPhonebookId"
            item-text="name"
            item-value="id"
            bottom
            autocomplete
            label="Please select a Phonebook"
          ></v-select>
        </v-col>
          </v-row>
          <v-row>
            <v-col class="centre">
              <v-btn
              @click="onAdd">
                Add New Entry
              </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </v-form>
      </v-col>
      <v-col class="centre">
        <v-row class="pa-md-6 mx-lg-auto" align="center">
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
            v-on:change="onPhonebookSelect"
          ></v-select>
        </v-col>
        <v-col
          cols="12"
          sm="6"
          md="6"
        >
          <v-text-field
            label="Search"
            placeholder=""
            v-model="filterText"
            @input="onPhonebookFilter"
          ></v-text-field>
        </v-col>
      </v-row>
      <div>
        <v-data-table
        :headers="headers"
        :items="items"
        item-key="name"
        class="elevation-1"
       ></v-data-table>
      </div>
      </v-col>
    </v-row>
      
      
      
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
      items: [],
      filterText: '',
      valid: false,
      newname: '',
      newnumber: '',
      newPhonebookId: ''
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
    reset () {
        this.$refs.addform.reset()
    },
    onPhonebookSelect(value){
      this.items = this.phonebooks.find(x => x.id == value).entries;
    },
    onPhonebookFilter(value){
      this.filterEntries(value);
    },
    onAdd(){
      axios.post('/phonebook/entry', {
        name: this.newname,
        number: this.newnumber,
        phonebookId: this.newPhonebookId
    })
    .then(() => {
      this.getPhoneBooks();
      this.onPhonebookSelect(this.phonebook);
    })
    .catch(function (error) {
      console.log(error);
    })
    .finally(() => {
      this.reset();
    });
    },
    getPhoneBooks(){
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
    },
    filterEntries(value){
      console.log(this.phonebook);
      axios.get('/phonebook/' + this.phonebook + '/entries/search?searchString=' + value)
      .then(resp => {
        this.items = (resp.data);
      })    
      .catch(err => {
        // Handle Error Here
        console.error(err);
    })
    }
  },
  beforeMount(){
    this.getPhoneBooks();
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
  /* display: flex; */
  align-items: center;
  justify-content: center;
  padding-left: 10%;
  padding-right: 10%;
  padding-top: 5%;
}
</style>
