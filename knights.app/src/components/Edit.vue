<template>
  <div>
    <h2>Edit Item</h2>
    <form @submit.prevent="updateItem">
      <label for="editedItemName">Item NickName:</label>
      <input type="text" id="editedItemName" v-model="neweditedItemName" required />
      <button type="submit">Update Item</button>
    </form>
  </div>
</template>

<script>
  import axios from "axios";
  export default {
    data() {
      return {
        neweditedItemName: '',
      };
    },
    methods: {
      updateItem() {
        axios.patch('http://localhost:5000/knights/' + document.getElementById("currentId").value, this.neweditedItemName, {
          headers: {
            'Content-Type': 'application/json',
          }
        }).then((response) => {
          alert('sucess');
          window.location = "#/";
        });
      },
    },
  };
</script>
